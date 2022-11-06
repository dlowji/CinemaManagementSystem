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
            dt.Columns.Add("Mã phòng", typeof(string));
            dt.Columns.Add("Tên phòng", typeof(string));
            dt.Columns.Add("Tên màn hình", typeof(string));
            dt.Columns.Add("Số chỗ ngồi", typeof(int));
            dt.Columns.Add("Tình trạng", typeof(int));
            dt.Columns.Add("Số hàng ghế", typeof(int));
            dt.Columns.Add("Ghế mỗi hàng", typeof(int));

            //using (CinemaDataContext db = new CinemaDataContext())
            //{
            //    var query = db.USP_GetCinema();

            //    foreach (var item in query)
            //    {
            //        dt.Rows.Add(item.Mã_phòng, item.Tên_phòng, item.Tên_màn_hình, item.Số_chỗ_ngồi, item.Tình_trạng, item.Số_hàng_ghế, item.Ghế_mỗi_hàng);
            //    }
            //}

            return dt;
        }

        public static bool InsertCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    //db.USP_InsertCinema(id, name, idMH, seats, status, numberOfRows, seatsPerRow);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static bool UpdateCinema(string id, string name, string idMH, int seats, int status, int numberOfRows, int seatsPerRow)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var pc = (from p in db.Raps
                          where p.id.Equals(id)
                          select p).First();

                //pc.TenPhong = name;
                //pc.idManHinh = idMH;
                pc.SoChoNgoi = seats;
                pc.TinhTrang = status;
                pc.SoHangGhe = numberOfRows;
                pc.SoGheMotHang = seatsPerRow;

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

        public static bool DeleteCinemaByScreenTypeId(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                //var pc = (from p in db.Raps
                //          where p.idManHinh.Equals(id)
                //          select p).First();

                //db.Raps.DeleteOnSubmit(pc);

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
