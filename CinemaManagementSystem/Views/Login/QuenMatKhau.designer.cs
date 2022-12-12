namespace CinemaManagementSystem
{
    partial class QuenMatKhau
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbMessage = new System.Windows.Forms.Label();
            this.pbBackIcon = new System.Windows.Forms.PictureBox();
            this.btnGuiMa = new System.Windows.Forms.Button();
            this.txbTaiKhoanCanKhoiPhuc = new System.Windows.Forms.TextBox();
            this.icon = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnTiepTuc = new System.Windows.Forms.Button();
            this.lbGuiLaiMa = new System.Windows.Forms.Label();
            this.btnQuaylai = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnQuaylai);
            this.panel1.Controls.Add(this.lbGuiLaiMa);
            this.panel1.Controls.Add(this.btnTiepTuc);
            this.panel1.Controls.Add(this.lbMessage);
            this.panel1.Controls.Add(this.pbBackIcon);
            this.panel1.Controls.Add(this.btnGuiMa);
            this.panel1.Controls.Add(this.txbTaiKhoanCanKhoiPhuc);
            this.panel1.Controls.Add(this.icon);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(380, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 375);
            this.panel1.TabIndex = 3;
            // 
            // lbMessage
            // 
            this.lbMessage.AllowDrop = true;
            this.lbMessage.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(44)))), ((int)(((byte)(34)))));
            this.lbMessage.Location = new System.Drawing.Point(50, 110);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(291, 74);
            this.lbMessage.TabIndex = 9;
            this.lbMessage.Text = "Chúng tôi sẽ gửi mã đặt lại mật khẩu thông qua Email khách hàng đã đăng ký thành " +
    "công.";
            // 
            // pbBackIcon
            // 
            this.pbBackIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbBackIcon.Image = global::CinemaManagementSystem.Properties.Resources.back;
            this.pbBackIcon.Location = new System.Drawing.Point(0, 0);
            this.pbBackIcon.Name = "pbBackIcon";
            this.pbBackIcon.Size = new System.Drawing.Size(41, 38);
            this.pbBackIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBackIcon.TabIndex = 8;
            this.pbBackIcon.TabStop = false;
            this.pbBackIcon.Click += new System.EventHandler(this.pbBackIcon_Click);
            // 
            // btnGuiMa
            // 
            this.btnGuiMa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(44)))), ((int)(((byte)(34)))));
            this.btnGuiMa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuiMa.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnGuiMa.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuiMa.ForeColor = System.Drawing.Color.White;
            this.btnGuiMa.Location = new System.Drawing.Point(143, 299);
            this.btnGuiMa.Name = "btnGuiMa";
            this.btnGuiMa.Size = new System.Drawing.Size(100, 35);
            this.btnGuiMa.TabIndex = 7;
            this.btnGuiMa.Text = "Gửi mã";
            this.btnGuiMa.UseVisualStyleBackColor = false;
            this.btnGuiMa.Click += new System.EventHandler(this.btnGuiMa_Click);
            // 
            // txbTaiKhoanCanKhoiPhuc
            // 
            this.txbTaiKhoanCanKhoiPhuc.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTaiKhoanCanKhoiPhuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.txbTaiKhoanCanKhoiPhuc.Location = new System.Drawing.Point(104, 206);
            this.txbTaiKhoanCanKhoiPhuc.Name = "txbTaiKhoanCanKhoiPhuc";
            this.txbTaiKhoanCanKhoiPhuc.Size = new System.Drawing.Size(207, 26);
            this.txbTaiKhoanCanKhoiPhuc.TabIndex = 4;
            this.txbTaiKhoanCanKhoiPhuc.Text = "Tài khoản cần khôi phục";
            this.txbTaiKhoanCanKhoiPhuc.Enter += new System.EventHandler(this.txbTaiKhoanCanKhoiPhuc_Enter);
            this.txbTaiKhoanCanKhoiPhuc.Leave += new System.EventHandler(this.txbTaiKhoanCanKhoiPhuc_Leave);
            // 
            // icon
            // 
            this.icon.Image = global::CinemaManagementSystem.Properties.Resources.mail;
            this.icon.Location = new System.Drawing.Point(79, 206);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(19, 25);
            this.icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.icon.TabIndex = 3;
            this.icon.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(44)))), ((int)(((byte)(34)))));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "KHÔI PHỤC MẬT KHẨU";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CinemaManagementSystem.Properties.Resources.cgv2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(380, 375);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnTiepTuc
            // 
            this.btnTiepTuc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(44)))), ((int)(((byte)(34)))));
            this.btnTiepTuc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTiepTuc.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnTiepTuc.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTiepTuc.ForeColor = System.Drawing.Color.White;
            this.btnTiepTuc.Location = new System.Drawing.Point(272, 299);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(100, 35);
            this.btnTiepTuc.TabIndex = 10;
            this.btnTiepTuc.Text = "Tiếp tục";
            this.btnTiepTuc.UseVisualStyleBackColor = false;
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);
            // 
            // lbGuiLaiMa
            // 
            this.lbGuiLaiMa.AllowDrop = true;
            this.lbGuiLaiMa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbGuiLaiMa.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGuiLaiMa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(44)))), ((int)(((byte)(34)))));
            this.lbGuiLaiMa.Location = new System.Drawing.Point(101, 247);
            this.lbGuiLaiMa.Name = "lbGuiLaiMa";
            this.lbGuiLaiMa.Size = new System.Drawing.Size(175, 24);
            this.lbGuiLaiMa.TabIndex = 11;
            this.lbGuiLaiMa.Text = "Chưa nhận được mã?";
            this.lbGuiLaiMa.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnQuaylai
            // 
            this.btnQuaylai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(44)))), ((int)(((byte)(34)))));
            this.btnQuaylai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuaylai.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnQuaylai.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuaylai.ForeColor = System.Drawing.Color.White;
            this.btnQuaylai.Location = new System.Drawing.Point(18, 299);
            this.btnQuaylai.Name = "btnQuaylai";
            this.btnQuaylai.Size = new System.Drawing.Size(100, 35);
            this.btnQuaylai.TabIndex = 12;
            this.btnQuaylai.Text = "Quay lại";
            this.btnQuaylai.UseVisualStyleBackColor = false;
            this.btnQuaylai.Click += new System.EventHandler(this.btnQuaylai_Click);
            // 
            // QuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 375);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "QuenMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuenMatKhau";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGuiMa;
        private System.Windows.Forms.TextBox txbTaiKhoanCanKhoiPhuc;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbBackIcon;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btnTiepTuc;
        private System.Windows.Forms.Label lbGuiLaiMa;
        private System.Windows.Forms.Button btnQuaylai;
    }
}