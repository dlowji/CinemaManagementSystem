using CinemaManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI.DAO
{
    public class StaffDAO
    {
		public static NhanVien GetStaffByID(string id)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from nv in db.NhanViens
                            where nv.id.Equals(id)
                            select nv;

                return query.FirstOrDefault();
            }
		}

		public static List<NhanVien> GetStaff()
		{
			List<NhanVien> staffList = new List<NhanVien>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from nv in db.NhanViens
                            select nv;

                foreach (var item in query)
                {
                    staffList.Add(item);
                }
            }

			return staffList;
		}

        public static DataTable GetListStaff()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã nhân viên", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Ngày sinh", typeof(DateTime));
            dt.Columns.Add("Địa chỉ", typeof(string));
            dt.Columns.Add("SĐT", typeof(string));
            dt.Columns.Add("CMND", typeof(int));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_GetStaff();

                foreach (var item in query)
                {
                    dt.Rows.Add(item.Mã_nhân_viên, item.Họ_tên, item.Ngày_sinh, item.Địa_chỉ, item.SĐT, item.CMND);
                }
            }

            return dt;
        }

        public static bool InsertStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_InsertStaff(id, hoTen, ngaySinh, diaChi, sdt, cmnd);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static bool UpdateStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var nv = (from n in db.NhanViens
                          where n.id.Equals(id)
                          select n).First();

                nv.HoTen = hoTen;
                nv.NgaySinh = ngaySinh;
                nv.DiaChi = diaChi;
                nv.SDT = sdt;
                nv.CMND = cmnd;

                //ask the datacontext to save all the changes
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static bool DeleteStaff(string id)
        {
            AccountDAO.DeleteAccountByIdStaff(id);

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from nv in db.NhanViens
                            where nv.id.Equals(id)
                            select nv).First();

                db.NhanViens.DeleteOnSubmit(query);

                //ask the datacontext to save all the changes
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static DataTable SearchStaffByName(string name)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã nhân viên", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Ngày sinh", typeof(DateTime));
            dt.Columns.Add("Địa chỉ", typeof(string));
            dt.Columns.Add("SĐT", typeof(string));
            dt.Columns.Add("CMND", typeof(int));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_SearchStaff(name);

                foreach (var item in query)
                {
                    dt.Rows.Add(item.Mã_nhân_viên, item.Họ_tên, item.Ngày_sinh, item.Địa_chỉ, item.SĐT, item.CMND);
                }
            }

            return dt;
        }
    }
}