using GUI.DAO;
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
    public partial class frmImport : Form
    {
        string staffId;
        public frmImport(string staffId)
        {
            InitializeComponent();
            LoadProductList();
            this.staffId = staffId;
        }

        void LoadProductList()
        {
            cbbProductList.DataSource = ProductDAO.GetListProduct();
            cbbProductList.DisplayMember = "Tên hiển thị";
            cbbProductList.ValueMember = "id";
        }

        private void btnCofirm_Click(object sender, EventArgs e)
        {
            string productId = cbbProductList.SelectedValue.ToString();
            decimal importPrice = Decimal.Parse(txbImportPrice.Text);
            int quantity = Int32.Parse(txbQuantity.Text);

            if (BillDAO.InsertImportReceipt(productId, importPrice, quantity, staffId))
            {
                MessageBox.Show("Nhập sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Nhập sản phẩm thất bại");
            }
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
