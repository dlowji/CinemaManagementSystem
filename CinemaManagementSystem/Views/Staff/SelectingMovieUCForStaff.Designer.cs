namespace CinemaManagementSystem.View.Customer
{
    partial class SelectingMovieUCForStaff
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
            this.btnMovieUC = new System.Windows.Forms.Button();
            this.pnData = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(68)))), ((int)(((byte)(78)))));
            this.panel1.Controls.Add(this.btnMovieUC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(185, 578);
            this.panel1.TabIndex = 1;
            // 
            // btnMovieUC
            // 
            this.btnMovieUC.FlatAppearance.BorderSize = 0;
            this.btnMovieUC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMovieUC.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMovieUC.ForeColor = System.Drawing.Color.White;
            this.btnMovieUC.Image = global::CinemaManagementSystem.Properties.Resources.video;
            this.btnMovieUC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMovieUC.Location = new System.Drawing.Point(0, 122);
            this.btnMovieUC.Name = "btnMovieUC";
            this.btnMovieUC.Size = new System.Drawing.Size(182, 54);
            this.btnMovieUC.TabIndex = 13;
            this.btnMovieUC.Text = "Phim đang chiếu";
            this.btnMovieUC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMovieUC.UseVisualStyleBackColor = true;
            this.btnMovieUC.Click += new System.EventHandler(this.btnMovieUC_Click);
            // 
            // pnData
            // 
            this.pnData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnData.Location = new System.Drawing.Point(187, 0);
            this.pnData.Margin = new System.Windows.Forms.Padding(2);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(1048, 578);
            this.pnData.TabIndex = 3;
            // 
            // SelectingMovieUCForStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 578);
            this.Controls.Add(this.pnData);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "SelectingMovieUCForStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GiaoDienChonPhim";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnMovieUC;
        private System.Windows.Forms.Panel pnData;
    }
}