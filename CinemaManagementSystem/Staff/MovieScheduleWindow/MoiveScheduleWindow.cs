﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEMA_NEW.Staff.MovieScheduleWindow
{
    public partial class MoiveScheduleWindow : Form
    {
        public MoiveScheduleWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void loadThongTinPhim(int maPhim)
        {

        }
    }
}
