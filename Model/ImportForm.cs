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
        // ⚡ Thêm ở đầu class ImportForm (ngoài các hàm)
        public event EventHandler ImportCompleted;

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

            using (XLWorkbook workbook = new XLWorkbook(path))
            {
                foreach (IXLWorksheet worksheet in workbook.Worksheets)
                {
                    DataTable dt = new DataTable(worksheet.Name);
                    bool firstRow = true;

                    foreach (IXLRow row in worksheet.RowsUsed())
                    {
                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
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

                            foreach (IXLCell cell in row.Cells(1, dt.Columns.Count))
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
            string connectionString = System.Configuration.ConfigurationManager
                .ConnectionStrings["QLSVConnection"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("⚠️ Chưa có kết nối SQL. Hãy mở lại form kết nối để chọn server & database!");
                return;
            }

            BusinessLayer.StudentService service = new BusinessLayer.StudentService(connectionString);

            if (dsSheets == null || dsSheets.Tables.Count == 0)
            {
                MessageBox.Show("❌ Chưa có dữ liệu để import!");
                return;
            }

            try
            {
                // Thứ tự import an toàn theo phụ thuộc FK
                string[] importOrder = {
    "Khoa",
    "Nganh",
    "Nien_Khoa",
    "Chuong_Trinh_Dao_Tao",
    "Giao_Vien",          // 👈 Thêm dòng này TRƯỚC Mon_Hoc
    "Mon_Hoc",
    "Lop",
    "Sinh_Vien",
    "Diem"
};

                foreach (string sheetName in importOrder)
                {
                    DataTable dt = dsSheets.Tables
                        .Cast<DataTable>()
                        .FirstOrDefault(t => t.TableName.Equals(sheetName, StringComparison.OrdinalIgnoreCase));

                    if (dt == null)
                        continue; // Sheet không có thì bỏ qua

                    // ✅ Lấy cấu hình mapping cho sheet
                    if (!BusinessLayer.SheetConfig.SheetMappings.TryGetValue(sheetName, out var config))
                    {
                        MessageBox.Show($"⚠️ Bỏ qua sheet '{sheetName}' (không có mapping).");
                        continue;
                    }

                    // ✅ Map cột Excel → DB
                    dt = DataAccessLayer.ExcelMapper.MapColumns(dt, config.Mapping);

                    // ✅ Upsert nếu có cột khóa, ngược lại BulkInsert
                    if (config.KeyColumns != null && config.KeyColumns.Length > 0)
                    {
                        service.UpsertGeneric(config.TableName, config.KeyColumns, dt);
                    }
                    else
                    {
                        service.ImportGeneric(dt, config.TableName);
                    }
                }

                // ✅ Sau khi import xong, báo kết quả
                // ✅ Sau khi import thành công tất cả sheet
                int totalStudents = service.GetStudentCount();
                MessageBox.Show($"🎉 Import tất cả sheet thành công!\nTổng số sinh viên hiện tại: {totalStudents}");

                // 🔔 Gửi tín hiệu về Dashboard
                ImportCompleted?.Invoke(this, EventArgs.Empty);

                // ✅ Reset form về trạng thái ban đầu
                dsSheets?.Clear();
                dataGridViewExcel.DataSource = null;
                lblSheetName.Text = "Chưa có sheet nào";
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
                textFileExcel.Text = string.Empty;
            }

            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi import toàn bộ: " + ex.Message);
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

