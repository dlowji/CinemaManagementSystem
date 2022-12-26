namespace CinemaManagementSystem.View.Customer
{
    partial class MovieViewUCForStaff
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
            this.cbbGenre = new System.Windows.Forms.ComboBox();
            this.pbSearchMovie = new System.Windows.Forms.PictureBox();
            this.txbSearchMovie = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.flpMovies = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchMovie)).BeginInit();
            this.SuspendLayout();
            // 
            // cbbGenre
            // 
            this.cbbGenre.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbGenre.FormattingEnabled = true;
            this.cbbGenre.Location = new System.Drawing.Point(257, 61);
            this.cbbGenre.Name = "cbbGenre";
            this.cbbGenre.Size = new System.Drawing.Size(121, 26);
            this.cbbGenre.TabIndex = 9;
            // 
            // pbSearchMovie
            // 
            this.pbSearchMovie.Image = global::CinemaManagementSystem.Properties.Resources.search;
            this.pbSearchMovie.Location = new System.Drawing.Point(27, 57);
            this.pbSearchMovie.Name = "pbSearchMovie";
            this.pbSearchMovie.Size = new System.Drawing.Size(27, 26);
            this.pbSearchMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSearchMovie.TabIndex = 8;
            this.pbSearchMovie.TabStop = false;
            // 
            // txbSearchMovie
            // 
            this.txbSearchMovie.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSearchMovie.Location = new System.Drawing.Point(60, 57);
            this.txbSearchMovie.Name = "txbSearchMovie";
            this.txbSearchMovie.Size = new System.Drawing.Size(134, 26);
            this.txbSearchMovie.TabIndex = 7;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(430, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 26);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Phim đang chiếu";
            // 
            // flpMovies
            // 
            this.flpMovies.AllowDrop = true;
            this.flpMovies.AutoScroll = true;
            this.flpMovies.BackColor = System.Drawing.Color.White;
            this.flpMovies.Location = new System.Drawing.Point(18, 108);
            this.flpMovies.Name = "flpMovies";
            this.flpMovies.Size = new System.Drawing.Size(1013, 445);
            this.flpMovies.TabIndex = 10;
            // 
            // MovieViewUCForStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpMovies);
            this.Controls.Add(this.cbbGenre);
            this.Controls.Add(this.pbSearchMovie);
            this.Controls.Add(this.txbSearchMovie);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label1);
            this.Name = "MovieViewUCForStaff";
            this.Size = new System.Drawing.Size(1048, 578);
            ((System.ComponentModel.ISupportInitialize)(this.pbSearchMovie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbbGenre;
        private System.Windows.Forms.PictureBox pbSearchMovie;
        private System.Windows.Forms.TextBox txbSearchMovie;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpMovies;
    }
}
