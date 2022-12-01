using CinemaManagementSystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem.View.Others
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool validateResult = validateInputs();

            if (!validateResult)
            {
                return;
            }

            string id = txbMaPhatHanh.Text;
            string name = txbTenDotPhatHanh.Text;
            decimal price = decimal.Parse(txbMenhGia.Text);
            decimal minPrice = decimal.Parse(txbToiThieu.Text);
            bool status = rdbtnActive.Checked;
            DateTime startDate = dtmFromDate.Value;
            DateTime endDate = dtmToDate.Value;
            int productType = Int32.Parse(cbbNhomHang.SelectedValue.ToString());

            SaveVoucherRelease(id, name, startDate, endDate, price, minPrice, productType, status);
        }

        private bool SaveVoucherRelease(string id, string name, DateTime startDate, DateTime endDate, decimal price, decimal minPrice, int productType, bool status)
        {
            bool result = VoucherController.SaveVoucherRelease(id, name, startDate, endDate, price, minPrice, productType, status);

            if (result)
            {
                MessageBox.Show("Thêm đợt phát hành voucher mới thành công", "Thành công");
                Hide();
            }
            else
            {
                MessageBox.Show("Thêm đợt phát hành voucher mới thất bại", "Thất bại");
            }

            return true;
        }

        private bool validateInputs()
        {
            var controls = new[]
            {
                txbMaPhatHanh,
                txbTenDotPhatHanh,
                txbMenhGia,
                txbToiThieu
            };

            foreach (var item in controls.Where(c => String.IsNullOrWhiteSpace(c.Text)))
            {
                MessageBox.Show("Thông tin không được bỏ trống hoặc chứa khoảng trắng");
                return false;
            }

            return true;
        }

        private void txbMenhGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txbToiThieu_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
