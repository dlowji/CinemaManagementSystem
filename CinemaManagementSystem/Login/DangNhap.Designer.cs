namespace CinemaManagementSystem
{
    partial class DangNhap
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
            this.lbFlashMessage = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.llbQuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.txbMatKhau = new System.Windows.Forms.TextBox();
            this.txbTenDangNhap = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbFlashMessage);
            this.panel1.Controls.Add(this.btnDangNhap);
            this.panel1.Controls.Add(this.llbQuenMatKhau);
            this.panel1.Controls.Add(this.txbMatKhau);
            this.panel1.Controls.Add(this.txbTenDangNhap);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(322, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(443, 326);
            this.panel1.TabIndex = 1;
            // 
            // lbFlashMessage
            // 
            this.lbFlashMessage.AutoSize = true;
            this.lbFlashMessage.BackColor = System.Drawing.Color.Transparent;
            this.lbFlashMessage.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlashMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(22)))), ((int)(((byte)(25)))));
            this.lbFlashMessage.Location = new System.Drawing.Point(106, 239);
            this.lbFlashMessage.Name = "lbFlashMessage";
            this.lbFlashMessage.Size = new System.Drawing.Size(225, 18);
            this.lbFlashMessage.TabIndex = 11;
            this.lbFlashMessage.Text = "Tài khoản đăng nhập không tồn tại !!";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(110)))), ((int)(((byte)(162)))));
            this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDangNhap.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnDangNhap.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(165, 272);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(100, 35);
            this.btnDangNhap.TabIndex = 7;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // llbQuenMatKhau
            // 
            this.llbQuenMatKhau.AutoSize = true;
            this.llbQuenMatKhau.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbQuenMatKhau.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llbQuenMatKhau.Location = new System.Drawing.Point(131, 203);
            this.llbQuenMatKhau.Name = "llbQuenMatKhau";
            this.llbQuenMatKhau.Size = new System.Drawing.Size(107, 18);
            this.llbQuenMatKhau.TabIndex = 6;
            this.llbQuenMatKhau.TabStop = true;
            this.llbQuenMatKhau.Text = "Quên mật khẩu?";
            this.llbQuenMatKhau.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbQuenMatKhau_LinkClicked);
            // 
            // txbMatKhau
            // 
            this.txbMatKhau.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(110)))), ((int)(((byte)(162)))));
            this.txbMatKhau.Location = new System.Drawing.Point(134, 161);
            this.txbMatKhau.Name = "txbMatKhau";
            this.txbMatKhau.Size = new System.Drawing.Size(207, 25);
            this.txbMatKhau.TabIndex = 5;
            this.txbMatKhau.Text = "Mật khẩu";
            this.txbMatKhau.Enter += new System.EventHandler(this.txbMatKhau_Enter);
            this.txbMatKhau.Leave += new System.EventHandler(this.txbMatKhau_Leave);
            // 
            // txbTenDangNhap
            // 
            this.txbTenDangNhap.Font = new System.Drawing.Font("Open Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(110)))), ((int)(((byte)(162)))));
            this.txbTenDangNhap.Location = new System.Drawing.Point(134, 116);
            this.txbTenDangNhap.Name = "txbTenDangNhap";
            this.txbTenDangNhap.Size = new System.Drawing.Size(207, 25);
            this.txbTenDangNhap.TabIndex = 4;
            this.txbTenDangNhap.Text = "Tên đăng nhập";
            this.txbTenDangNhap.Enter += new System.EventHandler(this.txbTenDangNhap_Enter);
            this.txbTenDangNhap.Leave += new System.EventHandler(this.txbTenDangNhap_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::CinemaManagementSystem.Properties.Resources.password_76;
            this.pictureBox3.Location = new System.Drawing.Point(109, 161);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(19, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CinemaManagementSystem.Properties.Resources.user_icon_150670;
            this.pictureBox2.Location = new System.Drawing.Point(109, 116);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 25);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans ExtraBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(110)))), ((int)(((byte)(162)))));
            this.label1.Location = new System.Drawing.Point(102, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "WELCOME BACK";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::CinemaManagementSystem.Properties.Resources.MV5BZjYzZDgzMmYtYjY5Zi00YTk1LThhMDYtNjFlNzM4MTZhYzgyXkEyXkFqcGdeQXVyMTE5NDQ1MzQ3__V1_;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(295, 375);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // DangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 375);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.Name = "DangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbMatKhau;
        private System.Windows.Forms.TextBox txbTenDangNhap;
        private System.Windows.Forms.LinkLabel llbQuenMatKhau;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Label lbFlashMessage;
    }
}

