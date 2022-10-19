using CinemaManagementSystem.Helper;
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
    public partial class ThemNhanVien : Form
    {
        private List<ChucVuNhanVien> chucVuNhanViens;
        public ThemNhanVien()
        {
            InitializeComponent();
            chucVuNhanViens = new List<ChucVuNhanVien>();
            loadChucVu();
            loadGioiTinh();
        }

        private void ThemNhanVien_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!txbMatKhau.Text.Equals(txbXacNhanMatKhau.Text))
            {
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp");
                Hide();
                return;
            }

            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from nv in db.NhanViens
                            where nv.DaXoa == false
                            select nv;

                int index = query.Count();
                StringBuilder maNhanVien = new StringBuilder("NV");
                
                if (index + 1 < 10)
                {
                    maNhanVien.Append("00").Append((index+1).ToString());
                }
                else
                {
                    maNhanVien.Append("0").Append((index + 1).ToString());
                }

                Boolean gioiTinh = cbbGioiTinh.SelectedItem.ToString().Equals("Nam") ? true : false;
                string matKhauMaHoa = Helper.Helper.EncodePasswordToBase64(txbMatKhau.Text);

                NhanVien inserted = new NhanVien();
                inserted.MaNhanVien = maNhanVien.ToString();
                inserted.Ten = txbTen.Text;
                inserted.GioiTinh = gioiTinh;
                inserted.NgaySinh = dtpNgaySinh.Value;
                inserted.SoDienThoai = txbSoDienThoai.Text;
                inserted.Email = txbEmail.Text;
                inserted.MaChucVu = getMaChucVu(cbbChucVu.SelectedItem.ToString());
                inserted.NgayVaoLam = dtpNgayVaoLam.Value;
                inserted.TenTaiKhoan = txbTaiKhoan.Text;
                inserted.MatKhau = matKhauMaHoa;
                inserted.DaXoa = false;

                db.NhanViens.InsertOnSubmit(inserted);
                db.SubmitChanges();
            }
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
    }
}
