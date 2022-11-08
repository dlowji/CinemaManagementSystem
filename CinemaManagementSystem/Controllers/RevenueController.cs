using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;

namespace CinemaManagementSystem.Controllers
{
    public class RevenueController
    {
        public static void LoadMovieIntoComboBox(ComboBox cbb)
        {
            cbb.DataSource = MovieController.findAll();
            cbb.DisplayMember = "TenPhim";
            cbb.ValueMember = "ID";
        }

        public static DataTable GetRevenue(string idMovie, DateTime fromDate, DateTime toDate)
        {
            return RevenueDAO.GetRevenue(idMovie, fromDate, toDate);
        }

        public static decimal GetTotalRevenue(DataGridView dtgvRevenue)
        {
            decimal sum = 0;

            foreach (DataGridViewRow row in dtgvRevenue.Rows)
            {
                sum += Convert.ToDecimal(row.Cells["Tiền bán vé"].Value);
            }

            return sum;
        }
    }
}
