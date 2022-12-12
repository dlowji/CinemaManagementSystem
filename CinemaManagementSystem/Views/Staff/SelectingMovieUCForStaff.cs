using GUI;
using System;
using System.Windows.Forms;

namespace CinemaManagementSystem.View.Customer
{
    public partial class SelectingMovieUCForStaff : Form
    {
        private string staffId;

        public SelectingMovieUCForStaff(string staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
        }

        private void btnMovieUC_Click(object sender, EventArgs e)
        {
            pnData.Controls.Clear();
            MovieViewUCForStaff movieUc = new MovieViewUCForStaff(pnData, "");
            movieUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(movieUc);
        }

        private void btnFoodUC_Click(object sender, EventArgs e)
        {
            pnData.Controls.Clear();
            FoodDrinkUCForStaff foodDrinkUc = new FoodDrinkUCForStaff("", null, null, null, Decimal.Zero, pnData);
            foodDrinkUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(foodDrinkUc);
        }
    }
}
