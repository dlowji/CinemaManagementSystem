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
using System.Windows.Forms.DataVisualization.Charting;
using ComboBox = System.Windows.Forms.ComboBox;

namespace CinemaManagementSystem.Controllers
{
    public class RevenueController
    {
        public static void LoadMovieIntoComboBox(ComboBox cbb)
        {
            cbb.DataSource = MovieController.GetMovies();
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

        public static decimal GetTotalTicketPriceByDurationOfTime(int fromHour, int toHour, DateTime date)
        {
            decimal totalPrice = 0;

            TimeSpan ts = new TimeSpan(fromHour, 0, 0);
            TimeSpan timeSpan = new TimeSpan(toHour - 1, 59, 59);

            DateTime start = date.Date + ts;
            DateTime end = date.Date + timeSpan;

            List<HoaDon> receipts = ReceiptDAO.GetTicketReceipts();

            foreach (HoaDon receipt in receipts)
            {
                if (DateTime.Compare(receipt.CreatedAt, start) >= 0 && DateTime.Compare(receipt.CreatedAt, end) <= 0)
                {
                    totalPrice += (receipt.TongTien);
                }
            }

            return totalPrice;
        }

        public static decimal GetTotalImportPriceByDurationOfTime(int fromHour, int toHour, DateTime date)
        {
            decimal totalPrice = 0;

            TimeSpan ts = new TimeSpan(fromHour, 0, 0);
            TimeSpan timeSpan = new TimeSpan(toHour - 1, 59, 59);

            DateTime start = date.Date + ts;
            DateTime end = date.Date + timeSpan;

            List<HoaDonNhapHang> receipts = ReceiptDAO.GetImportReceipts();

            foreach (HoaDonNhapHang receipt in receipts)
            {
                if (DateTime.Compare(receipt.CreatedAt, start) >= 0 && DateTime.Compare(receipt.CreatedAt, end) <= 0)
                {
                    totalPrice += (decimal)receipt.TongTien;
                }
            }

            return totalPrice;
        }

        public static decimal GetTotalTicketPriceByQuarter(int quarter, int year)
        {
            decimal totalPrice = 0;

            List<HoaDon> receipts = ReceiptDAO.GetTicketReceipts();

            foreach (HoaDon receipt in receipts)
            {
                if(Helper.Helper.GetQuarter(receipt.CreatedAt) == quarter && receipt.CreatedAt.Year == year)
                {
                    totalPrice += receipt.TongTien;
                }
            }

            return totalPrice;
        }

        public static decimal GetTotalImportPriceByQuarter(int quarter, int year)
        {
            decimal totalPrice = 0;

            List<HoaDonNhapHang> receipts = ReceiptDAO.GetImportReceipts();

            foreach (HoaDonNhapHang receipt in receipts)
            {
                if (Helper.Helper.GetQuarter(receipt.CreatedAt) == quarter && receipt.CreatedAt.Year == year)
                {
                    totalPrice += (decimal)receipt.TongTien;
                }
            }

            return totalPrice;
        }

        public static decimal GetTotalTicketPriceByMonth(int month, int year)
        {
            decimal totalPrice = 0;

            List<HoaDon> receipts = ReceiptDAO.GetTicketReceipts();

            foreach (HoaDon receipt in receipts)
            {
                if (receipt.CreatedAt.Month == month && receipt.CreatedAt.Year == year)
                {
                    totalPrice += receipt.TongTien;
                }
            }

            return totalPrice;
        }

        public static decimal GetTotalImportPriceByMonth(int month, int year)
        {
            decimal totalPrice = 0;

            List<HoaDonNhapHang> receipts = ReceiptDAO.GetImportReceipts();

            foreach (HoaDonNhapHang receipt in receipts)
            {
                if (receipt.CreatedAt.Month == month && receipt.CreatedAt.Year == year)
                {
                    totalPrice += (decimal)receipt.TongTien;
                }
            }

            return totalPrice;
        }
    }
}
