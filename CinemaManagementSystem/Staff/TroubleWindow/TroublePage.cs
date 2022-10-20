using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CINEMA_NEW.Staff.TroubleWindow
{
    public partial class TroublePage : Form
    {
        public TroublePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddError addError = new AddError();
            addError.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Suco> list = new List<Suco>();
            list.Add(new Suco("hu mang hinh tivi", "22012001", "chua giai quyet"));
            list.Add(new Suco("hu cai ghe", "22012001", "chua giai quyet"));
            list.Add(new Suco("hu cho quet", "22012001", "chua giai quyet"));
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            EditError edit = new EditError();
            edit.Show();
        }
    }
}
