﻿using CinemaManagementSystem;
using CinemaManagementSystem.Helper;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class FormatMovieUC : UserControl
    {
        BindingSource formatList = new BindingSource();

        public FormatMovieUC()
        {
            InitializeComponent();
            configStyle();
            LoadFormatMovie();
        }

        private void configStyle()
        {
            List<Control> allControls = Helper.GetAllControls(this);
            allControls.ForEach(k => k.Font = new Font("Verdana", 11));
            allControls.ForEach(k => k.ForeColor = ColorTranslator.FromHtml("#000006"));
        }

        void LoadFormatMovie()
        {
            dtgvFormat.DataSource = formatList;
            LoadFormatMovieList();
            LoadMovieIDIntoCombobox(cboFormat_MovieID);
            LoadScreenIDIntoCombobox(cboFormat_ScreenID);
            AddFormatBinding();
        }
        void LoadMovieIDIntoCombobox(ComboBox comboBox)
        {
            comboBox.DataSource = MovieDAO.GetListMovie();
            comboBox.DisplayMember = "ID";
            comboBox.ValueMember = "ID";
        }
        private void cboFormat_MovieID_SelectedValueChanged(object sender, EventArgs e)
        //Display the MovieName when MovieID changed
        {
            Phim movieSelected = cboFormat_MovieID.SelectedItem as Phim;
            txtFormat_MovieName.Text = movieSelected.TenPhim;
        }
        void LoadScreenIDIntoCombobox(ComboBox comboBox)
        {
            //comboBox.DataSource = CinemaTypeDAO.GetListScreenType();
            //comboBox.DisplayMember = "ID";
            //comboBox.ValueMember = "ID";
        }
        private void cboFormat_ScreenID_SelectedValueChanged(object sender, EventArgs e)
        {
            //LoaiManHinh screenTypeSelected = cboFormat_ScreenID.SelectedItem as LoaiManHinh;
            //txtFormat_ScreenName.Text = screenTypeSelected.TenMH;
        }
        void LoadFormatMovieList()
        {
            formatList.DataSource = FormatMovieDAO.GetListFormatMovie();
        }

        void AddFormatBinding()
        {
            txtFormatID.DataBindings.Add("Text", dtgvFormat.DataSource, "Mã định dạng", true, DataSourceUpdateMode.Never);
        }
        private void txtFormatID_TextChanged(object sender, EventArgs e)
        {
            string movieID = (string)dtgvFormat.SelectedCells[0].OwningRow.Cells["Mã phim"].Value;
            Phim movieSelecting = MovieDAO.GetMovieByID(movieID);
            ////This is the Movie that we're currently selecting in dtgv

            if (movieSelecting == null)
                return;

            //cboFormat_MovieID.SelectedItem = movieSelecting;

            int indexMovie = -1;
            int iMovie = 0;
            foreach (Phim item in cboFormat_MovieID.Items)
            {
                if (item.TenPhim == movieSelecting.TenPhim)
                {
                    indexMovie = iMovie;
                    break;
                }
                iMovie++;
            }
            cboFormat_MovieID.SelectedIndex = indexMovie;


            string screenName = (string)dtgvFormat.SelectedCells[0].OwningRow.Cells["Tên MH"].Value;
            LoaiRap screenTypeSelecting = CinemaTypeDAO.GetScreenTypeByName(screenName);
            //This is the ScreenType that we're currently selecting in dtgv

            if (screenTypeSelecting == null)
                return;

            //cboFormat_ScreenID.SelectedItem = screenTypeSelecting;

            int indexScreen = -1;
            int iScreen = 0;
            foreach (LoaiRap item in cboFormat_ScreenID.Items)
            {
                if (item.TenLoaiRap == screenTypeSelecting.TenLoaiRap)
                {
                    indexScreen = iScreen;
                    break;
                }
                iScreen++;
            }
            cboFormat_ScreenID.SelectedIndex = indexScreen;
        }

        private void btnShowFormat_Click(object sender, EventArgs e)
        {
            LoadFormatMovieList();
        }

        void InsertFormat(string id, string idMovie, string idScreen)
        {
            if (FormatMovieDAO.InsertFormatMovie(id, idMovie, idScreen))
            {
                MessageBox.Show("Thêm định dạng thành công");
            }
            else
            {
                MessageBox.Show("Thêm định dạng thất bại");
            }
        }
        private void btnInsertFormat_Click(object sender, EventArgs e)
        {
            string formatID = txtFormatID.Text;
            string movieID = cboFormat_MovieID.SelectedValue.ToString();
            string screenID = cboFormat_ScreenID.SelectedValue.ToString();
            InsertFormat(formatID, movieID, screenID);
            LoadFormatMovieList();
        }

        void UpdateFormat(string id, string idMovie, string idScreen)
        {
            if (FormatMovieDAO.UpdateFormatMovie(id, idMovie, idScreen))
            {
                MessageBox.Show("Sửa định dạng thành công");
            }
            else
            {
                MessageBox.Show("Sửa định dạng thất bại");
            }
        }
        private void btnUpdateFormat_Click(object sender, EventArgs e)
        {
            string formatID = txtFormatID.Text;
            string movieID = cboFormat_MovieID.SelectedValue.ToString();
            string screenID = cboFormat_ScreenID.SelectedValue.ToString();
            UpdateFormat(formatID, movieID, screenID);
            LoadFormatMovieList();
        }

        void DeleteFormat(string id)
        {
            if (FormatMovieDAO.DeleteFormatMovie(id))
            {
                MessageBox.Show("Xóa định dạng thành công");
            }
            else
            {
                MessageBox.Show("Xóa định dạng thất bại");
            }
        }
        private void btnDeleteFormat_Click(object sender, EventArgs e)
        {
            string formatID = txtFormatID.Text;
            DeleteFormat(formatID);
            LoadFormatMovieList();
        }
    }
}
