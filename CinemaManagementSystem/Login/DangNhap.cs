using CinemaManagementSystem.Helper;
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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
            lbFlashMessage.Hide();
        }

        private void txbTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txbTenDangNhap.Text == "Tên đăng nhập") 
            {
                txbTenDangNhap.Text = "";
            }
        }

        private void txbTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (txbTenDangNhap.Text == "") 
            {
                txbTenDangNhap.Text = "Tên đăng nhập";
            }
        }

        private void txbMatKhau_Enter(object sender, EventArgs e)
        {
            if (txbMatKhau.Text == "Mật khẩu")
            {
                txbMatKhau.Text = "";
                txbMatKhau.PasswordChar = '*';
            }
        }

        private void txbMatKhau_Leave(object sender, EventArgs e)
        {
            if (txbMatKhau.Text == "")
            {
                txbMatKhau.Text = "Mật khẩu";
                txbMatKhau.PasswordChar = '\0';
            }
        }

        private void llbQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau formQuenMatKhau = new QuenMatKhau();
            this.Hide();
            formQuenMatKhau.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            login();
            
        }

        private void login()
        {
            string username = txbTenDangNhap.Text;
            string password = txbMatKhau.Text;

            if (username == "Tên đăng nhập" || password == "Mật khẩu")
            {
                lbFlashMessage.Text = "Vui lòng nhập đầy đủ thông tin";
                lbFlashMessage.Show();
                return;
            }

            using (CinemaDataContext db = new CinemaDataContext())
            {
                NhanVien nv = db.NhanViens.SingleOrDefault(nhanvien => nhanvien.TenTaiKhoan.Equals(username));

                Boolean isExist = nv != null;


                if (!isExist)
                {
                    lbFlashMessage.Text = "Tài khoản này chưa được đăng ký";
                    lbFlashMessage.Show();
                    return;
                }

                Boolean matchPassword = Helper.Helper.DecodeFrom64(nv.MatKhau).Equals(password);

                if (!matchPassword)
                {
                    lbFlashMessage.Text = "Sai tên đăng nhập/mật khẩu";
                    lbFlashMessage.Show();
                    return;
                }

                TrangChu formTrangChu = new TrangChu();
                this.Hide();
                formTrangChu.Show();
            }
        }
    }
}
