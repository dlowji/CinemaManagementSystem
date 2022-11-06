﻿using CinemaManagementSystem.Admin;
using GUI.frmAdminUserControls.DataUserControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem.Admin.Data
{
    public partial class DataForm : Form
    {
        public DataForm()
        {
            InitializeComponent();
        }

        private void btnScreenTypeUC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnScreenTypeUC.Height;
            SidePanel.Top = btnScreenTypeUC.Top;
            pnData.Controls.Clear();
            ScreenTypeUC screenType = new ScreenTypeUC();
            screenType.Dock = DockStyle.Fill;
            pnData.Controls.Add(screenType);
        }

        private void btnCinemaUC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnCinemaUC.Height;
            SidePanel.Top = btnCinemaUC.Top;
            pnData.Controls.Clear();
            CinemaUC cinemaUc = new CinemaUC();
            cinemaUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(cinemaUc);
        }

        private void btnGenreUC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnGenreUC.Height;
            SidePanel.Top = btnGenreUC.Top;
            pnData.Controls.Clear();
            GenreUC genreUc = new GenreUC();
            genreUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(genreUc);
        }

        private void btnMovieUC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnMovieUC.Height;
            SidePanel.Top = btnMovieUC.Top;
            pnData.Controls.Clear();
            MovieUC movieUc = new MovieUC();
            movieUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(movieUc);
        }

        private void btnFormatMovieUC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnFormatMovieUC.Height;
            SidePanel.Top = btnFormatMovieUC.Top;
            pnData.Controls.Clear();
            FormatMovieUC formatMovieUc = new FormatMovieUC();
            formatMovieUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(formatMovieUc);
        }

        private void btnShowTimesUC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnShowTimesUC.Height;
            SidePanel.Top = btnShowTimesUC.Top;
            pnData.Controls.Clear();
            ShowTimesUC showTimesUc = new ShowTimesUC();
            showTimesUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(showTimesUc);
        }

        private void btnTicketsUC_Click(object sender, EventArgs e)
        {
            SidePanel.Height = btnTicketsUC.Height;
            SidePanel.Top = btnTicketsUC.Top;
            pnData.Controls.Clear();
            TicketsUC ticketsUc = new TicketsUC();
            ticketsUc.Dock = DockStyle.Fill;
            pnData.Controls.Add(ticketsUc);
        }
    }
}
