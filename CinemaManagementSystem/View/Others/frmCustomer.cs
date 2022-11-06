using CinemaManagementSystem;
using GUI.DAO;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmCustomer : Form
    {
        public frmCustomer()
        {
            InitializeComponent();
        }

        public KhachHang customer;

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            DataTable data = CustomerDAO.GetCustomerMember(txtCustomerID.Text, txtCustomerName.Text);

            if (data.Rows.Count == 0)
            {
                MessageBox.Show("ID hoặc Họ tên của Khách Hàng không chính xác!\nVui lòng nhập lại thông tin.");
                return;
            }

            customer = new KhachHang();

            DataRow row = data.Rows[0];

            customer.id = row["Mã khách hàng"].ToString();
            customer.HoTen = row["Họ tên"].ToString();
            customer.NgaySinh = DateTime.Parse(row["Ngày sinh"].ToString());
            customer.DiaChi = row["Địa chỉ"].ToString();
            customer.SDT = row["SĐT"].ToString();
            customer.CMND = (int)row["CMND"];
            customer.DiemTichLuy = (int)row["Điểm tích lũy"];

            DialogResult = DialogResult.OK;
        }
    }
}
