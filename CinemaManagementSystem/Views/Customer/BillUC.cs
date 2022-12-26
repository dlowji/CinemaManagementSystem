using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
using CinemaManagementSystem.Views.Customer;
using GUI.frmAdminUserControls.DataUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ticketPayment;

namespace CinemaManagementSystem.View.Customer
{
    public partial class BillUC : UserControl
    {
        private List<Button> selectedSeats;
        private List<Support> selectedProducts;
        private Phim movie;
        private LichChieu showTimes;
        private Panel homepage;
        private decimal totalTicketPrice;
        private decimal totalProductPrice = 0;
        private decimal discount = 0;


        private decimal maxPoint = 0;
        private string customerId;
        public BillUC(List<Button> selectedSeats, List<Support> selectedProducts, LichChieu showTimes, Phim movie, decimal totalTicketPrice, string customerId, Panel homepage)
        {
            InitializeComponent();
            this.showTimes = showTimes;
            this.movie = movie;
            this.selectedSeats = selectedSeats;
            this.selectedProducts = selectedProducts;
            this.totalTicketPrice = totalTicketPrice;
            this.customerId = customerId;
            this.homepage = homepage;
        }

        private void BillUC_Load(object sender, EventArgs e)
        {
            LoadInformation();
        }

        private void LoadInformation()
        {
            Rap cinema = CinemaController.GetCinemaById(showTimes.idRap);
            CumRap cineplex = CinemaController.GetCineplexByCinemaID(showTimes.idRap);

            lbMovieName.Text = movie.TenPhim;
            lbDate.Text = showTimes.ThoiGianChieu.ToShortDateString();
            lbTime.Text = showTimes.ThoiGianChieu.ToShortTimeString() + " - "
                + showTimes.ThoiGianChieu.AddMinutes(movie.ThoiLuong).ToShortTimeString();
            lbCinema.Text = cinema.TenRap;
            lbCineplex.Text = cineplex.Ten;
            lbSeats.Text = LoadSeatsInfor();
            lbTicketPrice.Text = Helper.Helper.FormatVNMoney(showTimes.GiaVe);
            lbTotalTicketPrice.Text = Helper.Helper.FormatVNMoney(totalTicketPrice);

            int offsetY = 0;

            //products
            foreach (var item in selectedProducts)
            {
                Decimal quantity = item.OldValue;
                SanPham product = item.Product;

                if (quantity == 0)
                {
                    continue;
                }

                // 
                // label for name
                // 
                Label lbForName = new Label();
                lbForName.AutoSize = true;
                lbForName.Font = new Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbForName.ForeColor = Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
                lbForName.Location = new Point(7, 51 + offsetY);
                lbForName.Size = new Size(77, 16);
                lbForName.TabIndex = 1;
                lbForName.Text = product.TenHienThi;
                // 
                // label for detail
                // 
                Label lbForDetail = new Label();
                lbForDetail.AutoSize = true;
                lbForDetail.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbForDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
                lbForDetail.Location = new System.Drawing.Point(7, lbForName.Location.Y + 30);
                lbForDetail.Size = new System.Drawing.Size(77, 16);

                StringBuilder sb = new StringBuilder();
                sb.Append(quantity).Append(" x ").Append(Helper.Helper.FormatVNMoney((decimal)product.GiaTien));

                lbForDetail.Text = sb.ToString();
                decimal totalPrice = (decimal)product.GiaTien * quantity;
                totalProductPrice += totalPrice;
                // 
                // label for total price
                // 
                Label lbForPrice = new Label();
                lbForPrice.AutoSize = true;
                lbForPrice.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lbForPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
                lbForPrice.Location = new System.Drawing.Point(187, lbForName.Location.Y);
                lbForPrice.Size = new System.Drawing.Size(70, 16);
                lbForPrice.Text = Helper.Helper.FormatVNMoney(totalPrice);

                Panel pn = new Panel();
                pn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
                pn.Location = new System.Drawing.Point(7, lbForName.Location.Y + 59);
                pn.Size = new System.Drawing.Size(275, 1);

                pnProduct.Controls.Add(lbForName);
                pnProduct.Controls.Add(lbForDetail);
                pnProduct.Controls.Add(lbForPrice);
                pnProduct.Controls.Add(pn);

                offsetY += 78;
            }
            lbtotalProductPrice.Text = Helper.Helper.FormatVNMoney(totalProductPrice);

            lbTotalPrice.Text = Helper.Helper.FormatVNMoney(totalTicketPrice + totalProductPrice);
            lbFee.Text = Helper.Helper.FormatVNMoney(0);
            lbDiscount.Text = Helper.Helper.FormatVNMoney(0);
            lbAfterDiscount.Text = Helper.Helper.FormatVNMoney(totalTicketPrice + totalProductPrice - discount);
            maxPoint = Decimal.Round((decimal)(Decimal.ToDouble(totalTicketPrice + totalProductPrice - discount) * 0.9 / 1000));

            LoadCusInfo();
        }

