using GUI;
using System;
using System.Windows.Forms;

namespace CinemaManagementSystem.View.Customer
{
    public partial class GiaoDienChonPhim : Form
    {
        private string staffId;

        public GiaoDienChonPhim(string staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
        }

        private void flp_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;
            Phim movie = flp.Tag as Phim;
            frmSeller frm = new frmSeller(staffId, movie);
            frm.Show();

        }
        private void btnMovieUC_Click(object sender, EventArgs e)
        {
            pnData.Controls.Clear();
            MovieViewUC movieUc = new MovieViewUC("");
            movieUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(movieUc);
        }

        private void btnFoodUC_Click(object sender, EventArgs e)
        {
            pnData.Controls.Clear();
            FoodDrinkUC foodDrinkUc = new FoodDrinkUC();
            foodDrinkUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(foodDrinkUc);
        }
    }
}
