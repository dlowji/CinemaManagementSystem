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
    public class ScreenTypeDAO
    {
        public static List<LoaiManHinh> GetListScreenType()
        {
            List<LoaiManHinh> screenTypeList = new List<LoaiManHinh>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from mh in db.LoaiManHinhs
                            select mh;

                foreach (LoaiManHinh mh in query)
                {
                    screenTypeList.Add(mh);
                }
            }
            return screenTypeList;
        }

        public static DataTable GetScreenType()
        {
            DataTable dt = new DataTable();
            
            dt.Columns.Add("Mã loại màn hình", typeof(string));
            dt.Columns.Add("Tên màn hình", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from mh in db.LoaiManHinhs
                            select mh;

                foreach (LoaiManHinh mh in query)
                {
                    dt.Rows.Add(mh.id, mh.TenMH);                    
                }
            }
            
            return dt;
        }

        public static DataTable GetScreenTypeByFormatFilm(string screenTypeID)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã loại màn hình", typeof(string));
            dt.Columns.Add("Tên màn hình", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from mh in db.LoaiManHinhs
                            where mh.id.Equals(screenTypeID)
                            select mh;

                foreach (var item in query)
                {
                    dt.Rows.Add(item.id, item.TenMH);
                }
            }

            return dt;
        }

        public static bool InsertScreenType(string id, string name)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_InsertScreenType(id, name);
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static bool UpdateScreenType(string id, string name)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var pc = (from mh in db.LoaiManHinhs
                          where mh.id.Equals(id)
                          select mh).First();

                pc.TenMH = name;

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

        public static bool DeleteScreenType(string id)
        {
            CinemaDAO.DeleteCinemaByScreenTypeId(id);

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var filmType = (from ddp in db.DinhDangPhims
                          where ddp.idLoaiManHinh.Equals(id)
                          select ddp).First();

                db.DinhDangPhims.DeleteOnSubmit(filmType);

                var mh = (from m in db.LoaiManHinhs
                         where m.id.Equals(id)
                         select m).First();

                db.LoaiManHinhs.DeleteOnSubmit(mh);

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

        public static LoaiManHinh GetScreenTypeByName(string screenName)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from mh in db.LoaiManHinhs
                            where mh.TenMH.Equals(screenName)
                            select mh;

                return query.FirstOrDefault();
            }
        }
    }
}
