using GUI.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
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

        public static decimal GetTotalTicketPriceByMonth(int month)
        {
            decimal totalPrice = 0;

            List<HoaDon> receipts = ReceiptDAO.GetTicketReceipts();

            foreach (HoaDon receipt in receipts)
            {
                if (receipt.CreatedAt.Month == month)
                {
                    totalPrice += receipt.TongTien;
                }
            }

            return totalPrice;
        }

        public static DataTable Test()
        {
            int month = 12;

            DataTable dt = new DataTable();
            dt.Columns.Add("Month", typeof(string));
            dt.Columns.Add("Total Price", typeof(decimal));

            for (int i = 1; i <= month; i++)
            {
                string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i);
                //decimal totalPrice = GetTotalTicketPriceByMonth(i);

                //string monthName = "Month" + i.ToString();
                decimal totalPrice = i * 2;

                dt.Rows.Add(monthName, totalPrice);
            }

            return dt;
        }
    }
}
