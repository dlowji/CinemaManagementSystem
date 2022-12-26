using GUI.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem.Controllers
{
    public class ProductController
    {
        public static bool UpdateProductQuantity(string productId, decimal quantity)
        {
            int oldQuantity = ProductController.GetQuantityOfProduct(productId);

            int newQuantity = oldQuantity - (int)quantity;

            return StorageDAO.UpdateProductQuantity(productId, newQuantity);
        }

        public static DataTable GetProductList()
        {
            DataTable products = new DataTable();

            products.Columns.Add("Mã sản phẩm", typeof(string));
            products.Columns.Add("Tên hiển thị", typeof(string));
            products.Columns.Add("Loại sản phẩm", typeof(string));
            products.Columns.Add("Giá tiền", typeof(decimal));
            products.Columns.Add("Số lượng", typeof(int));
            products.Columns.Add("Nhà cung cấp", typeof(string));

            foreach (var item in ProductDAO.GetProducts())
            {
                SanPham product = ProductDAO.GetProductById(item.idSanPham);
                NhaCungCap supplier = ProductDAO.GetSupplierByProductId(item.idSanPham);

                string type = product.LoaiSanPham == 1 ? "Đồ ăn" : "Thức uống";
                products.Rows.Add(product.id, product.TenHienThi, type, product.GiaTien, item.SoLuong, supplier.Ten);
            }
            return products;
        }

        public static List<SanPham> GetProductsForView()
        {
            List<SanPham> products = new List<SanPham>();

            foreach (var item in ProductDAO.GetProducts())
            {
                SanPham product = ProductDAO.GetProductById(item.idSanPham);

                products.Add(product);
            }

            return products;
        }

        public static List<SanPham> GetFoodsForView()
        {
            List<SanPham> products = new List<SanPham>();

            foreach (var item in ProductDAO.GetProducts())
            {
                SanPham product = ProductDAO.GetProductById(item.idSanPham);

                if (product.LoaiSanPham == 1)
                {
                    products.Add(product);
                }
            }

            return products;
        }

        public static List<SanPham> GetDrinksForView()
        {
            List<SanPham> products = new List<SanPham>();

            foreach (var item in ProductDAO.GetProducts())
            {
                SanPham product = ProductDAO.GetProductById(item.idSanPham);

                if (product.LoaiSanPham == 2)
                {
                    products.Add(product);
                }
            }

            return products;
        }

        public static int GetQuantityOfProduct(string productId)
        {
            Kho storage = ProductDAO.GetProductInStorageById(productId);

            return (int)storage.SoLuong;
        }

        public static bool InsertProduct(string id, string tenHienThi, int loaiSanPham, decimal giaBan)
        {
            return ProductDAO.InsertProduct(id, tenHienThi, loaiSanPham, giaBan);
        }

        public static bool UpdateProduct(string id, string tenHienThi, int loaiSanPham, decimal giaBan)
        {
            return ProductDAO.UpdateProduct(id, tenHienThi, loaiSanPham, giaBan);
        }

        public static bool DeleteProduct(string id)
        {
            return ProductDAO.DeleteProduct(id);
        }

        public static DataTable SearchProductByName(string productName)
        {
            DataTable searchProductList = ProductDAO.SearchProductByName(productName);

            return searchProductList;
        }
    }
}
