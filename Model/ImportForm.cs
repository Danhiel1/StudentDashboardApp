﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using ClosedXML.Excel;

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
                    txtFilePath.Text = openFileDialog.FileName;
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
                                dt.Columns.Add(cell.Value.ToString());
                            firstRow = false;
                        }
                        else
                        {
                            DataRow toInsert = dt.NewRow();
                            int cellIndex = 0;
                            foreach (var cell in row.Cells(1, dt.Columns.Count))
                            {
                                toInsert[cellIndex] = cell.Value.ToString();
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
            if (string.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Vui lòng chọn file Excel trước!");
                return;
            }

            dsSheets = ReadExcelMultiSheet(txtFilePath.Text);

            if (dsSheets.Tables.Count > 0)
            {
                currentSheetIndex = 0;
                ShowCurrentSheet();
                btnNext.Enabled = true;
                btnNext.Visible= true;
                btnPrevious.Enabled = true;
                btnPrevious.Visible= true;
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
                dataGridView1.DataSource = dsSheets.Tables[currentSheetIndex];

                lblSheetName.Text = $"Sheet: {dsSheets.Tables[currentSheetIndex].TableName} " +
                                    $"({currentSheetIndex + 1}/{dsSheets.Tables.Count})";

                // Cấu hình hiển thị
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AllowUserToResizeColumns = false;
                dataGridView1.AllowUserToResizeRows = false;
                dataGridView1.RowHeadersVisible = false;

                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.DefaultCellStyle.BackColor = Color.White;
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

        private void lblSheetName_Click(object sender, EventArgs e)
        {

        }
    }
}
