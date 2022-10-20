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
    public partial class ThemSuatChieu : Form
    {
        List<Phim> phimList;
        List<PhongChieu> phongChieuList;
        public ThemSuatChieu()
        {
            InitializeComponent();
            phimList = new List<Phim>();
            phongChieuList = new List<PhongChieu>();
            loadPhim();
            loadPhongChieu();
            lbMoTaNgayChieu.Text = dtpNgayChieu.Value.ToString("dd/MM/yyyy");
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ThemSuatChieu_Load(object sender, EventArgs e)
        {

        }

        private void txbTenSuatChieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tenPhongChieu = cbbPhongChieu.SelectedItem.ToString();
            DateTime ngayChieu = DateTime.Parse(dtpNgayChieu.Value.ToString("yyyy/MM/dd"));
            DateTime gioBatDauSuatChieu = DateTime.Parse(dtpGioBatDau.Text);
            int maPhongChieu = getMaPhongChieu(tenPhongChieu);

            if (checkExistShowRoom(maPhongChieu, ngayChieu, gioBatDauSuatChieu))
            {
                this.Hide();
                return;
            }

            using (CinemaDataContext db = new CinemaDataContext())
            {
                CaiDatSuatChieu cdsc = new CaiDatSuatChieu();
                cdsc.NgayChieu = ngayChieu;
                cdsc.MaPhongChieu = maPhongChieu;

                db.CaiDatSuatChieus.InsertOnSubmit(cdsc);
                db.SubmitChanges();

                SuatChieu sc = new SuatChieu();
                sc.MaCaiDatSuatChieu = cdsc.MaCaiDatSuatChieu;
                sc.MaPhim = getMaPhim(cbbPhim.SelectedItem.ToString());
                sc.GiaVe = Int32.Parse(txbGiaVeSuatChieu.Text);
                sc.ThoiGianBatDau = gioBatDauSuatChieu.TimeOfDay;

                db.SuatChieus.InsertOnSubmit(sc);
                db.SubmitChanges();

                //lay ra tat ca cac ghe ngoi o phong chieu hien tai
                var query = from g in db.Ghes
                            where g.MaPhongChieu == maPhongChieu
                            select g;

                foreach (Ghe ghe in query)
                {
                    CaiDatGhe cdg = new CaiDatGhe();
                    cdg.MaGhe = ghe.MaGhe;
                    cdg.MaSuatChieu = sc.MaSuatChieu;
                    cdg.TrangThai = false;

                    db.CaiDatGhes.InsertOnSubmit(cdg);
                    db.SubmitChanges();
                }
            }
            this.Hide();
        }

        private Boolean checkExistShowRoom(int maPhongChieu, DateTime ngayChieu, DateTime gioBatDauSuatChieu)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from sc in db.SuatChieus
                            where sc.CaiDatSuatChieu.PhongChieu.MaPhongChieu == maPhongChieu && DateTime.Compare((DateTime)sc.CaiDatSuatChieu.NgayChieu, ngayChieu) == 0
                            select sc;

                foreach (SuatChieu sc in query)
                {
                    string gioBatDau = sc.ThoiGianBatDau.ToString();
                    string gioKetThuc = getGioKetThucCuaPhim(gioBatDau);

                    if (DateTime.Compare(gioBatDauSuatChieu, DateTime.Parse(gioBatDau)) > 0 && DateTime.Compare(gioBatDauSuatChieu, DateTime.Parse(gioKetThuc)) < 0)
                    {
                        MessageBox.Show("Khoảng thời gian từ " + gioBatDau + " đến " + gioKetThuc + " đã có phim chiếu tại phòng " + sc.CaiDatSuatChieu.PhongChieu.TenPhongChieu);
                        return true;
                    }
                }
            }

            return false;
        }

        private void loadPhim()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            select p;

                phimList.Clear();
                cbbPhim.Items.Clear();

                foreach (Phim p in query) 
                {
                    phimList.Add(p);
                    cbbPhim.Items.Add(p.TenPhim);
                }

            }
        }

        private int getMaPhongChieu(string tenPhongChieu)
        {
                foreach (PhongChieu pc in phongChieuList)
                {
                    if (pc.TenPhongChieu.Equals(tenPhongChieu))
                    {
                        return pc.MaPhongChieu;
                    }
                }

                return -1;
        }

        private int getMaPhim(string tenPhim)
        {
            foreach (Phim p in phimList)
            {
                if (p.TenPhim.Equals(tenPhim))
                {
                    return p.MaPhim;
                }
            }

            return -1;
        }

        private void loadPhongChieu()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from pc in db.PhongChieus
                            select pc;

                phongChieuList.Clear();
                cbbPhongChieu.Items.Clear();

                foreach (PhongChieu pc in query)
                {
                    phongChieuList.Add(pc);
                    cbbPhongChieu.Items.Add(pc.TenPhongChieu);
                }

            }
        }

        private void cbbPhim_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox phimComboBox = sender as ComboBox;
            lbMoTaTenPhim.Text = phimComboBox.SelectedItem.ToString();

            string gioBatDau = dtpGioBatDau.Text;
            string gioKetThuc = getGioKetThucCuaPhim(gioBatDau);

            loadGioBatDauChieu(DateTime.Parse(gioBatDau).TimeOfDay.ToString(), gioKetThuc);
        }

        private void dtpNgayChieu_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker = sender as DateTimePicker;
            lbMoTaNgayChieu.Text = dateTimePicker.Value.ToString();
        }

        private void dtpGioBatDau_ValueChanged(object sender, EventArgs e)
        {
            string gioBatDau = dtpGioBatDau.Text;
            string gioKetThuc = getGioKetThucCuaPhim(gioBatDau);

            loadGioBatDauChieu(DateTime.Parse(gioBatDau).TimeOfDay.ToString(), gioKetThuc);
        }

        private void loadGioBatDauChieu(string gioBatDau, string gioKetThuc)
        {
            lbMoTaGioChieu.Text = gioBatDau + " -> " + gioKetThuc;
        }

        private Phim getPhim(string tenPhim)
        {
            foreach (Phim p in phimList)
            {
                if (p.TenPhim.Equals(tenPhim))
                {
                    return p;
                }
            }

            return null;
        }

        private string getGioKetThucCuaPhim(string gioBatDau)
        {
            int thoiLuong = (int)getPhim(cbbPhim.SelectedItem.ToString()).ThoiLuong;

            //minutes
            TimeSpan minutes = TimeSpan.FromMinutes(thoiLuong);

            //hours

            string hours = string.Format("{0:00}:{1:00}", (int)minutes.TotalHours, minutes.Minutes);

            DateTime startTime = DateTime.Parse(gioBatDau);
            DateTime duration = DateTime.Parse(hours);

            DateTime endTime = startTime.Add(duration.TimeOfDay);

            return endTime.TimeOfDay.ToString();
        }

        private void txbGiaVeSuatChieu_TextChanged(object sender, EventArgs e)
        {
            lbMoTaGiaVe.Text = txbGiaVeSuatChieu.Text;
        }

        private void cbbPhongChieu_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox phongChieuComboBox = sender as ComboBox;
            lbMoTaPhongChieu.Text = phongChieuComboBox.SelectedItem.ToString();
        }
    }
}
