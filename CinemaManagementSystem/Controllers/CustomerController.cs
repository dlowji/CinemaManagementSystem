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

        public static bool UpdateMemberPoint(string cusId, int point)
        {
            return CustomerDAO.UpdatePointCustomer(cusId, point);
        }
        public static DataTable GetCustomerList()
        {
            DataTable customers = CustomerDAO.GetListCustomer();

            return customers;
        }

        public static KhachHang GetCustomerByPhone(string phone)
        {
            List<KhachHang> customerList = CustomerDAO.GetCustomers();

            foreach (var item in customerList)
            {
                if (item.SDT.Equals(phone))
                {
                    return item;
                }
            }

            return null;
        }

        public static KhachHang GetCustomerByCeritificate(int certificate)
        {
            List<KhachHang> customerList = CustomerDAO.GetCustomers();

            foreach (var item in customerList)
            {
                if (item.CMND == certificate)
                {
                    return item;
                }
            }

            return null;
        }

        public static KhachHang GetCustomerById(string cusId)
        {
            List<KhachHang> customerList = CustomerDAO.GetCustomers();

            foreach (var item in customerList)
            {
                if (item.id.Equals(cusId))
                {
                    return item;
                }
            }

            return null;
        }

        public static CapDoThanhVien GetMemberLevelById(string levelId)
        {
            List<CapDoThanhVien> levels = CustomerDAO.GetLevels();

            foreach (var item in levels)
            {
                if (item.id.Equals(levelId))
                {
                    return item;
                }
            }

            return null;
        }

        public static bool InsertCustomer(string id, string hoTen, string email, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            return CustomerDAO.InsertCustomer(id, hoTen, email, ngaySinh, diaChi, sdt, cmnd) != null;
        }

        public static bool UpdateCustomer(string id, string hoTen, string email, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
        {
            return CustomerDAO.UpdateCustomer(id, hoTen, email, ngaySinh, diaChi, sdt, cmnd, point);
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
