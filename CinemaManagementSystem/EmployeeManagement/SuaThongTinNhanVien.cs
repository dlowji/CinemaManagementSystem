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
    public partial class SuaThongTinNhanVien : Form
    {
        private List<ChucVuNhanVien> chucVuNhanViens;
        private string globalId;
        public SuaThongTinNhanVien()
        {
            InitializeComponent();
            chucVuNhanViens = new List<ChucVuNhanVien>();
            loadChucVu();
            loadGioiTinh();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void SuaThongTinNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from nv in db.NhanViens
                            where nv.MaNhanVien.Equals(globalId)
                            select nv;

                foreach (NhanVien nv in query)
                {
                    Boolean gioiTinh = cbbGioiTinh.SelectedItem.ToString().Equals("Nam") ? true : false;
                    
                    nv.Ten = txbTen.Text;
                    nv.GioiTinh = gioiTinh;
                    nv.NgaySinh = dtpNgaySinh.Value;
                    nv.SoDienThoai = txbSoDienThoai.Text;
                    nv.Email = txbEmail.Text;
                    nv.MaChucVu = getMaChucVu(cbbChucVu.SelectedItem.ToString());
                    nv.NgayVaoLam = dtpNgayVaoLam.Value;
                    nv.TenTaiKhoan = txbTaiKhoan.Text;
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
            this.Hide();
        }

        public void loadThongTinNhanVien(string maNhanVien)
        {
            globalId = maNhanVien;
                
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from nv in db.NhanViens
                            where nv.MaNhanVien.Equals(maNhanVien)
                            select nv;

                foreach (NhanVien nv in query)
                {
                    string gioiTinh = (bool)nv.GioiTinh ? "Nam" : "Nữ";
                    DateTime ngaySinh = (DateTime)nv.NgaySinh;
                    DateTime ngayVaoLam = (DateTime)nv.NgayVaoLam;

                    txbTen.Text = nv.Ten;
                    cbbGioiTinh.SelectedItem = gioiTinh;
                    dtpNgaySinh.Value = ngaySinh;
                    txbSoDienThoai.Text = nv.SoDienThoai;
                    txbEmail.Text = nv.Email;
                    cbbChucVu.SelectedItem = nv.ChucVuNhanVien.TenChucVu;
                    dtpNgayVaoLam.Value = ngayVaoLam;
                    txbTaiKhoan.Text = nv.TenTaiKhoan;
                    
                }
            }
        }

        private void loadGioiTinh()
        {
            List<String> genderList = new List<string>();

            genderList.Add("Nam");
            genderList.Add("Nữ");

            foreach (String gender in genderList)
            {
                cbbGioiTinh.Items.Add(gender);
            }
        }

        private void loadChucVu()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from cv in db.ChucVuNhanViens
                            select cv;

                foreach (ChucVuNhanVien cv in query)
                {
                    chucVuNhanViens.Add(cv);
                    cbbChucVu.Items.Add(cv.TenChucVu);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private int getMaChucVu(string tenChucVu)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from cv in db.ChucVuNhanViens
                            where cv.TenChucVu.Equals(tenChucVu)
                            select cv;

                foreach (ChucVuNhanVien cv in query)
                {
                    return cv.MaChucVu;
                }
            }

            return -1;
        }
    }
}
