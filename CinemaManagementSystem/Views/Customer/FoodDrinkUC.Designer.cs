namespace CinemaManagementSystem.View.Customer
{
    partial class FoodDrinkUC
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
            this.label1 = new System.Windows.Forms.Label();
            this.flpCart = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpAll = new System.Windows.Forms.TabPage();
            this.flpAll = new System.Windows.Forms.FlowLayoutPanel();
            this.tpFood = new System.Windows.Forms.TabPage();
            this.flpFood = new System.Windows.Forms.FlowLayoutPanel();
            this.tpDrink = new System.Windows.Forms.TabPage();
            this.flpDrink = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNext = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lbProductsPrice = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tpAll.SuspendLayout();
            this.tpFood.SuspendLayout();
            this.tpDrink.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh mục sản phẩm";
            // 
            // flpCart
            // 
            this.flpCart.AutoScroll = true;
            this.flpCart.BackColor = System.Drawing.Color.White;
            this.flpCart.Location = new System.Drawing.Point(727, 66);
            this.flpCart.Name = "flpCart";
            this.flpCart.Size = new System.Drawing.Size(290, 393);
            this.flpCart.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(978, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Xóa";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(724, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Thanh toán";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpAll);
            this.tabControl1.Controls.Add(this.tpFood);
            this.tabControl1.Controls.Add(this.tpDrink);
            this.tabControl1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 44);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(693, 522);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tpAll
            // 
            this.tpAll.AutoScroll = true;
            this.tpAll.Controls.Add(this.flpAll);
            this.tpAll.Location = new System.Drawing.Point(4, 27);
            this.tpAll.Name = "tpAll";
            this.tpAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpAll.Size = new System.Drawing.Size(685, 491);
            this.tpAll.TabIndex = 0;
            this.tpAll.Text = "Tất cả";
            this.tpAll.UseVisualStyleBackColor = true;
            // 
            // flpAll
            // 
            this.flpAll.AutoScroll = true;
            this.flpAll.Location = new System.Drawing.Point(6, 6);
            this.flpAll.Name = "flpAll";
            this.flpAll.Size = new System.Drawing.Size(673, 484);
            this.flpAll.TabIndex = 0;
            // 
            // tpFood
            // 
            this.tpFood.Controls.Add(this.flpFood);
            this.tpFood.Location = new System.Drawing.Point(4, 27);
            this.tpFood.Name = "tpFood";
            this.tpFood.Padding = new System.Windows.Forms.Padding(3);
            this.tpFood.Size = new System.Drawing.Size(685, 491);
            this.tpFood.TabIndex = 1;
            this.tpFood.Text = "Đồ ăn";
            this.tpFood.UseVisualStyleBackColor = true;
            // 
            // flpFood
            // 
            this.flpFood.AutoScroll = true;
            this.flpFood.Location = new System.Drawing.Point(6, 6);
            this.flpFood.Name = "flpFood";
            this.flpFood.Size = new System.Drawing.Size(673, 465);
            this.flpFood.TabIndex = 1;
            // 
            // tpDrink
            // 
            this.tpDrink.Controls.Add(this.flpDrink);
            this.tpDrink.Location = new System.Drawing.Point(4, 27);
            this.tpDrink.Name = "tpDrink";
            this.tpDrink.Size = new System.Drawing.Size(685, 491);
            this.tpDrink.TabIndex = 2;
            this.tpDrink.Text = "Thức uống";
            this.tpDrink.UseVisualStyleBackColor = true;
            // 
            // flpDrink
            // 
            this.flpDrink.AutoScroll = true;
            this.flpDrink.Location = new System.Drawing.Point(6, 6);
            this.flpDrink.Name = "flpDrink";
            this.flpDrink.Size = new System.Drawing.Size(676, 479);
            this.flpDrink.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(44)))), ((int)(((byte)(34)))));
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnNext.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(899, 521);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(118, 35);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Tiếp theo";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(737, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tổng:";
            // 
            // lbProductsPrice
            // 
            this.lbProductsPrice.AutoSize = true;
            this.lbProductsPrice.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProductsPrice.Location = new System.Drawing.Point(906, 482);
            this.lbProductsPrice.Name = "lbProductsPrice";
            this.lbProductsPrice.Size = new System.Drawing.Size(101, 18);
            this.lbProductsPrice.TabIndex = 13;
            this.lbProductsPrice.Text = "Thanh toán";
            // 
            // FoodDrinkUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbProductsPrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.flpCart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FoodDrinkUC";
            this.Size = new System.Drawing.Size(1048, 578);
            this.tabControl1.ResumeLayout(false);
            this.tpAll.ResumeLayout(false);
            this.tpFood.ResumeLayout(false);
            this.tpDrink.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flpCart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpAll;
        private System.Windows.Forms.TabPage tpFood;
        private System.Windows.Forms.TabPage tpDrink;
        private System.Windows.Forms.FlowLayoutPanel flpAll;
        private System.Windows.Forms.FlowLayoutPanel flpFood;
        private System.Windows.Forms.FlowLayoutPanel flpDrink;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbProductsPrice;
    }
}
