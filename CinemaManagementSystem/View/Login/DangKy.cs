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

namespace CinemaManagementSystem.View.Login
{
    public partial class DangKy : Form
    {
        private bool isChange = false;
        public DangKy()
        {
            InitializeComponent();
        }

        private void txbTenKhachHang_Enter(object sender, EventArgs e)
        {
            if (txbTenKhachHang.Text == "Họ và tên")
            {
                txbTenKhachHang.Text = "";
                txbTenKhachHang.ForeColor = Color.Black;
            }
        }

        private void txbTenKhachHang_Leave(object sender, EventArgs e)
        {
            if (txbTenKhachHang.Text == "")
            {
                txbTenKhachHang.Text = "Họ và tên";
                txbTenKhachHang.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void txbEmail_Enter(object sender, EventArgs e)
        {
            if (txbEmail.Text == "Email")
            {
                txbEmail.Text = "";
                txbEmail.ForeColor = Color.Black;
            }
        }

        private void txbEmail_Leave(object sender, EventArgs e)
        {
            if (txbEmail.Text == "")
            {
                txbEmail.Text = "Email";
                txbEmail.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void txbMatKhau_Enter(object sender, EventArgs e)
        {
            if (txbMatKhau.Text == "Mật khẩu")
            {
                txbMatKhau.Text = "";
                txbMatKhau.PasswordChar = '*';
                txbMatKhau.ForeColor = Color.Black;
            }
        }

        private void txbMatKhau_Leave(object sender, EventArgs e)
        {
            if (txbMatKhau.Text == "")
            {
                txbMatKhau.Text = "Mật khẩu";
                txbMatKhau.PasswordChar = '\0';
                txbMatKhau.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void txbXacNhanMK_Enter(object sender, EventArgs e)
        {
            if (txbXacNhanMK.Text == "Xác nhận mật khẩu")
            {
                txbXacNhanMK.Text = "";
                txbXacNhanMK.PasswordChar = '*';
                txbXacNhanMK.ForeColor = Color.Black;
            }
        }

        private void txbXacNhanMK_Leave(object sender, EventArgs e)
        {
            if (txbXacNhanMK.Text == "")
            {
                txbXacNhanMK.Text = "Xác nhận mật khẩu";
                txbXacNhanMK.PasswordChar = '\0';
                txbXacNhanMK.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void txbSoDienThoai_Enter(object sender, EventArgs e)
        {
            if (txbSoDienThoai.Text == "Số điện thoại")
            {
                txbSoDienThoai.Text = "";
                txbSoDienThoai.ForeColor = Color.Black;
            }
        }

        private void txbSoDienThoai_Leave(object sender, EventArgs e)
        {
            if (txbSoDienThoai.Text == "")
            {
                txbSoDienThoai.Text = "Số điện thoại";
                txbSoDienThoai.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            string cusName = txbTenKhachHang.Text;
            string email = txbEmail.Text;
            string password = txbMatKhau.Text;
            string confirm = txbXacNhanMK.Text;
            string phone = txbSoDienThoai.Text;
            string address = txbAddress.Text;
            string cmnd = txbCMND.Text;

            var requiredControls = new[]
            {
                txbTenKhachHang,
                txbEmail,
                txbMatKhau,
                txbXacNhanMK,
                txbSoDienThoai,
                txbAddress,
            };

            //validate
            foreach (var control in requiredControls.Where(c => String.IsNullOrWhiteSpace(c.Text)))
            {
                MessageBox.Show("Thông tin yêu cầu không được để trống hoặc chứa khoảng trắng", "Error");
                return;
            }

            if (!password.Equals(confirm))
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp", "Error");
                return;
            }

            DateTime birthday = dtpBirthday.Value;

            int certificate = -1;
            if (!String.IsNullOrEmpty(cmnd))
            {
                certificate = Convert.ToInt32(cmnd);
            }

            bool result = CustomerController.InsertMember(email, password, null, cusName, birthday, address, phone, certificate);

            if (result)
            {
                MessageBox.Show("Đăng ký thành công");
                DangNhap frm = new DangNhap();
                Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txbAddress.Text == "Địa chỉ")
            {
                txbAddress.Text = "";
                txbAddress.ForeColor = Color.Black;
            }
        }

        private void txbAddress_Leave(object sender, EventArgs e)
        {
            if (txbAddress.Text == "")
            {
                txbAddress.Text = "Số điện thoại";
                txbAddress.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void txbCMND_Enter(object sender, EventArgs e)
        {
            if (txbCMND.Text == "CMND")
            {
                txbCMND.Text = "";
                txbCMND.ForeColor = Color.Black;
            }
        }

        private void txbCMND_Leave(object sender, EventArgs e)
        {
            if (txbCMND.Text == "")
            {
                txbCMND.Text = "CMND";
                txbCMND.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void dtpBirthday_ValueChanged(object sender, EventArgs e)
        {
            isChange = true;
        }
    }
}
