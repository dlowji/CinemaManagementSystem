using CinemaManagementSystem;
using CinemaManagementSystem.Controllers;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmSeller : Form
    {
        string staffId;
        public frmSeller(string staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            dtpThoiGian.Enabled = false;
            cboFormatFilm.Enabled = false;
            cbbCineplex.Enabled = false;
        }

        private void frmSeller_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        public void LoadPlayingMovie(DateTime date)
        {
            cboFilmName.DataSource = MovieDAO.GetListPlayingMovieByDate(date);
            cboFilmName.DisplayMember = "TenPhim";
            cboFilmName.ValueMember = "id";
            groupBox1.Text = "Phim đang chiếu:";
        }

        public void LoadComingSoonMovie(DateTime date)
        {
            cboFilmName.DataSource = MovieDAO.GetListComingSoonMovieByDate(date);
            cboFilmName.DisplayMember = "TenPhim";
            cboFilmName.ValueMember = "id";
            groupBox1.Text = "Phim sắp chiếu:";
        }

        private void cboFilmName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilmName.SelectedIndex != -1)
            {
                dtpThoiGian.Enabled = false;
                cboFormatFilm.Enabled = false;
                cbbCineplex.Enabled = false;
                lvLichChieu.Items.Clear();
            }
        }

        private void cboFormatFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormatFilm.SelectedIndex != -1)
            {
                enableCineplex();
            }
        }

        private void cbbCineplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCineplex.SelectedIndex != -1)
            {
                lvLichChieu.Items.Clear();
                LoadListShowTimeByFilm();
            }
            else
            {
                cbbCineplex.SelectedItem = null;
                cbbCineplex.SelectedText = "--Hiện tại không có cụm rạp phù hợp--";
                lvLichChieu.Items.Clear();
            }
        }

        private void LoadListShowTimeByFilm()
        {
            string cinemaTypeId = cboFormatFilm.SelectedValue.ToString();
            string cineplexId = cbbCineplex.SelectedValue.ToString();
            string movieId = cboFilmName.SelectedValue.ToString();
            DataTable data = ShowTimesDAO.GetListShowTimeByValues(cinemaTypeId, cineplexId, movieId, dtpThoiGian.Value);
            if (data == null) return;
            foreach (DataRow row in data.Rows)
            {
                LichChieu showTimes = new LichChieu();

                showTimes.id = row["Mã lịch chiếu"].ToString();
                showTimes.ThoiGianChieu = DateTime.Parse(row["Thời gian chiếu"].ToString());
                showTimes.GiaVe = (decimal)row["Giá vé"];

                ListViewItem lvi = new ListViewItem("");
                lvi.SubItems.Add(TicketDAO.getCinemaNameByShowTimesId(showTimes.id));
                lvi.SubItems.Add(TicketDAO.getMovieNameByShowTimesId(showTimes.id));
                lvi.SubItems.Add(showTimes.ThoiGianChieu.ToShortTimeString());
                lvi.Tag = showTimes;

                string statusShowTimes = TicketDAO.CountTheNumberOfTicketsSoldByShowTime(showTimes.id)
                    + "/" + TicketDAO.CountToltalTicketByShowTime(showTimes.id);

                lvi.SubItems.Add(statusShowTimes);

                float status = (float)TicketDAO.CountTheNumberOfTicketsSoldByShowTime(showTimes.id)
                    / TicketDAO.CountToltalTicketByShowTime(showTimes.id);

                //thêm ảnh status
                if (status == 1)
                    lvi.ImageIndex = 2;
                else if (status > 0.5f)
                    lvi.ImageIndex = 1;
                else lvi.ImageIndex = 0;

                lvLichChieu.Items.Add(lvi);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Load lại form để cập nhật cơ sở dữ liệu
            this.OnLoad(null);
        }

        private void lvLichChieu_Click(object sender, EventArgs e)
        {
            if (lvLichChieu.SelectedItems.Count > 0)
            {
                timer1.Stop();
                LichChieu showTimes = lvLichChieu.SelectedItems[0].Tag as LichChieu;
                Phim movie = cboFilmName.SelectedItem as Phim;
                frmTheatre frm = new frmTheatre(showTimes, movie, staffId);
                this.Hide();
                frm.ShowDialog();
                this.OnLoad(null);
                this.Show();
            }
        }

        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
            enableFormatFilm();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            Phim movie = cboFilmName.SelectedItem as Phim;
            MovieDetail frm = new MovieDetail(movie);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                buyTicket();
            }
        }

        private void btnBuyticket_Click(object sender, EventArgs e)
        {
            buyTicket();
        }

        public void buyTicket()
        {
            enableDate();
            enableFormatFilm();
            loadFormatFilm();
        }

        private void enableDate()
        {
            dtpThoiGian.Enabled = true;
        }

        private void enableFormatFilm()
        {
            cboFormatFilm.Enabled = true;
        }

        private void enableCineplex()
        {
            cbbCineplex.Enabled = true;
            loadCineplex();
        }

        private void loadFormatFilm()
        {
            Phim movie = cboFilmName.SelectedItem as Phim;

            List<LoaiRap> cinemaTypeList = CinemaController.GetListCinemaTypeByMovie(movie.id);
            cboFormatFilm.DataSource = cinemaTypeList;
            cboFormatFilm.DisplayMember = "TenLoaiRap";
            cboFormatFilm.ValueMember = "id";

            if (cinemaTypeList.Count() == 0)
            {
                cboFormatFilm.SelectedItem = null;
                cboFormatFilm.SelectedText = "--Hiện tại không có loại rạp phù hợp--";
            }
        }

        private void loadCineplex()
        {
            string cinemaTypeID = cboFormatFilm.SelectedValue.ToString();
            string movieID = cboFilmName.SelectedValue.ToString();

            List<CumRap> cineplexList = CinemaController.GetListCineplexByCinemaTypeID(cinemaTypeID, movieID, dtpThoiGian.Value);
            cbbCineplex.DataSource = cineplexList;
            cbbCineplex.DisplayMember = "Ten";
            cbbCineplex.ValueMember = "id";

            if (cineplexList.Count() == 0)
            {
                cbbCineplex.SelectedItem = null;
                cbbCineplex.SelectedText = "--Hiện tại không có cụm rạp phù hợp--";
                lvLichChieu.Items.Clear();
            }
        }

        private void dtpThoiGian_ValueChanged_1(object sender, EventArgs e)
        {
            loadFormatFilm();
        }
    }
}
