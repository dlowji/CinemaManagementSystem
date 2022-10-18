using CINEMA_NEW.Staff.OrderFoodWindow;
using CINEMA_NEW.Staff.ShowtimePage;
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
    public partial class ChiTietSuatChieu : Form
    {
        public ChiTietSuatChieu()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void lbThayDoiGiaVe_Click(object sender, EventArgs e)
        {
            txbGiaVe.ReadOnly = false;
            txbGiaVe.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        public void loadThongTinSuatChieu(int maSuatChieu)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from sc in db.SuatChieus
                            where sc.MaSuatChieu == maSuatChieu
                            select sc;

                foreach (SuatChieu sc in query)
                {
                    lbTenPhim.Text = sc.Phim.TenPhim;
                    DateTime dt = (DateTime)sc.CaiDatSuatChieu.NgayChieu;
                    lbNgayChieu.Text = dt.ToString("dd/MM/yyyy");
                    lbPhongChieu.Text = "Phòng: " + sc.CaiDatSuatChieu.PhongChieu.TenPhongChieu;
                    txbGiaVe.Text = sc.GiaVe.ToString();
                    txbGiaVe.ReadOnly = true;
                    loadDanhSachGhe(maSuatChieu);
                }
            }
        }

        private void loadDanhSachGhe(int maSuatChieu)
        {
            using (CinemaDataContext db = new CinemaDataContext())
            {
                var query = from cdg in db.CaiDatGhes
                            where cdg.MaSuatChieu == maSuatChieu
                            select cdg;

                int startXLocation = 315;
                int startYLocation = 78;
                int offsetX = 35;
                int offsetY = 45;

                List<CaiDatGhe> caiDatGheList = new List<CaiDatGhe>();

                foreach (CaiDatGhe cdg in query)
                {
                    caiDatGheList.Add(cdg);
                }

                int index = 0;
                int tongSoGhe = caiDatGheList.Count();
                int soGheDaDat = 0;

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        CaiDatGhe caiDatGhe = caiDatGheList.ElementAt(index);

                        if (caiDatGhe.TrangThai == true)
                        {
                            soGheDaDat++;
                        }

                        Label lbl = new Label();
                        lbl.BorderStyle = BorderStyle.FixedSingle;
                        lbl.Cursor = Cursors.Hand;
                        lbl.FlatStyle = FlatStyle.Flat;
                        lbl.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
                        lbl.Location = new Point(startXLocation, startYLocation);
                        lbl.Size = new Size(30, 30);
                        lbl.Text = caiDatGhe.Ghe.DayGhe + caiDatGhe.Ghe.MaSoGhe;
                        lbl.TextAlign = ContentAlignment.MiddleCenter;

                        Controls.Add(lbl);
                        startXLocation += offsetX;
                        index++;
                    }
                    startYLocation += offsetY;
                    startXLocation = 315;
                }
                lbTongSoGhe.Text = tongSoGhe.ToString();
                lbGheDaDat.Text = soGheDaDat.ToString();
                lbConTrong.Text = (tongSoGhe - soGheDaDat).ToString();
                
            }
        }
    }
}
