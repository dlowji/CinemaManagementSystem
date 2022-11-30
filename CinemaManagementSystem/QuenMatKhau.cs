using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;

namespace CinemaManagementSystem
{
    public partial class QuenMatKhau : Form
    {
        private string globalCode;
        private string globalEmail;
        private DateTime lastSent;
        public QuenMatKhau()
        {
            InitializeComponent();

            btnTiepTuc.Hide();
            btnTiepTuc.Enabled = false;

            btnQuaylai.Hide();
            btnQuaylai.Enabled = false;

            lbGuiLaiMa.Hide();
        }

        private void txbTaiKhoanCanKhoiPhuc_Enter(object sender, EventArgs e)
        {
            if (txbTaiKhoanCanKhoiPhuc.Text == "Tài khoản cần khôi phục" || txbTaiKhoanCanKhoiPhuc.Text == "Mã bảo mật")
            {
                txbTaiKhoanCanKhoiPhuc.Text = "";
            }
        }

        private void txbTaiKhoanCanKhoiPhuc_Leave(object sender, EventArgs e)
        {
            if (txbTaiKhoanCanKhoiPhuc.Text == "")
            {
                if (lbMessage.Text.Contains("Mã bảo mật gồm 5 chữ số"))
                {
                    txbTaiKhoanCanKhoiPhuc.Text = "Mã bảo mật";
                }
                else
                {
                    txbTaiKhoanCanKhoiPhuc.Text = "Tài khoản cần khôi phục";
                }
            }
        }

        private void pbBackIcon_Click(object sender, EventArgs e)
        {
            reset();
            DangNhap formDangNhap = new DangNhap();
            this.Hide();
            formDangNhap.Show();
        }

        private void btnGuiMa_Click(object sender, EventArgs e)
        {
            string username = txbTaiKhoanCanKhoiPhuc.Text;

            if (username == null || username == "") 
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin được yêu cầu");
                return;
            }

            TaiKhoan account = AccountController.GetAccountByUsername(username);

            if (account == null)
            {
                MessageBox.Show("Tài khoản không tồn tại");
                return;
            }

            string email = account.UserName;
            globalEmail = email;

            loading(email);
        }

        private void loading(string email)
        {
            string code = Helper.Helper.generateRandomCode(5);

            globalCode = code;

            string emailName = email.Split('@')[0];
            string domainName = email.Split('@')[1];

            StringBuilder encryptedEmail = new StringBuilder(emailName);

            for (int i = 2; i < emailName.Length; i++)
            {
                encryptedEmail[i] = '*';
            }

            bool result = Helper.Helper.sendMail(email, code);
            encryptedEmail.Append('@');
            encryptedEmail.Append(domainName);

            if (result)
            {
                lastSent = DateTime.Now;
                lbMessage.Text = "Mã bảo mật gồm 5 chữ số đã được gửi tới Email:\n" + encryptedEmail;
                txbTaiKhoanCanKhoiPhuc.Text = "Mã bảo mật";
            }
            else
            {
                MessageBox.Show("Lỗi không thể gửi mã xác nhận tới tài khoản");
            }

            btnGuiMa.Hide();
            btnGuiMa.Enabled = false;

            btnTiepTuc.Show();
            btnTiepTuc.Enabled = true;

            btnQuaylai.Show();
            btnQuaylai.Enabled = true;

            lbGuiLaiMa.Show();

        }

        private void reset()
        {
            lbMessage.Text = "Chúng tôi sẽ gửi mã đặt lại mật khẩu thông qua Email liên kết với tài khoản trên";
            txbTaiKhoanCanKhoiPhuc.Text = "Tài khoản cần khôi phục";
            btnGuiMa.Show();
            btnGuiMa.Enabled = true;

            btnTiepTuc.Hide();
            btnTiepTuc.Enabled = false;

            btnQuaylai.Hide();
            btnQuaylai.Enabled = true;

            lbGuiLaiMa.Show();
        }

        private void confirmResetPassword()
        {
            if (lastSent.AddMinutes(1) <= DateTime.Now)
            {
                MessageBox.Show("Mã xác nhận đã hết hạn");
                return;
            }

            if (!txbTaiKhoanCanKhoiPhuc.Text.Equals(globalCode))
            {
                MessageBox.Show("Mã xác nhận không trùng khớp");
                return;
            }

            NhapMatKhauMoi frm = new NhapMatKhauMoi(globalEmail);
            this.Hide();
            frm.Show();
        }

        private void btnTiepTuc_Click(object sender, EventArgs e)
        {
            confirmResetPassword();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (lastSent.AddMinutes(1) > DateTime.Now)
            {
                MessageBox.Show("Thao tác quá nhanh, vui lòng thử lại sau");
                return;
            }
            string code = Helper.Helper.generateRandomCode(5);

            globalCode = code;

            bool result = Helper.Helper.sendMail(globalEmail, code);

            if (result)
            {
                lastSent = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Lỗi không thể gửi mã xác nhận tới tài khoản");
            }
        }

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            reset();
        }
    }
}
