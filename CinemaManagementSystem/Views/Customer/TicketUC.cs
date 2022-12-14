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
        public TicketUC(Phim movie, LichChieu showTimes, string seats)
        {
            InitializeComponent();
            this.movie = movie;
            this.showTimes = showTimes;
            this.seats = seats;
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureScreen();
        }

        private void CaptureScreen()
        {
            try
            {
                Bitmap captureBitmap = new Bitmap(1048, 578, PixelFormat.Format32bppArgb);

                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;

                Graphics captureGraphics = Graphics.FromImage(captureBitmap);

                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, -245, -83, captureRectangle.Size);

                captureBitmap.Save(@"D:\ticket.png", ImageFormat.Png);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
