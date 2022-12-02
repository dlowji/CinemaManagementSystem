using CinemaManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class VoucherDAO
    {
        private VoucherDAO() { }

        public static List<PhatHanhVoucher> GetListOfReleaseVoucher()
        {
            List<PhatHanhVoucher> voucherReleaseList = new List<PhatHanhVoucher>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var vouchers = from v in db.PhatHanhVouchers
                               select v;


                foreach (var item in vouchers)
                {
                    voucherReleaseList.Add(item);
                }
            }
            return voucherReleaseList;
        }

        public static List<Voucher> GetVouchersByReleaseVoucherId(string voucherReleaseId)
        {
            List<Voucher> voucherList = new List<Voucher>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var vouchers = from v in db.Vouchers
                               where v.idPhatHanh.Equals(voucherReleaseId)
                               select v;

                foreach (var item in voucherList)
                {
                    voucherList.Add(item);
                }
            }
            return voucherList;
        }

        public static bool SaveVoucher(string code, string voucherReleaseId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                Voucher voucher = new Voucher
                {
                    Code = code,
                    idPhatHanh = voucherReleaseId,
                    TrangThai = false
                };

                db.Vouchers.InsertOnSubmit(voucher);

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

        public static bool SaveVouchers(List<string> vouchers, string voucherReleaseId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                foreach (var item in vouchers)
                {
                    Voucher voucher = new Voucher
                    {
                        Code = item,
                        idPhatHanh = voucherReleaseId,
                        TrangThai = false
                    };

                    db.Vouchers.InsertOnSubmit(voucher);
                }

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

        public static bool ActiveVoucher(int voucherId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from v in db.Vouchers
                              where v.id == voucherId
                              select v;

                Voucher voucher = query.FirstOrDefault();

                voucher.TrangThai = true;

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

        public static bool DeleteVoucher(int voucherId)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from v in db.Vouchers
                            where v.id == voucherId
                            select v;

                Voucher voucher = query.FirstOrDefault();

                db.Vouchers.DeleteOnSubmit(voucher);

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

        public static bool SaveVoucherRelease(string id, string name, DateTime startDate, DateTime endDate, decimal price, decimal minPrice, int productType, bool status)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                PhatHanhVoucher voucherRelease = new PhatHanhVoucher
                {
                    id = id,
                    TenDotPhatHanh = name,
                    NgayBatDau = startDate,
                    NgayKetThuc = endDate,
                    MenhGia = price,
                    NhomHang = productType,
                    TrangThai = status
                    //GiaToiThieu = minPrice,
                };

                db.PhatHanhVouchers.InsertOnSubmit(voucherRelease);

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
