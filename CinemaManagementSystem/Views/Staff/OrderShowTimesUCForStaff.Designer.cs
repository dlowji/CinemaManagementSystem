namespace CinemaManagementSystem.View.Customer
{
    partial class OrderShowTimesUCForStaff
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelX = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbCineplex = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboFormatFilm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpThoiGian = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBuyticket = new System.Windows.Forms.Button();
            this.btnDetail = new System.Windows.Forms.Button();
            this.cboFilmName = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvLichChieu = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelX);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1043, 72);
            this.panel1.TabIndex = 0;
            // 
            // labelX
            // 
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX.ForeColor = System.Drawing.Color.Blue;
            this.labelX.Location = new System.Drawing.Point(8, 0);
            this.labelX.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(1027, 72);
            this.labelX.TabIndex = 1;
            this.labelX.Text = "Lịch Chiếu Phim";
            this.labelX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(319, 545);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbbCineplex);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboFormatFilm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpThoiGian);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBuyticket);
            this.groupBox1.Controls.Add(this.btnDetail);
            this.groupBox1.Controls.Add(this.cboFilmName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.groupBox1.Size = new System.Drawing.Size(319, 506);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Phim đang chiếu";
            // 
            // cbbCineplex
            // 
            this.cbbCineplex.FormattingEnabled = true;
            this.cbbCineplex.Location = new System.Drawing.Point(11, 273);
            this.cbbCineplex.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbbCineplex.Name = "cbbCineplex";
            this.cbbCineplex.Size = new System.Drawing.Size(289, 26);
            this.cbbCineplex.TabIndex = 11;
            this.cbbCineplex.SelectedIndexChanged += new System.EventHandler(this.cbbCineplex_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 245);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cụm Rạp:";
            // 
            // cboFormatFilm
            // 
            this.cboFormatFilm.FormattingEnabled = true;
            this.cboFormatFilm.Location = new System.Drawing.Point(11, 195);
            this.cboFormatFilm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboFormatFilm.Name = "cboFormatFilm";
            this.cboFormatFilm.Size = new System.Drawing.Size(289, 26);
            this.cboFormatFilm.TabIndex = 9;
            this.cboFormatFilm.SelectedIndexChanged += new System.EventHandler(this.cboFormatFilm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 167);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Suất Chiếu:";
            // 
            // dtpThoiGian
            // 
            this.dtpThoiGian.CustomFormat = "dd/MM/yyyy";
            this.dtpThoiGian.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpThoiGian.Location = new System.Drawing.Point(11, 126);
            this.dtpThoiGian.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpThoiGian.Name = "dtpThoiGian";
            this.dtpThoiGian.Size = new System.Drawing.Size(289, 27);
            this.dtpThoiGian.TabIndex = 6;
            this.dtpThoiGian.Value = new System.DateTime(2022, 11, 10, 0, 0, 0, 0);
            this.dtpThoiGian.ValueChanged += new System.EventHandler(this.dtpThoiGian_ValueChanged_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 98);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Thời Gian:";
            // 
            // btnBuyticket
            // 
            this.btnBuyticket.Location = new System.Drawing.Point(211, 343);
            this.btnBuyticket.Name = "btnBuyticket";
            this.btnBuyticket.Size = new System.Drawing.Size(89, 32);
            this.btnBuyticket.TabIndex = 5;
            this.btnBuyticket.Text = "Đặt vé";
            this.btnBuyticket.UseVisualStyleBackColor = true;
            this.btnBuyticket.Click += new System.EventHandler(this.btnBuyticket_Click);
            // 
            // btnDetail
            // 
            this.btnDetail.Location = new System.Drawing.Point(15, 343);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(103, 32);
            this.btnDetail.TabIndex = 5;
            this.btnDetail.Text = "Chi tiết";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // cboFilmName
            // 
            this.cboFilmName.FormattingEnabled = true;
            this.cboFilmName.Location = new System.Drawing.Point(11, 58);
            this.cboFilmName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cboFilmName.Name = "cboFilmName";
            this.cboFilmName.Size = new System.Drawing.Size(289, 26);
            this.cboFilmName.TabIndex = 4;
            this.cboFilmName.SelectedIndexChanged += new System.EventHandler(this.cboFilmName_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Phim:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lvLichChieu);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(319, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(724, 545);
            this.panel3.TabIndex = 2;
            // 
            // lvLichChieu
            // 
            this.lvLichChieu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader2});
            this.lvLichChieu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvLichChieu.FullRowSelect = true;
            this.lvLichChieu.HideSelection = false;
            this.lvLichChieu.Location = new System.Drawing.Point(2, 1);
            this.lvLichChieu.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvLichChieu.Name = "lvLichChieu";
            this.lvLichChieu.Size = new System.Drawing.Size(708, 506);
            this.lvLichChieu.TabIndex = 1;
            this.lvLichChieu.UseCompatibleStateImageBehavior = false;
            this.lvLichChieu.View = System.Windows.Forms.View.Details;
            this.lvLichChieu.Click += new System.EventHandler(this.lvLichChieu_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 38;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Phòng Chiếu";
            this.columnHeader1.Width = 167;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Tên Phim";
            this.columnHeader3.Width = 213;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Giờ Chiếu";
            this.columnHeader4.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tình Trạng";
            this.columnHeader2.Width = 150;
            // 
            // OrderShowTimes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OrderShowTimes";
            this.Size = new System.Drawing.Size(1043, 617);
            this.Load += new System.EventHandler(this.OrderShowTimes_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbCineplex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFormatFilm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpThoiGian;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuyticket;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.ComboBox cboFilmName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView lvLichChieu;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Timer timer1;
    }
}
