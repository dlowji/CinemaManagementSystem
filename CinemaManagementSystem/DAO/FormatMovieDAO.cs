using CinemaManagementSystem;
using GUI.frmAdminUserControls.DataUserControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class FormatMovieDAO
    {
        public static List<DinhDangPhim> GetListFormatMovieByMovie(string movieID)
        {
            List<DinhDangPhim> listFormat = new List<DinhDangPhim>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from ddp in db.DinhDangPhims
                            where ddp.idPhim.Equals(movieID)
                            select ddp;
                
                foreach (var item in query)
                {
                    listFormat.Add(item);
                }
            }

            return listFormat;
        }

        public static List<Object> GetListFormatMovieByMovieVersion2(string movieID)
        {
            List<Object> listFormat = new List<Object>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from ddp in db.DinhDangPhims
                            join mh in db.LoaiManHinhs
                            on ddp.idLoaiManHinh equals mh.id
                            where ddp.idPhim.Equals(movieID)
                            select new
                            {
                                id = ddp.id,
                                idPhim = ddp.idPhim,
                                idLoaiManHinh = ddp.idLoaiManHinh,
                                tenMH = ddp.LoaiManHinh.TenMH
                            };

                foreach (var item in query)
                {
                    listFormat.Add(item);
                }
            }

            return listFormat;
        }

        public static DataTable GetFormatMovieByID(string movieID, string screenTypeID)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã định dạng phim", typeof(string));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Tên màn hình", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            join ddp in db.DinhDangPhims
                            on p.id equals ddp.idPhim
                            join mh in db.LoaiManHinhs
                            on ddp.idLoaiManHinh equals mh.id
                            where p.id.Equals(movieID) && mh.id.Equals(screenTypeID)
                            select new
                            {
                                MaDinhDangPhim = ddp.id,
                                TenPhim = p.TenPhim,
                                TenManHinh = mh.TenMH
                            };

                foreach (var item in query)
                {
                    dt.Rows.Add(item.MaDinhDangPhim, item.TenPhim, item.TenManHinh);
                }
            }

            return dt;
        }

		public static DinhDangPhim GetFormatMovieByName(string movieName, string screenTypeName)
		{
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from p in db.Phims
                            join ddp in db.DinhDangPhims
                            on p.id equals ddp.idPhim
                            join mh in db.LoaiManHinhs
                            on ddp.idLoaiManHinh equals mh.id
                            where p.TenPhim.Equals(movieName) && mh.TenMH.Equals(screenTypeName)
                            select new
                            {
                                MaDinhDangPhim = ddp.id,
                                MaPhim = p.id,
                                MaManHinh = mh.id,
                            });

                foreach (var item in query)
                {
                    DinhDangPhim movie = new DinhDangPhim();
                    movie.id = item.MaDinhDangPhim;
                    movie.idPhim = item.MaPhim;
                    movie.idLoaiManHinh = item.MaManHinh;

                    return movie;
                }

                return null;
            }
        }

		public static List<DinhDangPhim> GetFormatMovie()
		{
			List<DinhDangPhim> formatMovieList = new List<DinhDangPhim>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            join ddp in db.DinhDangPhims
                            on p.id equals ddp.idPhim
                            join mh in db.LoaiManHinhs
                            on ddp.idLoaiManHinh equals mh.id
                            select ddp;

                foreach (var item in query)
                {
                    formatMovieList.Add(item);
                }
            }
     
			return formatMovieList;
		}

        public static DataTable GetListFormatMovie()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã định dạng", typeof(string));
            dt.Columns.Add("Mã phim", typeof(string));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Mã MH", typeof(string));
            dt.Columns.Add("Tên Mh", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_GetListFormatMovie();

                foreach (var item in query)
                {
                    dt.Rows.Add(item.Mã_định_dạng, item.Mã_phim, item.Tên_phim, item.Mã_MH, item.Tên_MH);
                }
            }

            return dt;
        }

        public static bool InsertFormatMovie(string id, string idMovie, string idScreen)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_InsertFormatMovie(id, idMovie, idScreen);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static bool UpdateFormatMovie(string id, string idMovie, string idScreen)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var ddp = (from d in db.DinhDangPhims
                            where d.id.Equals(id)
                            select d).First();

                ddp.idPhim = idMovie;
                ddp.idLoaiManHinh = idScreen;

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

        public static bool DeleteFormatMovie(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var lc = (from l in db.LichChieus
                          where l.idDinhDang.Equals(id)
                          select l).First();

                db.LichChieus.DeleteOnSubmit(lc);

                var ddp = (from d in db.DinhDangPhims
                           where d.id.Equals(id)
                           select d).First();

                db.DinhDangPhims.DeleteOnSubmit(ddp);

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

        public static string getMovieNameByFormatMovieId(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from ddp in db.DinhDangPhims
                            where ddp.id.Equals(id)
                            select ddp).First();

                return query.Phim.TenPhim; 
            }
        }

        public static string getScreenTypeNameByFormatMovieId(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from ddp in db.DinhDangPhims
                             where ddp.id.Equals(id)
                             select ddp).First();

                return query.LoaiManHinh.TenMH;
            }
        }
    }
}
