using CinemaManagementSystem.Helper;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem.Controllers
{
    public class BillController
    {
       public static bool Payment(List<Button> selectedSeats, List<Support> selectedProducts, string customerId, string staffId, decimal discount, decimal ticketPrice, decimal foodPrice, decimal totalPrice, bool isOnline)
       {
            KhachHang cus = CustomerController.GetCustomerById(customerId);

            CapDoThanhVien memberLevel = CustomerController.GetMemberLevelById(cus.idCapDoThanhVien);

            decimal point = (memberLevel.DiemThuongQuayVe * ticketPrice)/1000 + (memberLevel.DiemThuongBapNuoc * foodPrice)/1000;

            CustomerController.UpdateMemberPoint(cus.id, (int)cus.DiemTichLuy + (int)Decimal.Round(point));

            foreach (var item in selectedProducts)
            {
                decimal quantity = item.OldValue;
                SanPham product = item.Product;

                if (quantity <= 0)
                {
                    continue;
                }

                ProductController.UpdateProductQuantity(product.id, quantity);
            }

            HoaDon bill = BillDAO.InsertTicketBill(customerId, staffId, discount, totalPrice, isOnline);

            List<Ve> purchaseTickets = new List<Ve>();

            foreach (var item in selectedSeats)
            {
                purchaseTickets.Add(item.Tag as Ve);
            }

            foreach (var item in purchaseTickets)
            {
                bool result = BillDAO.InsertTicketBillDetail(bill, item);
                TicketDAO.BuyTicket(item.id, (decimal)item.TienBanVe);

                if (!result)
                {
                    return false;
                }
            }

            return true;
       }

        public static bool Payment(decimal usedPoint, List<Button> selectedSeats, List<Support> selectedProducts, string customerId, string staffId, decimal discount, decimal ticketPrice, decimal foodPrice, decimal totalPrice, bool isOnline)
        {
            KhachHang cus = CustomerController.GetCustomerById(customerId);

            CapDoThanhVien memberLevel = CustomerController.GetMemberLevelById(cus.idCapDoThanhVien);

            decimal point = (memberLevel.DiemThuongQuayVe * ticketPrice) / 1000 + (memberLevel.DiemThuongBapNuoc * foodPrice) / 1000;

            CustomerController.UpdateMemberPoint(cus.id, (int)cus.DiemTichLuy - (int)usedPoint + (int)Decimal.Round(point));

            foreach (var item in selectedProducts)
            {
                decimal quantity = item.OldValue;
                SanPham product = item.Product;

                if (quantity <= 0)
                {
                    continue;
                }

                ProductController.UpdateProductQuantity(product.id, quantity);
            }

            HoaDon bill = BillDAO.InsertTicketBill(customerId, staffId, discount, totalPrice, isOnline);

            List<Ve> purchaseTickets = new List<Ve>();

            foreach (var item in selectedSeats)
            {
                purchaseTickets.Add(item.Tag as Ve);
            }

            foreach (var item in purchaseTickets)
            {
                bool result = BillDAO.InsertTicketBillDetail(bill, item);
                TicketDAO.BuyTicket(item.id, (decimal)item.TienBanVe);

                if (!result)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
