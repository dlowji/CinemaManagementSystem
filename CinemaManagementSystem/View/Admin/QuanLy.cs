using CinemaManagementSystem.Admin.Data;
using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
using GUI;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinemaManagementSystem
{
    public partial class QuanLy : Form
    {
        BindingSource customerList = new BindingSource();
        BindingSource staffList = new BindingSource();
        BindingSource productList = new BindingSource();
        BindingSource importReceiptList = new BindingSource();
        BindingSource ticketReceiptList = new BindingSource();

        string staffId;

        public QuanLy(string staffId)
        {
            InitializeComponent();
            LoadRevenue();
            LoadStaff();
            LoadCustomer();
            LoadProduct();
            LoadImportReceipt();
            LoadTicketReceipt();
            this.staffId = staffId;
        }

        //begin product
        void LoadProduct()
        {
            dtgvProduct.DataSource = productList;
            LoadProductList();
            AddProductBinding();
        }

        void LoadProductList()
        {
            DataTable products = ProductController.GetProductList();
            productList.DataSource = products;
        }
        void AddProductBinding()
        {
            txbProductId.DataBindings.Add("Text", dtgvProduct.DataSource, "Mã sản phẩm", true, DataSourceUpdateMode.Never);
            txbProductName.DataBindings.Add("Text", dtgvProduct.DataSource, "Tên hiển thị", true, DataSourceUpdateMode.Never);
            txbProductType.DataBindings.Add("Text", dtgvProduct.DataSource, "Loại sản phẩm", true, DataSourceUpdateMode.Never);
            txbProductPrice.DataBindings.Add("Text", dtgvProduct.DataSource, "Giá tiền", true, DataSourceUpdateMode.Never);
            nudQuantity.DataBindings.Add("Value", dtgvProduct.DataSource, "Số lượng", true, DataSourceUpdateMode.Never);
        }
        private void btnShowProduct_Click(object sender, EventArgs e)
        {
            LoadProductList();
        }

        void InsertProduct(string id, string tenHienThi, int loaiSanPham, decimal giaBan)
        {
            bool result = ProductController.InsertProduct(id, tenHienThi, loaiSanPham, giaBan);

            if (result)
            {
                MessageBox.Show("Thêm sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại");
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            string productId = txbProductId.Text;
            string productName = txbProductName.Text;
            int productType = txbProductType.Text.Equals("Đồ ăn") ? 1 : 2;
            decimal productPrice = Decimal.Parse(txbProductPrice.Text);
            InsertProduct(productId, productName, productType, productPrice);
            LoadProductList();
        }

        void UpdateProduct(string id, string tenHienThi, int loaiSanPham, decimal giaBan)
        {
            bool result = ProductController.UpdateProduct(id, tenHienThi, loaiSanPham, giaBan);

            if (result)
            {
                MessageBox.Show("Sửa sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Sửa sản phẩm thất bại");
            }
        }
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            string productId = txbProductId.Text;
            string productName = txbProductName.Text;
            int productType = txbProductType.Text.Equals("Đồ ăn") ? 1 : 2;
            decimal productPrice = Decimal.Parse(txbProductPrice.Text);
            UpdateProduct(productId, productName, productType, productPrice);
            LoadProductList();
        }

        void DeleteProduct(string id)
        {
            bool result = ProductController.DeleteProduct(id);

            if (result)
            {
                MessageBox.Show("Xóa sản phẩm thành công");
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại");
            }
        }
        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string productId = txbProductId.Text;
            DeleteProduct(productId);
            LoadProductList();
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string productName = txbSearchProduct.Text;
            DataTable searchProdList = ProductController.SearchProductByName(productName);
            productList.DataSource = searchProdList;
        }

        private void txbSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchProduct.PerformClick();
                e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
            }
        }
        //end product

        void LoadCustomer()
        {
            dtgvCustomer.DataSource = customerList;
            LoadCustomerList();
            AddCustomerBinding();
        }

        void LoadCustomerList()
        {
            DataTable customers = CustomerController.GetCustomerList();
            customerList.DataSource = customers;
        }
        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerList();
        }

        void AddCustomerBinding()
        {
            txtCusID.DataBindings.Add("Text", dtgvCustomer.DataSource, "Mã khách hàng", true, DataSourceUpdateMode.Never);
            txtCusName.DataBindings.Add("Text", dtgvCustomer.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
            txtCusBirth.DataBindings.Add("Text", dtgvCustomer.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtCusAddress.DataBindings.Add("Text", dtgvCustomer.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtCusPhone.DataBindings.Add("Text", dtgvCustomer.DataSource, "SĐT", true, DataSourceUpdateMode.Never);
            txtCusINumber.DataBindings.Add("Text", dtgvCustomer.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            nudPoint.DataBindings.Add("Value", dtgvCustomer.DataSource, "Điểm tích lũy", true, DataSourceUpdateMode.Never);
        }
        void InsertCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            bool result = CustomerController.InsertCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd);

            if (result)
            {
                MessageBox.Show("Thêm khách hàng thành công");
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại");
            }
        }
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string cusID = txtCusID.Text;
            string cusName = txtCusName.Text;
            DateTime cusBirth = DateTime.Parse(txtCusBirth.Text);
            string cusAddress = txtCusAddress.Text;
            string cusPhone = txtCusPhone.Text;
            int cusINumber = Int32.Parse(txtCusINumber.Text);
            InsertCustomer(cusID, cusName, cusBirth, cusAddress, cusPhone, cusINumber);
            LoadCustomerList();
        }

        void UpdateCustomer(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
        {
            bool result = CustomerController.UpdateCustomer(id, hoTen, ngaySinh, diaChi, sdt, cmnd, point);

            if (result)
            {
                MessageBox.Show("Sửa khách hàng thành công");
            }
            else
            {
                MessageBox.Show("Sửa khách hàng thất bại");
            }
        }
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            string cusID = txtCusID.Text;
            string cusName = txtCusName.Text;
            DateTime cusBirth = DateTime.Parse(txtCusBirth.Text);
            string cusAddress = txtCusAddress.Text;
            string cusPhone = txtCusPhone.Text;
            int cusINumber = Int32.Parse(txtCusINumber.Text);
            int cusPoint = (int)nudPoint.Value;
            UpdateCustomer(cusID, cusName, cusBirth, cusAddress, cusPhone, cusINumber, cusPoint);
            LoadCustomerList();
        }

        void DeleteCustomer(string id)
        {
            bool result = CustomerController.DeleteCustomer(id);

            if (result)
            {
                MessageBox.Show("Xóa khách hàng thành công");
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại");
            }
        }
        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            string cusID = txtCusID.Text;
            DeleteCustomer(cusID);
            LoadCustomerList();
        }

        private void btnSearchCus_Click(object sender, EventArgs e)
        {
            string cusName = txtSearchCus.Text;
            DataTable searchCusList = CustomerController.SearchCustomerByName(cusName);
            customerList.DataSource = searchCusList;
        }

        private void txtSearchCus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchCus.PerformClick();
                e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
            }
        }

        // end customer

        //begin revenue
        void LoadRevenue()
        {
            LoadMovieIntoCombobox(cboSelectMovie);
            LoadDateTimePickerRevenue();//Set "Từ ngày" & "Đến ngày ngày" về đầu tháng & cuối tháng
            LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
        }
        void LoadMovieIntoCombobox(ComboBox comboBox)
        {
            RevenueController.LoadMovieIntoComboBox(comboBox);
        }
        void LoadDateTimePickerRevenue()
        {
            dtmFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtmToDate.Value = dtmFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadRevenue(string idMovie, DateTime fromDate, DateTime toDate)
        {
            CultureInfo culture = new CultureInfo("vi-VN");
            dtgvRevenue.DataSource = RevenueController.GetRevenue(idMovie, fromDate, toDate); ;
            txtDoanhThu.Text = GetSumRevenue().ToString("c", culture);
        }
        decimal GetSumRevenue()
        {
            return RevenueController.GetTotalRevenue(dtgvRevenue);
        }

        private void btnShowRevenue_Click(object sender, EventArgs e)
        {
            LoadRevenue(cboSelectMovie.SelectedValue.ToString(), dtmFromDate.Value, dtmToDate.Value);
        }

        private void btnReportRevenue_Click(object sender, EventArgs e)
        {

        }

        //end revenue

        //begin staff

        void LoadStaff()
        {
            dtgvStaff.DataSource = staffList;
            LoadStaffList();
            AddStaffBinding();
        }

        void LoadStaffList()
        {
            DataTable staffs = StaffController.GetStaffList();
            staffList.DataSource = staffs;
        }

        private void btnShowStaff_Click(object sender, EventArgs e)
        {
            LoadStaffList();
        }
        void AddStaffBinding()
        {
            txtStaffId.DataBindings.Add("Text", dtgvStaff.DataSource, "Mã nhân viên", true, DataSourceUpdateMode.Never);
            txtStaffName.DataBindings.Add("Text", dtgvStaff.DataSource, "Họ tên", true, DataSourceUpdateMode.Never);
            txtStaffBirth.DataBindings.Add("Text", dtgvStaff.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtStaffAddress.DataBindings.Add("Text", dtgvStaff.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtStaffPhone.DataBindings.Add("Text", dtgvStaff.DataSource, "SĐT", true, DataSourceUpdateMode.Never);
            txtStaffINumber.DataBindings.Add("Text", dtgvStaff.DataSource, "CMND", true, DataSourceUpdateMode.Never);
        }


        //Thêm Staff
        void AddStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            bool result = StaffController.InsertStaff(id, hoTen, ngaySinh, diaChi, sdt, cmnd);

            if (result)
            {
                MessageBox.Show("Thêm nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }
        }
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            string staffId = txtStaffId.Text;
            string staffName = txtStaffName.Text;
            DateTime staffBirth = DateTime.Parse(txtStaffBirth.Text);
            string staffAddress = txtStaffAddress.Text;
            string staffPhone = txtStaffPhone.Text;
            int staffINumber = Int32.Parse(txtStaffINumber.Text);
            AddStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
            LoadStaffList();
        }

        //Sửa Staff
        void UpdateStaff(string id, string hoTen, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            bool result = StaffController.UpdateStaff(id, hoTen, ngaySinh, diaChi, sdt, cmnd);

            if (result)
            {
                MessageBox.Show("Sửa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thất bại");
            }
        }
        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            string staffId = txtStaffId.Text;
            string staffName = txtStaffName.Text;
            DateTime staffBirth = DateTime.Parse(txtStaffBirth.Text);
            string staffAddress = txtStaffAddress.Text;
            string staffPhone = txtStaffPhone.Text;
            int staffINumber = Int32.Parse(txtStaffINumber.Text);
            UpdateStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
            LoadStaffList();
        }

        //Xóa Staff
        void DeleteStaff(string id)
        {
            bool result = StaffController.DeleteStaff(id);

            if (result)
            {
                MessageBox.Show("Xóa nhân viên thành công");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
            }
        }
        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            string staffId = txtStaffId.Text;
            DeleteStaff(staffId);
            LoadStaffList();
        }

        //Tìm kiếm Staff
        private void btnSearchStaff_Click(object sender, EventArgs e)
        {
            string staffName = txtSearchStaff.Text;
            DataTable staffSearchList = StaffController.SearchStaffByName(staffName);
            staffList.DataSource = staffSearchList;
        }

        private void txtSearchStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearchStaff.PerformClick();
                e.SuppressKeyPress = true;//Tắt tiếng *ting của windows
            }
        }

        //end staff

        //begin history

        //begin import
        void LoadImportReceipt()
        {
            dtgvImportReceipt.DataSource = importReceiptList;
            LoadImportReceiptList();
        }

        void LoadImportReceiptList()
        {
            DataTable receipts = ReceiptController.GetImportReceiptList();
            importReceiptList.DataSource = receipts;
        }

        //end import

        //begin ticketReceipt
        void LoadTicketReceipt()
        {
            dtgvTicketReceipt.DataSource = ticketReceiptList;
            LoadTicketReceiptList();
        }

        void LoadTicketReceiptList()
        {
            DataTable receipts = ReceiptController.GetTicketReceiptList();
            ticketReceiptList.DataSource = receipts;
        }

        //end ticket receipt

        //end history

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

        private void lbData_Click(object sender, EventArgs e)
        {
            DataForm frm = new DataForm();
            frm.Show();
        }

        private void btnStaffUC_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLyNhanSu;
        }

        private void btnCustomerUC_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLyKhachHang;
        }

        private void btnRevenueUC_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLyDoanhThu;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLySuCo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLyLichSu;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tcQuanLy.SelectedTab = QuanLyVoucher;
        }

        private void btnDataUC_Click(object sender, EventArgs e)
        {
            DataForm frm = new DataForm();
            frm.ShowDialog();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            frmImport frm = new frmImport(staffId);
            frm.Show();
            LoadProductList();
        }

        private void QuanLy_Load(object sender, EventArgs e)
        {
            List<Control> allControls = Helper.Helper.GetAllControls(this);
            allControls.ForEach(k => k.Font = new System.Drawing.Font("Verdana", 11));
            allControls.ForEach(k => k.ForeColor = ColorTranslator.FromHtml("#000006"));
        }

        private void btnExportImportReceipt_Click(object sender, EventArgs e)
        {
            Helper.Helper.Export2Excel(dtgvImportReceipt);
        }

        private void btnExportTicketReceipt_Click(object sender, EventArgs e)
        {
            Helper.Helper.Export2Excel(dtgvTicketReceipt);
        }
    }

}
