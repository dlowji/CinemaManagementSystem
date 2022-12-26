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

namespace CinemaManagementSystem.View.Customer
{
    public partial class FoodDrinkUCForStaff : UserControl
    {
        private List<Button> selectedSeat;
        private Panel homepage;
        private LichChieu showTimes;
        private Phim movie;
        private decimal totalTicketPrice;

        List<SanPham> products = new List<SanPham>();
        List<Support> supports = new List<Support>();
        private decimal totalProductPrice;
        private string staffId;
        private string workingDirectory;
        private string projectDirectory;
        public FoodDrinkUCForStaff(string staffId, List<Button> selectedSeat, LichChieu showTimes, Phim movie, decimal totalTicketPrice, Panel homepage)
        {
            InitializeComponent();
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            LoadProductList();
            LoadProducts(flpAll);
            this.staffId = staffId;
            this.homepage = homepage;
            this.showTimes = showTimes;
            this.movie = movie;
            this.selectedSeat = selectedSeat;
            this.totalTicketPrice = totalTicketPrice;
            totalProductPrice = 0;
        }
        private void LoadProducts(FlowLayoutPanel viewFlp)
        {
            viewFlp.Controls.Clear();

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
                lbForProductName.AutoSize = true;

                lbForProductName.Text = item.TenHienThi;
                lbForProductName.Font = new Font("Verdana", 11);

                //button plus
                Button btn = new Button();
                btn.AutoSize = true;
                btn.Tag = item;

                int quantity = ProductController.GetQuantityOfProduct(item.id);
                if (quantity <= 0)
                {
                    btn.Enabled = false;
                }

                btn.Click += AddToCart;

                btn.Image = Properties.Resources.plus__1_;
                btn.Location = new Point(3, 3);
                btn.Name = "button1";
                btn.Size = new Size(35, 34);
                btn.TabIndex = 0;
                btn.UseVisualStyleBackColor = true;

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
                flp.Size = new Size(190, 250);
                flp.Cursor = Cursors.Hand;
                flp.Tag = item;
                flp.Click += flp_Click;
                flp.FlowDirection = FlowDirection.LeftToRight;
                flp.BorderStyle = BorderStyle.FixedSingle;
                flp.Controls.Add(pb);
                flp.Controls.Add(lbForProductName);
                flp.Controls.Add(btn);
                flp.Controls.Add(lbForQuantity);
                flp.Controls.Add(lbForPrice);

                viewFlp.Controls.Add(flp);
            }
        }

        private void flp_Click(object sender, EventArgs e)
        {
            //FlowLayoutPanel flp = sender as FlowLayoutPanel;
            //Phim movie = flp.Tag as Phim;
            //frmSeller frm = new frmSeller(staffId, movie);
            //frm.Show();

        }

        private void LoadProductList()
        {
            products.Clear();
            products = ProductController.GetProductsForView();
        }

        private void LoadFoodsList()
        {
            products.Clear();
            products = ProductController.GetFoodsForView();
        }

        private void LoadDrinksList()
        {
            products.Clear();
            products = ProductController.GetDrinksForView();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            BillUCForStaff billUC = new BillUCForStaff(selectedSeat, supports, showTimes, movie, totalTicketPrice, staffId);
            billUC.Dock = DockStyle.Fill;

            homepage.Controls.Clear();
            homepage.Controls.Add(billUC);
        }

        private void AddToCart(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.Enabled = false;
            SanPham product = btn.Tag as SanPham;

            Label lbForProductName = new Label();
            lbForProductName.AutoSize = true;

            lbForProductName.Text = product.TenHienThi;
            lbForProductName.Font = new Font("Verdana", 11);

            Label lbForPrice = new Label();
            lbForPrice.AutoSize = true;

            lbForPrice.Text = Helper.Helper.FormatVNMoney((decimal)product.GiaTien);
            lbForPrice.Font = new Font("Verdana", 11);

            NumericUpDown nud = new NumericUpDown();
            nud.Font = new Font("Verdana", 11);
            nud.AutoSize = true;
            nud.Value = 1;

            Support sp = new Helper.Support();
            sp.OldValue = 1;
            sp.Product = product;

            supports.Add(sp);

            nud.Tag = sp;
            nud.ValueChanged += UpdatePrice;

            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.Size = new Size(290, 60);
            flp.Tag = product;
            flp.FlowDirection = FlowDirection.LeftToRight;
            flp.BorderStyle = BorderStyle.FixedSingle;
            flp.Controls.Add(lbForProductName);
            flp.Controls.Add(nud);
            flp.Controls.Add(lbForPrice);

            flpCart.Controls.Add(flp);

            totalProductPrice += (decimal)product.GiaTien * nud.Value;
            lbProductsPrice.Text = Helper.Helper.FormatVNMoney(totalProductPrice);
        }

        private void UpdatePrice(object sender, EventArgs e)
        {
            NumericUpDown nud = sender as NumericUpDown;
            Support sp = nud.Tag as Support;

            Decimal oldValue = sp.OldValue;
            SanPham product = sp.Product;

            int quantity = ProductController.GetQuantityOfProduct(product.id);

            if (nud.Value > quantity)
            {
                MessageBox.Show("Số lượng sản phẩm không có đủ", "Cảnh báo");
                nud.Value = quantity;
                return;
            }

            if (nud.Value > oldValue)
            {
                totalProductPrice += (nud.Value - oldValue) * (decimal)product.GiaTien;
            }
            else if (nud.Value < oldValue)
            {
                totalProductPrice -= (oldValue - nud.Value) * (decimal)product.GiaTien;
            }

            sp.OldValue = nud.Value;

            lbProductsPrice.Text = Helper.Helper.FormatVNMoney(totalProductPrice);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;

            if (current.Name == "tpFood")
            {
                LoadFoodsList();
                LoadProducts(flpFood);
                return;
            }

            if (current.Name == "tpDrink")
            {
                LoadDrinksList();
                LoadProducts(flpDrink);
                return;
            }
        }
    }
}
