using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaManagementSystem.Controllers
{
    public class VoucherController
    {
       public static DataTable GetDataTableOfVoucherRelease()
       {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã phát hành", typeof(string));
            dt.Columns.Add("Tên đợt phát hành", typeof(string));
            dt.Columns.Add("Từ ngày", typeof(string));
            dt.Columns.Add("Đến ngày", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Mệnh giá", typeof(decimal));

            List<PhatHanhVoucher> voucherReleaseList = VoucherDAO.GetListOfReleaseVoucher();


            foreach (var item in voucherReleaseList)
            {
                List<Voucher> voucherList = VoucherDAO.GetVouchersByReleaseVoucherId(item.id);

                int count = voucherList.Count;

                DateTime startDate = (DateTime)item.NgayBatDau;
                DateTime endDate = (DateTime)item.NgayKetThuc;

                dt.Rows.Add(item.id, item.TenDotPhatHanh, startDate.ToShortDateString(), endDate.ToShortDateString(), count, item.MenhGia);
            }

            return dt;
       }

       public static bool SaveVoucherRelease(string id, string name, DateTime startDate, DateTime endDate, decimal price, decimal minPrice, int productType, bool status)
       {
            return VoucherDAO.SaveVoucherRelease(id, name, startDate, endDate, price, minPrice, productType, status);
       }
    }
}