        private string LoadSeatsInfor()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in selectedSeats)
            {
                sb.Append(item.Text).Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        private void LoadCusInfo()
        {
            KhachHang cus = CustomerController.GetCustomerById(customerId);

            if (cus is null)
            {
                MessageBox.Show("Lỗi hệ thống", "Lỗi xác thực");
                return;
            }

            lbPhone.Visible = true;
            txbPhone.Visible = true;
            txbPhone.Text = cus.SDT;

            lbName.Visible = true;
            txbName.Visible = true;
            txbName.Text = cus.HoTen;

            lbEmail.Visible = true;
            txbEmail.Visible = true;
            txbEmail.Text = cus.Email;

            lbVoucher.Visible = true;
            nud.Maximum = 10000;
            nud.Tag = (decimal)cus.DiemTichLuy;
            nud.Value = (decimal)cus.DiemTichLuy;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            PaymentUC paymentUC = new PaymentUC(checkBox1.Checked, nud.Value, movie, showTimes, LoadSeatsInfor(), homepage, totalTicketPrice, totalProductPrice, discount, customerId, selectedSeats, selectedProducts);
            paymentUC.Dock = DockStyle.Fill;

            homepage.Controls.Clear();
            homepage.Controls.Add(paymentUC);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (nud.Value < 20)
                {
                    MessageBox.Show("Điểm thưởng tối thiểu được sử dụng cho mỗi giao dịch là 20 điểm trở lên", "Thông báo");
                    return;
                }
                nud.Enabled = true;

                if (nud.Value >= maxPoint)
                {
                    nud.Value = maxPoint;
                }

                nud.Tag = nud.Value;
                discount = nud.Value * 1000;
                lbDiscount.Text = Helper.Helper.FormatVNMoney(discount);
                lbAfterDiscount.Text = Helper.Helper.FormatVNMoney(totalTicketPrice + totalProductPrice - discount);
            }
            else
            {
                nud.Enabled = false;
                discount = 0;
                lbDiscount.Text = Helper.Helper.FormatVNMoney(discount);
                lbAfterDiscount.Text = Helper.Helper.FormatVNMoney(totalTicketPrice + totalProductPrice - discount);
            }
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            decimal oldValue = (decimal)nud.Tag;

            if (nud.Value > maxPoint)
            {
                if (checkBox1.Checked == true)
                {
                    MessageBox.Show("Điểm thưởng chỉ được sử dụng thanh toán tối đa 90% giá trị đơn hàng.", "Thông báo");
                    nud.Value = maxPoint;
                    return;
                }
            }

            KhachHang cus = CustomerController.GetCustomerById(customerId);
            if (nud.Value > cus.DiemTichLuy)
            {
                MessageBox.Show("Khách hàng hiện tại chỉ có tối đa " + cus.DiemTichLuy + " điểm thưởng");
                nud.Value = (decimal)cus.DiemTichLuy;
                return;
            }

            if (checkBox1.Checked == true)
            {
                discount = nud.Value * 1000;
                lbDiscount.Text = Helper.Helper.FormatVNMoney(discount);
                lbAfterDiscount.Text = Helper.Helper.FormatVNMoney(totalTicketPrice + totalProductPrice - discount);
                nud.Tag = nud.Value;
            }

        }
    }
}
