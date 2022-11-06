using CinemaManagementSystem;
using System;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class RevenueDAO
    {
        public static DataTable GetRevenue(string idMovie, DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Ngày chiếu", typeof(DateTime));
            dt.Columns.Add("Giờ chiếu", typeof(TimeSpan));
            dt.Columns.Add("Số vé đã bán", typeof(int));
            dt.Columns.Add("Tiền bán vé", typeof(decimal));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_GetReportRevenueByMovieAndDate(idMovie, fromDate, toDate);

                foreach (var item in query)
                {
                    dt.Rows.Add(item.TenPhim, item.NgayChieu, item.GioChieu, item.SoVeDaBan, item.TienBanVe);
                }
            }

            return dt;
        }
    }
}
