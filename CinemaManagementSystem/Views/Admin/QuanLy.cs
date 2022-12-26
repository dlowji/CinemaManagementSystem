using CinemaManagementSystem.Admin.Data;
using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.View.Others;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace CinemaManagementSystem
{
    public partial class QuanLy : Form
    {
        BindingSource customerList = new BindingSource();
        BindingSource staffList = new BindingSource();
        BindingSource productList = new BindingSource();
        BindingSource importReceiptList = new BindingSource();
        BindingSource ticketReceiptList = new BindingSource();
        BindingSource voucherReleaseList = new BindingSource();

        private string staffId;
        private string receiptSearchType = "Mã đơn";
        private string receiptSearchTime = "Toàn bộ";
        private string ticketReceiptSearchTime = "Toàn bộ";

        public QuanLy(string staffId)
        {
            InitializeComponent();
            tcQuanLy.Appearance = TabAppearance.FlatButtons;
            tcQuanLy.ItemSize = new Size(0, 1);
            tcQuanLy.SizeMode = TabSizeMode.Fixed;
            btnVoucherUC.Enabled = false;
            this.staffId = staffId;
            LoadStaff();
            LoadCustomer();
            LoadProduct();
            LoadRevenue();
            LoadImportReceipt();
            LoadTicketReceipt();
            LoadVoucherRelease();
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
            string productId = txbProductId.Text.Trim();
            string productName = txbProductName.Text.Trim();
            int productType = txbProductType.Text.Trim().Equals("Đồ ăn") ? 1 : 2;
            decimal productPrice = Decimal.Parse(txbProductPrice.Text.Trim());
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
            string productId = txbProductId.Text.Trim();
            string productName = txbProductName.Text.Trim();
            int productType = txbProductType.Text.Trim().Equals("Đồ ăn") ? 1 : 2;
            decimal productPrice = Decimal.Parse(txbProductPrice.Text.Trim());
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
            string productId = txbProductId.Text.Trim();

            if (String.IsNullOrWhiteSpace(productId))
            {
                MessageBox.Show("Mã sản phẩm cần xóa không được để trống", "Cảnh báo");
                return;
            }

            DeleteProduct(productId);
            LoadProductList();
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string productName = txbSearchProduct.Text.Trim().ToUpper();
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
            txbEmail.DataBindings.Add("Text", dtgvCustomer.DataSource, "Email", true, DataSourceUpdateMode.Never);
            txtCusBirth.DataBindings.Add("Text", dtgvCustomer.DataSource, "Ngày sinh", true, DataSourceUpdateMode.Never);
            txtCusAddress.DataBindings.Add("Text", dtgvCustomer.DataSource, "Địa chỉ", true, DataSourceUpdateMode.Never);
            txtCusPhone.DataBindings.Add("Text", dtgvCustomer.DataSource, "SĐT", true, DataSourceUpdateMode.Never);
            txtCusINumber.DataBindings.Add("Text", dtgvCustomer.DataSource, "CMND", true, DataSourceUpdateMode.Never);
            nudPoint.DataBindings.Add("Value", dtgvCustomer.DataSource, "Điểm tích lũy", true, DataSourceUpdateMode.Never);
        }
        void InsertCustomer(string id, string hoTen, string email, DateTime ngaySinh, string diaChi, string sdt, int cmnd)
        {
            bool result = CustomerController.InsertCustomer(id, hoTen, email, ngaySinh, diaChi, sdt, cmnd);

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
            string email = txbEmail.Text;
            DateTime cusBirth = DateTime.Parse(txtCusBirth.Text);
            string cusAddress = txtCusAddress.Text;
            string cusPhone = txtCusPhone.Text;
            int cusINumber = Int32.Parse(txtCusINumber.Text);
            InsertCustomer(cusID, cusName, email, cusBirth, cusAddress, cusPhone, cusINumber);
            LoadCustomerList();
        }

        void UpdateCustomer(string id, string hoTen, string email, DateTime ngaySinh, string diaChi, string sdt, int cmnd, int point)
        {
            bool result = CustomerController.UpdateCustomer(id, hoTen, email, ngaySinh, diaChi, sdt, cmnd, point);

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
            string email = txbEmail.Text;
            DateTime cusBirth = DateTime.Parse(txtCusBirth.Text);
            string cusAddress = txtCusAddress.Text;
            string cusPhone = txtCusPhone.Text;
            int cusINumber = Int32.Parse(txtCusINumber.Text);
            int cusPoint = (int)nudPoint.Value;
            UpdateCustomer(cusID, cusName, email, cusBirth, cusAddress, cusPhone, cusINumber, cusPoint);
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

            if (String.IsNullOrWhiteSpace(cusName))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng trước khi tìm kiếm", "Cảnh báo");
                return;
            }

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
            string staffAddress = txtStaffAddress.Text;
            string staffPhone = txtStaffPhone.Text;
            int staffINumber = Int32.Parse(txtStaffINumber.Text);
            try
            {
                DateTime staffBirth = DateTime.Parse(txtStaffBirth.Text);
                AddStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
                LoadStaffList();
            }
            catch (Exception)
            {
                MessageBox.Show("Thông tin không hợp lệ", "Cảnh báo");
                return;
            }
            
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
            string staffAddress = txtStaffAddress.Text;
            string staffPhone = txtStaffPhone.Text;
            int staffINumber = Int32.Parse(txtStaffINumber.Text);
            try
            {
                DateTime staffBirth = DateTime.Parse(txtStaffBirth.Text);
                UpdateStaff(staffId, staffName, staffBirth, staffAddress, staffPhone, staffINumber);
                LoadStaffList();
            }
            catch (Exception)
            {
                MessageBox.Show("Thông tin không hợp lệ", "Cảnh báo");
                return;
            }
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
            string staffId = txtStaffId.Text.Trim();

            if (String.IsNullOrWhiteSpace(staffId))
            {
                MessageBox.Show("Mã nhân viên cần xóa không được để trống", "Cảnh báo");
                return;
            }

            DeleteStaff(staffId);
            LoadStaffList();
        }

        //Tìm kiếm Staff
        private void btnSearchStaff_Click(object sender, EventArgs e)
        {
            string staffName = txtSearchStaff.Text;

            if (String.IsNullOrWhiteSpace(staffName))
            {
                MessageBox.Show("Vui lòng nhập tên nhân viên trước khi tìm kiếm", "Cảnh báo");
                return;

            }

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
            cbbSearchType.SelectedIndex = 0;
            cbbSearchTime.SelectedIndex = 0;
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
            cbbTicketReceiptSearch.SelectedIndex = 0;
            cbbTicketReceiptTimeSearch.SelectedIndex = 0;
            LoadTicketReceiptList();
        }

        void LoadTicketReceiptList()
        {
            DataTable receipts = ReceiptController.GetTicketReceiptList();
            ticketReceiptList.DataSource = receipts;
        }

        //end ticket receipt

        //end history

        //begin voucher
        private void LoadVoucherRelease()
        {
            dtgvVoucherRelease.DataSource = voucherReleaseList;
            LoadVoucherReleaseList();
        }

        private void LoadVoucherReleaseList()
        {
            DataTable voucherReleaseDataTable = VoucherController.GetDataTableOfVoucherRelease();
            voucherReleaseList.DataSource = voucherReleaseDataTable;
        }

        //end voucher

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

            var controls = new[]
            {
                btnDataUC,
                btnCustomerUC,
                btnStaffUC,
                btnHistoryUC,
                btnProductUC,
                btnRevenueUC,
                btnVoucherUC,
            };

            foreach (var item in controls)
            {
                item.ForeColor = Color.White;
                item.Font = new Font(item.Font, FontStyle.Bold);
            }
        }

        private void btnExportImportReceipt_Click(object sender, EventArgs e)
        {
            Helper.Helper.Export2Excel(dtgvImportReceipt);
        }

        private void btnExportTicketReceipt_Click(object sender, EventArgs e)
        {
            Helper.Helper.Export2Excel(dtgvTicketReceipt);
        }

        private void btnAddVoucherRelease_Click(object sender, EventArgs e)
        {
            NewVoucherRelease frm = new NewVoucherRelease();
            frm.Show();
        }

        private void SearchStaffByName(string staffName)
        {
            StaffController.SearchStaffByName(staffName);
        }

        private void btnReportRevenue_Click_1(object sender, EventArgs e)
        {
            Chart frm = new Chart();
            frm.DrawChartByDate(DateTime.Now);
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Chart frm = new Chart();
            frm.DrawChartByQuarter(DateTime.Now);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Chart frm = new Chart();
            frm.DrawChartByYear(DateTime.Now);
            frm.Show();
        }

        private void txbSearchImportReceipt_Enter(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Text == "Tìm kiếm")
            {
                txb.Text = "";
            }
        }

        private void txbSearchImportReceipt_Leave(object sender, EventArgs e)
        {
            TextBox txb = sender as TextBox;
            if (txb.Text == "")
            {
                txb.Text = "Tìm kiếm";
            }
        }

        private void cbbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedIndex == 0)
            {
                receiptSearchType = "Mã đơn";
            }
            else if (cbb.SelectedIndex == 1)
            {
                receiptSearchType = "Nhân viên";
            }
            else if (cbb.SelectedIndex == 2)
            {
                receiptSearchType = "Sản phẩm";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string input = txbSearchImportReceipt.Text;

            if (String.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm", "Cảnh báo");
                return;
            }

            DataTable searchReceiptList = new DataTable();

            if (receiptSearchType.Equals("Mã đơn"))
            {
                searchReceiptList = ReceiptController.SearchImportReceiptById(input, receiptSearchTime);
            }
            else if (receiptSearchType.Equals("Nhân viên"))
            {
                searchReceiptList = ReceiptController.SearchImportReceiptByStaffName(input, receiptSearchTime);
            }
            else if (receiptSearchType.Equals("Sản phẩm"))
            {
                searchReceiptList = ReceiptController.SearchImportReceiptByProductName(input, receiptSearchTime);
            }

            importReceiptList.DataSource = searchReceiptList;
        }

        private void cbbSearchTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            receiptSearchTime = cbbSearchTime.Text;
            button3.PerformClick();
        }

        private void pbTicketSearch_Click(object sender, EventArgs e)
        {
            string input = txbTicketReceipt.Text;

            if (String.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm", "Cảnh báo");
                return;
            }

            DataTable searchReceiptList = new DataTable();

            if (dtpSearchTime.Enabled)
            {
                if (receiptSearchType.Equals("Mã đơn"))
                {
                    searchReceiptList = ReceiptController.SearchTicketReceiptById(input, dtpSearchTime.Value);
                }
                else if (receiptSearchType.Equals("Khách hàng"))
                {
                    searchReceiptList = ReceiptController.SearchTicketReceiptByCusName(input, dtpSearchTime.Value);
                }
                else if (receiptSearchType.Equals("Trực tuyến"))
                {
                    searchReceiptList = ReceiptController.SearchTicketReceiptByStatus(input, dtpSearchTime.Value);
                }
            }
            else
            {
                DateTime? nullDateTime = null;

                if (receiptSearchType.Equals("Mã đơn"))
                {
                    searchReceiptList = ReceiptController.SearchTicketReceiptById(input, nullDateTime);
                }
                else if (receiptSearchType.Equals("Khách hàng"))
                {
                    searchReceiptList = ReceiptController.SearchTicketReceiptByCusName(input, nullDateTime);
                }
                else if (receiptSearchType.Equals("Trực tuyến"))
                {
                    searchReceiptList = ReceiptController.SearchTicketReceiptByStatus(input, nullDateTime);
                }
            }

            ticketReceiptList.DataSource = searchReceiptList;
        }

        private void cbbTicketReceiptTimeSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedIndex == 0)
            {
                dtpSearchTime.Enabled = false;
            }
            else if (cbb.SelectedIndex == 1)
            {
                dtpSearchTime.Enabled = true;
            }
        }

        private void cbbTicketReceiptSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbb = sender as ComboBox;

            if (cbb.SelectedIndex == 0)
            {
                ticketReceiptSearchTime = "Mã đơn";
            }
            else if (cbb.SelectedIndex == 1)
            {
                ticketReceiptSearchTime = "Khách hàng";
            }
            else if (cbb.SelectedIndex == 2)
            {
                ticketReceiptSearchTime = "Trực tuyến";
            }
        }

        private void dtpSearchTime_ValueChanged(object sender, EventArgs e)
        {
            pbTicketSearch_Click(pbTicketSearch, e);
        }

        private void txtStaffPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtStaffINumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCusPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtCusINumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txbProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }

}
