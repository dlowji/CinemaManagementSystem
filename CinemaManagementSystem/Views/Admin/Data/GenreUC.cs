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
    public partial class GenreUC : UserControl
    {
        BindingSource genreList = new BindingSource();

        public GenreUC()
        {
            InitializeComponent();
            Helper.ConfigStyle(this);
            LoadGenre();
        }

        void LoadGenre()
        {
            dtgvGenre.DataSource = genreList;
            LoadGenreList();
            AddGenreBinding();
        }
        void LoadGenreList()
        {
            DataTable genres = GenreController.GetDataTableGenre();
            genreList.DataSource = genres;
        }
        void AddGenreBinding()
        {
            txtGenreID.DataBindings.Add("Text", dtgvGenre.DataSource, "Mã thể loại", true, DataSourceUpdateMode.Never);
            txtGenreName.DataBindings.Add("Text", dtgvGenre.DataSource, "Tên thể loại", true, DataSourceUpdateMode.Never);
            txtGenreDesc.DataBindings.Add("Text", dtgvGenre.DataSource, "Mô tả", true, DataSourceUpdateMode.Never);
        }
        private void btnShowGenre_Click(object sender, EventArgs e)
        {
            LoadGenreList();
        }

        void InsertGenre(string id, string name, string desc)
        {
            bool result = GenreController.InsertGenre(id, name, desc);

            if (result)
            {
                MessageBox.Show("Thêm thể loại thành công");
            }
            else
            {
                MessageBox.Show("Thêm thể loại thất bại");
            }
        }
        private void btnInsertGenre_Click(object sender, EventArgs e)
        {
            string GenreID = txtGenreID.Text;
            string GenreName = txtGenreName.Text;
            string GenreDesc = txtGenreDesc.Text;
            InsertGenre(GenreID, GenreName, GenreDesc);
            LoadGenreList();
        }

        void UpdateGenre(string id, string name, string desc)
        {
            bool result = GenreController.UpdateGenre(id, name, desc);

            if (result)
            {
                MessageBox.Show("Sửa thể loại thành công");
            }
            else
            {
                MessageBox.Show("Sửa thể loại thất bại");
            }
        }
        private void btnUpdateGenre_Click(object sender, EventArgs e)
        {
            string GenreID = txtGenreID.Text;
            string GenreName = txtGenreName.Text;
            string GenreDesc = txtGenreDesc.Text;
            UpdateGenre(GenreID, GenreName, GenreDesc);
            LoadGenreList();
        }

        void DeleteGenre(string id)
        {
            bool result = GenreController.DeleteGenre(id);

            if (result)
            {
                MessageBox.Show("Xóa thể loại thành công");
            }
            else
            {
                MessageBox.Show("Xóa thể loại thất bại");
            }
        }
        private void btnDeleteGenre_Click(object sender, EventArgs e)
        {
            string GenreID = txtGenreID.Text;
            DeleteGenre(GenreID);
            LoadGenreList();
        }
    }
}
