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
        private List<String> thangs;
        private List<String> nams;
        public TrangChu()
        {
            InitializeComponent();
            thangs = new List<String>();
            nams = new List<String>();
            cbbTimKiemKhachHang.SelectedIndex = 0;
            cbbThangNam.SelectedIndex = 0;
            loadNam();
            loadThang();
            loadPhim("");
            loadSuatChieu("", DateTime.Today.ToString("dd/MM/yyyy"));
            loadPhongChieu();
            loadNhanVien();
            loadKhachHang();
        }

        private void loadNam()
        {
            nams.Add("2021");
            nams.Add("2022");
        }

        private void loadThang()
        {
            thangs.Add("Tháng 1");
            thangs.Add("Tháng 2");
            thangs.Add("Tháng 3");
            thangs.Add("Tháng 4");
            thangs.Add("Tháng 5");
            thangs.Add("Tháng 6");
            thangs.Add("Tháng 7");
            thangs.Add("Tháng 8");
            thangs.Add("Tháng 9");
            thangs.Add("Tháng 10");
            thangs.Add("Tháng 11");
            thangs.Add("Tháng 12");
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

            if (label.Text == "Toàn bộ")
            {
                loadSuatChieu("", dateString);
                return;
            }

            string tenPhong = label.Text.Split(' ')[1];
            currentRoom = tenPhong;
            loadSuatChieu(tenPhong, dateString);
        }

        private void QuanLyPhim_Click(object sender, EventArgs e)
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
            loadSuatChieu("", DateTime.Today.ToString("dd/MM/yyyy"));
        }

        private void dtpNgayChieu_ValueChanged(object sender, EventArgs e)
        {
            string dateString = dtpNgayChieu.Value.ToString("dd/MM/yyyy");
            loadSuatChieu(currentRoom, dateString);
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            int maSuatChieu = Int32.Parse(dtgvSuatChieu.SelectedCells[0].OwningRow.Cells["Mã suất chiếu"].Value.ToString());
       
            ChiTietSuatChieu formChiTietSuatChieu = new ChiTietSuatChieu();
            formChiTietSuatChieu.loadThongTinSuatChieu(maSuatChieu);
            formChiTietSuatChieu.ShowDialog();

            string dateString = dtpNgayChieu.Value.ToString("dd/MM/yyyy");
            this.loadSuatChieu(currentRoom, dateString);
        }

        private void txbTimKiemNhanVien_Enter(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;

            if (txb.Text == "Tìm kiếm")
            {
                txb.Text = "";
            }
        }

        private void txbTimKiemNhanVien_Leave(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;

            if (txb.Text == "")
            {
                txb.Text = "Tìm kiếm";
            }
        }

        private void loadNhanVien()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from nv in db.NhanViens
                            where nv.DaXoa == false
                            select nv;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã nhân viên", typeof(string));
                dt.Columns.Add("Họ và tên", typeof(string));
                dt.Columns.Add("Giới tính", typeof(string));
                dt.Columns.Add("Ngày sinh", typeof(string));
                dt.Columns.Add("Số điện thoại", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Chức vụ", typeof(string));
                dt.Columns.Add("Ngày vào làm", typeof(string));

                foreach (NhanVien nv in query)
                {
                    string gioiTinh = (bool)nv.GioiTinh ? "Nam" : "Nữ";
                    DateTime ngaySinh = (DateTime)nv.NgaySinh;
                    DateTime ngayVaoLam = (DateTime)nv.NgayVaoLam;
                    dt.Rows.Add(nv.MaNhanVien, nv.Ten, gioiTinh, ngaySinh.ToString("dd/MM/yyyy"), nv.SoDienThoai, nv.Email, nv.ChucVuNhanVien.TenChucVu, ngayVaoLam.ToString("dd/MM/yyyy")); ;
                }

                dtgvNhanVien.DataSource = dt;
                dtgvNhanVien.Columns[0].Width = 80;
                dtgvNhanVien.Columns[1].Width = 120;
                dtgvNhanVien.Columns[2].Width = 80;
                dtgvNhanVien.Columns[6].Width = 80;

            }
        }

        private void loadKhachHang()
        {
            loadCbbGiaTriThangNam();

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from kh in db.KhachHangs
                            where kh.DaXoa == false
                            select kh;

                DataTable dt = new DataTable();
                dt.Columns.Add("Mã khách hàng", typeof(string));
                dt.Columns.Add("Tên khách hàng", typeof(string));
                dt.Columns.Add("Số điện thoại", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Ngày đăng ký", typeof(string));
                dt.Columns.Add("Chi tiêu trong kỳ", typeof(string));

                foreach (KhachHang kh in query)
                {
                    DateTime ngayDangKy = (DateTime)kh.ThoiGianTao;
                    int chiTieuTrongKy = 0;
                    dt.Rows.Add(kh.MaKhachHang, kh.Ten, kh.SoDienThoai, kh.Email, ngayDangKy.ToString("dd/MM/yyyy"), chiTieuTrongKy.ToString());
                }

                dtgvKhachHang.DataSource = dt;
                //dtgvKhachHang.Columns[0].Width = 80;
                //dtgvKhachHang.Columns[1].Width = 120;
                //dtgvKhachHang.Columns[2].Width = 80;

            }
        }

        private void loadCbbGiaTriThangNam()
        {
            cbbGiaTriThangNam.Items.Clear();

            if (cbbThangNam.SelectedItem.ToString() == "Theo năm")
            {
                foreach (String nam in nams)
                {
                    cbbGiaTriThangNam.Items.Add(nam);
                }
            }
            else if (cbbThangNam.SelectedItem.ToString() == "Theo tháng")
            {
                foreach (String thang in thangs)
                {
                    cbbGiaTriThangNam.Items.Add(thang);
                }
            }
        }

        private void btnXemChiTietNhanVien_Click(object sender, EventArgs e)
        {
            string maNhanVien = dtgvNhanVien.SelectedCells[0].OwningRow.Cells["Mã nhân viên"].Value.ToString();
            SuaThongTinNhanVien formThongTinNhanVien = new SuaThongTinNhanVien();
            formThongTinNhanVien.loadThongTinNhanVien(maNhanVien);
            formThongTinNhanVien.ShowDialog();
        }

        private void btnAddNhanVien_Click(object sender, EventArgs e)
        {
            ThemNhanVien formThemNhanVien = new ThemNhanVien();
            formThemNhanVien.ShowDialog();
            loadNhanVien();
        }

        private void txbTimKiemKhachHang_Enter(object sender, EventArgs e)
        {

        }

        private void cbbThangNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadCbbGiaTriThangNam();
        }
    }

}
