using CinemaManagementSystem;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI.DAO
{
    public class CustomerDAO
    {
        public static DataTable GetCustomerMember(string customerID, string name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách hàng", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Ngày sinh", typeof(DateTime));
            dt.Columns.Add("Địa chỉ", typeof(string));
            dt.Columns.Add("SĐT", typeof(string));
            dt.Columns.Add("CMND", typeof(int));
            dt.Columns.Add("Điểm tích lũy", typeof(int));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from kh in db.KhachHangs
                            where kh.id.Equals(customerID) && kh.HoTen.Equals(name)
                            select kh;

                foreach (var item in query)
                {
                    dt.Rows.Add(item.id, item.HoTen, item.NgaySinh, item.DiaChi, item.SDT, item.CMND, item.DiemTichLuy);
                }
            }

            return dt;
        }

        public static DataTable GetListCustomer()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách hàng", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Ngày sinh", typeof(DateTime));
            dt.Columns.Add("Địa chỉ", typeof(string));
            dt.Columns.Add("SĐT", typeof(string));
            dt.Columns.Add("CMND", typeof(int));
            dt.Columns.Add("Điểm tích lũy", typeof(int));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from kh in db.KhachHangs
                            select kh;

                foreach (var item in query)
                {
                    dt.Rows.Add(item.id, item.HoTen, item.NgaySinh, item.DiaChi, item.SDT, item.CMND, item.DiemTichLuy);
                }
            }

            return dt;
        }

        public static bool InsertCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                KhachHang cus = new KhachHang
                {
                    id = id,
                    HoTen = hoTen,
                    NgaySinh = ngaySinh,
                    DiaChi = diaChi,
                    SDT = sdt,
                    CMND = cmnd,
                    DiemTichLuy = 0,
                    idCapDoThanhVien = "LV01"
                };

                db.KhachHangs.InsertOnSubmit(cus);

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

        public static bool UpdateCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var kh = (from k in db.KhachHangs
                          where k.id.Equals(id)
                          select k).First();

                kh.HoTen = hoTen;
                kh.NgaySinh = ngaySinh;
                kh.DiaChi = diaChi;
                kh.SDT = sdt;
                kh.CMND = cmnd;
                kh.DiemTichLuy = point;

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

        public static bool UpdatePointCustomer(string id, int point)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var kh = (from k in db.KhachHangs
                          where k.id.Equals(id)
                          select k).First();

                kh.DiemTichLuy = point;

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

        public static bool DeleteCustomer(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var kh = (from k in db.KhachHangs
                          where k.id.Equals(id)
                          select k).First();

                db.KhachHangs.DeleteOnSubmit(kh);

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

        public static DataTable SearchCustomerByName(string name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách hàng", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Ngày sinh", typeof(DateTime));
            dt.Columns.Add("Địa chỉ", typeof(string));
            dt.Columns.Add("SĐT", typeof(string));
            dt.Columns.Add("CMND", typeof(int));
            dt.Columns.Add("Điểm tích lũy", typeof(int));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_SearchCustomer(name);

                foreach (var item in query)
                {
                    dt.Rows.Add(item.Mã_khách_hàng, item.Họ_tên, item.Ngày_sinh, item.Địa_chỉ, item.SĐT, item.CMND, item.Điểm_tích_lũy);
                }
            }

            return dt;
        }
    }
}
