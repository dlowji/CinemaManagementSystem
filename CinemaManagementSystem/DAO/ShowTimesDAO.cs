using CinemaManagementSystem;
using GUI.frmAdminUserControls.DataUserControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI.DAO
{
    public class ShowTimesDAO
    {
        public static DataTable GetListShowTimeByValues(string cinemaTypeId, string cineplexId, string movieId, DateTime date)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã lịch chiếu", typeof(string));
            dt.Columns.Add("Tên rạp", typeof(string));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Thời gian chiếu", typeof(DateTime));
            dt.Columns.Add("Loại rạp", typeof(string));
            dt.Columns.Add("Giá vé", typeof(decimal));
            dt.Columns.Add("Trạng thái", typeof(int));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from lichChieu in db.LichChieus
                            where lichChieu.idPhim.Equals(movieId)
                            select lichChieu;

                foreach (var item in query)
                {
                    DateTime showTimeDate = DateTime.Parse(item.ThoiGianChieu.ToShortDateString());
                    DateTime customDate = DateTime.Parse(date.ToShortDateString());
                    if (!showTimeDate.Equals(customDate) || !item.Rap.LoaiRap.id.Equals(cinemaTypeId) || !item.Rap.CumRap.id.Equals(cineplexId))
                    {
                        continue;
                    }

                    dt.Rows.Add(item.id, item.Rap.TenRap, item.Phim.TenPhim, item.ThoiGianChieu, item.Rap.LoaiRap.TenLoaiRap, item.GiaVe, item.TrangThai);
                }
            }

            return dt;
        }

        public static List<LichChieu> GetAllListShowTimes()
        {
            List<LichChieu> listShowTimes = new List<LichChieu>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            join lc in db.LichChieus
                            on p.id equals lc.idPhim
                            join pc in db.Raps
                            on lc.idRap equals pc.id
                            orderby lc.ThoiGianChieu
                            select lc;

                foreach (var item in query)
                {
                    listShowTimes.Add(item);
                }
            }
           
            return listShowTimes;
        }
        public static List<LichChieu> GetListShowTimesNotCreateTickets()
        {
            List<LichChieu> listShowTimes = new List<LichChieu>();
           
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            join lc in db.LichChieus
                            on p.id equals lc.idPhim
                            join pc in db.Raps
                            on lc.idRap equals pc.id
                            where lc.TrangThai == 0
                            orderby lc.ThoiGianChieu
                            select lc;

                foreach (var item in query)
                {
                    listShowTimes.Add(item);
                }
            }

            return listShowTimes;
        }
        public static int UpdateStatusShowTimes(string showTimesID, int status)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_UpdateStatusShowTimes(showTimesID, status);
                    return 1;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return -1;
                }
            }
        }

		public static DataTable GetListShowtime()
		{
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã lịch chiếu", typeof(string));
            dt.Columns.Add("Thời gian chiếu", typeof(DateTime));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Tên rạp", typeof(string));
            dt.Columns.Add("Loại rạp", typeof(string));
            dt.Columns.Add("Cụm rạp", typeof(string));
            dt.Columns.Add("Giá vé", typeof(decimal));
            dt.Columns.Add("Trạng thái", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from lichChieu in db.LichChieus
                            select lichChieu;

                foreach (var item in query)
                {
                    string trangThai = item.TrangThai == 1 ? "Đã tạo vé" : "Chưa tạo vé";
                    dt.Rows.Add(item.id, item.ThoiGianChieu, item.Rap.TenRap, item.Rap.LoaiRap.TenLoaiRap, item.Rap.CumRap.Ten, item.Phim.TenPhim, item.GiaVe, trangThai);
                }
            }

            return dt;
		}

		public static bool InsertShowtime(string id, string cinemaID, string movieID, DateTime time, decimal ticketPrice)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                LichChieu lichChieu = new LichChieu
                {
                    id = id,
                    ThoiGianChieu = time,
                    idRap = cinemaID,
                    idPhim = movieID,
                    GiaVe = ticketPrice,
                    TrangThai = 0
                };

                db.LichChieus.InsertOnSubmit(lichChieu);

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

		public static bool UpdateShowtime(string id, string cinemaID, string movieId, DateTime time, decimal ticketPrice)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var lichChieu = (from lc in db.LichChieus
                                where lc.id.Equals(id)
                                select lc).First();

                lichChieu.ThoiGianChieu = time;
                lichChieu.idRap = cinemaID;
                lichChieu.idPhim = movieId;
                lichChieu.GiaVe = ticketPrice;

                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

		public static bool DeleteShowtime(string id)
		{
            TicketDAO.DeleteTicketsByShowTimes(id);

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var lc = (from l in db.LichChieus
                           where l.id.Equals(id)
                           select l);

                db.LichChieus.DeleteAllOnSubmit(lc);

                //ask the datacontext to save all the changes
                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

		public static DataTable SearchShowtimeByMovieName(string movieName)
		{
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã lịch chiếu", typeof(string));
            dt.Columns.Add("Thời gian chiếu", typeof(DateTime));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Tên rạp", typeof(string));
            dt.Columns.Add("Loại rạp", typeof(string));
            dt.Columns.Add("Cụm rạp", typeof(string));
            dt.Columns.Add("Giá vé", typeof(decimal));
            dt.Columns.Add("Trạng thái", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_SearchShowtimeByMovieName(movieName);

                foreach (var item in query)
                {
                    dt.Rows.Add(item.Mã_lịch_chiếu, item.Cụm_Rạp, item.Tên_phim, item.Loại_Rạp, item.Thời_gian_chiếu, item.Giá_vé);
                }
            }

            return dt;
        }

        public static string getShowTimesIdByCinemaName(string name)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from lc in db.LichChieus
                            where lc.Rap.TenRap.Equals(name)
                            select lc);

                return query.FirstOrDefault().id;
            }
        }

        public static int getShowTimesStatusByCinemaName(string name)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from lc in db.LichChieus
                             where lc.Rap.TenRap.Equals(name)
                             select lc);

                return query.FirstOrDefault().TrangThai;
            }
        }
	}
}
