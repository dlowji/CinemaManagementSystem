using CinemaManagementSystem.Controllers;
using GUI.DAO;
using GUI.frmAdminUserControls.DataUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem.View.Customer
{
    public partial class OrderSeatUCForStaff : UserControl
    {
        private Panel homepage;

        string staffId;
        int SIZE = 30;//Size của ghế
        int GAP = 7;//Khoảng cách giữa các ghế

        List<Ve> listSeat = new List<Ve>();

        //dùng lưu vết các Ghế đang chọn
        List<Button> listSeatSelected = new List<Button>();

        decimal displayPrice = 0;//Hiện thị giá vé
        decimal ticketPrice = 0;//Lưu giá vé gốc
        decimal total = 0;//Tổng giá tiền
        decimal discount = 0;//Tiền được giảm
        decimal payment = 0;//Tiền phải trả
        int plusPoint = 0;//Số điểm tích lũy khi mua vé

        LichChieu Times;
        Phim Movie;
        public OrderSeatUCForStaff(LichChieu showTimes, Phim movie, string staffId, Panel homepage)
        {
            InitializeComponent();
            Times = ShowTimeController.GetShowTimeById(showTimes.id);
            Movie = movie;
            this.staffId = staffId;
            this.homepage = homepage;
        }
        private void LoadDataCinema(string cinemaName)
        {
            Rap cinema = CinemaDAO.GetCinemaByName(cinemaName);
            int Row = cinema.SoHangGhe;
            int Column = cinema.SoGheMotHang;
            flpSeat.Size = new Size((SIZE + 20 + GAP) * Column, (SIZE + GAP) * Row);
        }

        private void LoadBill()
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            //Đổi culture vùng quốc gia để đổi đơn vị tiền tệ 

            //Thread.CurrentThread.CurrentCulture = culture;
            //dùng thread để chuyển cả luồng đang chạy về vùng quốc gia đó

            //lblTicketPrice.Text = displayPrice.ToString("c", culture);
            //lblTotal.Text = total.ToString("c", culture);
            //lblDiscount.Text = discount.ToString("c", culture);
            //lblPayment.Text = payment.ToString("c", culture);

            //Đổi đơn vị tiền tệ
            //gán culture chỗ này thì chỉ có chỗ này sd culture này còn
            //lại sài mặc định
        }

        private void LoadSeats(List<Ve> list)
        {
            flpSeat.Controls.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Button btnSeat = new Button() { Width = SIZE + 20, Height = SIZE };
                btnSeat.Text = TicketDAO.getSeatNameByTicketId(list[i].id);
                if (list[i].TrangThai == 1)
                    btnSeat.BackColor = Color.Red;
                else
                    btnSeat.BackColor = Color.White;
                btnSeat.Click += BtnSeat_Click;
                flpSeat.Controls.Add(btnSeat);

                btnSeat.Tag = list[i];
            }
        }

        private void BtnSeat_Click(object sender, EventArgs e)
        {
            Button btnSeat = sender as Button;
            if (btnSeat.BackColor == Color.White)
            {
                //grpLoaiVe.Enabled = true;
                //rdoAdult.Checked = true;

                btnSeat.BackColor = Color.Yellow;
                Ve ticket = btnSeat.Tag as Ve;

                ticket.TienBanVe = ticketPrice;
                displayPrice = (decimal)ticket.TienBanVe;
                total += ticketPrice;
                payment = total - discount;
                ticket.LoaiVe = 1;

                listSeatSelected.Add(btnSeat);
                plusPoint++;
                //lblPlusPoint.Text = plusPoint + "";
            }
            else if (btnSeat.BackColor == Color.Yellow)
            {
                btnSeat.BackColor = Color.White;
                Ve ticket = btnSeat.Tag as Ve;

                total -= (decimal)ticket.TienBanVe;
                payment = total - discount;
                ticket.TienBanVe = 0;
                displayPrice = (decimal)ticket.TienBanVe;
                ticket.LoaiVe = 0;

                listSeatSelected.Remove(btnSeat);
                plusPoint--;
                //lblPlusPoint.Text = plusPoint + "";
                //grpLoaiVe.Enabled = false;
            }
            else if (btnSeat.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế số [" + btnSeat.Text + "] đã có người mua");
            }
            LoadBill();
            if (listSeatSelected.Count > 0)
            {
                //chkCustomer.Enabled = true;
            }
            else
            {
                //chkCustomer.Enabled = false;
            }
        }

        //dùng để ẩn hiện lable điểm tích lũy của khách hàng thành viên
        private void ShowOrHideLablePoint()
        {
            //if (chkCustomer.Checked == true)
            //{
            //    pnCustomer.Visible = true;
            //}
            //else
            //{
            //    pnCustomer.Visible = false;
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn hủy tất cả những vé đã chọn ko?",
                "Hủy Mua Vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            foreach (Button btn in listSeatSelected)
            {
                btn.BackColor = Color.White;
            }
            RestoreDefault();
            this.OnLoad(new EventArgs());
        }

        private void RestoreDefault()
        {
            listSeatSelected.Clear();

            //rdoAdult.Checked = true;
            //grpLoaiVe.Enabled = false;
            //chkCustomer.Checked = false;
            //chkCustomer.Enabled = false;

            ShowOrHideLablePoint();

            total = 0;
            displayPrice = 0;
            discount = 0;
            payment = 0;
            plusPoint = 0;

            LoadBill();
        }

        private void OrderSeat_Load(object sender, EventArgs e)
        {
            ticketPrice = Times.GiaVe;
            CumRap cineplex = CinemaController.GetCineplexByCinemaID(Times.idRap);

            lblInformation.Text = cineplex.Ten + " | " + TicketDAO.getCinemaNameByShowTimesId(Times.id) + " | " + TicketDAO.getMovieNameByShowTimesId(Times.id);
            lblTime.Text = Times.ThoiGianChieu.ToShortDateString() + " | "
                + Times.ThoiGianChieu.ToShortTimeString() + " - "
                + Times.ThoiGianChieu.AddMinutes(Movie.ThoiLuong).ToShortTimeString();
            if (Movie.ApPhich != null)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                picFilm.Image = Image.FromFile(projectDirectory + Movie.ApPhich);
            }

            //rdoAdult.Checked = true;
            //chkCustomer.Enabled = false;
            //grpLoaiVe.Enabled = false;

            LoadDataCinema(TicketDAO.getCinemaNameByShowTimesId(Times.id));

            ShowOrHideLablePoint();

            listSeat = TicketDAO.GetListTicketsByShowTimes(Times.id);

            LoadSeats(listSeat);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            FoodDrinkUCForStaff foodDrinkUC = new FoodDrinkUCForStaff(staffId, listSeatSelected, Times, Movie, total, homepage);
            foodDrinkUC.Dock = DockStyle.Fill;

            homepage.Controls.Clear();
            homepage.Controls.Add(foodDrinkUC);
        }
    }
}
