using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem.Controllers
{
    public class MovieController
    {
        public static List<Phim> GetMovies()
        {
            return MovieDAO.GetListMovie();
        }

        public static List<Phim> FindAll(DateTime dateTime)
        {
            List<Phim> movies = new List<Phim>();

            foreach (var item in MovieDAO.GetListMovie())
            {
                if (DateTime.Compare(item.NgayKhoiChieu, dateTime) <= 0 && DateTime.Compare(dateTime, item.NgayKetThuc) <= 0)
                {
                    movies.Add(item);
                }
            }

            return movies;
        }

        public static Phim FindById(string movieId)
        {
            return MovieDAO.GetMovieByID(movieId);
        }

        public static Phim GetMovieByShowTime(string showTimeId)
        {
            LichChieu showTime = ShowTimeController.GetShowTimeById(showTimeId);
            if (showTime == null)
            {
                return null;
            }

            Phim movie = MovieDAO.GetMovieByID(showTime.idPhim);

            return movie;
        }

        public static List<Phim> FindByGenre(string genreId, DateTime dateTime)
        {
            if (genreId.Equals("TL00"))
            {
                return FindAll(dateTime);
            }

            TheLoai genre = new TheLoai();
            List<Phim> movies = new List<Phim>();
            List<PhanLoaiPhim> movies_genres = MovieByGenreDAO.GetMovieGenres();

            foreach (var item in GenreDAO.GetListGenre())
            {
                if (item.id.Equals(genreId))
                {
                    genre = item;
                    break;
                }
            }

            foreach (var item in movies_genres)
            {
                if (item.idTheLoai.Equals(genre.id))
                {
                    Phim movie = FindById(item.idPhim);

                    if (DateTime.Compare(movie.NgayKhoiChieu, dateTime) <= 0 && DateTime.Compare(dateTime, movie.NgayKetThuc) <= 0)
                    {
                        movies.Add(movie);
                    }
                }
            }

            return movies;
        }

        public static List<Phim> FindByGenre(string movieName, string genreId, DateTime dateTime)
        {
            if (genreId.Equals("TL00"))
            {
                List<Phim> searchMovies = new List<Phim>();
                foreach (var item in MovieController.FindAll(dateTime))
                {

                    if (item.TenPhim.Contains(movieName))
                    {
                        searchMovies.Add(item);
                    }
                }

                return searchMovies;
            }
            
            TheLoai genre = new TheLoai();
            List<Phim> movies = new List<Phim>();
            List<PhanLoaiPhim> movies_genres = MovieByGenreDAO.GetMovieGenres();

            foreach (var item in GenreDAO.GetListGenre())
            {
                if (item.id.Equals(genreId))
                {
                    genre = item;
                    break;
                }
            }

            foreach (var item in movies_genres)
            {
                if (item.idTheLoai.Equals(genre.id))
                {
                    Phim movie = FindById(item.idPhim);

                    if (DateTime.Compare(movie.NgayKhoiChieu, dateTime) <= 0 && DateTime.Compare(dateTime, movie.NgayKetThuc) <= 0)
                    {
                        if (movie.TenPhim.Contains(movieName))
                        {
                            movies.Add(movie);
                        }
                    }
                }
            }

            return movies;
        }

        public static DataTable GetMovie()
        {
            return MovieDAO.GetMovie();
        }

        public static List<KiemDuyetPhim> GetListCensorShip()
        {
            return MovieDAO.GetCensorShipList();
        }

        public static KiemDuyetPhim GetMovieCensorShipByMovieId(string movieId)
        {
            return MovieDAO.GetCensorShipByMovieId(movieId);
        }

        public static bool InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, string actors, int year, string imagePath, string idKiemDuyetPhim)
        {
            return MovieDAO.InsertMovie(id, name, desc, length, startDate, endDate, productor, director, actors, year, imagePath, idKiemDuyetPhim);
        }

        public static bool UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, string actors, int year,string imagePath, string idKiemDuyetPhim)
        {
            return MovieDAO.UpdateMovie(id, name, desc, length, startDate, endDate, productor, director, actors, year, imagePath, idKiemDuyetPhim);
        }

        public static bool DeleteMovie(string id)
        {
            MovieByGenreDAO.DeleteMovie_GenreByMovieID(id);
            return MovieDAO.DeleteMovie(id);
        }
    }
}
