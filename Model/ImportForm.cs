using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DevExpress.XtraBars;
using ClosedXML.Excel;
using DataAccessLayer;

namespace StudentDashboardApp.Model
{
    public partial class ImportForm : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private DataSet dsSheets;           // Chứa toàn bộ sheet
        private int currentSheetIndex = 0;  // Sheet hiện tại

        public ImportForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                openFileDialog.Title = "Chọn file Excel cần import";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textFileExcel.Text = openFileDialog.FileName;
                }
            }
        }

        // Hàm đọc toàn bộ sheet
        private DataSet ReadExcelMultiSheet(string path)
        {
            DataSet ds = new DataSet();

            using (var workbook = new XLWorkbook(path))
            {
                foreach (var worksheet in workbook.Worksheets)
                {
                    DataTable dt = new DataTable(worksheet.Name);
                    bool firstRow = true;

                    foreach (var row in worksheet.RowsUsed())
                    {
                        if (firstRow)
                        {
                            foreach (var cell in row.Cells())
                            {
                                string colName = cell.Value.ToString();

                                // ✅ Nếu là sheet "Diem" thì set kiểu double cho các cột điểm
                                if (worksheet.Name.Equals("Diem", StringComparison.OrdinalIgnoreCase) &&
                                    (colName == "DiemThuongXuyen" ||
                                     colName == "DiemDinhKy" ||
                                     colName == "DiemTrungBinh" ||
                                     colName == "DiemThi" ||
                                     colName == "DiemTongKet"))
                                {
                                    dt.Columns.Add(colName, typeof(double));
                                }
                                else
                                {
                                    dt.Columns.Add(colName, typeof(string));
                                }
                            }
                            firstRow = false;
                        }
                        else
                        {
                            DataRow toInsert = dt.NewRow();
                            int cellIndex = 0;

                            foreach (var cell in row.Cells(1, dt.Columns.Count))
                            {
                                if (cell.Value.IsBlank)
                                {
                                    toInsert[cellIndex] = DBNull.Value;
                                }
                                else
                                {
                                    object raw = cell.Value;

                                    // ✅ Gán đúng kiểu
                                    if (dt.Columns[cellIndex].DataType == typeof(double))
                                    {
                                        if (double.TryParse(raw.ToString(), out double d))
                                            toInsert[cellIndex] = d;
                                        else
                                            toInsert[cellIndex] = DBNull.Value;
                                    }
                                    else
                                    {
                                        toInsert[cellIndex] = raw.ToString();
                                    }
                                }
                                cellIndex++;
                            }
                            dt.Rows.Add(toInsert);
                        }
                    }
                    ds.Tables.Add(dt);
                }

            }
            return ds;
        }



        // Preview file
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textFileExcel.Text))
            {
                MessageBox.Show("Vui lòng chọn file Excel trước!");
                return;
            }

            dsSheets = ReadExcelMultiSheet(textFileExcel.Text);

            if (dsSheets.Tables.Count > 0)
            {
                currentSheetIndex = 0;
                ShowCurrentSheet();
                btnNext.Enabled = true;
                btnNext.Visible = true;
                btnPrevious.Enabled = true;
                btnPrevious.Visible = true;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu trong file Excel!");
            }
        }

        // Hiển thị sheet hiện tại
        private void ShowCurrentSheet()
        {
            if (dsSheets != null && dsSheets.Tables.Count > 0)
            {
                dataGridViewExcel.DataSource = dsSheets.Tables[currentSheetIndex];

                lblSheetName.Text = $"Sheet: {dsSheets.Tables[currentSheetIndex].TableName} " +
                                    $"({currentSheetIndex + 1}/{dsSheets.Tables.Count})";

                // Cấu hình hiển thị
                dataGridViewExcel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewExcel.AllowUserToResizeColumns = false;
                dataGridViewExcel.AllowUserToResizeRows = false;
                dataGridViewExcel.RowHeadersVisible = false;


            }
        }

        // Nút Next
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (dsSheets != null && currentSheetIndex < dsSheets.Tables.Count - 1)
            {
                currentSheetIndex++;
                ShowCurrentSheet();
            }
        }

        // Nút Previous
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (dsSheets != null && currentSheetIndex > 0)
            {
                currentSheetIndex--;
                ShowCurrentSheet();
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=.;Database=QLSV;Trusted_Connection=True;Encrypt=False;";
            var service = new BusinessLayer.StudentService(connectionString);

            if (dsSheets == null || dsSheets.Tables.Count == 0)
            {
                MessageBox.Show("❌ Chưa có dữ liệu để import!");
                return;
            }

            DataTable dt = dsSheets.Tables[currentSheetIndex]; // sheet hiện tại
            string sheetName = dt.TableName;

            try
            {
                // ✅ Tìm config theo tên sheet
                if (!BusinessLayer.SheetConfig.SheetMappings.TryGetValue(sheetName, out var config))
                {
                    MessageBox.Show($"❌ Không tìm thấy mapping cho sheet: {sheetName}");
                    return;
                }

                // ✅ Map cột Excel → DB
                dt = DataAccessLayer.ExcelMapper.MapColumns(dt, config.Mapping);
              
                // ✅ Dùng Upsert nếu có cột khóa, ngược lại BulkInsert
                if (config.KeyColumns != null && config.KeyColumns.Length > 0)
                {
                    service.UpsertGeneric(config.TableName, config.KeyColumns, dt);
                    MessageBox.Show($"Upsert sheet '{sheetName}' vào bảng '{config.TableName}' thành công!");
                }
                else
                {
                    service.ImportGeneric(dt, config.TableName);
                    MessageBox.Show($"Import sheet '{sheetName}' vào bảng '{config.TableName}' thành công!");
                }
                



                // ✅ Nếu là Sinh_Vien thì báo số lượng
                if (config.TableName.Equals("Sinh_Vien", StringComparison.OrdinalIgnoreCase))
                {
                    int total = service.GetStudentCount();
                    MessageBox.Show($"Tổng số sinh viên hiện tại: {total}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi import: " + ex.Message);
            }
        }

        private void txtFilePath_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewExcel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

}

