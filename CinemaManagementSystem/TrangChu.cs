using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem
{
    public partial class TrangChu : Form
    {
        private string currentRoom = "";
        public TrangChu()
        {
            InitializeComponent();
            loadPhim("");
            loadSuatChieu("", "17/10/2022");
            loadPhongChieu();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void TrangChu_Load(object sender, EventArgs e)
        {

        }

        private void lbQuanLyPhim_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLyPhim;
        }

        private void lbQuanLySuatChieu_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLySuatChieu;
        }

        private void lbQuanLySanPham_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLySanPham;
        }

        private void lbQuanLyNhanSu_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLyNhanSu;
        }

        private void lbQuanLyKhachHang_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLyKhachHang;
        }

        private void lbThongKe_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = ThongKe;
        }

        private void lbLichSu_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = LichSu;
        }

        private void lbVoucher_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = Voucher;
        }

        private void lbSuCo_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLyPhim;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemPhimMoi formThemPhim = new ThemPhimMoi();
            formThemPhim.ShowDialog();
            loadPhim("");
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void lbToanBo_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            lb.ForeColor = Color.FromArgb(37, 110, 162);
        }

        private void lbToanBo_MouseLeave(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            lb.ForeColor = Color.Gray;
        }

        private void lbToanBo_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.Focus();
            currentRoom = label.Text.Split(' ')[1];
            string dateString = dtpNgayChieu.Value.ToString("dd/MM/yyyy");
            string tenPhong = label.Text.Split(' ')[1];
            loadSuatChieu(tenPhong, dateString);
        }

        private void QuanLyPhim_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadSuatChieu(string tenPhong, string ngayChieu)
        {
            using (CinemaDataContext db = new CinemaDataContext()) 
            {
                DateTime date = DateTime.ParseExact(ngayChieu, "dd/MM/yyyy", null);

                var query = from sc in db.SuatChieus
                            where sc.CaiDatSuatChieu.NgayChieu.Equals(date)
                            select sc;

                if (tenPhong != "")
                {
                    query = from sc in db.SuatChieus
                            where sc.CaiDatSuatChieu.NgayChieu.Equals(date) && sc.CaiDatSuatChieu.PhongChieu.TenPhongChieu.Equals(tenPhong)
                            select sc;
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã suất chiếu", typeof(int));
                dt.Columns.Add("Tên phim", typeof(string));
                dt.Columns.Add("Loại phim", typeof(string));
                dt.Columns.Add("Thời lượng", typeof(string));
                dt.Columns.Add("Giờ chiếu", typeof(string));

                foreach (SuatChieu sc in query)
                {
                    dt.Rows.Add(sc.MaSuatChieu, sc.Phim.TenPhim, "2D", sc.Phim.ThoiLuong, sc.ThoiGianBatDau);
                }

                dtgvSuatChieu.DataSource = dt;
                dtgvSuatChieu.Columns[1].Width = 150;
            }
        }

        private void loadPhongChieu()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from pc in db.PhongChieus
                            select pc;
                int startYPosition = 95;
                foreach (PhongChieu pc in query)
                {
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Cursor = Cursors.Hand;
                    label.ForeColor = Color.Gray;
                    label.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
                    label.Location = new Point(7, startYPosition);
                    label.Name = "lbPhong"+pc.TenPhongChieu;
                    label.Size = new Size(67, 21);
                    label.TabIndex = 5;
                    label.Text = "Phòng "+pc.TenPhongChieu;
                    label.MouseLeave += new EventHandler(lbToanBo_MouseLeave);
                    label.MouseHover += new EventHandler(lbToanBo_MouseHover);
                    label.Click += new EventHandler(lbToanBo_Click);

                    QuanLySuatChieu.Controls.Add(label);
                    startYPosition += 30;
                }
            }
        }

        public void loadPhim(string keyword)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var queryAllFilm = from p in db.Phims
                                   where p.DaXoa == false
                                   select p;

                if (keyword != "")
                {
                    queryAllFilm = from p in db.Phims
                                   where p.DaXoa == false && p.TenPhim.Contains(keyword)
                                   select p;
                }
                
                DataTable dt = new DataTable();
                dt.Columns.Add("Mã phim", typeof(int));
                dt.Columns.Add("Tên phim", typeof(string));
                dt.Columns.Add("Loại phim", typeof(string));
                dt.Columns.Add("Quốc gia", typeof(string));
                dt.Columns.Add("Thể loại", typeof(string));
                dt.Columns.Add("Thời lượng (phút)", typeof(string));

                foreach (Phim p in queryAllFilm)
                {
                    dt.Rows.Add(p.MaPhim, p.TenPhim, "2D", p.QuocGia.TenQuocGia, p.TheLoaiPhim.TenTheLoaiPhim, p.ThoiLuong);
                }

                dtgvPhim.DataSource = dt;
                dtgvPhim.Columns[1].Width = 150;
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                int maPhim = Int32.Parse(dtgvPhim.SelectedCells[0].OwningRow.Cells["Mã phim"].Value.ToString());
                ChinhSuaPhim formChinhSuaPhim = new ChinhSuaPhim();
                formChinhSuaPhim.loadThongTinPhim(maPhim);
                formChinhSuaPhim.ShowDialog();
                this.loadPhim("");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                int maPhim = Int32.Parse(dtgvPhim.SelectedCells[0].OwningRow.Cells["Mã phim"].Value.ToString());

                var query = from p in db.Phims
                           where p.MaPhim == maPhim
                           select p;

                foreach (Phim p in query)
                {
                    p.DaXoa = true;
                }

                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
            }
            loadPhim("");
        }

        private void txbTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txbTimKiem.Text;
            loadPhim(keyword);
        }

        private void txbTimKiem_Enter(object sender, EventArgs e)
        {
            if (txbTimKiem.Text == "Tìm kiếm")
            {
                txbTimKiem.Text = "";
            }
        }

        private void txbTimKiem_Leave(object sender, EventArgs e)
        {
            if (txbTimKiem.Text == "")
            {
                txbTimKiem.Text = "Tìm kiếm";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemSuatChieu formThemSuatChieu = new ThemSuatChieu();
            formThemSuatChieu.ShowDialog();
        }

        private void dtpNgayChieu_ValueChanged(object sender, EventArgs e)
        {
            string dateString = dtpNgayChieu.Value.ToString("dd/MM/yyyy");
            loadSuatChieu(currentRoom, dateString);
        }
    }

}
