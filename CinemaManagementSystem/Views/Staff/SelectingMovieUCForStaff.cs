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
            MovieViewUCForStaff movieUc = new MovieViewUCForStaff(pnData, staffId);
            movieUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(movieUc);
        }
    }
}
