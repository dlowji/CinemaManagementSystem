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

namespace CinemaManagementSystem
{
    public partial class QuenMatKhau : Form
    {
        private string globalCode;
        private string globalUsername;
        public QuenMatKhau()
        {
            InitializeComponent();
            lbFlashMessage.Hide();
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
            string tenDangNhap = txbTaiKhoanCanKhoiPhuc.Text;

            using (CinemaDataContext db = new CinemaDataContext())
            {
                TaiKhoan t = db.TaiKhoans.SingleOrDefault(taikhoan => taikhoan.TenDangNhap.Equals(tenDangNhap));

                Boolean isExist = t != null;

                if (!isExist)
                {
                    lbFlashMessage.Text = "Tài khoản đăng nhập không tồn tại";
                    lbFlashMessage.Show();
                    return;
                }

                Boolean isRegistered = t.Email != null;

                if (!isRegistered)
                {
                    lbFlashMessage.Text = "Tài khoản chưa đăng ký email";
                    lbFlashMessage.Show();
                    return;
                }

                loading(t.Email);
            }
        }

        private void sendMail(string email, string code)
        {
            var from = new MailAddress("cinemadlowji@gmail.com");
            var to = new MailAddress(email);

            var subject = "Lấy lại mật khẩu đăng nhập";
            var body = "<h3 style='color: rgb(37,110,162);'>Dlowji Cinema</h3><p>Chúng tôi đã nhận được yêu cầu đặt lại mật khẩu Dlowji App của bạn.</p><p>Nhập mã đặt lại mật khẩu sau đây:</p>"+code+"<p>Nếu bạn không yêu cầu mật khẩu mới, vui lòng bỏ qua tin nhắn này.</p>";

            string username = "7fb8aeeca5eda3";
            string password = "9bbf94a6d618fa";

            string host = "smtp.mailtrap.io";
            int port = 2525;

            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            var mail = new MailMessage();
            mail.Subject = subject;
            mail.From = from;
            mail.To.Add(to);
            mail.Body = body;
            mail.IsBodyHtml = true;

            client.Send(mail);
        }

        private void loading(string email)
        {
            lbFlashMessage.Hide();
            string code = generateRandomCode(5);

            globalCode = code;

            string emailName = email.Split('@')[0];
            string domainName = email.Split('@')[1];

            StringBuilder encryptedEmail = new StringBuilder(emailName);

            for (int i = 2; i < emailName.Length; i++)
            {
                encryptedEmail[i] = '*';
            }
            encryptedEmail.Append('@');
            encryptedEmail.Append(domainName);
            lbMessage.Text = "Mã bảo mật gồm 5 chữ số đã được gửi tới Email:\n" + encryptedEmail;
            txbTaiKhoanCanKhoiPhuc.Text = "Mã bảo mật";
            lbMessage.Location = new Point(lbMessage.Location.X, lbMessage.Location.Y - 84);
            txbTaiKhoanCanKhoiPhuc.Location = new Point(txbTaiKhoanCanKhoiPhuc.Location.X, txbTaiKhoanCanKhoiPhuc.Location.Y + 84);
            icon.Location = new Point(icon.Location.X, icon.Location.Y + 84);
            icon.Image = Properties.Resources.password_76;

            btnXacNhan.Location = new Point(181, 257);

            btnXacNhan.Show();
            btnGuiMa.Hide();

            sendMail(email, code);
        }

        private string generateRandomCode(int length)
        {
            string code = "";
            Random rd = new Random();

            for (int i = 0; i < length; i++)
            {
                code += rd.Next(0, 10).ToString();
            }

            return code;
        }

        private void reset()
        {
            lbMessage.Text = "Chúng tôi sẽ gửi mã đặt lại mật khẩu thông qua Email liên kết với tài khoản trên";
            txbTaiKhoanCanKhoiPhuc.Text = "Tài khoản cần khôi phục";
            lbMessage.Location = new Point(lbMessage.Location.X, lbMessage.Location.Y + 84);
            txbTaiKhoanCanKhoiPhuc.Location = new Point(txbTaiKhoanCanKhoiPhuc.Location.X, txbTaiKhoanCanKhoiPhuc.Location.Y - 84);
            icon.Location = new Point(icon.Location.X, icon.Location.Y - 84);
            icon.Image = Properties.Resources.mail;

            btnXacNhan.Location = new Point(140, 257);
            btnGuiMa.Show();
            btnXacNhan.Hide();
        }

        private void confirmResetPassword()
        {
            if (!txbTaiKhoanCanKhoiPhuc.Text.Equals(globalCode))
            {
                lbFlashMessage.Text = "Mã bảo mật sai";
                lbFlashMessage.Show();
                return;
            }

            NhapMatKhauMoi formNhapMatKhauMoi = new NhapMatKhauMoi();
            formNhapMatKhauMoi.Show();
            this.Hide();

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            confirmResetPassword();
        }
    }
}
