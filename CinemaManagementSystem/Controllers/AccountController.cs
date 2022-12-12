using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class AccountController
    {
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

        public static TaiKhoan GetAccountByUsername(string username)
        {
            return AccountDAO.GetAccountByUserName(username);
        }

        public static bool IsRegistedAccount(string username)
        {
            List<TaiKhoan> accounts = AccountDAO.GetAccounts();

            foreach (var item in accounts)
            {
                if (item.UserName.Equals(username))
                {
                    return true;
                }
            }

            return false;
        }

       public static bool UpdatePasswordForAccount(string username, string newPass)
       {
            string hashPass = PasswordEncryption(newPass);

            return AccountDAO.UpdatePasswordForAccount(username, hashPass);
       }

        public static bool Register(string id, string username, string password, string name, DateTime birthday, string address, string phone, int cmnd)
        {
            KhachHang cus = CustomerDAO.InsertCustomer(id, name, username, birthday, address, phone, cmnd);

            if (cus == null)
            {
                return false;
            }

            string hashPass = PasswordEncryption(password);

            return AccountDAO.InsertAccount(username, hashPass, 3, null, cus.id);
        }

        public static bool Login(string username, string password)
        {
            string hashPass = PasswordEncryption(password);

            List<TaiKhoan> accounts = AccountDAO.GetAccounts();

            foreach (var item in accounts)
            {
                if (item.UserName.Equals(username) && item.Pass.Equals(hashPass))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
