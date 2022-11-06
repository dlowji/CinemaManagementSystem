using CinemaManagementSystem;
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
            btnBuyticket.Enabled = false;
        }

        private void frmSeller_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void LoadMovie(DateTime date)
        {
            cboFilmName.DataSource = MovieDAO.GetListMovieByDate(date);
            cboFilmName.DisplayMember = "TenPhim";
        }

        public void LoadPlayingMovie(DateTime date)
        {
            cboFilmName.DataSource = MovieDAO.GetListPlayingMovieByDate(date);
            cboFilmName.DisplayMember = "TenPhim";
            groupBox1.Text = "Phim đang chiếu:";
        }

        public void LoadComingSoonMovie(DateTime date)
        {
            cboFilmName.DataSource = MovieDAO.GetListComingSoonMovieByDate(date);
            cboFilmName.DisplayMember = "TenPhim";
            groupBox1.Text = "Phim sắp chiếu:";
        }

        private void cboFilmName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFilmName.SelectedIndex != -1)
            {
                cboFormatFilm.DataSource = null;
                lvLichChieu.Items.Clear();
                loadFormatFilm();
            }
        }

        private void cboFormatFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboFormatFilm.SelectedIndex != -1)
            {
                //lvLichChieu.Items.Clear();
                //DinhDangPhim format = cboFormatFilm.SelectedItem as DinhDangPhim;
                //LoadListShowTimeByFilm(format.id);
                enableCineplex();
            }
        }

        private void cbbCineplex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCineplex.SelectedIndex != -1)
            {
                lvLichChieu.Items.Clear();
                DinhDangPhim format = cboFormatFilm.SelectedItem as DinhDangPhim;
                LoadListShowTimeByFilm(format.id);
            }
        }

        private void LoadListShowTimeByFilm(string formatMovieID)
        {
            DataTable data = ShowTimesDAO.GetListShowTimeByFormatMovie(formatMovieID, dtpThoiGian.Value);
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
            MovieDetail frm = new MovieDetail();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                buyTicket();
            }
        }

        private void btnBuyticket_Click(object sender, EventArgs e)
        {
        }

        public void buyTicket()
        {
            enableDate();
            loadFormatFilm();
            enableFormatFilm();
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
            loadCineplex();
            cbbCineplex.Enabled = true;
        }

        private void loadFormatFilm()
        {
            Phim movie = cboFilmName.SelectedItem as Phim;
            cboFormatFilm.DataSource = FormatMovieDAO.GetListFormatMovieByMovie(movie.id);
            cboFormatFilm.DisplayMember = "idLoaiManHinh";
        }

        private void loadCineplex()
        {
            DinhDangPhim format = cboFormatFilm.SelectedItem as DinhDangPhim;
            cbbCineplex.DataSource = CineplexDAO.GetListCineplexByFormatMovie(format.id, DateTime.Parse(dtpThoiGian.Value.ToShortDateString()));
            cbbCineplex.DisplayMember = "Ten";
        }
    }
}
