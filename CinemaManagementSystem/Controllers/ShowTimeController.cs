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

    }
}
