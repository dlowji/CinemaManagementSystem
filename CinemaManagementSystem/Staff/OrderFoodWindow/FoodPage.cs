using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEMA_NEW.Staff.OrderFoodWindow
{
    public partial class FoodPage : Form
    {
        public FoodPage()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {   
                Panel pan = new Panel();
                pan.Name = "panel";
                pan.BackColor = Color.Red;
                pan.Width = 250;
                pan.Height = 50;
                Label l = new Label();
                l.Text = "Pepsi khong duong";
                pan.Controls.Add(l);
                flowLayoutPanelFoodList.Controls.Add(pan);
                labelTong.Text += "45000";
        }
    }
}
