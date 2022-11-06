using CinemaManagementSystem;
using GUI.frmAdminUserControls.DataUserControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class MovieDAO
    {
        //ảnh -> byte[]
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        //byte[] -> ảnh
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static List<Phim> GetListMovieByDate(DateTime date)
        {
            List<Phim> listMovie = new List<Phim>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            where date <= p.NgayKetThuc
                            select p;

                foreach (var item in query)
                {
                    listMovie.Add(item);
                }
            }

            return listMovie;
        }

        public static List<Phim> GetListPlayingMovieByDate(DateTime date)
        {
            List<Phim> listMovie = new List<Phim>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            where date <= p.NgayKetThuc && date > p.NgayKhoiChieu
                            select p;

                foreach (var item in query)
                {
                    listMovie.Add(item);
                }
            }

            return listMovie;
        }
        public static List<Phim> GetListComingSoonMovieByDate(DateTime date)
        {
            List<Phim> listMovie = new List<Phim>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            where date < p.NgayKhoiChieu
                            select p;

                foreach (var item in query)
                {
                    listMovie.Add(item);
                }
            }

            return listMovie;
        }

        public static List<Phim> GetListMovie()
        {
            List<Phim> listMovie = new List<Phim>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            select p;

                foreach (var item in query)
                {
                    listMovie.Add(item);
                }
            }

            return listMovie;
        }

        public static DataTable GetMovie()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã phim", typeof(string));
            dt.Columns.Add("Tên phim", typeof(string));
            dt.Columns.Add("Mô tả", typeof(string));
            dt.Columns.Add("Thời lượng", typeof(float));
            dt.Columns.Add("Ngày khởi chiếu", typeof(DateTime));
            dt.Columns.Add("Ngày kết thúc", typeof(DateTime));
            dt.Columns.Add("Sản xuất", typeof(string));
            dt.Columns.Add("Đạo diễn", typeof(string));
            dt.Columns.Add("Năm SX", typeof(int));
            dt.Columns.Add("Poster", typeof(Image));


            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_GetMovie();

                foreach (var item in query)
                {
                    dt.Rows.Add(item.Mã_phim, item.Tên_phim, item.Mô_tả, item.Thời_lượng, item.Ngày_khởi_chiếu, item.Ngày_kết_thúc, item.Sản_xuất, item.Đạo_diễn, item.Năm_SX, item.Áp_Phích);
                }
            }

            return dt;
        }

        public static bool InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                Phim p = new Phim
                {
                    id = id,
                    TenPhim = name,
                    MoTa = desc,
                    ThoiLuong = length,
                    NgayKhoiChieu = startDate,
                    NgayKetThuc = endDate,
                    SanXuat = productor,
                    DaoDien = director,
                    NamSX = year,
                    ApPhich = image
                };

                db.Phims.InsertOnSubmit(p);

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

        public static bool UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, int year, byte[] image)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_UpdateMovie(id, name, desc, length, startDate, endDate, productor, director, year, image);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static bool DeleteMovie(string id)
        {
			MovieByGenreDAO.DeleteMovie_GenreByMovieID(id);

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query2 = from ddp in db.DinhDangPhims
                        where ddp.idPhim.Equals(id)
                        select ddp;

                db.DinhDangPhims.DeleteAllOnSubmit(query2);

                var query = from p in db.Phims
                            where p.id.Equals(id)
                            select p;

                db.Phims.DeleteAllOnSubmit(query);

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

        public static Phim GetMovieByID(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            where p.id.Equals(id)
                            select p;

                return query.FirstOrDefault();
            }
        }
    }
}
