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

        public static List<CumRap> GetListCineplexByFormatMovie(string formatMovieID, DateTime date)
        {
            List<CumRap> listCineplex = new List<CumRap>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            join d in db.DinhDangPhims
                            on p.id equals d.idPhim
                            join l in db.LichChieus
                            on d.id equals l.idDinhDang
                            join pc in db.PhongChieus
                            on l.idPhong equals pc.id
                            where d.id.Equals(formatMovieID)
                            orderby l.ThoiGianChieu
                            select l;

                foreach (var item in query)
                {
                    DateTime time = item.ThoiGianChieu;
                    if (DateTime.Parse(time.ToShortDateString()) == date)
                    {
                        listCineplex.Add(item.PhongChieu.CumRap);  
                    }
                }

            }

            return listCineplex;
        }
    }
}
