using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
using CinemaManagementSystem.View.Customer;
using CinemaManagementSystem.View.Login;
using GUI;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CinemaManagementSystem
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void txbTenDangNhap_Enter(object sender, EventArgs e)
        {
            if (txbTenDangNhap.Text == "Tên đăng nhập") 
            {
                txbTenDangNhap.Text = "";
                txbTenDangNhap.ForeColor = Color.Black;
            }
        }

        private void txbTenDangNhap_Leave(object sender, EventArgs e)
        {
            if (txbTenDangNhap.Text == "") 
            {
                txbTenDangNhap.Text = "Tên đăng nhập";
                txbTenDangNhap.ForeColor = Color.FromArgb(170, 170, 170);
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

        private void llbQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            QuenMatKhau frm = new QuenMatKhau();
            this.Hide();
            frm.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            btnDangNhap.Enabled = false;

            var requiredControls = new[]
            {
                txbTenDangNhap,
                txbMatKhau,
            };

            bool isValidFields = Helper.Helper.ValidateValidFields(requiredControls);

            if (!isValidFields)
            {
                MessageBox.Show("Thông tin đăng nhập không được để trống hoặc chứa khoảng trắng", "Cảnh báo");
                return;
            }

            string username = txbTenDangNhap.Text;
            string password = txbMatKhau.Text;

            bool result = AccountController.Login(username, password);
            if (result)
            {
                TaiKhoan loginAccount = AccountController.GetAccountByUsername(username);

                if (loginAccount.LoaiTK == 1) //admin
                {
                    QuanLy frm = new QuanLy(loginAccount.idNV);
                    this.Hide();
                    frm.Show();
                }
                else if (loginAccount.LoaiTK == 2) //staff
                {
                    SelectingMovieUCForStaff frm = new SelectingMovieUCForStaff(loginAccount.idNV);
                    this.Hide();
                    frm.Show();
                }
                else if (loginAccount.LoaiTK == 3) // cus
                {
                    GiaoDienChonPhim frm = new GiaoDienChonPhim(loginAccount.idKH);
                    this.Hide();
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu", "Thông báo");
            }

            btnDangNhap.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy frm = new DangKy();
            frm.Show();
            Hide();
        }
    }
}
