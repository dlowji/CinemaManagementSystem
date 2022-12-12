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
       public static bool Payment(List<Button> selectedSeats, string customerId, string staffId, decimal discount, decimal ticketPrice, decimal foodPrice, decimal totalPrice, bool isOnline)
       {
            KhachHang cus = CustomerController.GetCustomerById(customerId);

            CapDoThanhVien memberLevel = CustomerController.GetMemberLevelById(cus.idCapDoThanhVien);

            decimal point = memberLevel.DiemThuongQuayVe * ticketPrice + memberLevel.DiemThuongBapNuoc * foodPrice;

            CustomerController.UpdateMemberPoint(cus.id, (int)cus.DiemTichLuy + (int)Decimal.Round(point));
            HoaDon bill = BillDAO.InsertTicketBill(customerId, staffId, discount, totalPrice, isOnline);

            List<Ve> purchaseTickets = new List<Ve>();

            foreach (var item in selectedSeats)
            {
                purchaseTickets.Add(item.Tag as Ve);
            }

            foreach (var item in purchaseTickets)
            {
                bool result = BillDAO.InsertTicketBillDetail(bill, item);

                if (!result)
                {
                    return false;
                }
            }

            return true;
       }
    }
}
