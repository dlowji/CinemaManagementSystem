using CinemaManagementSystem;
using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class MovieUC : UserControl
    {
        BindingSource movieList = new BindingSource();
        private string workingDirectory;
        private string projectDirectory;
        private string fileName;
        private string sourcePath;
        private string targetPath;

        public MovieUC()
        {
            InitializeComponent();
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            //Helper.configStyle(this);
            LoadMovie();
        }

        void LoadMovie()
        {
            dtgvMovie.DataSource = movieList;
            LoadMovieList();
            AddMovieBinding();
        }
        void LoadMovieList()
        {
            DataTable movies = MovieController.GetMovie();
            movieList.DataSource = movies;
        }
        private void btnShowMovie_Click(object sender, EventArgs e)
        {
            LoadMovieList();
        }
        void AddMovieBinding()
        {
            txtMovieID.DataBindings.Add("Text", dtgvMovie.DataSource, "Mã phim", true, DataSourceUpdateMode.Never);
            txtMovieName.DataBindings.Add("Text", dtgvMovie.DataSource, "Tên phim", true, DataSourceUpdateMode.Never);
            txtMovieDesc.DataBindings.Add("Text", dtgvMovie.DataSource, "Mô tả", true, DataSourceUpdateMode.Never);
            txtMovieLength.DataBindings.Add("Text", dtgvMovie.DataSource, "Thời lượng", true, DataSourceUpdateMode.Never);
            dtmMovieStart.DataBindings.Add("Value", dtgvMovie.DataSource, "Ngày khởi chiếu", true, DataSourceUpdateMode.Never);
            dtmMovieEnd.DataBindings.Add("Value", dtgvMovie.DataSource, "Ngày kết thúc", true, DataSourceUpdateMode.Never);
            txtMovieProductor.DataBindings.Add("Text", dtgvMovie.DataSource, "Sản xuất", true, DataSourceUpdateMode.Never);
            txtMovieDirector.DataBindings.Add("Text", dtgvMovie.DataSource, "Đạo diễn", true, DataSourceUpdateMode.Never);
            txbActors.DataBindings.Add("Text", dtgvMovie.DataSource, "Diễn viên", true, DataSourceUpdateMode.Never);
            txtMovieYear.DataBindings.Add("Text", dtgvMovie.DataSource, "Năm SX", true, DataSourceUpdateMode.Never);
            LoadGenreIntoCheckedList(clbMovieGenre);
            LoadCensorShipIntoComboBox(cboKiemDuyet);
        }
        void LoadCensorShipIntoComboBox(ComboBox cbo)
        {
            cbo.DataSource = MovieController.GetListCensorShip();
            cbo.DisplayMember = "Ten";
            cbo.ValueMember = "id";
        }

        void LoadGenreIntoCheckedList(CheckedListBox checkedList)
        {
            List<TheLoai> genreList = GenreDAO.GetListGenre();
            checkedList.DataSource = genreList;
            checkedList.DisplayMember = "TenTheLoai";
        }
        private void txtMovieID_TextChanged(object sender, EventArgs e)
        //Use to binding the CheckedListBox Genre of Movie and picture of Movie
        {
            picFilm.Image = null;
            for (int i = 0; i < clbMovieGenre.Items.Count; i++)
            {
                clbMovieGenre.SetItemChecked(i, false);
                //Uncheck all CheckBox first
            }

            List<TheLoai> listGenreOfMovie = MovieByGenreDAO.GetListGenreByMovieID(txtMovieID.Text);
            for (int i = 0; i < clbMovieGenre.Items.Count; i++)
            {
                TheLoai genre = (TheLoai)clbMovieGenre.Items[i];
                foreach (TheLoai item in listGenreOfMovie)
                {
                    if (genre.id == item.id)
                    {
                        clbMovieGenre.SetItemChecked(i, true);
                        break;
                    }
                }
            }

            Phim movie = MovieDAO.GetMovieByID(txtMovieID.Text);

            if (picFilm.Image != null)
            {
                picFilm.Image.Dispose();
                picFilm.Image = null;
           
            }

           if (movie.ApPhich != null)
            {
                picFilm.Image = Image.FromFile(projectDirectory + movie.ApPhich);
                picFilm.ImageLocation = projectDirectory + movie.ApPhich;
            }
        }

        void InsertMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, string actors, int year, string imagePath, string idKiemDuyetPhim)
        {
            bool result = MovieController.InsertMovie(id, name, desc, length, startDate, endDate, productor, director, actors, year, imagePath, idKiemDuyetPhim);

            if (result)
            {
                MessageBox.Show("Thêm phim thành công");
            }
            else
            {
                MessageBox.Show("Thêm phim thất bại");
            }
        }
        void InsertMovie_Genre(string movieID, CheckedListBox checkedListBox)
        //Insert into table 'PhanLoaiPhim'
        {
            List<TheLoai> checkedGenreList = new List<TheLoai>();
            foreach (TheLoai checkedItem in checkedListBox.CheckedItems)
            {
                checkedGenreList.Add(checkedItem);
            }
            MovieByGenreDAO.InsertMovie_Genre(movieID, checkedGenreList);
        }

        private void btnUpLoadPictureFilm_Click(object sender, EventArgs e)
        {
            try
            {
                string filePathImage = null;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Pictures files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png)|*.jpg; *.jpeg; *.jpe; *.jfif; *.png|All files (*.*)|*.*";
                openFile.FilterIndex = 1;
                openFile.RestoreDirectory = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    filePathImage = openFile.FileName;
                    picFilm.Image = Image.FromFile(filePathImage.ToString());

                    sourcePath = Path.GetDirectoryName(openFile.FileName);
                    fileName = Path.GetFileName(openFile.FileName);
                    targetPath = projectDirectory + "/Images";

                    string sourceFile = Path.Combine(sourcePath, fileName);
                    picFilm.ImageLocation = sourceFile;
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void btnAddMovie_Click(object sender, EventArgs e)
        {
            string movieID = txtMovieID.Text;
            string censorShipID = cboKiemDuyet.SelectedValue.ToString();
            string movieName = txtMovieName.Text;
            string movieDesc = txtMovieDesc.Text;
            float movieLength = float.Parse(txtMovieLength.Text);
            DateTime startDate = dtmMovieStart.Value;
            DateTime endDate = dtmMovieEnd.Value;
            string productor = txtMovieProductor.Text;
            string director = txtMovieDirector.Text;
            string actors = txbActors.Text;
            int year = int.Parse(txtMovieYear.Text);
            if (picFilm.Image == null)
            {
                MessageBox.Show("Mời bạn thêm hình ảnh cho phim trước");
                return;
            }

            bool copyResult = Helper.FileCopy(fileName, sourcePath, targetPath);

            if (!copyResult)
            {
                MessageBox.Show("Thêm phim thất bại");
                return;
            }

            string imagePath = picFilm.ImageLocation;
            string storedPath = "/Images/" + Path.GetFileName(imagePath);

            InsertMovie(movieID, movieName, movieDesc, movieLength, startDate, endDate, productor, director, actors, year, storedPath, censorShipID);
            InsertMovie_Genre(movieID, clbMovieGenre);
            LoadMovieList();
        }

        void UpdateMovie(string id, string name, string desc, float length, DateTime startDate, DateTime endDate, string productor, string director, string actors, int year, string imagePath, string idKiemDuyetPhim)
        {
            bool result = MovieController.UpdateMovie(id, name, desc, length, startDate, endDate, productor, director, actors, year, imagePath, idKiemDuyetPhim);

            if (result)
            {
                MessageBox.Show("Sửa phim thành công");
            }
            else
            {
                MessageBox.Show("Sửa phim thất bại");
            }
        }
        void UpdateMovie_Genre(string movieID, CheckedListBox checkedListBox)
        {
            List<TheLoai> checkedGenreList = new List<TheLoai>();
            foreach (TheLoai checkedItem in checkedListBox.CheckedItems)
            {
                checkedGenreList.Add(checkedItem);
            }
            MovieByGenreDAO.UpdateMovie_Genre(movieID, checkedGenreList);
        }
        private void btnUpdateMovie_Click(object sender, EventArgs e)
        {
            string movieID = txtMovieID.Text;
            string censorShipID = cboKiemDuyet.SelectedValue.ToString();
            string movieName = txtMovieName.Text;
            string movieDesc = txtMovieDesc.Text;
            float movieLength = float.Parse(txtMovieLength.Text);
            DateTime startDate = dtmMovieStart.Value;
            DateTime endDate = dtmMovieEnd.Value;
            string productor = txtMovieProductor.Text;
            string director = txtMovieDirector.Text;
            string actors = txbActors.Text;
            int year = int.Parse(txtMovieYear.Text);
            if (picFilm.Image == null)
            {
                MessageBox.Show("Mời bạn thêm hình ảnh cho phim trước");
                return;
            }

            bool copyResult = Helper.FileCopy(fileName, sourcePath, targetPath);

            if (!copyResult)
            {
                MessageBox.Show("Sửa phim thất bại");
                return;
            }

            string imagePath = picFilm.ImageLocation;
            string storedPath = "/Images/" + Path.GetFileName(imagePath);

            UpdateMovie(movieID, movieName, movieDesc, movieLength, startDate, endDate, productor, director, actors, year, storedPath, censorShipID);
            UpdateMovie_Genre(movieID, clbMovieGenre);
            LoadMovieList();
        }

        void DeleteMovie(string id)
        {
            if (MovieDAO.DeleteMovie(id))
            {
                MessageBox.Show("Xóa phim thành công");
            }
            else
            {
                MessageBox.Show("Xóa phim thất bại");
            }
        }
        private void btnDeleteMovie_Click(object sender, EventArgs e)
        {
            string movieID = txtMovieID.Text;
            DeleteMovie(movieID);
            LoadMovieList();
        }
    }
}
