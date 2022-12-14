namespace CinemaManagementSystem.View.Customer
{
    partial class OrderSeat
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblInformation = new System.Windows.Forms.Label();
            this.flpSeat = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.picFilm = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilm)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel4.Controls.Add(this.lblTime);
            this.panel4.Controls.Add(this.lblInformation);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1142, 34);
            this.panel4.TabIndex = 6;
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(639, 9);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(48, 18);
            this.lblTime.TabIndex = 2;
            this.lblTime.Text = "Time";
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(12, 9);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(104, 18);
            this.lblInformation.TabIndex = 1;
            this.lblInformation.Text = "Information";
            // 
            // flpSeat
            // 
            this.flpSeat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.flpSeat.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpSeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpSeat.Location = new System.Drawing.Point(45, 114);
            this.flpSeat.Name = "flpSeat";
            this.flpSeat.Size = new System.Drawing.Size(800, 376);
            this.flpSeat.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkOrange;
            this.label1.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(881, 48);
            this.label1.TabIndex = 8;
            this.label1.Text = "Màn Chiếu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picFilm
            // 
            this.picFilm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFilm.Location = new System.Drawing.Point(857, 128);
            this.picFilm.Name = "picFilm";
            this.picFilm.Size = new System.Drawing.Size(167, 210);
            this.picFilm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFilm.TabIndex = 9;
            this.picFilm.TabStop = false;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(44)))), ((int)(((byte)(34)))));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnNext.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(906, 495);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(118, 35);
            this.btnNext.TabIndex = 10;
            this.btnNext.Text = "Tiếp theo";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(923, 368);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đang chọn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(923, 419);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 12;
            this.label3.Text = "Đã mua";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(874, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 35);
            this.label4.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(874, 410);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 35);
            this.label5.TabIndex = 11;
            // 
            // OrderSeat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.OldLace;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.picFilm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpSeat);
            this.Controls.Add(this.panel4);
            this.Name = "OrderSeat";
            this.Size = new System.Drawing.Size(1142, 533);
            this.Load += new System.EventHandler(this.OrderSeat_Load);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFilm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.FlowLayoutPanel flpSeat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picFilm;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
