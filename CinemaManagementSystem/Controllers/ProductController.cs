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
    public class ProductController
    {
        public static DataTable GetProductList()
        {
            DataTable products = ProductDAO.GetListProduct();

            return products;
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
