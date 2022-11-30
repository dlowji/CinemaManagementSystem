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

namespace CinemaManagementSystem
{
    public partial class NhapMatKhauMoi : Form
    {
        private string globalUsername;
        public NhapMatKhauMoi(string email)
        {
            InitializeComponent();

            globalUsername = email;
            txbTaiKhoanCanKhoiPhuc.Text = globalUsername;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string username = txbTaiKhoanCanKhoiPhuc.Text;
            string password = txbMatKhauMoi.Text;
            string confirmPassword = txbXacNhanMatKhau.Text;

            var controls = new[]
            {
                txbTaiKhoanCanKhoiPhuc,
                txbMatKhauMoi,
                txbXacNhanMatKhau
            };

            foreach (var control in controls.Where(c => String.IsNullOrWhiteSpace(c.Text)))
            {
                MessageBox.Show("Thông tin không được để trống hoặc chứa khoảng trắng");
                return;
            }

            if (!password.Equals(confirmPassword))
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp");
                return;
            }

            updatePassword(username, password);
        }

        private void updatePassword(string username, string newPass)
        {
            bool result = AccountController.UpdatePasswordForAccount(username, newPass);

            if (result)
            {
                MessageBox.Show("Cập nhật mật khẩu thành công", "Success", MessageBoxButtons.OK);
                DangNhap frm = new DangNhap();
                Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Cập nhật mật khẩu thất bại");
            }
        }

        private void txbMatKhauMoi_Enter(object sender, EventArgs e)
        {
            if (txbMatKhauMoi.Text == "Mật khẩu mới")
            {
                txbMatKhauMoi.Text = "";
                txbMatKhauMoi.PasswordChar = '*';
                txbMatKhauMoi.ForeColor = Color.Black;
            }
        }

        private void txbMatKhauMoi_Leave(object sender, EventArgs e)
        {
            if (txbMatKhauMoi.Text == "")
            {
                txbMatKhauMoi.Text = "Mật khẩu mới";
                txbMatKhauMoi.PasswordChar = '\0';
                txbMatKhauMoi.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }

        private void txbXacNhanMatKhau_Enter(object sender, EventArgs e)
        {
            if (txbXacNhanMatKhau.Text == "Xác nhận mật khẩu")
            {
                txbXacNhanMatKhau.Text = "";
                txbXacNhanMatKhau.PasswordChar = '*';
                txbXacNhanMatKhau.ForeColor = Color.Black;
            }
        }

        private void txbXacNhanMatKhau_Leave(object sender, EventArgs e)
        {
            if (txbXacNhanMatKhau.Text == "")
            {
                txbXacNhanMatKhau.Text = "Xác nhận mật khẩu";
                txbXacNhanMatKhau.PasswordChar = '\0';
                txbXacNhanMatKhau.ForeColor = Color.FromArgb(170, 170, 170);
            }
        }
    }
}
