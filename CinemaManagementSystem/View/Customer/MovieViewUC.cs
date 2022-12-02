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

namespace CinemaManagementSystem.View.Customer
{
    public partial class MovieViewUC : UserControl
    {
        List<Phim> movies = new List<Phim>();
        private string staffId;
        private string workingDirectory;
        private string projectDirectory;

        public MovieViewUC(string staffId)
        {
            InitializeComponent();
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            LoadMovies();
            this.staffId = staffId;
        }

        private void LoadMovies()
        {
            LoadMovieList();

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

                //flowlayout panel
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Size = new Size(191, 259);
                flp.Cursor = Cursors.Hand;
                flp.Tag = item;
                flp.Click += flp_Click;
                flp.FlowDirection = FlowDirection.LeftToRight;
                flp.BorderStyle = BorderStyle.FixedSingle;
                flp.Controls.Add(pb);
                flp.Controls.Add(lbForMovieName);
                flp.Controls.Add(lbForReleaseYear);

                flpMovies.Controls.Add(flp);
            }
        }

        private void flp_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;
            Phim movie = flp.Tag as Phim;
            frmSeller frm = new frmSeller(staffId, movie);
            frm.Show();

        }

        private void LoadMovieList()
        {
            movies = MovieController.findAll();
        }
    }
}
