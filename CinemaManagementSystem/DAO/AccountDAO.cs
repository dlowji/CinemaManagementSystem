using CinemaManagementSystem;
using System;
using System.Data;
using System.Linq;
using System.Security.Cryptography;//thư viện để mã hóa mật khẩu
using System.Text;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class AccountDAO
    {
        private AccountDAO() { }

        private static string PasswordEncryption(string password)
        {
            //tính năng bảo mật cho việc đăng nhập
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);//chuyển qua mảng kiểu byte từ một chuỗi
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            //tạo ra bảng has(bảng băm) chứa các mảng byte
            //từ mật khẩu được mã hóa thành mảng băm

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            //tính năng mã hóa nâng cao bằng việc đảo ngược mật khẩu
            char[] arr = hasPass.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static int Login(string userName, string passWord)
        {
            string pass = PasswordEncryption(passWord);

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var result = db.USP_Login(userName, pass).ToList();

                if (result == null)
                    return -1;
                else if (result.Count > 0)
                    return 1;
                else
                    return 0;
            }

        }

        public static bool UpdatePasswordForAccount(string userName, string passWord, string newPassWord)
        {

            string oldPass = PasswordEncryption(passWord);
            string newPass = PasswordEncryption(newPassWord);

            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_UpdatePasswordForAccount(userName, oldPass, newPass);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static TaiKhoan GetAccountByUserName(string userName)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from tk in db.TaiKhoans
                            where tk.UserName.Equals(userName)
                            select tk;

                return query.FirstOrDefault();
            }
        }

        public static void DeleteAccountByIdStaff(string idStaff)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var deleteAccount = from tk in db.TaiKhoans
                                    where tk.idNV.Equals(idStaff)
                                    select tk;

                foreach (var account in deleteAccount)
                {
                    db.TaiKhoans.DeleteOnSubmit(account);
                }

                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

		public static DataTable GetAccountList()
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                return (DataTable)db.USP_GetAccountList();
            }
		}

		public static bool InsertAccount(string username, string password, int accountType, string staffID)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                string hashPass = PasswordEncryption(password);
                TaiKhoan acc = new TaiKhoan
                {
                    UserName = username,
                    Pass = hashPass,
                    LoaiTK = accountType,
                    idNV = staffID
                };

                db.TaiKhoans.InsertOnSubmit(acc);

                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
		}

		public static bool UpdateAccount(string username, int accountType)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_UpdateAccount(username, accountType);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
		}

		public static bool DeleteAccount(string username)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var deleteAccount = from tk in db.TaiKhoans
                                    where tk.UserName.Equals(username)
                                    select tk;

                foreach (var account in deleteAccount)
                {
                    db.TaiKhoans.DeleteOnSubmit(account);
                }

                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

		public static DataTable SearchAccountByStaffName(string name)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                return (DataTable)db.USP_SearchAccount(name);
            }
		}

		public static bool ResetPassword(string username)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_ResetPasswordtAccount(username);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
		}
    }
}
