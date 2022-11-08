using CinemaManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;//thư viện để mã hóa mật khẩu
using System.Text;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class CineplexDAO
    {
        private CineplexDAO() { }

        public static List<CumRap> GetListCineplex()
        {
            List<CumRap> cineplexs = new List<CumRap> ();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from cr in db.CumRaps
                            select cr;

                foreach (var item in query)
                {
                    cineplexs.Add(item);
                }
            }

            return cineplexs;
        }

        public static List<CumRap> GetListCineplexByCinemaTypeID(string cinemaTypeID, string movieId, DateTime date)
        {
            List<CumRap> cineplexs = new List<CumRap>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from lc in db.LichChieus
                            where lc.idPhim.Equals(movieId)
                            select lc;

                foreach (var item in query)
                {
                    DateTime showTimeDate = DateTime.Parse(item.ThoiGianChieu.ToShortDateString());
                    DateTime customDate = DateTime.Parse(date.ToShortDateString());

                    if (!item.Rap.idLoaiRap.Equals(cinemaTypeID) || !showTimeDate.Equals(customDate))
                    {
                        continue;
                    }

                    if (cineplexs.Contains(item.Rap.CumRap))
                    {
                        continue;
                    }

                    cineplexs.Add(item.Rap.CumRap);
                }
            }

            return cineplexs;
        }
    }
}
