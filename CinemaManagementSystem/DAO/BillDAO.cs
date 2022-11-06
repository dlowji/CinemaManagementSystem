using CinemaManagementSystem;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class BillDAO
    {
        private BillDAO() { }
        
        public static Boolean InsertImportReceipt(string productId, decimal importPrice, int quantity, string staffId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from re in db.HoaDonNhapHangs
                            select re;

                int count = query.Count();

                StringBuilder receiptId = new StringBuilder("IR");

                if (count + 1 > 9)
                {
                    receiptId.Append((count + 1).ToString());
                }
                else
                {
                    receiptId.Append("0").Append((count + 1).ToString());
                }

                HoaDonNhapHang receipt = new HoaDonNhapHang
                {
                    id = receiptId.ToString(),
                    idSanPham = productId,
                    GiaNhapHang = importPrice,
                    SoLuong = quantity,
                    idNhanVien = staffId,
                    CreatedAt = DateTime.Now,
                };

                db.HoaDonNhapHangs.InsertOnSubmit(receipt);
                StorageDAO.UpdateProductQuantity(productId, quantity);

                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public static HoaDon InsertTicketBill(string customerId, string staffId, decimal discount, decimal totalPrice)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from hd in db.HoaDons
                            select hd;

                int count = query.Count();

                StringBuilder billId = new StringBuilder("TB");

                if (count + 1 > 9)
                {
                    billId.Append((count + 1).ToString());
                }
                else
                {
                    billId.Append("0").Append((count + 1).ToString());
                }

                HoaDon bill = new HoaDon
                {
                    id = billId.ToString(),
                    idKhachHang = (customerId == null || customerId == "") ? "KH00" : customerId,
                    idNhanVien = staffId,
                    GiamGia = discount,
                    TongTien = totalPrice,
                    CreatedAt = DateTime.Now,
                };

                db.HoaDons.InsertOnSubmit(bill);

                try
                {
                    db.SubmitChanges();
                    return bill;
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }

        public static Boolean InsertTicketBillDetail(HoaDon hoaDon, Ve ve)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                HoaDonDatVe bill = new HoaDonDatVe
                {
                    idHoaDon = hoaDon.id,
                    idVe = ve.id,
                    giaVe = (decimal)ve.TienBanVe,
                };

                db.HoaDonDatVes.InsertOnSubmit(bill);

                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                    throw;
                }
            }
        }
    }
}
