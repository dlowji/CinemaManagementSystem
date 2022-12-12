using CinemaManagementSystem;
using System;
using System.Collections.Generic;
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

        public static List<TaiKhoan> GetAccounts()
        {
            List<TaiKhoan> accounts = new List<TaiKhoan>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from acc in db.TaiKhoans
                            select acc;

                foreach (var item in query)
                {
                    accounts.Add(item);
                }
            }

            return accounts;
        }

        public static bool UpdatePasswordForAccount(string userName, string newPassword)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var accounts = from acc in db.TaiKhoans
                              where acc.UserName.Equals(userName)
                              select acc;

                int counter = accounts.Count();

                if (counter == 0)
                {
                    return false;
                }
                else if (counter == 1)
                {
                    TaiKhoan tk = accounts.First();
                    tk.Pass = newPassword;
                }

                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
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

		public static bool InsertAccount(string username, string password, int accountType, string staffID, string cusId)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                TaiKhoan acc = new TaiKhoan
                {
                    UserName = username,
                    Pass = password,
                    LoaiTK = accountType,
                    idNV = staffID,
                    idKH = cusId,
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
