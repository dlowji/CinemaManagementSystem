using CINEMA_NEW.Staff.OrderFoodWindow;
using CINEMA_NEW.Staff.ShowtimePage;
using CINEMA_NEW.Staff.TroubleWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEMA_NEW.Staff
{
    public partial class MainStaffWindow : Form
    {
        public MainStaffWindow()
        {
            InitializeComponent();
        }

        private void panelPhimdangchieu_Click(object sender, EventArgs e)
        {
            ShowtimePage.ShowtimePage formShowTimePage = new ShowtimePage.ShowtimePage();
            formShowTimePage.ShowDialog();
        }

        private void panelDoan_Click(object sender, EventArgs e)
        {
            FoodPage f = new FoodPage();
            f.Show();
        }

        private void panelBaocaosuco_Click(object sender, EventArgs e)
        {
            TroublePage f = new TroublePage();
            f.Show();
        }
    }
}
