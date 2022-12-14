using CinemaManagementSystem.Controllers;
using CinemaManagementSystem.Helper;
using GUI.DAO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GUI.frmAdminUserControls.DataUserControl
{
    public partial class CinemaTypeUC : UserControl
    {
        BindingSource screenTypeList = new BindingSource();
        public CinemaTypeUC()
        {
            InitializeComponent();
            //Helper.ConfigStyle(this);
            LoadScreenType();
        }

        void LoadScreenType()
        {
            dtgvScreenType.DataSource = screenTypeList;
            LoadScreenTypeList();
            AddScreenTypeBinding();
        }
        void LoadScreenTypeList()
        {
            screenTypeList.DataSource = CinemaController.GetCinemaTypeDataTable();
        }
        void AddScreenTypeBinding()
        {
            txtScreenTypeID.DataBindings.Add("Text", dtgvScreenType.DataSource, "Mã loại rạp", true, DataSourceUpdateMode.Never);
            txtScreenTypeName.DataBindings.Add("Text", dtgvScreenType.DataSource, "Tên loại rạp", true, DataSourceUpdateMode.Never);
        }
        private void btnShowScreenType_Click(object sender, EventArgs e)
        {
            LoadScreenTypeList();
        }

        void InsertScreenType(string id, string name)
        {
            bool result = CinemaController.InsertCinemaType(id, name);

            if (result)
            {
                MessageBox.Show("Thêm loại rạp thành công");
            }
            else
            {
                MessageBox.Show("Thêm loại rạp thất bại");
            }
        }
        private void btnInsertScreenType_Click(object sender, EventArgs e)
        {
            string screenTypeID = txtScreenTypeID.Text;
            string screenTypeName = txtScreenTypeName.Text;
            InsertScreenType(screenTypeID, screenTypeName);
            LoadScreenTypeList();
        }

        void UpdateScreenType(string id, string name)
        {
            bool result = CinemaController.UpdateCinemaType(id, name);

            if (result)
            {
                MessageBox.Show("Sửa loại rạp thành công");
            }
            else
            {
                MessageBox.Show("Sửa loại rạp thất bại");
            }
        }
        private void btnUpdateScreenType_Click(object sender, EventArgs e)
        {
            string screenTypeID = txtScreenTypeID.Text;
            string screenTypeName = txtScreenTypeName.Text;
            UpdateScreenType(screenTypeID, screenTypeName);
            LoadScreenTypeList();
        }

        void DeleteScreenType(string id)
        {
            bool result = CinemaController.DeleteCinemaType(id);

            if (result)
            {
                MessageBox.Show("Xóa loại rạp thành công");
            }
            else
            {
                MessageBox.Show("Xóa loại rạp thất bại");
            }
        }
        private void btnDeleteScreenType_Click(object sender, EventArgs e)
        {
            string screenTypeID = txtScreenTypeID.Text;
            DeleteScreenType(screenTypeID);
            LoadScreenTypeList();
        }
    }
}
