using CinemaManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class ProductDAO
    {
        private ProductDAO() { }
        public static DataTable GetListProduct()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã sản phẩm", typeof(string));
            dt.Columns.Add("Tên hiển thị", typeof(string));
            dt.Columns.Add("Loại sản phẩm", typeof(string));
            dt.Columns.Add("Giá tiền", typeof(decimal));
            dt.Columns.Add("Số lượng", typeof(int));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from sp in db.SanPhams
                            join storage in db.Khos
                            on sp.id equals storage.idSanPham
                            select new
                            {
                                id = sp.id,
                                TenHienThi = sp.TenHienThi,
                                GiaTien = sp.GiaTien,
                                LoaiSanPham = sp.LoaiSanPham,
                                SoLuong = storage.SoLuong
                            };

                foreach (var item in query)
                {
                    string type = item.LoaiSanPham == 1 ? "Đồ ăn" : "Thức uống";
                    dt.Rows.Add(item.id, item.TenHienThi, type, item.GiaTien, item.SoLuong);
                }
            }

            return dt;
        }

        public static List<Kho> GetProducts()
        {
            List<Kho> storages = new List<Kho>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from sp in db.SanPhams
                            join storage in db.Khos
                            on sp.id equals storage.idSanPham
                            select storage;

                foreach (var item in query)
                {
                    storages.Add(item);
                }
            }

            return storages;
        }

        public static SanPham GetProductById(string productId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var product = from p in db.SanPhams
                              where p.id.Equals(productId)
                              select p;

                return product.First();
            }
        }

        public static Kho GetProductInStorageById(string productId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var storage = from s in db.Khos
                              where s.idSanPham.Equals(productId)
                              select s;

                return storage.First();
            }
        }

        public static NhaCungCap GetSupplierByProductId(string productId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var product = from p in db.SanPhams
                              where p.id.Equals(productId)
                              select p;

                return product.First().NhaCungCap;
            }
        }

        public static bool InsertProduct(string id, string tenHienThi, int loaiSanPham, decimal giaBan)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                SanPham p = new SanPham
                {
                    id = id,
                    TenHienThi = tenHienThi,
                    LoaiSanPham = loaiSanPham,
                    GiaTien = giaBan
                };

                Kho storage = new Kho
                {
                    idSanPham = id,
                    SoLuong = 0,
                };

                db.Khos.InsertOnSubmit(storage);
                db.SanPhams.InsertOnSubmit(p);

                try
                {
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
            }
        }

        public static bool UpdateProduct(string id, string tenHienThi, int loaiSanPham, decimal giaTien)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var sp = (from p in db.SanPhams
                          where p.id.Equals(id)
                          select p).First();

                sp.TenHienThi = tenHienThi;
                sp.LoaiSanPham = loaiSanPham;
                sp.GiaTien = giaTien;

                //ask the datacontext to save all the changes
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

        public static bool DeleteProduct(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var sp = (from p in db.SanPhams
                          where p.id.Equals(id)
                          select p).First();

                var storage = (from kho in db.Khos
                               where kho.idSanPham.Equals(id)
                               select kho).First();

                db.Khos.DeleteOnSubmit(storage);
                db.SanPhams.DeleteOnSubmit(sp);

                //ask the datacontext to save all the changes
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

        public static DataTable SearchProductByName(string name)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã sản phẩm", typeof(string));
            dt.Columns.Add("Tên hiển thị", typeof(string));
            dt.Columns.Add("Loại sản phẩm", typeof(string));
            dt.Columns.Add("Giá tiền", typeof(decimal));
            dt.Columns.Add("Số lượng", typeof(decimal));

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from sp in db.SanPhams
                            join storage in db.Khos
                            on sp.id equals storage.idSanPham
                            where sp.TenHienThi.Contains(name)
                            select new
                            {
                                id = sp.id,
                                TenHienThi = sp.TenHienThi,
                                GiaTien = sp.GiaTien,
                                LoaiSanPham = sp.LoaiSanPham,
                                SoLuong = storage.SoLuong
                            };

                foreach (var item in query)
                {
                    string type = item.LoaiSanPham == 1 ? "Đồ ăn" : "Thức uống";
                    dt.Rows.Add(item.id, item.TenHienThi, type, item.GiaTien, item.SoLuong);
                }
            }

            return dt;
        }

        public static SanPham GetProductByName(string name)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from sp in db.SanPhams
                            where sp.TenHienThi.Equals(name)
                            select sp;

                return query.First();
            }
        }
    }
}
