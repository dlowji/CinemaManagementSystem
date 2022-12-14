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
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Tên sản phẩm", typeof(string));
            dt.Columns.Add("Gía nhập hàng", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Nhân viên", typeof(string));
            dt.Columns.Add("Nhà cung cấp", typeof(string));
            dt.Columns.Add("Ngày nhập", typeof(string));

            List<HoaDonNhapHang> importReceiptList = ReceiptDAO.GetImportReceipts();

            foreach (var item in importReceiptList)
            {
                SanPham product = ProductDAO.GetProductById(item.idSanPham);
                NhaCungCap supplier = ProductDAO.GetSupplierById(item.idNhaCungCap);
                NhanVien staff = StaffController.GetStaffById(item.idNhanVien);
 
                dt.Rows.Add(item.id, product.TenHienThi, item.GiaNhapHang, item.SoLuong, item.TongTien, staff.HoTen, supplier.Ten, item.CreatedAt);
            }

            return dt;
        }

        public static DataTable GetTicketReceiptList()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Khách hàng", typeof(string));
            dt.Columns.Add("Nhân viên", typeof(string));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Giảm giá", typeof(decimal));
            dt.Columns.Add("Sau giảm giá", typeof(decimal));
            dt.Columns.Add("Ngày xuất", typeof(string));
            dt.Columns.Add("Trực tuyến", typeof(string));

            List<HoaDon> ticketReceiptList = ReceiptDAO.GetTicketReceipts();

            foreach (var item in ticketReceiptList)
            {
                decimal afterDiscountPrice = item.TongTien - item.GiamGia;
                KhachHang cus = CustomerController.GetCustomerById(item.idKhachHang);
                NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                string staffName = staff is null ? "" : staff.HoTen;

                dt.Rows.Add(item.id, cus.HoTen, staffName, item.TongTien, item.GiamGia, afterDiscountPrice, item.CreatedAt, (bool)item.TrucTuyen);
            }

            return dt;
        }

        public static DataTable SearchImportReceiptById(string receiptId, string time)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Tên sản phẩm", typeof(string));
            dt.Columns.Add("Gía nhập hàng", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Nhân viên", typeof(string));
            dt.Columns.Add("Nhà cung cấp", typeof(string));
            dt.Columns.Add("Ngày nhập", typeof(string));

            List<HoaDonNhapHang> importReceiptList = ReceiptDAO.GetImportReceipts();

            bool isAllTime = time.Equals("Toàn bộ");

            foreach (var item in importReceiptList)
            {
                if (isAllTime)
                {
                    if (item.id.Equals(receiptId))
                    {
                        SanPham product = ProductDAO.GetProductById(item.idSanPham);
                        NhaCungCap supplier = ProductDAO.GetSupplierById(item.idNhaCungCap);
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                        dt.Rows.Add(item.id, product.TenHienThi, item.GiaNhapHang, item.SoLuong, item.TongTien, staff.HoTen, supplier.Ten, item.CreatedAt.ToString());
                    }
                }
                else
                {
                    int month = Int32.Parse(time.Split(' ')[1]);

                    if (item.id.Equals(receiptId) && item.CreatedAt.Month == month)
                    {
                        SanPham product = ProductDAO.GetProductById(item.idSanPham);
                        NhaCungCap supplier = ProductDAO.GetSupplierById(item.idNhaCungCap);
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                        dt.Rows.Add(item.id, product.TenHienThi, item.GiaNhapHang, item.SoLuong, item.TongTien, staff.HoTen, supplier.Ten, item.CreatedAt.ToString());
                    }
                }
            }

            return dt;

        }

        public static DataTable SearchImportReceiptByStaffName(string staffName, string time)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Tên sản phẩm", typeof(string));
            dt.Columns.Add("Gía nhập hàng", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Nhân viên", typeof(string));
            dt.Columns.Add("Nhà cung cấp", typeof(string));
            dt.Columns.Add("Ngày nhập", typeof(string));

            List<HoaDonNhapHang> importReceiptList = ReceiptDAO.GetImportReceipts();

            bool isAllTime = time.Equals("Toàn bộ");
            
            foreach (var item in importReceiptList)
            {
                NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                if (isAllTime)
                {
                    if (staff.HoTen.Contains(staffName))
                    {
                        SanPham product = ProductDAO.GetProductById(item.idSanPham);
                        NhaCungCap supplier = ProductDAO.GetSupplierById(item.idNhaCungCap);

                        dt.Rows.Add(item.id, product.TenHienThi, item.GiaNhapHang, item.SoLuong, item.TongTien, staff.HoTen, supplier.Ten, item.CreatedAt.ToString());
                    }
                }
                else
                {
                    int month = Int32.Parse(time.Split(' ')[1]);

                    if (staff.HoTen.Contains(staffName) && item.CreatedAt.Month == month)
                    {
                        SanPham product = ProductDAO.GetProductById(item.idSanPham);
                        NhaCungCap supplier = ProductDAO.GetSupplierById(item.idNhaCungCap);

                        dt.Rows.Add(item.id, product.TenHienThi, item.GiaNhapHang, item.SoLuong, item.TongTien, staff.HoTen, supplier.Ten, item.CreatedAt.ToString());
                    }
                }
            }

            return dt;
        }

        public static DataTable SearchImportReceiptByProductName(string productName, string time)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Tên sản phẩm", typeof(string));
            dt.Columns.Add("Gía nhập hàng", typeof(string));
            dt.Columns.Add("Số lượng", typeof(int));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Nhân viên", typeof(string));
            dt.Columns.Add("Nhà cung cấp", typeof(string));
            dt.Columns.Add("Ngày nhập", typeof(string));

            List<HoaDonNhapHang> importReceiptList = ReceiptDAO.GetImportReceipts();

            bool isAllTime = time.Equals("Toàn bộ");

            foreach (var item in importReceiptList)
            {
                SanPham product = ProductDAO.GetProductById(item.idSanPham);

                if (isAllTime)
                {
                    if (product.TenHienThi.Contains(productName))
                    {
                        NhaCungCap supplier = ProductDAO.GetSupplierById(item.idNhaCungCap);
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                        dt.Rows.Add(item.id, product.TenHienThi, item.GiaNhapHang, item.SoLuong, item.TongTien, staff.HoTen, supplier.Ten, item.CreatedAt.ToString());
                    }
                }
                else
                {
                    int month = Int32.Parse(time.Split(' ')[1]);

                    if (product.TenHienThi.Contains(productName) && item.CreatedAt.Month == month)
                    {
                        NhaCungCap supplier = ProductDAO.GetSupplierById(item.idNhaCungCap);
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                        dt.Rows.Add(item.id, product.TenHienThi, item.GiaNhapHang, item.SoLuong, item.TongTien, staff.HoTen, supplier.Ten, item.CreatedAt.ToString());
                    }
                }
            }

            return dt;
        }

        public static DataTable SearchTicketReceiptById(string receiptId, DateTime? date)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Khách hàng", typeof(string));
            dt.Columns.Add("Nhân viên", typeof(string));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Giảm giá", typeof(decimal));
            dt.Columns.Add("Sau giảm giá", typeof(decimal));
            dt.Columns.Add("Trực tuyến", typeof(bool));
            dt.Columns.Add("Ngày xuất", typeof(string));

            List<HoaDon> ticketReceiptList = ReceiptDAO.GetTicketReceipts();

            bool isAllTime = date == null;

            foreach (var item in ticketReceiptList)
            {
                if (isAllTime)
                {
                    if (item.id.Equals(receiptId))
                    {
                        KhachHang cus = CustomerController.GetCustomerById(item.idKhachHang);
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                        decimal afterDiscount = item.TongTien - item.GiamGia;

                        dt.Rows.Add(item.id, cus.HoTen, staff.HoTen, item.TongTien, item.GiamGia, afterDiscount, item.TrucTuyen, item.CreatedAt);
                    }
                }
                else
                {
                    DateTime dateTime = (DateTime)date;

                    if (item.id.Equals(receiptId) && DateTime.Compare(item.CreatedAt, dateTime) == 0)
                    {
                        KhachHang cus = CustomerController.GetCustomerById(item.idKhachHang);
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                        decimal afterDiscount = item.TongTien - item.GiamGia;

                        dt.Rows.Add(item.id, cus.HoTen, staff.HoTen, item.TongTien, item.GiamGia, afterDiscount, item.TrucTuyen, item.CreatedAt);
                    }
                }
            }

            return dt;

        }

        public static DataTable SearchTicketReceiptByCusName(string staffName, DateTime? date)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Khách hàng", typeof(string));
            dt.Columns.Add("Nhân viên", typeof(string));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Giảm giá", typeof(decimal));
            dt.Columns.Add("Sau giảm giá", typeof(decimal));
            dt.Columns.Add("Trực tuyến", typeof(bool));
            dt.Columns.Add("Ngày xuất", typeof(string));

            List<HoaDon> ticketReceiptList = ReceiptDAO.GetTicketReceipts();

            bool isAllTime = date == null;

            foreach (var item in ticketReceiptList)
            {
                KhachHang cus = CustomerController.GetCustomerById(item.idKhachHang);

                if (isAllTime)
                {
                    if (cus.HoTen.Contains(staffName))
                    {
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                        decimal afterDiscount = item.TongTien - item.GiamGia;
                        dt.Rows.Add(item.id, cus.HoTen, staff.HoTen, item.TongTien, item.GiamGia, afterDiscount, item.TrucTuyen, item.CreatedAt);
                    }
                }
                else
                {
                    DateTime dateTime = (DateTime)date;

                    if (cus.HoTen.Contains(staffName) && DateTime.Compare(item.CreatedAt, dateTime) == 0)
                    {
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                        decimal afterDiscount = item.TongTien - item.GiamGia;
                        dt.Rows.Add(item.id, cus.HoTen, staff.HoTen, item.TongTien, item.GiamGia, afterDiscount, item.TrucTuyen, item.CreatedAt);
                    }
                }
            }

            return dt;
        }

        public static DataTable SearchTicketReceiptByStatus(string productName, DateTime? date)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đơn", typeof(string));
            dt.Columns.Add("Khách hàng", typeof(string));
            dt.Columns.Add("Nhân viên", typeof(string));
            dt.Columns.Add("Tổng giá", typeof(decimal));
            dt.Columns.Add("Giảm giá", typeof(decimal));
            dt.Columns.Add("Sau giảm giá", typeof(decimal));
            dt.Columns.Add("Trực tuyến", typeof(bool));
            dt.Columns.Add("Ngày xuất", typeof(string));

            List<HoaDon> ticketReceiptList = ReceiptDAO.GetTicketReceipts();

            bool isAllTime = date == null;

            foreach (var item in ticketReceiptList)
            {
                bool status = (bool)item.TrucTuyen;

                if (isAllTime)
                {
                    if (status)
                    {
                        KhachHang cus = CustomerController.GetCustomerById(item.idKhachHang);
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);
                        decimal afterDiscount = item.TongTien - item.GiamGia;
                        dt.Rows.Add(item.id, cus.HoTen, staff.HoTen, item.TongTien, item.GiamGia, afterDiscount, item.TrucTuyen, item.CreatedAt);
                    }
                }
                else
                {
                    DateTime dateTime = (DateTime)date;

                    if (status && DateTime.Compare(item.CreatedAt, dateTime) == 0)
                    {
                        KhachHang cus = CustomerController.GetCustomerById(item.idKhachHang);
                        NhanVien staff = StaffController.GetStaffById(item.idNhanVien);

                        decimal afterDiscount = item.TongTien - item.GiamGia;

                        dt.Rows.Add(item.id, cus.HoTen, staff.HoTen, item.TongTien, item.GiamGia, afterDiscount, item.TrucTuyen, item.CreatedAt);
                    }
                }
            }

            return dt;
        }
    }
}
