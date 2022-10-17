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
        public NhapMatKhauMoi()
        {
            InitializeComponent();
            lbFlashMessage.Hide();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string username = txbTaiKhoanCanKhoiPhuc.Text;
            string password = txbMatKhauMoi.Text;
            string confirmPassword = txbXacNhanMatKhau.Text;

            if (!password.Equals(confirmPassword))
            {
                lbFlashMessage.Text = "Xác nhận mật khẩu không trùng khớp";
                lbFlashMessage.Show();
                return;
            }

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from tk in db.TaiKhoans
                            where tk.TenDangNhap == username
                            select tk;

                foreach (TaiKhoan tk in query)
                {
                    tk.MatKhau = password;
                }

                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            DangNhap formDangNhap = new DangNhap();
            this.Hide();
            formDangNhap.Show();
        }

        private void txbMatKhauMoi_Enter(object sender, EventArgs e)
        {
            if (txbMatKhauMoi.Text == "Mật khẩu mới")
            {
                txbMatKhauMoi.Text = "";
            }
        }

        private void txbMatKhauMoi_Leave(object sender, EventArgs e)
        {
            if (txbMatKhauMoi.Text == "")
            {
                txbMatKhauMoi.Text = "Mật khẩu mới";
            }
        }

        private void txbXacNhanMatKhau_Enter(object sender, EventArgs e)
        {
            if (txbXacNhanMatKhau.Text == "Xác nhận mật khẩu")
            {
                txbXacNhanMatKhau.Text = "";
            }
        }

        private void txbXacNhanMatKhau_Leave(object sender, EventArgs e)
        {
            if (txbXacNhanMatKhau.Text == "")
            {
                txbXacNhanMatKhau.Text = "Xác nhận mật khẩu";
            }
        }
    }
}
