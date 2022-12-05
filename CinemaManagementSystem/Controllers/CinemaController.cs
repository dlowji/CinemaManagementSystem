using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class CinemaController
    {
        public static DataTable GetListCinema()
        {
            DataTable cinemas = CinemaDAO.GetListCinema();

            return cinemas;
        }

        public static Rap GetCinemaById(string cinemaID)
        {
            return CinemaDAO.GetCinemaByID(cinemaID);
        }

        public static List<LoaiRap> GetListCinemaTypeByMovie(string movieId)
        {
            return CinemaTypeDAO.GetListCinemaTypeByMovie(movieId); 
        }

        public static LoaiRap GetCinemaTypeByID(string cinemaTypeId)
        {
            return CinemaTypeDAO.GetCinemaTypeByID(cinemaTypeId);
        }

        public static List<LoaiRap> GetListCinemaType()
        {
            return CinemaTypeDAO.GetListCinemaType();
        }

        public static LoaiRap GetCinemaTypeByCinemaID(string cinemaId)
        {
            return CinemaDAO.GetCinemaTypeByCinemaID(cinemaId);
        }

        public static CumRap GetCineplexByCinemaID(string cinemaId)
        {
            return CinemaDAO.GetCineplexByCinemaID(cinemaId);
        }

        public static List<CumRap> GetListCineplex()
        {
            return CineplexDAO.GetListCineplex();
        }

        public static List<CumRap> GetListCineplexByCinemaTypeID(string cinemaTypeId, string movieId, DateTime date)
        {
            return CineplexDAO.GetListCineplexByCinemaTypeID(cinemaTypeId, movieId, date);
        }

        public static DataTable GetCinemaTypeDataTable()
        {
            return CinemaTypeDAO.GetCinemaType();
        }

        public static bool InsertCinema(string id, string tenRap, int soChoNgoi, int tinhTrang, int soHangGhe, int soGheMotHang, string idLoaiRap, string idCumRap)
        {
            return CinemaDAO.InsertCinema(id, tenRap, soChoNgoi, tinhTrang, soHangGhe, soGheMotHang, idLoaiRap, idCumRap);
        }

        public static bool UpdateCinema(string id, string tenRap, int soChoNgoi, int tinhTrang, int soHangGhe, int soGheMotHang, string idLoaiRap, string idCumRap)
        {
            return CinemaDAO.UpdateCinema(id, tenRap, soChoNgoi, tinhTrang, soHangGhe, soGheMotHang, idLoaiRap, idCumRap);
        }

        public static bool DeleteCinema(string id)
        {
            return CinemaDAO.DeleteCinema(id);
        }

        public static bool InsertCinemaType(string id, string name)
        {
            return CinemaTypeDAO.InsertCinemaType(id, name);
        }

        public static bool UpdateCinemaType(string id, string name)
        {
            return CinemaTypeDAO.UpdateCinemaType(id, name);
        }

        public static bool DeleteCinemaType(string id)
        {
            return CinemaTypeDAO.DeleteCinemaType(id);
        }
    }
}
