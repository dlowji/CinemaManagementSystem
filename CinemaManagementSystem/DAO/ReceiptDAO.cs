using CinemaManagementSystem;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class ReceiptDAO
    {
        private ReceiptDAO() { }

        public static List<HoaDon> GetTicketReceipts()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from hd in db.HoaDons
                            select hd;

                return query.ToList();
            }
        }

        public static List<HoaDon> GetProductReceipts()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from hdsp in db.HoaDonSanPhams
                            join hd in db.HoaDons
                            on hdsp.idHoaDon equals hd.id
                            select hd;

                return query.ToList();
            }
        }

        public static List<HoaDonNhapHang> GetImportReceipts()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from hdnh in db.HoaDonNhapHangs
                            select hdnh;

                return query.ToList();
            }
        }
    }
}
