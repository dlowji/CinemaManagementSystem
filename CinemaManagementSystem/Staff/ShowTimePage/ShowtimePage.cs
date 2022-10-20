using CINEMA_NEW.Staff.MovieScheduleWindow;
using CinemaManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEMA_NEW.Staff.ShowtimePage
{
    public partial class ShowtimePage : Form
    {
        private string theLoai = "";
        private string tenPhim = "";
        private string ngayChieu = DateTime.Today.ToString("dd/MM/yyyy");
        public ShowtimePage()
        {
            InitializeComponent();
            loadSuatChieu(tenPhim, theLoai, ngayChieu);
            dtpNgayChieu.Value = DateTime.Today;
            loadCbbTheLoai();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            MoiveScheduleWindow moive = new MoiveScheduleWindow();
            moive.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Text == "Tìm kiếm phim")
            {
                txb.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Text == "")
            {
                txb.Text = "Tìm kiếm phim";
            }
        }

        public void loadSuatChieu(string keyword, string theLoai, string ngayChieu)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                DateTime date = DateTime.ParseExact(ngayChieu, "dd/MM/yyyy", null);

                var query = from sc in db.SuatChieus
                            where sc.CaiDatSuatChieu.NgayChieu.Equals(date)
                            select sc;

                if (theLoai != "")
                {
                    query = from sc in db.SuatChieus
                            where sc.CaiDatSuatChieu.NgayChieu.Equals(date) && sc.Phim.TheLoaiPhim.TenTheLoaiPhim.Equals(theLoai)
                            select sc;
                }

                if (keyword != "")
                {
                    query = from sc in db.SuatChieus
                            where sc.CaiDatSuatChieu.NgayChieu.Equals(date) && sc.Phim.TenPhim.Contains(keyword)
                            select sc;
                }

                fllPhim.Controls.Clear();

                foreach (SuatChieu sc in query)
                {
                    FlowLayoutPanel pn = new FlowLayoutPanel();
                    PictureBox pb = new PictureBox();
                    Label lbTenPhim = new Label();
                    Label lbNamPhatHanh = new Label();

                    int maPhim = sc.Phim.MaPhim;
                    
                    lbTenPhim.AutoSize = true;
                    lbTenPhim.Font = new Font("Microsoft Sans Serif", 12F);
                    lbTenPhim.Name = "lbTenPhim "+maPhim.ToString();
                    lbTenPhim.Size = new Size(142, 20);
                    lbTenPhim.Text = sc.Phim.TenPhim;

                    //for picture box
                    pb.Name = "pb "+ maPhim.ToString();
                    pb.Size = new Size(197, 198);
                    pb.TabStop = false;
                    pb.BorderStyle = BorderStyle.FixedSingle;

                    //for panel
                    pn.BackColor = SystemColors.ButtonFace;
                    pn.BorderStyle = BorderStyle.FixedSingle;
                    pn.Controls.Add(pb);
                    pn.Controls.Add(lbTenPhim);
                    pn.Cursor = Cursors.Hand;
                    pn.ForeColor = SystemColors.ControlText;
                    pn.Name = "pnPhim "+ maPhim.ToString();
                    pn.Size = new Size(203, 277);
                    pn.Click += new EventHandler(pn_Click);

                    //add phim to list
                    fllPhim.Controls.Add(pn);
                }
            }
        }

        private void pn_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel pn = sender as FlowLayoutPanel;

            int maPhim = Int32.Parse(pn.Name.Split(' ')[1]);

            MoiveScheduleWindow formChiTietPhim = new MoiveScheduleWindow();
            formChiTietPhim.loadThongTinPhim(maPhim);
            formChiTietPhim.ShowDialog();
        }

        private void loadCbbTheLoai()
        {
            using (CinemaDataContext db = new CinemaDataContext()) 
            {
                var query = from tl in db.TheLoaiPhims
                            select tl;

                cbbTheLoai.Items.Clear();

                foreach (TheLoaiPhim tl in query)
                {
                    cbbTheLoai.Items.Add(tl.TenTheLoaiPhim);
                }
            }
        }

        private void dtpNgayChieu_ValueChanged(object sender, EventArgs e)
        {
            ngayChieu = dtpNgayChieu.Value.ToString("dd/MM/yyyy");

            loadSuatChieu(tenPhim, theLoai, ngayChieu);
        }

        private void cbbTheLoai_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            theLoai = cbb.SelectedItem.ToString();
            loadSuatChieu(tenPhim, theLoai, ngayChieu);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tenPhim = textBox1.Text;
            loadSuatChieu(tenPhim, theLoai, ngayChieu);
            
        }
    }
}
