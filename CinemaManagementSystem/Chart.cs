using CinemaManagementSystem.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CinemaManagementSystem
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Chart_Load(object sender, EventArgs e)
        {
            fillChart();
        }

        private void fillChart()
        {
            chart1.DataSource = RevenueController.Test();
            chart1.Series["TotalPrice"].XValueMember = "Month";
            chart1.Series["TotalPrice"].YValueMembers = "Total Price";

            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Month";
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.LightBlue;

            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Revenue";
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LightGray;

            chart1.ChartAreas["ChartArea1"].BackColor = Color.AntiqueWhite;
            chart1.ChartAreas["ChartArea1"].BackSecondaryColor = Color.White;
            chart1.ChartAreas["ChartArea1"].BackGradientStyle = GradientStyle.HorizontalCenter;
            chart1.ChartAreas["ChartArea1"].BorderColor = Color.Blue;
            chart1.ChartAreas["ChartArea1"].BorderDashStyle = ChartDashStyle.Solid;
            chart1.ChartAreas["ChartArea1"].BorderWidth = 1;
        }
    }
}
