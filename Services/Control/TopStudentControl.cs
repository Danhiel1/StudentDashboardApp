using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentDashboardApp
{
    public partial class TopStudentControl : UserControl
    {
        public TopStudentControl()
        {
            InitializeComponent();
        }

        private void TopStudentControl_Load(object sender, EventArgs e)
        {
            // Xóa hết item cũ (nếu có)
            comboBoxEdit2.Properties.Items.Clear();

            // Gán danh sách năm từ 2020 đến năm hiện tại
            for (int year = 2000; year <= DateTime.Now.Year; year++)
            {
                comboBoxEdit2.Properties.Items.Add(year.ToString());
            }

            // Chọn mặc định năm hiện tại
            comboBoxEdit2.SelectedIndex = comboBoxEdit2.Properties.Items.Count - 1;
        }

        private void chartControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
