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
        public static DataTable GetListShowTimeByFormatMovie(string formatMovieID, DateTime date)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã lịch chiếu", typeof(string));
            dt.Columns.Add("Tên phòng chiếu", typeof(string));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Thời gian chiếu", typeof(DateTime));
            dt.Columns.Add("Mã định dạng phim", typeof(string));
            dt.Columns.Add("Giá vé", typeof(decimal));
            dt.Columns.Add("Trạng thái", typeof(int));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_GetListShowTimesByFormatMovie(formatMovieID, date);

                foreach (var item in query)
                {
                    dt.Rows.Add(item.id, item.TenPhong, item.TenPhim, item.ThoiGianChieu, item.idDinhDang, item.GiaVe, item.TrangThai);
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
                            join ddp in db.DinhDangPhims
                            on p.id equals ddp.idPhim
                            join lc in db.LichChieus
                            on ddp.id equals lc.idDinhDang
                            join pc in db.PhongChieus
                            on lc.idPhong equals pc.id
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
                            join ddp in db.DinhDangPhims
                            on p.id equals ddp.idPhim
                            join lc in db.LichChieus
                            on ddp.id equals lc.idDinhDang
                            join pc in db.PhongChieus
                            on lc.idPhong equals pc.id
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
            dt.Columns.Add("Mã phòng", typeof(string));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Màn hình", typeof(string));
            dt.Columns.Add("Thời gian chiếu", typeof(DateTime));
            dt.Columns.Add("Giá vé", typeof(decimal));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                db.DeferredLoadingEnabled = false;

                var query = db.USP_GetShowtime();

                foreach (var item in query)
                {
                    dt.Rows.Add(item.Mã_lịch_chiếu, item.Mã_phòng, item.Tên_phim, item.Màn_hình, item.Thời_gian_chiếu, item.Giá_vé);
                }
            }

            return dt;
		}

		public static bool InsertShowtime(string id, string cinemaID, string formatMovieID, DateTime time, float ticketPrice)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_InsertShowtime(id, cinemaID, formatMovieID, time, ticketPrice);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
		}

		public static bool UpdateShowtime(string id, string cinemaID, string formatMovieID, DateTime time, float ticketPrice)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_UpdateShowtime(id, cinemaID, formatMovieID, time, ticketPrice);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
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
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

		public static DataTable SearchShowtimeByMovieName(string movieName)
		{
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã lịch chiếu", typeof(string));
            dt.Columns.Add("Mã phòng", typeof(string));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Màn hình", typeof(string));
            dt.Columns.Add("Thời gian chiếu", typeof(DateTime));
            dt.Columns.Add("Giá vé", typeof(decimal));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_SearchShowtimeByMovieName(movieName);

                foreach (var item in query)
                {
                    dt.Rows.Add(item.Mã_lịch_chiếu, item.Mã_phòng, item.Tên_phim, item.Màn_hình, item.Thời_gian_chiếu, item.Giá_vé);
                }
            }

            return dt;
        }

        public static string getShowTimesIdByCinemaName(string name)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from lc in db.LichChieus
                            where lc.PhongChieu.TenPhong.Equals(name)
                            select lc);

                return query.FirstOrDefault().id;
            }
        }

        public static int getShowTimesStatusByCinemaName(string name)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from lc in db.LichChieus
                             where lc.PhongChieu.TenPhong.Equals(name)
                             select lc);

                return query.FirstOrDefault().TrangThai;
            }
        }
	}
}
