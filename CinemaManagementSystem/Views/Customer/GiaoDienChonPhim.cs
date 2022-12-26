using GUI;
using System;
using System.Windows.Forms;

namespace CinemaManagementSystem.View.Customer
{
    public partial class GiaoDienChonPhim : Form
    {
        private string customerId;

        public GiaoDienChonPhim(string customerId)
        {
            InitializeComponent();
            this.customerId = customerId;
        }

        private void btnMovieUC_Click(object sender, EventArgs e)
        {
            pnData.Controls.Clear();
            MovieViewUC movieUc = new MovieViewUC(pnData, customerId);
            movieUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(movieUc);
        }

        public void test(LichChieu showTimes, Phim movie, string staffId)
        {
            pnData.Controls.Clear();
            OrderSeat orderSeatUC = new OrderSeat(showTimes, movie, customerId, pnData);
            orderSeatUC.Dock = DockStyle.Fill;
            pnData.Controls.Add(orderSeatUC);
        }
    }
}
