using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
using GUI.frmAdminUserControls.DataUserControl;
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

namespace CinemaManagementSystem.Views.Customer
{
    public partial class PaymentUC : UserControl
    {
        private Phim movie;
        private LichChieu showTimes;
        private Panel homepage;
        private List<Button> selectedSeats;
        private List<Support> selectedProducts;
        private string seats;
        private string workingDirectory;
        private string projectDirectory;
        private decimal totalTicketPrice;
        private decimal totalProductPrice = 0;
        private decimal discount = 0;
        private bool usePoint;
        private decimal point;

        private string customerId;
        public PaymentUC(bool usePoint, decimal point, Phim movie, LichChieu showTimes, string seats, Panel homepage, decimal totalTicketPrice, decimal totalProductPrice, decimal discount, string customerId, List<Button> selectedSeats, List<Support> selectedProducts)
        {
            InitializeComponent();
            this.movie = movie;
            this.showTimes = showTimes;
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            this.seats = seats;
            this.homepage = homepage;
            this.selectedSeats = selectedSeats;
            this.selectedProducts = selectedProducts;
            this.totalTicketPrice = totalTicketPrice;
            this.totalProductPrice = totalProductPrice;
            this.discount = discount;
            this.customerId = customerId;
            this.usePoint = usePoint;
            this.point = point;
        }

        private void PaymentUC_Load(object sender, EventArgs e)
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
            lbTotalPrice.Text = "Tổng cộng: " + Helper.Helper.FormatVNMoney(totalTicketPrice + totalProductPrice - discount);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool result = false;

            if (usePoint)
            {
                result = BillController.Payment(point, selectedSeats, selectedProducts, customerId, null, discount, totalTicketPrice, totalProductPrice, totalTicketPrice + totalProductPrice, true);
            }
            else
            {
                result = BillController.Payment(selectedSeats, selectedProducts, customerId, null, discount, totalTicketPrice, totalProductPrice, totalTicketPrice + totalProductPrice, true);
            }    

            if (result)
            {
                MessageBox.Show("Thanh toán hóa đơn thành công", "Thông báo");
                TicketUC ticketUC = new TicketUC(movie, showTimes, seats, totalTicketPrice + totalProductPrice - discount);
                ticketUC.Dock = DockStyle.Fill;

                homepage.Controls.Clear();
                homepage.Controls.Add(ticketUC);
            }
            else
            {
                MessageBox.Show("Thanh toán hóa đơn thất bại", "Thông báo");
                return;
            }
        }
    }
}
