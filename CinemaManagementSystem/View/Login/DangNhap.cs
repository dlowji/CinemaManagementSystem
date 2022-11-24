using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
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
        private LoginController loginController;
        public DangNhap()
        {
            InitializeComponent();
            loginController = new LoginController();
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
            //QuenMatKhau formQuenMatKhau = new QuenMatKhau();
            //this.Hide();
            //formQuenMatKhau.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            btnDangNhap.Enabled = false;
            string userName = txbTenDangNhap.Text;
            string passWord = txbMatKhau.Text;
            int result = loginController.Login(userName, passWord);
            if (result == 1)
            {
                TaiKhoan loginAccount = AccountDAO.GetAccountByUserName(userName);
                if (loginAccount.LoaiTK == 1) //admin
                {
                    QuanLy frm = new QuanLy(loginAccount.idNV);
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                }
                else if (loginAccount.LoaiTK == 2 || loginAccount.LoaiTK == 3) //staff
                {
                    frmDashBoard frm = new frmDashBoard(loginAccount);
                    this.Hide();
                    frm.ShowDialog();
                    this.Show();
                }
            }
            else if (result == 0)
            {
                MessageBox.Show("SAI TÊN TÀI KHOẢN HOẶC MẬT KHẨU!!!!", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("KẾT NỐI THẤT BẠI", "THÔNG BÁO");
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
