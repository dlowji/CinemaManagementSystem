using CinemaManagementSystem;
using GUI.frmAdminUserControls.DataUserControl;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI.DAO
{
    public class TicketDAO
    {
        public static List<Ve> GetListTicketsByShowTimes(string showTimesID)
        {
            List<Ve> listTicket = new List<Ve>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from ve in db.Ves
                            where ve.idLichChieu.Equals(showTimesID)
                            select ve;

                foreach (var item in query)
                {
                    listTicket.Add(item);
                }
            }

            return listTicket;
        }

        public static List<Ve> GetListTicketsBoughtByShowTimes(string showTimesID)
        {
            List<Ve> listTicket = new List<Ve>();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from ve in db.Ves
                            where ve.idLichChieu.Equals(showTimesID) && ve.TrangThai == 1
                            select ve;

                foreach (var item in query)
                {
                    listTicket.Add(item);
                }
            }

            return listTicket;
        }

        public static int CountToltalTicketByShowTime(string showTimesID)
        {
            //string query = "Select count (id) from Ve where idLichChieu ='" + showTimesID + "'";

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from ve in db.Ves
                            where ve.idLichChieu.Equals(showTimesID)
                            select ve;

                return query.Count();
            }
        }
        public static int CountTheNumberOfTicketsSoldByShowTime(string showTimesID)
        {
            //string query = "Select count (id) from Ve where idLichChieu ='" + showTimesID + "' and TrangThai = 1 ";
            
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from ve in db.Ves
                            where ve.idLichChieu.Equals(showTimesID) && ve.TrangThai == 1
                            select ve;

                return query.Count();
            }
        }
        public static int BuyTicket(string ticketID, int type, decimal price)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var ve = (from v in db.Ves
                           where v.id.Equals(ticketID)
                           select v).First();

                ve.TrangThai = 1;
                ve.LoaiVe = type;
                ve.TienBanVe = price;

                //ask the datacontext to save all the changes
                try
                {
                    db.SubmitChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return -1;
                }
            }
        }
        public static int BuyTicket(string ticketID, int type, string customerID, decimal price)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var ve = (from v in db.Ves
                          where v.id.Equals(ticketID)
                          select v).First();

                ve.TrangThai = 1;
                ve.LoaiVe = type;
                ve.idKhachHang = customerID;
                ve.TienBanVe = price;

                //ask the datacontext to save all the changes
                try
                {
                    db.SubmitChanges();
                    return 1;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return -1;
                }
            }
        }

        public static int InsertTicketByShowTimes(string showTimesID, string seatName)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_InsertTicketByShowTimes(showTimesID, seatName);
                    return 1;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return -1;
                }
            }
        }

        public static int DeleteTicketsByShowTimes(string showTimesID)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                try
                {
                    db.USP_DeleteTicketsByShowTimes(showTimesID);
                    return 1;
                }
                catch (Exception e) 
                {
                    MessageBox.Show(e.Message);
                    return -1;
                }
            }
        }

        public static string getCinemaNameByShowTimesId(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from lc in db.LichChieus
                            where lc.id.Equals(id)
                            select lc).First();

                return query.Rap.TenRap;
            }
        }

        public static string getMovieNameByShowTimesId(string id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from lc in db.LichChieus
                             where lc.id.Equals(id)
                             select lc).First();

                return query.Phim.TenPhim;
            }
        }

        public static string getSeatNameByTicketId(int id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = (from ve in db.Ves
                             where ve.id == id
                             select ve).First();

                return query.MaGheNgoi;
            }
        }
    }
}
