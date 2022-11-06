using CinemaManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class GenreDAO
    {
        public static List<TheLoai> GetListGenre()
        {
            List<TheLoai> genreList = new List<TheLoai>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from tl in db.TheLoais
                            select tl;

                foreach (var item in query)
                {
                    genreList.Add(item);
                }
            }

            return genreList;
        }

        public static DataTable GetGenre()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã thể loại", typeof(string));
            dt.Columns.Add("Tên thể loại", typeof(string));
            dt.Columns.Add("Mô tả", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from tl in db.TheLoais
                            select tl;

                foreach (var item in query)
                {
                    dt.Rows.Add(item.id, item.TenTheLoai, item.MoTa);
                }
            }

            return dt;
        }

        public static bool InsertGenre(string id, string name, string desc)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_InsertGenre(id, name, desc);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static bool UpdateGenre(string id, string name, string desc)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var tl = (from t in db.TheLoais
                           where t.id.Equals(id)
                           select t).First();

                tl.TenTheLoai = name;
                tl.MoTa = desc;

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

        public static bool DeleteGenre(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var plp = (from p in db.PhanLoaiPhims
                          where p.idTheLoai.Equals(id)
                          select p).First();

                db.PhanLoaiPhims.DeleteOnSubmit(plp);

                var tl = (from t in db.TheLoais
                           where t.id.Equals(id)
                           select t).First();

                db.TheLoais.DeleteOnSubmit(tl);

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
    }
}
