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
    public class StaffController
    {
        public static DataTable GetStaffList()
        {
            DataTable staffs = StaffDAO.GetListStaff();

            return staffs;
        }

        public static bool InsertStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            return StaffDAO.InsertStaff(id, hoTen, ngaySinh, diaChi, sdt, cmnd);
        }

        public static bool UpdateStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            return StaffDAO.UpdateStaff(id, hoTen, ngaySinh, diaChi, sdt, cmnd);
        }

        public static bool DeleteStaff(string id)
        {
            return StaffDAO.DeleteStaff(id);
        }

        public static DataTable SearchStaffByName(string staffName)
        {
            DataTable searchStaffList = StaffDAO.SearchStaffByName(staffName);

            return searchStaffList;
        }

    }
}
