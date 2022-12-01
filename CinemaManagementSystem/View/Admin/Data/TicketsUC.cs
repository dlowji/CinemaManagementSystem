using CinemaManagementSystem;
using CinemaManagementSystem.Helper;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Windows.Forms;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class TicketsUC : UserControl
    {
        public TicketsUC()
        {
            InitializeComponent();
            Helper.configStyle(this);
            LoadAllListShowTimes();
        }
        void LoadAllListShowTimes()
        {
            lsvAllListShowTimes.Items.Clear();

            List<LichChieu> allListShowTime = ShowTimesDAO.GetAllListShowTimes();

            foreach (LichChieu showTimes in allListShowTime)
            {
                ListViewItem lvi = new ListViewItem(TicketDAO.getCinemaNameByShowTimesId(showTimes.id));
                lvi.SubItems.Add(TicketDAO.getMovieNameByShowTimesId(showTimes.id));
                lvi.SubItems.Add(showTimes.ThoiGianChieu.ToString("HH:mm:ss dd/MM/yyyy"));
                lvi.Tag = showTimes;

                if (showTimes.TrangThai == 1)
                {
                    lvi.SubItems.Add("Đã tạo");
                }
                else
                {
                    lvi.SubItems.Add("Chưa Tạo");
                }
                lsvAllListShowTimes.Items.Add(lvi);
            }
        }

        void LoadTicketsByShowTimes(string showTimesID)
        {
            List<Ve> listTicket = TicketDAO.GetListTicketsByShowTimes(showTimesID);
            DataTable dt = new DataTable();

            dt.Columns.Add("Mã vé", typeof(int));
            dt.Columns.Add("Loại vé", typeof(string));
            dt.Columns.Add("Mã lịch chiếu", typeof(string));
            dt.Columns.Add("Mã ghế ngồi", typeof(string));
            dt.Columns.Add("Mã khách hàng", typeof(string));
            dt.Columns.Add("Trạng thái", typeof(string));
            dt.Columns.Add("Tiền bán vé", typeof(string));

            foreach (var item in listTicket)
            {
                string represent = Helper.getTicketTypeRepresentation((int)item.LoaiVe);
                string payStatus = (item.TrangThai == 0) ? "Chưa bán" : "Đã bán";
                decimal price = (decimal)item.TienBanVe;

                dt.Rows.Add(item.id, represent, item.idLichChieu, item.MaGheNgoi, item.idKhachHang, payStatus, price.ToString("0.##"));
            }

            dtgvTicket.DataSource = dt;
        }
        void LoadTicketsBoughtByShowTimes(string showTimesID)
        {
            List<Ve> listTicket = TicketDAO.GetListTicketsBoughtByShowTimes(showTimesID);
            dtgvTicket.DataSource = listTicket;
        }

        void AutoCreateTicketsByShowTimesId(string showTimesId)
        {
            int result = 0;
            Rap cinema = CinemaDAO.GetCinemaByName(TicketDAO.getCinemaNameByShowTimesId(showTimesId));
            int Row = cinema.SoHangGhe;
            int Column = cinema.SoGheMotHang;
            for (int i = 0; i < Row; i++)
            {
                int temp = i + 65;
                char nameRow = (char)(temp);
                for (int j = 1; j <= Column; j++)
                {
                    string seatName = nameRow.ToString() + j;
                    result += TicketDAO.InsertTicketByShowTimes(showTimesId, seatName);
                }
            }
            if (result == Row * Column)
            {
                int ret = ShowTimesDAO.UpdateStatusShowTimes(showTimesId, 1);
                if (ret > 0)
                    MessageBox.Show("TẠO VÉ TỰ ĐỘNG THÀNH CÔNG!", "THÔNG BÁO");
            }
            else
                MessageBox.Show("TẠO VÉ TỰ ĐỘNG THẤT BẠI!", "THÔNG BÁO");
        }

        private void btnAddTicketsByShowTime_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                string cinemaName = lsvAllListShowTimes.SelectedItems[0].Text;

                int trangThai = ShowTimesDAO.getShowTimesStatusByCinemaName(cinemaName);

                if (trangThai == 1)
                {
                    MessageBox.Show("LỊCH CHIẾU NÀY ĐÃ ĐƯỢC TẠO VÉ!!!", "THÔNG BÁO");
                    return;
                }

                string showTimesId = ShowTimesDAO.getShowTimesIdByCinemaName(cinemaName);
                AutoCreateTicketsByShowTimesId(showTimesId);
                LoadAllListShowTimes();
                LoadTicketsByShowTimes(showTimesId);
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ TẠO!!!", "THÔNG BÁO");
            }
        }

        private void lsvAllListShowTimes_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                string cinemaName = lsvAllListShowTimes.SelectedItems[0].Text;

                string id = ShowTimesDAO.getShowTimesIdByCinemaName(cinemaName);

                LoadTicketsByShowTimes(ShowTimesDAO.getShowTimesIdByCinemaName(cinemaName));
            }
        }

        private void btnDeleteTicketsByShowTime_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                string cinemaName = lsvAllListShowTimes.SelectedItems[0].Text;

                int trangThai = ShowTimesDAO.getShowTimesStatusByCinemaName(cinemaName);

                if (trangThai == 0)
                {
                    MessageBox.Show("LỊCH CHIẾU NÀY CHƯA ĐƯỢC TẠO VÉ!!!", "THÔNG BÁO");
                    return;
                }
                DeleteTicketsByShowTimesId(ShowTimesDAO.getShowTimesIdByCinemaName(cinemaName));
                LoadAllListShowTimes();
                LoadTicketsByShowTimes(ShowTimesDAO.getShowTimesIdByCinemaName(cinemaName));
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ XÓA!!!", "THÔNG BÁO");
            }
        }

        private void DeleteTicketsByShowTimesId(string showTimesId)
        {
            Rap cinema = CinemaDAO.GetCinemaByName(TicketDAO.getCinemaNameByShowTimesId(showTimesId));
            int Row = cinema.SoHangGhe;
            int Column = cinema.SoGheMotHang;
            int result = TicketDAO.DeleteTicketsByShowTimes(showTimesId);
            if (result == Row * Column)
            {
                int ret = ShowTimesDAO.UpdateStatusShowTimes(showTimesId, 0);
                if (ret > 0)
                    MessageBox.Show("XÓA TẤT CẢ CÁC VÉ CỦA LỊCH CHIẾU ID=" + showTimesId + " THÀNH CÔNG!", "THÔNG BÁO");
            }
            else
                MessageBox.Show("XÓA TẤT CẢ CÁC VÉ CỦA LỊCH CHIẾU ID=" + showTimesId + " THẤT BẠI!", "THÔNG BÁO");
        }

        private void btnAllListShowTimes_Click(object sender, EventArgs e)
        {
            LoadAllListShowTimes();
        }

        private void btnShowShowTimeNotCreateTickets_Click(object sender, EventArgs e)
        {
            LoadListShowTimesNotCreateTickets();
        }

        private void LoadListShowTimesNotCreateTickets()
        {
            lsvAllListShowTimes.Items.Clear();

            List<LichChieu> allListShowTime = ShowTimesDAO.GetListShowTimesNotCreateTickets();
            foreach (LichChieu showTimes in allListShowTime)
            {
                ListViewItem lvi = new ListViewItem(TicketDAO.getCinemaNameByShowTimesId(showTimes.id));
                lvi.SubItems.Add(TicketDAO.getMovieNameByShowTimesId(showTimes.id));
                lvi.SubItems.Add(showTimes.ThoiGianChieu.ToString("HH:mm:ss dd/MM/yyyy"));
                lvi.Tag = showTimes;

                if (showTimes.TrangThai == 1)
                {
                    lvi.SubItems.Add("Đã tạo");
                }
                else
                {
                    lvi.SubItems.Add("Chưa Tạo");
                }
                lsvAllListShowTimes.Items.Add(lvi);
            }
        }

        private void btnShowAllTicketsBoughtByShowTime_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                string cinemaName = lsvAllListShowTimes.SelectedItems[0].Text;

                LoadTicketsBoughtByShowTimes(ShowTimesDAO.getShowTimesIdByCinemaName(cinemaName));
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ XEM!!!", "THÔNG BÁO");
            }
        }

        private void btnShowAllTicketsByShowTime_Click(object sender, EventArgs e)
        {
            if (lsvAllListShowTimes.SelectedItems.Count > 0)
            {
                string cinemaName = lsvAllListShowTimes.SelectedItems[0].Text;

                LoadTicketsByShowTimes(ShowTimesDAO.getShowTimesIdByCinemaName(cinemaName));
            }
            else
            {
                MessageBox.Show("BẠN CHƯA CHỌN LỊCH CHIẾU ĐỂ XEM!!!", "THÔNG BÁO");
            }
        }
    }
}
