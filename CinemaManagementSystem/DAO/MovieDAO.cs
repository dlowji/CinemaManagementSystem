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
            dt.Columns.Add("Diễn viên", typeof(string));
            dt.Columns.Add("Năm SX", typeof(int));
            dt.Columns.Add("Poster", typeof(Image));
            dt.Columns.Add("Kiểm duyệt", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from phim in db.Phims
                            join kdp in db.KiemDuyetPhims
                            on phim.idKiemDuyetPhim equals kdp.id
                            select new
                            {
                                phim,
                            };

                foreach (var item in query)
                {
                    Phim phim = item.phim;
                    Image obj = null;
                    string workingDirectory = Environment.CurrentDirectory;
                    string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                    if (phim.ApPhich != null)
                    {
                        obj = Image.FromFile(projectDirectory + phim.ApPhich);
                    }
                  
                    dt.Rows.Add(phim.id, phim.TenPhim, phim.MoTa, phim.ThoiLuong, phim.NgayKhoiChieu, phim.NgayKetThuc, phim.SanXuat, phim.DaoDien, phim.DienVien, phim.NamSX, obj, phim.KiemDuyetPhim.Ten);
                }
            }

            return dt;
        }

        public static bool InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, string actors, int year, string imagePath, string idKiemDuyetPhim)
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
                    DienVien = actors,
                    NamSX = year,
                    ApPhich = imagePath,
                    idKiemDuyetPhim = idKiemDuyetPhim
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

        public static bool UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, string actors, int year, string imagePath, string idKiemDuyetPhim)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var phim = (from p in db.Phims
                           where p.id.Equals(id)
                           select p).First();

                phim.TenPhim = name;
                phim.MoTa = desc;
                phim.ThoiLuong = length;
                phim.NgayKhoiChieu = startDate;
                phim.NgayKetThuc = endDate;
                phim.SanXuat = productor;
                phim.DaoDien = director;
                phim.DienVien = actors;
                phim.NamSX = year;
                phim.ApPhich = imagePath;
                phim.idKiemDuyetPhim = idKiemDuyetPhim;

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

        public static bool DeleteMovie(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
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

        public static List<KiemDuyetPhim> GetCensorShipList()
        {
            List<KiemDuyetPhim> list = new List<KiemDuyetPhim> ();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from kdp in db.KiemDuyetPhims
                            select kdp;

                foreach (var item in query)
                {
                    list.Add(item);
                }
            }

            return list; 
        }

        public static KiemDuyetPhim GetCensorShipByMovieId(string movieId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from phim in db.Phims
                            where phim.id.Equals(movieId)
                            select phim).First();

                return query.KiemDuyetPhim;
            }

        }
    }
}
