using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class ShowTimeController
    {
        public static DataTable GetListShowTimes()
        {
            return ShowTimesDAO.GetListShowtime();
        }

        public static LichChieu GetShowTimeById(string showTimesId)
        {
            List<LichChieu> showTimesList = ShowTimesDAO.GetAllListShowTimes();

            foreach (var item in showTimesList)
            {
                if (item.id.Equals(showTimesId))
                {
                    return item;
                }
            }

            return null;
        }

        public static bool InsertShowTime(string id, string cinemaId, string movieId, decimal ticketPrice, DateTime time)
        {
            return ShowTimesDAO.InsertShowtime(id, cinemaId, movieId, time, ticketPrice);
        }

        public static bool UpdateShowTime(string id, string cinemaId, string movieId, decimal ticketPrice, DateTime time)
        {
            return ShowTimesDAO.UpdateShowtime(id, cinemaId, movieId, time, ticketPrice);
        }

        public static bool DeleteShowTime(string id)
        {
            return ShowTimesDAO.DeleteShowtime(id);
        }

    }
}
