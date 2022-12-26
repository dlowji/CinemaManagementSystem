using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
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

namespace CinemaManagementSystem.View.Customer
{
    public partial class BillUCForStaff : UserControl
    {
        private List<Button> selectedSeats;
        private List<Support> selectedProducts;
        private Phim movie;
        private LichChieu showTimes;
        private KhachHang member;
        private decimal totalTicketPrice;
        private decimal totalProductPrice = 0;
        private decimal discount = 0;

        private string staffId;
        public BillUCForStaff(List<Button> selectedSeats, List<Support> selectedProducts, LichChieu showTimes, Phim movie, decimal totalTicketPrice, string staffId)
        {
            InitializeComponent();
            this.showTimes = showTimes;
            this.movie = movie;
            this.selectedSeats = selectedSeats;
            this.selectedProducts = selectedProducts;
            this.totalTicketPrice = totalTicketPrice;
            this.staffId = staffId;
            member = null;
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
                + showTimes.ThoiGianChieu.AddMinutes(movie.ThoiLuong).ToShortTimeString(); ;
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

        private void cbStranger_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStranger.Checked == true)
            {
                lbPhone.Visible = false;
                txbPhone.Visible = false;
                btnPhone.Visible = false;

                lbName.Visible = false;
                txbName.Visible = false;

                lbEmail.Visible = false;
                txbEmail.Visible = false;

                lbVoucher.Visible = false;
                txbVoucher.Visible = false;
            }
            else
            {
                lbPhone.Visible = true;
                txbPhone.Visible = true;
                btnPhone.Visible = true;
            }
        }

        private void btnPhone_Click(object sender, EventArgs e)
        {
            string phone = txbPhone.Text;

            if (String.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi thông tin");
                return;
            }

            KhachHang cus = CustomerController.GetCustomerByPhone(phone);

            if (cus is null)
            {
                MessageBox.Show("Số điện thoại chưa được đăng ký thành viên", "Lỗi xác thực");
                return;
            }

            member = cus;

            lbName.Visible = true;
            txbName.Visible = true;
            txbName.Text = cus.HoTen;

            lbEmail.Visible = true;
            txbEmail.Visible = true;
            txbEmail.Text = cus.Email;

            lbVoucher.Visible = true;
            txbVoucher.Visible = true;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            bool result;

            if (cbStranger.Checked == true) // khach vang lai
            {
                result = BillController.Payment(selectedSeats, selectedProducts, "KH00", staffId, discount, totalTicketPrice, totalProductPrice, totalTicketPrice + totalProductPrice, false);
            }
            else
            {
                if (member is null)
                {
                    MessageBox.Show("Vui lòng xác nhận loại khách hàng trước khi thanh toán", "Cảnh báo");
                    return;
                }

                result = BillController.Payment(selectedSeats, selectedProducts, member.id, staffId, discount,totalTicketPrice, totalProductPrice, totalTicketPrice + totalProductPrice, false);
            }

            if (result)
            {
                MessageBox.Show("Thanh toán hóa đơn thành công", "Thông báo");
                return;
            }
            else
            {
                MessageBox.Show("Thanh toán hóa đơn thất bại", "Thông báo");
                return;
            }
        }
    }
}
