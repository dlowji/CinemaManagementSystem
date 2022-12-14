using CinemaManagementSystem;
using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
using GUI.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class ShowTimesUC : UserControl
    {
        BindingSource showtimeList = new BindingSource();
        public ShowTimesUC()
        {
            InitializeComponent();
            Helper.ConfigStyle(this);
            LoadShowtime();
        }

        void LoadShowtime()
        {
            dtgvShowtime.DataSource = showtimeList;
            LoadShowtimeList();
            LoadCinemaIntoComboBox();
            LoadMovieIntoComboBox();
            LoadCinemaTypeIntoComboBox(cboCinemaType);
            LoadCineplexIntoComboBox();
            AddShowtimeBinding();
        }
        void LoadShowtimeList()
        {
            DataTable showTimes = ShowTimeController.GetListShowTimes();

            showtimeList.DataSource = showTimes;
        }
        private void btnShowShowtime_Click(object sender, EventArgs e)
        {
            LoadShowtimeList();
        }

        private void LoadCinemaTypeByCinemaId(string cinemaId)
        {
            LoaiRap loaiRap = CinemaController.GetCinemaTypeByCinemaID(cinemaId);

            if (loaiRap == null)
            {
                return;
            }

            int indexCinemaType = -1;
            int iCinemaType = 0;

            foreach (LoaiRap item in cboCinemaType.Items)
            {
                if (item.TenLoaiRap == loaiRap.TenLoaiRap)
                {
                    indexCinemaType = iCinemaType;
                    break;
                }
                iCinemaType++;
            }
            cboCinemaType.SelectedIndex = indexCinemaType;
        }

        private void LoadCinemaByShowTimeId(string showTimeId)
        {
            LichChieu showTime = ShowTimeController.GetShowTimeById(showTimeId);
            Rap cinema = CinemaController.GetCinemaById(showTime.idRap);

            if (cinema == null)
            {
                return;
            }

            int indexCinema = -1;
            int iCinema = 0;

            foreach (Rap item in cboCinema.Items)
            {
                if (item.id == cinema.id)
                {
                    indexCinema = iCinema;
                    break;
                }
                iCinema++;
            }
            cboCinema.SelectedIndex = indexCinema;
        }

        private void LoadCineplexByCinemaId(string cinemaId)
        {
            CumRap cumRap = CinemaController.GetCineplexByCinemaID(cinemaId);

            if (cumRap == null)
            {
                return;
            }

            int indexCineplex = -1;
            int iCineplex = 0;

            foreach (CumRap item in cboCineplex.Items)
            {
                if (item.Ten == cumRap.Ten)
                {
                    indexCineplex = iCineplex;
                    break;
                }
                iCineplex++;
            }
            cboCineplex.SelectedIndex = indexCineplex;
        }

        private void LoadMovieByShowTimeId(string showTimeId)
        {
            Phim movie = MovieController.GetMovieByShowTime(showTimeId);

            if (movie == null)
            {
                return;
            }

            int indexMovie = -1;
            int iMovie = 0;

            foreach (Phim item in cboMovies.Items)
            {
                if (item.id == movie.id)
                {
                    indexMovie = iMovie;
                    break;
                }
                iMovie++;
            }
            cboCinema.SelectedIndex = indexMovie;
        }

        //Binding
        void AddShowtimeBinding()
        {
            txtShowtimeID.DataBindings.Add("Text", dtgvShowtime.DataSource, "Mã lịch chiếu", true, DataSourceUpdateMode.Never);
            dtmShowtimeDate.DataBindings.Add("Value", dtgvShowtime.DataSource, "Thời gian chiếu", true, DataSourceUpdateMode.Never);
            //dtmShowtimeTime.DataBindings.Add("Value", dtgvShowtime.DataSource, "Thời gian chiếu", true, DataSourceUpdateMode.Never);
            txtTicketPrice_Showtime.DataBindings.Add("Text", dtgvShowtime.DataSource, "Giá vé", true, DataSourceUpdateMode.Never);
        }
        void LoadCineplexIntoComboBox()
        {
            cboCineplex.DataSource = CinemaController.GetListCineplex();
            cboCineplex.DisplayMember = "Ten";
            cboCinema.ValueMember = "id";
        }
        void LoadCinemaTypeIntoComboBox(ComboBox cbo)
        {
            cbo.DataSource = CinemaController.GetListCinemaType();
            cbo.DisplayMember = "TenLoaiRap";
            cbo.ValueMember = "id";
        }

        void LoadCinemaIntoComboBox()
        {
            cboCinema.DataSource = CinemaController.GetCinemas();
            cboCinema.DisplayMember = "TenRap";
            cboCinema.ValueMember = "id";
        }

        void LoadMovieIntoComboBox()
        {
            cboMovies.DataSource = MovieController.GetMovies();
            cboMovies.DisplayMember = "Ten";
            cboMovies.ValueMember = "id";
        }
        private void cboFormatID_Showtime_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cboCineplex.SelectedIndex != -1)
            //{
            //    List<DinhDangPhim> list = FormatMovieDAO.GetFormatMovie();
            //    DinhDangPhim formatMovieSelecting = list[cboCineplex.SelectedIndex];

            //    txtMovieName_Showtime.Text = FormatMovieDAO.getMovieNameByFormatMovieId(formatMovieSelecting.id);
            //    txtScreenTypeName_Showtime.Text = FormatMovieDAO.getScreenTypeNameByFormatMovieId(formatMovieSelecting.id);

            //    cboCinema.DataSource = null;
            //    LoaiManHinh screenType = CinemaTypeDAO.GetScreenTypeByName(FormatMovieDAO.getScreenTypeNameByFormatMovieId(formatMovieSelecting.id));
            //    cboCinema.DataSource = CinemaDAO.GetCinemaByScreenTypeID(screenType.id);
            //    cboCinema.DisplayMember = "TenPhong";
            //}
        }
        private void txtShowtimeID_TextChanged(object sender, EventArgs e)
        {
            string showTimeId = txtShowtimeID.Text;
            LoadCinemaByShowTimeId(showTimeId);
            string cinemaID = cboCinema.SelectedValue.ToString();

            LoadCinemaTypeByCinemaId(cinemaID);
            LoadCineplexByCinemaId(cinemaID);
            LoadMovieByShowTimeId(showTimeId);
        }

        //Insert
        void InsertShowtime(string id, string cinemaID, string movieId, DateTime time, decimal ticketPrice)
        {
            bool result = ShowTimeController.InsertShowTime(id, cinemaID, movieId, ticketPrice, time);

            if (result)
            {
                MessageBox.Show("Thêm lịch chiếu thành công");
            }
            else
            {
                MessageBox.Show("Thêm lịch chiếu thất bại");
            }
        }
        private void btnInsertShowtime_Click(object sender, EventArgs e)
        {
            string showtimeID = txtShowtimeID.Text;
            string cinemaID = cboCinema.SelectedValue.ToString();
            string movieId = cboMovies.SelectedValue.ToString();
            DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            //Bind dtmShowtimeDate to "time.date" and dtmShowtimeTime to "time.time" ... TODO : Look for a better way to do this
            decimal ticketPrice =  Decimal.Parse(txtTicketPrice_Showtime.Text);
            InsertShowtime(showtimeID, cinemaID, movieId, time, ticketPrice);
            LoadShowtimeList();
        }

        //Update
        void UpdateShowtime(string id, string cinemaID, string movieId, DateTime time, decimal ticketPrice)
        {
            bool result = ShowTimeController.UpdateShowTime(id, cinemaID, movieId, ticketPrice, time);

            if (result)
            {
                MessageBox.Show("Sửa lịch chiếu thành công");
            }
            else
            {
                MessageBox.Show("Sửa lịch chiếu thất bại");
            }
        }
        private void btnUpdateShowtime_Click(object sender, EventArgs e)
        {
            string showtimeID = txtShowtimeID.Text;
            string cinemaID = cboCinema.SelectedValue.ToString();
            string movieId = cboMovies.SelectedValue.ToString();
            DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            //Bind dtmShowtimeDate to "time.date" and dtmShowtimeTime to "time.time" ... TODO : Look for a better way to do this
            decimal ticketPrice = Decimal.Parse(txtTicketPrice_Showtime.Text);
            UpdateShowtime(showtimeID, cinemaID, movieId, time, ticketPrice);
            LoadShowtimeList();
        }

        //Delete
        void DeleteShowtime(string id)
        {
            bool result = ShowTimeController.DeleteShowTime(id);

            if (result)
            {
                MessageBox.Show("Xóa lịch chiếu thành công");
            }
            else
            {
                MessageBox.Show("Xóa lịch chiếu thất bại");
            }
        }
        private void btnDeleteShowtime_Click(object sender, EventArgs e)
        {
            string showtimeID = txtShowtimeID.Text;
            DeleteShowtime(showtimeID);
            LoadShowtimeList();
        }

        //Search
        private void btnSearchShowtime_Click(object sender, EventArgs e)
        {
            string movieName = txtSearchShowtime.Text;
            showtimeList.DataSource = ShowTimesDAO.SearchShowtimeByMovieName(movieName);
        }

		private void txtSearchShowtime_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchShowtime.PerformClick();
                e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboCinema_SelectedValueChanged(object sender, EventArgs e)
        {
            string cinemaID = cboCinema.SelectedValue.ToString();

            //MessageBox.Show(cinemaID);
            //LoadCinemaTypeByCinemaId(cinemaID);
            //LoadCineplexByCinemaId(cinemaID);
        }
    }
}
