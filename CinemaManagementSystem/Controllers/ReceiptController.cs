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
    public class ReceiptController
    {
        public static DataTable GetImportReceiptList()
        {
            DataTable receipts = ReceiptDAO.GetImportReceiptList();

            return receipts;
        }

        public static DataTable GetTicketReceiptList()
        {
            DataTable receipts = ReceiptDAO.GetTicketReceiptList();

            return receipts;
        }
    }
}
