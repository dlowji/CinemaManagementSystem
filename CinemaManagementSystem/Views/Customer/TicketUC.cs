using CinemaManagementSystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem.Views.Customer
{
    public partial class TicketUC : UserControl
    {
        private Phim movie;
        private LichChieu showTimes;
        private string seats;
        private string workingDirectory;
        private string projectDirectory;
        private decimal totalPrice;
        public TicketUC(Phim movie, LichChieu showTimes, string seats, decimal totalPrice)
        {
            InitializeComponent();
            this.movie = movie;
            this.showTimes = showTimes;
            this.seats = seats;
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            this.totalPrice = totalPrice;
        }

        private void TicketUC_Load(object sender, EventArgs e)
        {
            lbMovieName.Text = movie.TenPhim;
            lbDateTime.Text = showTimes.ThoiGianChieu.DayOfWeek + ", " + showTimes.ThoiGianChieu.ToShortDateString();
            lbTime.Text = showTimes.ThoiGianChieu.ToShortTimeString() + " - "
                + showTimes.ThoiGianChieu.AddMinutes(movie.ThoiLuong).ToShortTimeString();

            Rap cinema = CinemaController.GetCinemaById(showTimes.idRap);
            CumRap cineplex = CinemaController.GetCineplexByCinemaID(showTimes.idRap);

            lbCinema.Text = cinema.TenRap;
            lbCineplex.Text = cineplex.Ten;

            lbSeats.Text = seats;
            lbPrice.Text = Helper.Helper.FormatVNMoney(totalPrice);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();
            printDocument1.Print();
        }

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            try
            {
                memoryImage = new Bitmap(1048, 578, PixelFormat.Format32bppArgb);

                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                Graphics captureGraphics = Graphics.FromImage(memoryImage);

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, -295, -83, captureRectangle.Size);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }
    }
}
