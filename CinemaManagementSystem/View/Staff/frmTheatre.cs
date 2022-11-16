using CinemaManagementSystem;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;//thư viện thay đổi vùng/quốc gia
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTheatre : Form
    {
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

        KhachHang customer;//lưu lại khách hàng thành viên

        LichChieu Times;
        Phim Movie;

        public frmTheatre(LichChieu showTimes, Phim movie, string staffId)
        {
            InitializeComponent();

            Times = showTimes;
            Movie = movie;
            this.staffId = staffId;
        }

        private void frmTheatre_Load(object sender, EventArgs e)
        {
            ticketPrice = Times.GiaVe;

            lblInformation.Text = "CGV Hung Vuong | " + TicketDAO.getCinemaNameByShowTimesId(Times.id) + " | " + TicketDAO.getMovieNameByShowTimesId(Times.id);
            lblTime.Text = Times.ThoiGianChieu.ToShortDateString() + " | "
                + Times.ThoiGianChieu.ToShortTimeString() + " - "
                + Times.ThoiGianChieu.AddMinutes(Movie.ThoiLuong).ToShortTimeString();
            if (Movie.ApPhich != null)
            {
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
                picFilm.Image = Image.FromFile("");
            }

            rdoAdult.Checked = true;
            chkCustomer.Enabled = false;
            grpLoaiVe.Enabled = false;

            LoadDataCinema(TicketDAO.getCinemaNameByShowTimesId(Times.id));

            ShowOrHideLablePoint();

            listSeat = TicketDAO.GetListTicketsByShowTimes(Times.id);

            LoadSeats(listSeat);
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

            lblTicketPrice.Text = displayPrice.ToString("c", culture);
            lblTotal.Text = total.ToString("c", culture);
            lblDiscount.Text = discount.ToString("c", culture);
            lblPayment.Text = payment.ToString("c", culture);

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
                grpLoaiVe.Enabled = true;
                rdoAdult.Checked = true;

                btnSeat.BackColor = Color.Yellow;
                Ve ticket = btnSeat.Tag as Ve;

                ticket.TienBanVe = ticketPrice;
                displayPrice = (decimal)ticket.TienBanVe;
                total += ticketPrice;
                payment = total - discount;
                ticket.LoaiVe = 1;

                listSeatSelected.Add(btnSeat);
                plusPoint++;
                lblPlusPoint.Text = plusPoint + "";
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
                lblPlusPoint.Text = plusPoint + "";
                grpLoaiVe.Enabled = false;
            }
            else if (btnSeat.BackColor == Color.Red)
            {
                MessageBox.Show("Ghế số [" + btnSeat.Text + "] đã có người mua");
            }
            LoadBill();
            if (listSeatSelected.Count > 0)
            {
                chkCustomer.Enabled = true;
            }
            else
            {
                chkCustomer.Enabled = false;
            }
        }

        //dùng để ẩn hiện lable điểm tích lũy của khách hàng thành viên
        private void ShowOrHideLablePoint()
        {
            if (chkCustomer.Checked == true)
            {
                pnCustomer.Visible = true;
            }
            else
            {
                pnCustomer.Visible = false;
            }
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

            rdoAdult.Checked = true;
            grpLoaiVe.Enabled = false;
            chkCustomer.Checked = false;
            chkCustomer.Enabled = false;

            ShowOrHideLablePoint();

            total = 0;
            displayPrice = 0;
            discount = 0;
            payment = 0;
            plusPoint = 0;

            LoadBill();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (listSeatSelected.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn vé trước khi thanh toán!");
                return;
            }
            string message = "Bạn có chắc chắn mua những vé: \n";
            foreach (Button btn in listSeatSelected)
            {
                message += "[" + btn.Text + "] ";
            }
            message += "\nKhông?";
            DialogResult result = MessageBox.Show(message, "Hỏi Mua",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                int ret = 0;
                if (chkCustomer.Checked == true)
                {
                    HoaDon bill = BillDAO.InsertTicketBill(customer.id, staffId, discount, total);
                    foreach (Button btn in listSeatSelected)
                    {
                        Ve ticket = btn.Tag as Ve;

                        ret += TicketDAO.BuyTicket(ticket.id.ToString(), (int)ticket.LoaiVe, customer.id, (decimal)ticket.TienBanVe);
                        BillDAO.InsertTicketBillDetail(bill, ticket);
                    }
					customer.DiemTichLuy += plusPoint;
					CustomerDAO.UpdatePointCustomer(customer.id, (int)customer.DiemTichLuy);
                }
                else
                {
                    HoaDon bill = BillDAO.InsertTicketBill(null, staffId, discount, total);
                    foreach (Button btn in listSeatSelected)
                    {
                        Ve ticket = btn.Tag as Ve;

                        ret += TicketDAO.BuyTicket(ticket.id.ToString(), (int)ticket.LoaiVe, (decimal)ticket.TienBanVe);
                        BillDAO.InsertTicketBillDetail(bill, ticket);
                    }
                }
                if (ret == listSeatSelected.Count)
                {
                    MessageBox.Show("Bạn đã mua vé thành công!");
                }
            }
            RestoreDefault();
            this.OnLoad(new EventArgs());
        }

        private void rdoStudent_Click(object sender, EventArgs e)
        {
            if (rdoStudent.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ve ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ve;
                ticket.LoaiVe = 1;

                decimal oldPrice = (decimal)ticket.TienBanVe;
                ticket.TienBanVe = 0.8M * ticketPrice;
                displayPrice = (decimal)ticket.TienBanVe;
                total = (decimal)(total + ticket.TienBanVe - oldPrice);
                payment = total - discount;

                LoadBill();
            }
        }

        private void rdoAdult_Click(object sender, EventArgs e)
        {
            if (rdoAdult.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ve ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ve;
                ticket.LoaiVe = 0;

                decimal oldPrice = (decimal)ticket.TienBanVe;
                ticket.TienBanVe = ticketPrice;
                displayPrice = (decimal)ticket.TienBanVe;
                total = (decimal)(total + ticket.TienBanVe - oldPrice);
                payment = total - discount;

                LoadBill();
            }
        }

        private void rdoChild_Click(object sender, EventArgs e)
        {
            if (rdoChild.Checked == true)
            {
                if (listSeatSelected.Count == 0) return;
                Ve ticket = listSeatSelected[listSeatSelected.Count - 1].Tag as Ve;
                ticket.LoaiVe = 2;

                decimal oldPrice = (decimal)ticket.TienBanVe;
                ticket.TienBanVe = 0.7M * ticketPrice;
                displayPrice = (decimal)ticket.TienBanVe;
                total = (decimal)(total + ticket.TienBanVe - oldPrice);
                payment = total - discount;

                LoadBill();
            }
        }

        private void chkCustomer_Click(object sender, EventArgs e)
        {
            if (chkCustomer.Checked == true)
            {
                frmCustomer frm = new frmCustomer();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    customer = frm.customer;
                    lblCustomerName.Text = customer.HoTen;
                    lblPoint.Text = customer.DiemTichLuy + "";
                    ShowOrHideLablePoint();
                }
                else
                {
                    chkCustomer.Checked = false;
                }
            }
            else
            {
                ShowOrHideLablePoint();
                customer = null;
            }
        }

        private void btnFreeTicket_Click(object sender, EventArgs e)
        {
            int freeTickets = (int)numericFreeTickets.Value;
            if (freeTickets <= 0) return;

            if (freeTickets > listSeat.Count)
            {
                MessageBox.Show("BẠN CHỈ ĐỔI ĐƯỢC TỐT ĐA [" + listSeatSelected.Count + "] VÉ", "THÔNG BÁO");
                return;
            }
            int pointFreeTicket = freeTickets * 20;
            if (customer.DiemTichLuy < pointFreeTicket)
            {
                MessageBox.Show("BẠN KHÔNG ĐỦ ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ", "THÔNG BÁO");
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("BẠN CÓ MUỐN DÙNG ĐIỂM TÍCH LŨY ĐỂ ĐỔI [" + freeTickets + "] VÉ MIỄN PHÍ KHÔNG?",
                                        "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    customer.DiemTichLuy -= pointFreeTicket;
                    plusPoint -= freeTickets;

                    if (CustomerDAO.UpdatePointCustomer(customer.id, (int)customer.DiemTichLuy))
                    {
                        MessageBox.Show("BẠN ĐÃ DỔI ĐƯỢC [" + freeTickets + "] VÉ MIỄN PHÍ THÀNH CÔNG", "THÔNG BÁO");
                    }
                    lblPoint.Text = "" + customer.DiemTichLuy;
                    lblPlusPoint.Text = "" + plusPoint;

                    for (int i = 0; i < listSeatSelected.Count && freeTickets > 0; i++)
                    {
                        Ve ticket = listSeatSelected[i].Tag as Ve;
                        if (ticket.TienBanVe != 0)
                        {
                            discount += (decimal)ticket.TienBanVe;
                            ticket.TienBanVe = 0;
                            freeTickets--;
                        }
                    }

                    payment = total - discount;
                    LoadBill();
                }
            }
        }
    }
}
