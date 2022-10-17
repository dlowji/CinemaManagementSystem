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
    public partial class ThemPhimMoi : Form
    {
        private List<QuocGia> quocGias;
        private List<TheLoaiPhim> theLoaiPhims;
        public ThemPhimMoi()
        {
            InitializeComponent();
            quocGias = new List<QuocGia>();
            theLoaiPhims = new List<TheLoaiPhim>();
            loadTheLoaiPhim();
            loadQuocGia();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                Phim p = new Phim();

                p.TenPhim = txbTenPhim.Text;
                p.DaoDien = txbTacGia.Text;
                p.NamPhatHanh = Int32.Parse(txbNamPhatHanh.Text);
                p.ThoiLuong = Int32.Parse(txbThoiLuong.Text);
                p.MaTheLoaiPhim = getMaTheLoaiPhim(cbbTheLoai.SelectedItem.ToString());
                p.MaQuocGia = getMaQuocGia(cbbQuocGia.SelectedItem.ToString());
                p.MoTa = rtxbMoTa.Text;
                p.DaXoa = false;

                db.Phims.InsertOnSubmit(p);
                db.SubmitChanges();
            }
            this.Hide();
        }

        private void loadTheLoaiPhim()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var queryAllGenre = from tlp in db.TheLoaiPhims
                                    select tlp;

                cbbTheLoai.Items.Clear();
                theLoaiPhims.Clear();

                foreach (TheLoaiPhim tlp in queryAllGenre)
                {
                    cbbTheLoai.Items.Add(tlp.TenTheLoaiPhim);
                    theLoaiPhims.Add(tlp);
                }
            }
        }

        private void loadQuocGia()
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var queryAllGenre = from qg in db.QuocGias
                                    select qg;

                cbbQuocGia.Items.Clear();
                quocGias.Clear();

                foreach (QuocGia qg in queryAllGenre)
                {
                    cbbQuocGia.Items.Add(qg.TenQuocGia);
                    quocGias.Add(qg);
                }
            }
        }

        private int getMaTheLoaiPhim(string tenTheLoaiPhim)
        {
            foreach (TheLoaiPhim tlp in theLoaiPhims)
            {
                if (tlp.TenTheLoaiPhim.Equals(tenTheLoaiPhim))
                {
                    return tlp.MaTheLoaiPhim;
                }
            }

            return -1;
        }

        private int getMaQuocGia(string tenQuocGia)
        {
            foreach (QuocGia qg in quocGias)
            {
                if (qg.TenQuocGia.Equals(tenQuocGia))
                {
                    return qg.MaQuocGia;
                }
            }

            return -1;
        }
    }
}
