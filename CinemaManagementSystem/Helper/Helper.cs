using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CinemaManagementSystem.Helper
{
    public static class Helper
    {
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        //this function Convert to Decord your Password
        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        public static string GetTicketTypeRepresentation(int ticketType)
        {
            StringBuilder representString = new StringBuilder();
            switch (ticketType)
            {
                case 0: 
                    representString.Append("Vé người lớn");
                    break;
                case 1:
                    representString.Append("Vé học sinh - sinh viên");
                    break;
                case 2:
                    representString.Append("Vé trẻ em");
                    break;
                default:
                    representString.Append("Vé không xác định");
                    break;
            }

            return representString.ToString();
        }


        public static List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }

        public static bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"(84|0[3|5|7|8|9])+([0-9]{8})\b").Success;
        }

        public static bool CompareStrings(string first, string second)
        {
            return first.Equals(second);
        }


        public static List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }

        public static void ConfigStyle(Control container)
        {
            List<Control> allControls = GetAllControls(container);
            allControls.ForEach(k => k.Font = new Font("Verdana", 11));
            allControls.ForEach(k => k.ForeColor = ColorTranslator.FromHtml("#000006"));
        }

        public static void Export2Excel(DataGridView dtgv)
        {
            dtgv.SelectAll();
            DataObject copyData = dtgv.GetClipboardContent();

            if (copyData != null)
            {
                Clipboard.SetDataObject(copyData);
            }

            Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            xlapp.Visible = true;

            Microsoft.Office.Interop.Excel.Workbook xlwbook;
            Microsoft.Office.Interop.Excel.Worksheet xlsheet;

            object miseddata = System.Reflection.Missing.Value;

            xlwbook = xlapp.Workbooks.Add(miseddata);

            xlsheet = (Microsoft.Office.Interop.Excel.Worksheet)xlwbook.Worksheets.get_Item(1);

            Microsoft.Office.Interop.Excel.Range xlr = (Microsoft.Office.Interop.Excel.Range)xlsheet.Cells[1, 1];

            xlr.Select();

            xlsheet.PasteSpecial(xlr, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

        }

        public static string GenerateRandomCode(int length)
        {
            string code = "";
            Random rd = new Random();

            for (int i = 0; i < length; i++)
            {
                code += rd.Next(0, 10).ToString();
            }

            return code;
        }

        public static bool SendMail(string email, string code)
        {
            var from = new MailAddress("paimoncinema@gmail.com");
            var to = new MailAddress(email);

            var subject = "Lấy lại mật khẩu đăng nhập";
            var body = "<h3 style='color: rgb(235, 44, 34);'>Paimon Cinema</h3><p>Chúng tôi đã nhận được yêu cầu đặt lại mật khẩu Paimon App của bạn.</p><p>Nhập mã đặt lại mật khẩu sau đây:</p>" + code + "<p>Nếu bạn không yêu cầu mật khẩu mới, vui lòng bỏ qua tin nhắn này.</p>";

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

            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SendMailForVouchers(string email, List<string> vouchers)
        {
            var from = new MailAddress("paimoncinema@gmail.com");
            var to = new MailAddress(email);

            var subject = "Tri ân khách hàng";
            StringBuilder body = new StringBuilder();

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
            mail.Body = body.ToString();
            mail.IsBodyHtml = true;

            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool FileCopy(string fileName, string sourcePath, string targetPath)
        {
            // Use Path class to manipulate file and directory paths.
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, fileName);

            // To copy a folder's contents to a new location:
            // Create a new target folder.
            // If the directory already exists, this method does not create a new directory.
            System.IO.Directory.CreateDirectory(targetPath);

            // To copy a file to another location and
            // overwrite the destination file if it already exists.
            try
            {
                System.IO.File.Copy(sourceFile, destFile, true);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            } 
        }

        public static (string, List<string>) GetListCode(int quantity, int length, string firstChars, string lastChars)
        {
            List<string> ListCode = new List<string>();
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            int randomLength = length - firstChars.Length - lastChars.Length;
            if (randomLength <= 0)
            {
                return ("Độ dài của voucher phải lớn hơn độ dài chuỗi kí tự đầu + độ dài chuỗi kí tự cuối", null);
            }
            if (randomLength < 4)
            {
                return ($"Độ dài của voucher phải lớn hơn độ dài chuỗi kí tự đầu + độ dài chuỗi kí tự cuối + 4 ", null);
            }
            for (int i = 0; i < quantity; i++)
            {

                var stringChars = new char[randomLength];
                for (int j = 0; j < stringChars.Length; j++)
                {
                    stringChars[j] = chars[random.Next(chars.Length)];
                }
                string newCode = new String(stringChars);
                var isExist = ListCode.Any(code => code == newCode);
                if (isExist)
                {
                    i--;
                    continue;
                }
                ListCode.Add(firstChars + newCode + lastChars);
            }

            return (null, ListCode);
        }
        public static string FormatVNMoney(decimal money)
        {
            if (money == 0)
            {
                return "0 ₫";
            }
            return String.Format(CultureInfo.InvariantCulture,
                                "{0:#,#} ₫", money);
        }

        public static bool ValidateValidFields(TextBox[] requiredControls)
        {
            //validate
            foreach (var control in requiredControls.Where(c => String.IsNullOrWhiteSpace(c.Text)))
            {
                return false;
            }

            foreach (var control in requiredControls.Where(c => c.Text.Contains(" ")))
            {
                return false;
            }

            return true;
        }

        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }
        public static int GetQuarter(DateTime date)
        {
            if (date.Month >= 4 && date.Month <= 6)
                return 1;
            else if (date.Month >= 7 && date.Month <= 9)
                return 2;
            else if (date.Month >= 10 && date.Month <= 12)
                return 3;
            else
                return 4;
        }
    }
}
