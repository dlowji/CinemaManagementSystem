using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
using GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem
{
    public partial class FoodAndDrink : Form
    {
        List<SanPham> products = new List<SanPham>();
        private string staffId;
        private string workingDirectory;
        private string projectDirectory;
        public FoodAndDrink(string staffId)
        {
            InitializeComponent();
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            LoadProducts();
            this.staffId = staffId;
        }
        private void LoadProducts()
        {
            LoadProductList();

            foreach (var item in products)
            {
                //picture box
                PictureBox pb = new PictureBox();
                pb.Size = new Size(196, 180);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;

                if (pb.Image != null)
                {
                    pb.Image.Dispose();
                    pb.Image = null;
                }

                if (item.ApPhich != null)
                {
                    pb.Image = Image.FromFile(projectDirectory + item.ApPhich);
                    pb.ImageLocation = projectDirectory + item.ApPhich;
                }

                //label for product name
                Label lbForProductName = new Label();
                //lbForProductName.AutoSize = true;

                lbForProductName.Text = item.TenHienThi;
                lbForProductName.Font = new Font("Verdana", 11);

                //label for product quantity
                Label lbForQuantity = new Label();
                lbForQuantity.AutoSize = true;

                lbForQuantity.Text = "SL: " + ProductController.GetQuantityOfProduct(item.id).ToString();
                lbForQuantity.Font = new Font("Verdana", 11);

                //label for product price
                Label lbForPrice = new Label();
                lbForPrice.AutoSize = true;

                lbForPrice.Text = Helper.Helper.FormatVNMoney((decimal)item.GiaTien);
                lbForPrice.Font = new Font("Verdana", 11);

                //flowlayout panel
                FlowLayoutPanel flp = new FlowLayoutPanel();
                flp.Size = new Size(191, 259);
                flp.Cursor = Cursors.Hand;
                flp.Tag = item;
                flp.Click += flp_Click;
                flp.FlowDirection = FlowDirection.LeftToRight;
                flp.BorderStyle = BorderStyle.FixedSingle;
                flp.Controls.Add(pb);
                flp.Controls.Add(lbForProductName);
                flp.Controls.Add(lbForQuantity);
                flp.Controls.Add(lbForPrice);

                flpAll.Controls.Add(flp);
            }
        }

        private void flp_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel flp = sender as FlowLayoutPanel;
            Phim movie = flp.Tag as Phim;
            frmSeller frm = new frmSeller(staffId, movie);
            frm.Show();

        }

        private void LoadProductList()
        {
            products = ProductController.GetProductsForView();
        }
    }
}
