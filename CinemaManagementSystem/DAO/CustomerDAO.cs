using CinemaManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI.DAO
{
    public class CustomerDAO
    {

        public static List<CapDoThanhVien> GetLevels()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from level in db.CapDoThanhViens
                            select level;

                return query.ToList();
            }
        }
        public static DataTable GetCustomerMember(string customerID, string name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách hàng", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Email", typeof(string));
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
                    if (item.id.Equals("KH00"))
                    {
                        continue;
                    }

                    dt.Rows.Add(item.id, item.HoTen, item.Email, item.NgaySinh, item.DiaChi, item.SDT, item.CMND, item.DiemTichLuy);
                }
            }

            return dt;
        }

        public static DataTable GetListCustomer()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách hàng", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Email", typeof(string));
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
                    if (item.id.Equals("KH00"))
                    {
                        continue;
                    }
                    dt.Rows.Add(item.id, item.HoTen, item.Email, item.NgaySinh, item.DiaChi, item.SDT, item.CMND, item.DiemTichLuy);
                }
            }

            return dt;
        }

        public static KhachHang InsertCustomer(string id, string hoTen, string email, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                StringBuilder customId = new StringBuilder("KH");

                if (id is null)
                {
                    var query = from c in db.KhachHangs
                                select c;

                    int count = query.Count();

                    if (count + 1 < 10)
                    {
                        customId.Append("0").Append((count + 1).ToString());
                    }
                    else
                    {
                        customId.Append((count + 1).ToString());
                    }
                }

                KhachHang cus = new KhachHang
                {
                    id = id is null ? customId.ToString() : id,
                    HoTen = hoTen,
                    Email = email,
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
                    return cus;
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public static bool UpdateCustomer(string id, string hoTen, string email, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var kh = (from k in db.KhachHangs
                          where k.id.Equals(id)
                          select k).First();

                kh.HoTen = hoTen;
                kh.Email = email;
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

        public static List<KhachHang> GetCustomers()
        {
            List<KhachHang> customerList = new List<KhachHang>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var customers = from c in db.KhachHangs
                                select c;

                foreach (var item in customers)
                {
                    customerList.Add(item);
                }
            }

            return customerList;
        }

        public static DataTable SearchCustomerByName(string name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã khách hàng", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            //dt.Columns.Add("Email", typeof(string));
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
