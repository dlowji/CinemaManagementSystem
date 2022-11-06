using CinemaManagementSystem;
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class StorageDAO
    {
        private StorageDAO() { }
        
        public static Boolean UpdateProductQuantity(string productId, int quantity)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from kho in db.Khos
                            where kho.idSanPham.Equals(productId)
                            select kho).First();

                query.SoLuong += quantity;

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
    }
}
