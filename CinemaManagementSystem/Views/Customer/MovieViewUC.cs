using CinemaManagementSystem.Controllers;
using GUI;
using GUI.DAO;
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

namespace CinemaManagementSystem.View.Customer
{
    public partial class MovieViewUC : UserControl
    {

        List<Phim> movies = new List<Phim>();
        private string customerId;
        private string workingDirectory;
        private string projectDirectory;
        private Panel homepage;

        private string searchGenre;
        private string searchMovieName;

        public MovieViewUC(Panel homepage, string customerId)
        {
            InitializeComponent();
            this.homepage = homepage;
            this.customerId = customerId;
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            LoadMovieGenre();
            dateTimePicker1.Value = DateTime.Now;
            LoadMovieList();
            LoadMovies();
        }

        private void LoadMovies()
        {
            flpMovies.Controls.Clear();

            foreach (var item in movies)
            {
                //picture box
                PictureBox pb = new PictureBox();
                pb.Size = new Size(196, 180);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                if (pb.Image != null)
                {
                    pb.Image.Dispose();
                    pb.Image = null;
                }

                if (item.ApPhich != null)
                {
                    pb.Image = Image.FromFile(projectDirectory + item.ApPhich);
                    pb.ImageLocation = projectDirectory + item.ApPhich;
                }

                //label for movie name
                Label lbForMovieName = new Label();
                lbForMovieName.AutoSize = true;

                lbForMovieName.Text = item.TenPhim;
                lbForMovieName.Font = new Font("Verdana", 11);

                //label for movie release yeaer
                Label lbForReleaseYear = new Label();

                lbForReleaseYear.Text = item.NamSX.ToString();
                lbForReleaseYear.Font = new Font("Verdana", 11);

                //button for order
                Button btn = new Button();
                btn.AutoSize = true;
                btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(44)))), ((int)(((byte)(34)))));
                btn.Cursor = System.Windows.Forms.Cursors.Hand;
                btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
                btn.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                btn.ForeColor = System.Drawing.Color.White;
                btn.Size = new System.Drawing.Size(118, 35);
                btn.Text = "Đặt phim";
                btn.Tag = item;
                btn.Click += flp_Click;

                //flowlayout panel
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Size = new Size(191, 280);
                flp.Cursor = Cursors.Hand;
                flp.Tag = item;
                flp.FlowDirection = FlowDirection.LeftToRight;
                flp.BorderStyle = BorderStyle.FixedSingle;
                flp.Controls.Add(pb);
                flp.Controls.Add(lbForMovieName);
                flp.Controls.Add(lbForReleaseYear);
                flp.Controls.Add(btn);

                flpMovies.Controls.Add(flp);
            }
        }

        private void flp_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Phim movie = btn.Tag as Phim;
            OrderShowTimes showTimeUC = new OrderShowTimes(customerId, movie, homepage);
            homepage.Controls.Clear();
            showTimeUC.Dock = DockStyle.Fill;
            homepage.Controls.Add(showTimeUC);

        }

        private void LoadMovieList()
        {
            movies = MovieController.FindAll(dateTimePicker1.Value);
        }

        private void LoadMovieListByInputs(string movieName, string genreId, DateTime time)
        {
            if (String.IsNullOrWhiteSpace(movieName))
            {
                movies = MovieController.FindByGenre(genreId, time);
            }
            else
            {
                movies = MovieController.FindByGenre(movieName, genreId, time);
            }
        }

        private void LoadMovieGenre()
        {
            cbbGenre.DataSource = GenreDAO.GetListGenre();
            cbbGenre.DisplayMember = "TenTheLoai";
            cbbGenre.ValueMember = "id";
        }

        private void cbbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchGenre = cbbGenre.SelectedValue.ToString();
            searchMovieName = txbSearchMovie.Text;

            LoadMovieListByInputs(searchMovieName, searchGenre, dateTimePicker1.Value);
            LoadMovies();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cbbGenre_SelectedIndexChanged(cbbGenre, e);
        }

        private void pbSearchMovie_Click(object sender, EventArgs e)
        {
            cbbGenre_SelectedIndexChanged(cbbGenre, e);
        }
    }
}
