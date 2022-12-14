using CinemaManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class CinemaDAO
    {

        public static List<Rap> GetCinemas()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from rap in db.Raps
                            select rap;

                return query.ToList();
            }
        }
        public static Rap GetCinemaByName(string cinemaName)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from pc in db.Raps
                            where pc.TenRap.Equals(cinemaName)
                            select pc;

                return query.FirstOrDefault();
            }
        }

        public static LoaiRap GetCinemaTypeByCinemaID(string cinemaId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from rap in db.Raps
                            where rap.id == cinemaId
                            select rap).First();

                return query.LoaiRap;
            }
        }
        public static CumRap GetCineplexByCinemaID(string cinemaId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from rap in db.Raps
                             where rap.id == cinemaId
                             select rap);

                return query.First().CumRap;
            }
        }

        public static Rap GetCinemaByID(string id)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from pc in db.Raps
                            where pc.id.Equals(id)
                            select pc;

                return query.FirstOrDefault();
            }
        }

		public static List<Rap> GetCinemaByScreenTypeID(string screenTypeID)
		{
            List<Rap> cinemaList = new List<Rap>();

            //         using (CinemaDataContext db = new CinemaDataContext())
            //         {
            //             var query = from pc in db.Raps
            //                         where pc.idManHinh.Equals(screenTypeID)
            //                         select pc;
            //             foreach (Rap pc in query)
            //    {
            //	    cinemaList.Add(pc);
            //    }
            //         }

            return cinemaList;
        }

        public static DataTable GetListCinema()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã rạp", typeof(string));
            dt.Columns.Add("Tên rạp", typeof(string));
            dt.Columns.Add("Số chỗ ngồi", typeof(int));
            dt.Columns.Add("Tình trạng", typeof(string));
            dt.Columns.Add("Số hàng ghế", typeof(int));
            dt.Columns.Add("Ghế mỗi hàng", typeof(int));
            dt.Columns.Add("Loại rạp", typeof(string));
            dt.Columns.Add("Cụm rạp", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from rap in db.Raps
                            join loaiRap in db.LoaiRaps
                            on rap.idLoaiRap equals loaiRap.id
                            join cumRap in db.CumRaps
                            on rap.idCumRap equals cumRap.id
                            select new { rap };

                foreach (var item in query)
                {
                    Rap rap = item.rap;
                    string trangThai = rap.TinhTrang == 1 ? "Đang hoạt động" : "Không hoạt động";
                    dt.Rows.Add(rap.id, rap.TenRap, rap.SoChoNgoi, trangThai, rap.SoHangGhe, rap.SoGheMotHang, rap.LoaiRap.TenLoaiRap, rap.CumRap.Ten);
                }
            }

            return dt;
        }

        public static bool InsertCinema(string id, string tenRap, int soChoNgoi, int tinhTrang, int soHangGhe, int soGheMotHang, string idLoaiRap, string idCumRap)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                Rap rap = new Rap
                {
                    id = id,
                    TenRap = tenRap,
                    SoChoNgoi = soChoNgoi,
                    TinhTrang = tinhTrang,
                    SoHangGhe = soHangGhe,
                    SoGheMotHang = soGheMotHang,
                    idLoaiRap = idLoaiRap,
                    idCumRap = idCumRap
                };

                db.Raps.InsertOnSubmit(rap);

                try
                {
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static bool UpdateCinema(string id, string tenRap, int soChoNgoi, int tinhTrang, int soHangGhe, int soGheMotHang, string idLoaiRap, string idCumRap)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var rap = (from r in db.Raps
                          where r.id.Equals(id)
                          select r).First();

                rap.TenRap = tenRap;
                rap.SoChoNgoi = soChoNgoi;
                rap.TinhTrang = tinhTrang;
                rap.SoHangGhe = soHangGhe;
                rap.SoGheMotHang = soGheMotHang;
                rap.idLoaiRap = idLoaiRap;
                rap.idCumRap = idCumRap;

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

        public static bool DeleteCinema(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var pc = (from p in db.Raps
                          where p.id.Equals(id)
                          select p).First();

                db.Raps.DeleteOnSubmit(pc);

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

        public static bool DeleteCinemaByCinemaTypeId(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var rap = (from r in db.Raps
                          where r.idLoaiRap.Equals(id)
                          select r).First();

                db.Raps.DeleteOnSubmit(rap);

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
    }
}
