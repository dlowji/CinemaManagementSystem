using CinemaManagementSystem;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GUI.DAO
{
    public class ReceiptDAO
    {
        private ReceiptDAO() { }

        public static List<HoaDon> GetTicketReceipts()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from hddv in db.HoaDonDatVes
                            join hd in db.HoaDons
                            on hddv.idHoaDon equals hd.id
                            select hd;

                return query.ToList();
            }
        }

        public static List<HoaDon> GetProductReceipts()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from hdsp in db.HoaDonSanPhams
                            join hd in db.HoaDons
                            on hdsp.idHoaDon equals hd.id
                            select hd;

                return query.ToList();
            }
        }

        public static List<HoaDonNhapHang> GetImportReceipts()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from hdnh in db.HoaDonNhapHangs
                            select hdnh;

                return query.ToList();
            }
        }

        public static DataTable GetImportReceiptList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Tên sản phẩm", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Nhân viên", typeof(string));
            dt.Columns.Add("Nhà cung cấp", typeof(string));
            dt.Columns.Add("Ngày nhập", typeof(string));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from receipt in db.HoaDonNhapHangs
                            select receipt;

                foreach (var item in query)
                {
                    dt.Rows.Add(item.id, item.SanPham.TenHienThi, item.SoLuong, item.TongTien, item.NhanVien.HoTen, item.NhaCungCap.Ten, item.CreatedAt.ToString());
                }
            }

            return dt;
        }
        public static DataTable GetTicketReceiptList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Ngày xuất", typeof(string));
            dt.Columns.Add("Khách hàng", typeof(string));
            dt.Columns.Add("Số điện thoại", typeof(string));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Giảm giá", typeof(decimal));
            dt.Columns.Add("Sau giảm giá", typeof(decimal));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from receipt in db.HoaDons
                            select receipt;

                foreach (var item in query)
                {
                    decimal afterDiscountPrice = item.TongTien - item.GiamGia;
                    dt.Rows.Add(item.id, item.CreatedAt.ToString(), item.KhachHang.HoTen, item.KhachHang.SDT, item.TongTien, item.NhanVien.HoTen, item.GiamGia, afterDiscountPrice);
                }
            }

            return dt;
        }
    }
}
