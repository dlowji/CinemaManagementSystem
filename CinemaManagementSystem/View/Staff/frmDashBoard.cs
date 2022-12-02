using CinemaManagementSystem;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDashBoard : Form
    {
        public frmDashBoard(TaiKhoan acc)
        {
            InitializeComponent();

            this.LoginAccount = acc;
        }

        private TaiKhoan loginAccount;

        public TaiKhoan LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            //frmSeller frm = new frmSeller(loginAccount.idNV);
            //frm.LoadPlayingMovie(DateTime.Now);
            //frm.Show();
        }

        private void btnSeller_Click(object sender, EventArgs e)
        {
            //frmSeller frm = new frmSeller(loginAccount.idNV);
            //frm.LoadComingSoonMovie(DateTime.Now);
            //frm.Show();
        }
    }
}