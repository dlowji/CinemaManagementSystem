using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class GenreController
    {
        public static DataTable GetDataTableGenre()
        {
            DataTable genres = GenreDAO.GetDataTableGenre();
            
            return genres;
        }

        public static List<TheLoai> GetListGenreByMovieId(string movieId)
        {
            return MovieByGenreDAO.GetListGenreByMovieID(movieId);
        }

        public static bool InsertGenre(string id, string name, string desc)
        {
            return GenreDAO.InsertGenre(id, name, desc);
        }

        public static bool UpdateGenre(string id, string name, string desc)
        {
            return GenreDAO.UpdateGenre(id, name, desc);
        }

        public static bool DeleteGenre(string id)
        {
            return GenreDAO.DeleteGenre(id);
        }
    }
}
