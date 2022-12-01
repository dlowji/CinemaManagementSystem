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
            Helper.configStyle(this);
            LoadShowtime();
        }

        void LoadShowtime()
        {
            dtgvShowtime.DataSource = showtimeList;
            LoadShowtimeList();
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
            //#region Change selected index of ComboBox FormatMovie
            //string movieName = (string)dtgvShowtime.SelectedCells[0].OwningRow.Cells["Tên phim"].Value;
            //string screenTypeName = (string)dtgvShowtime.SelectedCells[0].OwningRow.Cells["Màn hình"].Value;
            //DinhDangPhim formatMovieSelecting = FormatMovieDAO.GetFormatMovieByName(movieName, screenTypeName);
            //if (formatMovieSelecting == null)
            //    return;
            //int indexFormatMovie = -1;
            //for (int i = 0; i < cboCineplex.Items.Count; i++)
            //{
            //    DinhDangPhim item = cboCineplex.Items[i] as DinhDangPhim;
            //    if (item.id == formatMovieSelecting.id)
            //    {
            //        indexFormatMovie = i;
            //        break;
            //    }
            //}
            //cboCineplex.SelectedIndex = indexFormatMovie;
            //#endregion
            //#region Change selected index of ComboBox Cinema
            //string cinemaID = (string)dtgvShowtime.SelectedCells[0].OwningRow.Cells["Mã phòng"].Value;
            //PhongChieu cinemaSelecting = CinemaDAO.GetCinemaByID(cinemaID);
            ////This is the Cinema that we're currently selecting in dtgv

            //if (cinemaSelecting == null)
            //    return;

            //int indexCinema = -1;
            //int iCinema = 0;
            //foreach (PhongChieu item in cboCinema.Items)
            //{
            //    if (item.id == cinemaSelecting.id)
            //    {
            //        indexCinema = iCinema;
            //        break;
            //    }
            //    iCinema++;
            //}
            //cboCinema.SelectedIndex = indexCinema;
            //#endregion
            //toolTipCinema.SetToolTip(cboCinema, "Danh sách phòng chiếu hỗ trợ loại màn hình trên");
        }

        //Insert
        void InsertShowtime(string id, string cinemaID, string formatMovieID, DateTime time, float ticketPrice)
        {
            //bool result = ShowTimeController.InsertShowTime();

            //if (result)
            //{
            //    MessageBox.Show("Thêm lịch chiếu thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Thêm lịch chiếu thất bại");
            //}
        }
        private void btnInsertShowtime_Click(object sender, EventArgs e)
        {
            //string showtimeID = txtShowtimeID.Text;
            //string cinemaID = ((PhongChieu)cboCinema.SelectedItem).id;
            //string formatMovieID = ((DinhDangPhim)cboCineplex.SelectedItem).id;
            //DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            ////Bind dtmShowtimeDate to "time.date" and dtmShowtimeTime to "time.time" ... TODO : Look for a better way to do this
            //float ticketPrice = float.Parse(txtTicketPrice_Showtime.Text);
            //InsertShowtime(showtimeID, cinemaID, formatMovieID, time, ticketPrice);
            //LoadShowtimeList();
        }

        //Update
        void UpdateShowtime(string id, string cinemaID, string formatMovieID, DateTime time, float ticketPrice)
        {
            //bool result = ShowTimeController.UpdateShowTime();

            //if (result)
            //{
            //    MessageBox.Show("Sửa lịch chiếu thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Sửa lịch chiếu thất bại");
            //}
        }
        private void btnUpdateShowtime_Click(object sender, EventArgs e)
        {
            //string showtimeID = txtShowtimeID.Text;
            //string cinemaID = ((PhongChieu)cboCinema.SelectedItem).id;
            //string formatMovieID = ((DinhDangPhim)cboCineplex.SelectedItem).id;
            //DateTime time = new DateTime(dtmShowtimeDate.Value.Year, dtmShowtimeDate.Value.Month, dtmShowtimeDate.Value.Day, dtmShowtimeTime.Value.Hour, dtmShowtimeTime.Value.Minute, dtmShowtimeTime.Value.Second);
            ////Bind dtmShowtimeDate to "time.date" and dtmShowtimeTime to "time.time" ... TODO : Look for a better way to do this
            //float ticketPrice = float.Parse(txtTicketPrice_Showtime.Text);
            //UpdateShowtime(showtimeID, cinemaID, formatMovieID, time, ticketPrice);
            //LoadShowtimeList();
        }

        //Delete
        void DeleteShowtime(string id)
        {
            //bool result = ShowTimeController.DeleteShowTime(id);

            //if (result)
            //{
            //    MessageBox.Show("Xóa lịch chiếu thành công");
            //}
            //else
            //{
            //    MessageBox.Show("Xóa lịch chiếu thất bại");
            //}
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
    }
}
