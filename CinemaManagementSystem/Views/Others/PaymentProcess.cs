using CinemaManagementSystem;
using CinemaManagementSystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ticketPayment
{
    public partial class PaymentProcess : Form
    {
        private Phim movie;
        private LichChieu showTimes;
        private string seats;
        private string workingDirectory;
        private string projectDirectory;
        public PaymentProcess(Phim movie, LichChieu showTimes, string seats)
        {
            InitializeComponent();
            this.movie = movie;
            this.showTimes = showTimes;
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            this.seats = seats;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void PaymentProcess_Load(object sender, EventArgs e)
        {
            lbMovieName.Text = movie.TenPhim;
            lbDate.Text = movie.NgayKetThuc.DayOfWeek + ", " + movie.NgayKhoiChieu.ToShortDateString();
            lbTime.Text = showTimes.ThoiGianChieu.ToShortTimeString() + " - "
                + showTimes.ThoiGianChieu.AddMinutes(movie.ThoiLuong).ToShortTimeString();
            pbAvatar.Image = Image.FromFile(projectDirectory + movie.ApPhich);

            Rap cinema = CinemaController.GetCinemaById(showTimes.idRap);
            CumRap cineplex = CinemaController.GetCineplexByCinemaID(showTimes.idRap);

            lbCinema.Text = cinema.TenRap;
            lbCineplex.Text = cineplex.Ten;

            lbSeat.Text += seats;

            KiemDuyetPhim censor = MovieController.GetMovieCensorShipByMovieId(movie.id);
            lbRated.Text = censor.Ten + " - " + censor.MoTa;
        }
    }
}
