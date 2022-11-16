using CinemaManagementSystem;
using GUI.frmAdminUserControls.DataUserControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI.DAO
{
    public class CinemaTypeDAO
    {
        public static List<LoaiRap> GetListCinemaType()
        {
            List<LoaiRap> cinemaTypeList = new List<LoaiRap>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from mh in db.LoaiRaps
                            select mh;

                foreach (LoaiRap lr in query)
                {
                    cinemaTypeList.Add(lr);
                }
            }
            return cinemaTypeList;
        }

        public static List<LoaiRap> GetListCinemaTypeByMovie(string movieId)
        {
            List<LoaiRap> cinemaTypeList = new List<LoaiRap>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from lc in db.LichChieus
                            where lc.idPhim.Equals(movieId)
                            select lc;

                foreach (LichChieu lc in query)
                {
                    if (cinemaTypeList.Contains(lc.Rap.LoaiRap))
                    {
                        continue;
                    }

                    cinemaTypeList.Add(lc.Rap.LoaiRap);
                }
            }
            return cinemaTypeList;
        }

        public static DataTable GetCinemaType()
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Mã loại rạp", typeof(string));
            dt.Columns.Add("Tên loại rạp", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from mh in db.LoaiRaps
                            select mh;

                foreach (LoaiRap lr in query)
                {
                    dt.Rows.Add(lr.id, lr.TenLoaiRap);                    
                }
            }
            
            return dt;
        }

        public static LoaiRap GetCinemaTypeByID(string cinemaTypeId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from loaiRap in db.LoaiRaps
                            where loaiRap.id.Equals(cinemaTypeId)
                            select loaiRap;

                return query.FirstOrDefault();
            }
        }

        public static bool InsertCinemaType(string id, string name)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                LoaiRap loaiRap = new LoaiRap
                {
                    id = id,
                    TenLoaiRap = name
                };

                db.LoaiRaps.InsertOnSubmit(loaiRap);

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

        public static bool UpdateCinemaType(string id, string name)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var loaiRap = (from lr in db.LoaiRaps
                          where lr.id.Equals(id)
                          select lr).First();

                loaiRap.TenLoaiRap = name;

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

        public static bool DeleteCinemaType(string id)
        {
            CinemaDAO.DeleteCinemaByCinemaTypeId(id);

            using (CinemaDataContext db = new CinemaDataContext())
            {

                var loaiRap = (from lr in db.LoaiRaps
                          where lr.id.Equals(id)
                          select lr).First();

                db.LoaiRaps.DeleteOnSubmit(loaiRap);

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

        public static LoaiRap GetScreenTypeByName(string screenName)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from mh in db.LoaiRaps
                            where mh.TenLoaiRap.Equals(screenName)
                            select mh;

                return query.FirstOrDefault();
            }
        }
    }
}
