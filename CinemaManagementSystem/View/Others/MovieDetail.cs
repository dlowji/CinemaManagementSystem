using CinemaManagementSystem.Controllers;
using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem
{
    public partial class MovieDetail : Form
    {
        private Phim movie;
        private string workingDirectory;
        private string projectDirectory;
        public MovieDetail(Phim movie)
        {
            InitializeComponent();
            this.movie = movie;
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MovieDetail_Load(object sender, EventArgs e)
        {
            lbMovieName.Text = movie.TenPhim;
            lbDirector.Text = movie.DaoDien;
            lbActors.Text = movie.DienVien;
            lbStartDate.Text = movie.NgayKhoiChieu.ToShortDateString();
            lbDesc.Text = movie.MoTa;
            lbTimeLength.Text = movie.ThoiLuong.ToString() + " phút";
            pbPoster.Image = Image.FromFile(projectDirectory + movie.ApPhich);

            List<TheLoai> genres = GenreController.GetListGenreByMovieId(movie.id);

            lbGenres.Text = "";

            foreach (var item in genres)
            {
                lbGenres.Text += item.TenTheLoai + ", ";
            }

            lbGenres.Text = lbGenres.Text.Remove(lbGenres.Text.Length - 2, 2);

            KiemDuyetPhim censor = MovieController.GetMovieCensorShipByMovieId(movie.id);
            lbRated.Text = censor.Ten + " - " + censor.MoTa;
        }
    }
}
