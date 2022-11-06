using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class LoginController
    {
        public int Login(string username, string password)
        {
            return AccountDAO.Login(username, password);
        }
    }
}
