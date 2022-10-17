using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CinemaManagementSystem
{
    public partial class ChinhSuaPhim : Form
    {
        private int globalId;
        private List<QuocGia> quocGias;
        private List<TheLoaiPhim> theLoaiPhims;
        public ChinhSuaPhim()
        {
            InitializeComponent();
            quocGias = new List<QuocGia>();
            theLoaiPhims = new List<TheLoaiPhim>();
            loadTheLoaiPhim();
            loadQuocGia();
        }

        private void ChinhSuaPhim_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from p in db.Phims
                            where p.MaPhim == globalId
                            select p;

                foreach (Phim p in query)
                {
                    p.TenPhim = txbTenPhim.Text;
                    p.DaoDien = txbTacGia.Text;
                    p.NamPhatHanh = Int32.Parse(txbNamPhatHanh.Text);
                    p.ThoiLuong = Int32.Parse(txbThoiLuong.Text);
                    p.MaTheLoaiPhim = getMaTheLoaiPhim(cbbTheLoai.SelectedItem.ToString());
                    p.MaQuocGia = getMaQuocGia(cbbQuocGia.SelectedItem.ToString());
                    p.MoTa = rtxbMoTa.Text;
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

        public void loadThongTinPhim(int id)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var queryFilmById = from p in db.Phims
                                    where p.MaPhim == id
                                    select p;


                foreach (Phim p in queryFilmById)
                {
                    txbTenPhim.Text = p.TenPhim;
                    txbTacGia.Text = p.DaoDien;
                    txbNamPhatHanh.Text = p.NamPhatHanh.ToString();
                    txbThoiLuong.Text = p.ThoiLuong.ToString();
                    cbbQuocGia.SelectedItem = p.QuocGia.TenQuocGia;
                    cbbTheLoai.SelectedItem = p.TheLoaiPhim.TenTheLoaiPhim;
                    rtxbMoTa.Text = p.MoTa;
                }
            }

            globalId = id;
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
