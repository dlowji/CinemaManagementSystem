using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class AccountController
    {
       public static TaiKhoan GetAccountByUsername(string username)
       {
            return AccountDAO.GetAccountByUserName(username);
       }

       public static bool UpdatePasswordForAccount(string username, string newPass)
       {
            return AccountDAO.UpdatePasswordForAccount(username, newPass);
       }
    }
}
