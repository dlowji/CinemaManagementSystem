using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class MovieController
    {
        public static List<Phim> findAll()
        {
            return MovieDAO.GetListMovie();
        }

        public static DataTable GetMovie()
        {
            return MovieDAO.GetMovie();
        }

        public static List<KiemDuyetPhim> GetListCensorShip()
        {
            return MovieDAO.GetCensorShipList();
        }

        public static bool InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, string actors, int year, byte[] image, string idKiemDuyetPhim)
        {
            return MovieDAO.InsertMovie(id, name, desc, length, startDate, endDate, productor, director, actors, year, image, idKiemDuyetPhim);
        }

        public static bool UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, string actors, int year, byte[] image, string idKiemDuyetPhim)
        {
            return MovieDAO.UpdateMovie(id, name, desc, length, startDate, endDate, productor, director, actors, year, image, idKiemDuyetPhim);
        }

        public static bool DeleteMovie(string id)
        {
            return MovieDAO.DeleteMovie(id);
        }
    }
}
