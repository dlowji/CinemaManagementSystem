using CinemaManagementSystem.Controllers;
using Microsoft.Office.Interop.Excel;
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
using System.Windows.Forms.VisualStyles;

namespace CinemaManagementSystem
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
            ConfigStyle();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void Chart_Load(object sender, EventArgs e)
        {
        }

        public void DrawChartByDate(DateTime date)
        {
            string[] duration = { "0h - 4h", "4h - 8h", "8h - 12h", "12h - 16h", "16h - 20h", "20h - 24h" };

            for (int j = 0; j < duration.Length; j++)
            {
                chart1.Series["Tiền bán vé"].Points.AddXY(duration[j], RevenueController.GetTotalTicketPriceByDurationOfTime(4*j, 4*j+4, date));
                chart1.Series["Tiền nhập hàng"].Points.AddXY(duration[j], RevenueController.GetTotalImportPriceByDurationOfTime(4 * j, 4 * j + 4, date));
            }
        }

        public void DrawChartByQuarter(DateTime date)
        {
            int year = date.Year;

            string[] duration = { "Quý I", "Quý II", "Quý III", "Quý IV"};

            for (int j = 0; j < duration.Length; j++)
            {
                chart1.Series["Tiền bán vé"].Points.AddXY(duration[j], RevenueController.GetTotalTicketPriceByQuarter(j+1, year));
                chart1.Series["Tiền nhập hàng"].Points.AddXY(duration[j], RevenueController.GetTotalImportPriceByQuarter(j+1, year));
            }
            
        }

        public void DrawChartByYear(DateTime date)
        {
            int year = date.Year;

            string[] duration = { "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12" };

            for (int j = 0; j < duration.Length; j++)
            {
                chart1.Series["Tiền bán vé"].Points.AddXY(duration[j], RevenueController.GetTotalTicketPriceByMonth(j + 1, year));
                chart1.Series["Tiền nhập hàng"].Points.AddXY(duration[j], RevenueController.GetTotalImportPriceByMonth(j + 1, year));
            }
        }

        private void ConfigStyle()
        {
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;

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
