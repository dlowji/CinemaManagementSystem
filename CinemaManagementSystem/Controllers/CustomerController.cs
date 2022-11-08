using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem.Controllers
{
    public class CustomerController
    {
        public static DataTable GetCustomerList()
        {
            DataTable customers = CustomerDAO.GetListCustomer();

            return customers;
        }

        public static bool InsertCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            return CustomerDAO.InsertCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd);
        }

        public static bool UpdateCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
        {
            return CustomerDAO.UpdateCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd, point);
        }

        public static bool DeleteCustomer(string id)
        {
            return CustomerDAO.DeleteCustomer(id);
        }

        public static DataTable SearchCustomerByName(string customerName)
        {
            DataTable searchCustomerList = CustomerDAO.SearchCustomerByName(customerName);

            return searchCustomerList;
        }
    }
}
