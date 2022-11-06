using CinemaManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class MovieByGenreDAO
    {
        public static List<TheLoai> GetListGenreByMovieID(string id)
        {
            List<TheLoai> genreList = new List<TheLoai>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = db.USP_GetListGenreByMovie(id);

                foreach (var item in query)
                {
                    TheLoai tl = new TheLoai();
                    tl.id = item.id;
                    tl.TenTheLoai = item.TenTheLoai;
                    tl.MoTa = item.MoTa;

                    genreList.Add(tl);
                }
            }

            return genreList;
        }

        public static void InsertMovie_Genre(string movieID, List<TheLoai> genreList)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                foreach (TheLoai item in genreList)
                {
                    PhanLoaiPhim plp = new PhanLoaiPhim
                    {
                        idPhim = movieID,
                        idTheLoai = item.id,
                    };

                    db.PhanLoaiPhims.InsertOnSubmit(plp);
                }

                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void UpdateMovie_Genre(string movieID, List<TheLoai> genreList)
        //Idea : Delete all rows that contain movieID, then re-add all genre that have been chosen from CheckedListBox to 'PhanLoaiPhim' with movieID
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from plp in db.PhanLoaiPhims
                            where plp.idPhim.Equals(movieID)
                            select plp;

                db.PhanLoaiPhims.DeleteAllOnSubmit(query);

                foreach (TheLoai item in genreList)
                {
                    PhanLoaiPhim plp = new PhanLoaiPhim
                    {
                        idPhim = movieID,
                        idTheLoai = item.id,
                    };

                    db.PhanLoaiPhims.InsertOnSubmit(plp);
                }

                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void DeleteMovie_GenreByMovieID(string movieID)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var plp = (from p in db.PhanLoaiPhims
                           where p.idPhim.Equals(movieID)
                           select p);

                db.PhanLoaiPhims.DeleteAllOnSubmit(plp);

                //ask the datacontext to save all the changes
                try
                {
                    db.SubmitChanges();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
