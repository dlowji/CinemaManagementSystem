namespace CINEMA_NEW.Staff
{
    partial class MainStaffWindow
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDoan = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelPhimdangchieu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelBaocaosuco = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelDoan.SuspendLayout();
            this.panelPhimdangchieu.SuspendLayout();
            this.panelBaocaosuco.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(973, 42);
            this.panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.flowLayoutPanel1.Controls.Add(this.panelPhimdangchieu);
            this.flowLayoutPanel1.Controls.Add(this.panelDoan);
            this.flowLayoutPanel1.Controls.Add(this.panelBaocaosuco);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 48);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(231, 437);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panelDoan
            // 
            this.panelDoan.Controls.Add(this.label1);
            this.panelDoan.Location = new System.Drawing.Point(3, 60);
            this.panelDoan.Name = "panelDoan";
            this.panelDoan.Size = new System.Drawing.Size(228, 51);
            this.panelDoan.TabIndex = 0;
            this.panelDoan.Click += new System.EventHandler(this.panelDoan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đồ ăn";
            // 
            // panelPhimdangchieu
            // 
            this.panelPhimdangchieu.Controls.Add(this.label2);
            this.panelPhimdangchieu.Location = new System.Drawing.Point(3, 3);
            this.panelPhimdangchieu.Name = "panelPhimdangchieu";
            this.panelPhimdangchieu.Size = new System.Drawing.Size(228, 51);
            this.panelPhimdangchieu.TabIndex = 1;
            this.panelPhimdangchieu.Click += new System.EventHandler(this.panelPhimdangchieu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(4, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Phim đang chiếu";
            // 
            // panelBaocaosuco
            // 
            this.panelBaocaosuco.Controls.Add(this.label3);
            this.panelBaocaosuco.Location = new System.Drawing.Point(3, 117);
            this.panelBaocaosuco.Name = "panelBaocaosuco";
            this.panelBaocaosuco.Size = new System.Drawing.Size(228, 51);
            this.panelBaocaosuco.TabIndex = 2;
            this.panelBaocaosuco.Click += new System.EventHandler(this.panelBaocaosuco_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(4, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Báo cáo sự cố";
            // 
            // MainStaffWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 518);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Name = "MainStaffWindow";
            this.Text = "MainStaffWindow";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelDoan.ResumeLayout(false);
            this.panelDoan.PerformLayout();
            this.panelPhimdangchieu.ResumeLayout(false);
            this.panelPhimdangchieu.PerformLayout();
            this.panelBaocaosuco.ResumeLayout(false);
            this.panelBaocaosuco.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelPhimdangchieu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDoan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelBaocaosuco;
        private System.Windows.Forms.Label label3;
    }
}