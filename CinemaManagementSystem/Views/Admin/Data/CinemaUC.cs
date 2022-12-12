using CinemaManagementSystem;
using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class CinemaUC : UserControl
    {
        BindingSource cinemaList = new BindingSource();
        public CinemaUC()
        {
            InitializeComponent();
            Helper.ConfigStyle(this);
            LoadCinema();
        }

        void LoadCinema()
        {
            dtgvCinema.DataSource = cinemaList;
            LoadCinemaList();
            LoadCinemaTypeIntoComboBox(cboCinemaType);
            LoadCineplexIntoComboBox(cboCineplex);
            AddCinemaBinding();
        }
        void LoadCinemaList()
        {
            DataTable cinemas = CinemaController.GetListCinema();

            cinemaList.DataSource = cinemas;
        }
        void AddCinemaBinding()
        {
            txtCinemaID.DataBindings.Add("Text", dtgvCinema.DataSource, "Mã rạp", true, DataSourceUpdateMode.Never);
            txtCinemaName.DataBindings.Add("Text", dtgvCinema.DataSource, "Tên rạp", true, DataSourceUpdateMode.Never);
            txtCinemaSeats.DataBindings.Add("Text", dtgvCinema.DataSource, "Số chỗ ngồi", true, DataSourceUpdateMode.Never);
            txtCinemaStatus.DataBindings.Add("Text", dtgvCinema.DataSource, "Tình trạng", true, DataSourceUpdateMode.Never);
            txtNumberOfRows.DataBindings.Add("Text", dtgvCinema.DataSource, "Số hàng ghế", true, DataSourceUpdateMode.Never);
            txtSeatsPerRow.DataBindings.Add("Text", dtgvCinema.DataSource, "Ghế mỗi hàng", true, DataSourceUpdateMode.Never);
        }
        void LoadCinemaTypeIntoComboBox(ComboBox cbo)
        {
            cbo.DataSource = CinemaController.GetListCinemaType();
            cbo.DisplayMember = "TenLoaiRap";
            cbo.ValueMember = "id";
        }

        void LoadCineplexIntoComboBox(ComboBox cbo)
        {
            cbo.DataSource = CinemaController.GetListCineplex();
            cbo.DisplayMember = "Ten";
            cbo.ValueMember = "id";
        }

        void InsertCinema(string id, string tenRap, int soChoNgoi, int tinhTrang, int soHangGhe, int soGheMotHang, string idLoaiRap, string idCumRap)
        {
            bool result = CinemaController.InsertCinema(id, tenRap, soChoNgoi, tinhTrang, soHangGhe, soGheMotHang, idLoaiRap, idCumRap);

            if (result)
            {
                MessageBox.Show("Thêm rạp chiếu thành công");
            }
            else
            {
                MessageBox.Show("Thêm rạp chiếu thất bại");
            }
        }
        private void btnInsertCinema_Click(object sender, EventArgs e)
        {
            string cinemaID = txtCinemaID.Text;
            string cinemaName = txtCinemaName.Text;
            string cinemaTypeID = cboCinemaType.SelectedValue.ToString();
            string cineplexID = cboCineplex.SelectedValue.ToString();
            int cinemaSeats = int.Parse(txtCinemaSeats.Text);
            int cinemaStatus = txtCinemaStatus.Text == "Đang hoạt động" ? 1 : 0;
            int numberOfRows = int.Parse(txtNumberOfRows.Text);
            int seatsPerRows = int.Parse(txtSeatsPerRow.Text);
            InsertCinema(cinemaID, cinemaName, cinemaSeats, cinemaStatus, numberOfRows, seatsPerRows, cinemaTypeID, cineplexID);
            LoadCinemaList();
        }

        void UpdateCinema(string id, string tenRap, int soChoNgoi, int tinhTrang, int soHangGhe, int soGheMotHang, string idLoaiRap, string idCumRap)
        {
            bool result = CinemaController.UpdateCinema(id, tenRap, soChoNgoi, tinhTrang, soHangGhe, soGheMotHang, idLoaiRap, idCumRap);

            if (result)
            {
                MessageBox.Show("Sửa rạp chiếu thành công");
            }
            else
            {
                MessageBox.Show("Sửa rạp chiếu thất bại");
            }
        }
        private void btnUpdateCinema_Click(object sender, EventArgs e)
        {
            string cinemaID = txtCinemaID.Text;
            string cinemaName = txtCinemaName.Text;
            string cinemaTypeID = cboCinemaType.SelectedValue.ToString();
            string cineplexID = cboCineplex.SelectedValue.ToString();
            int cinemaSeats = int.Parse(txtCinemaSeats.Text);
            int cinemaStatus = txtCinemaStatus.Text == "Đang hoạt động" ? 1 : 0;
            int numberOfRows = int.Parse(txtNumberOfRows.Text);
            int seatsPerRows = int.Parse(txtSeatsPerRow.Text);
            UpdateCinema(cinemaID, cinemaName, cinemaSeats, cinemaStatus, numberOfRows, seatsPerRows, cinemaTypeID, cineplexID);
            LoadCinemaList();
        }

        void DeleteCinema(string id)
        {
            bool result = CinemaController.DeleteCinema(id);

            if (result)
            {
                MessageBox.Show("Xóa rạp chiếu thành công");
            }
            else
            {
                MessageBox.Show("Xóa rạp chiếu thất bại");
            }
        }
        private void btnDeleteCinema_Click(object sender, EventArgs e)
        {
            string cinemaID = txtCinemaID.Text;
            DeleteCinema(cinemaID);
            LoadCinemaList();
        }

        private void txtCinemaID_TextChanged(object sender, EventArgs e)
        {
            string cinemaID = txtCinemaID.Text;
            LoadCinemaTypeByCinemaId(cinemaID);
            LoadCineplexByCinemaId(cinemaID);
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
    }
}
