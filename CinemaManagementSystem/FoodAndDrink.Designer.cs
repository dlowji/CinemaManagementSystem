namespace CinemaManagementSystem
{
    partial class FoodAndDrink
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
            this.label1 = new System.Windows.Forms.Label();
            this.tcFoodAndDrink = new System.Windows.Forms.TabControl();
            this.tpAll = new System.Windows.Forms.TabPage();
            this.tpFood = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tpDrink = new System.Windows.Forms.TabPage();
            this.flpAll = new System.Windows.Forms.FlowLayoutPanel();
            this.flpFood = new System.Windows.Forms.FlowLayoutPanel();
            this.flpDrink = new System.Windows.Forms.FlowLayoutPanel();
            this.tcFoodAndDrink.SuspendLayout();
            this.tpAll.SuspendLayout();
            this.tpFood.SuspendLayout();
            this.tpDrink.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh mục sản phẩm";
            // 
            // tcFoodAndDrink
            // 
            this.tcFoodAndDrink.Controls.Add(this.tpAll);
            this.tcFoodAndDrink.Controls.Add(this.tpFood);
            this.tcFoodAndDrink.Controls.Add(this.tpDrink);
            this.tcFoodAndDrink.Location = new System.Drawing.Point(0, 35);
            this.tcFoodAndDrink.Name = "tcFoodAndDrink";
            this.tcFoodAndDrink.SelectedIndex = 0;
            this.tcFoodAndDrink.Size = new System.Drawing.Size(664, 702);
            this.tcFoodAndDrink.TabIndex = 2;
            // 
            // tpAll
            // 
            this.tpAll.Controls.Add(this.flpAll);
            this.tpAll.Location = new System.Drawing.Point(4, 22);
            this.tpAll.Name = "tpAll";
            this.tpAll.Padding = new System.Windows.Forms.Padding(3);
            this.tpAll.Size = new System.Drawing.Size(656, 676);
            this.tpAll.TabIndex = 0;
            this.tpAll.Text = "Tất cả";
            this.tpAll.UseVisualStyleBackColor = true;
            // 
            // tpFood
            // 
            this.tpFood.Controls.Add(this.flpFood);
            this.tpFood.Location = new System.Drawing.Point(4, 22);
            this.tpFood.Name = "tpFood";
            this.tpFood.Padding = new System.Windows.Forms.Padding(3);
            this.tpFood.Size = new System.Drawing.Size(656, 676);
            this.tpFood.TabIndex = 1;
            this.tpFood.Text = "Đồ ăn";
            this.tpFood.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(670, 57);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(241, 301);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(666, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thanh toán";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(872, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Xóa";
            // 
            // tpDrink
            // 
            this.tpDrink.Controls.Add(this.flpDrink);
            this.tpDrink.Location = new System.Drawing.Point(4, 22);
            this.tpDrink.Name = "tpDrink";
            this.tpDrink.Padding = new System.Windows.Forms.Padding(3);
            this.tpDrink.Size = new System.Drawing.Size(656, 676);
            this.tpDrink.TabIndex = 2;
            this.tpDrink.Text = "Thức uống";
            this.tpDrink.UseVisualStyleBackColor = true;
            // 
            // flpAll
            // 
            this.flpAll.AutoScroll = true;
            this.flpAll.Location = new System.Drawing.Point(3, 6);
            this.flpAll.Name = "flpAll";
            this.flpAll.Size = new System.Drawing.Size(650, 664);
            this.flpAll.TabIndex = 0;
            // 
            // flpFood
            // 
            this.flpFood.AutoScroll = true;
            this.flpFood.Location = new System.Drawing.Point(3, 7);
            this.flpFood.Name = "flpFood";
            this.flpFood.Size = new System.Drawing.Size(650, 664);
            this.flpFood.TabIndex = 1;
            // 
            // flpDrink
            // 
            this.flpDrink.AutoScroll = true;
            this.flpDrink.Location = new System.Drawing.Point(3, 6);
            this.flpDrink.Name = "flpDrink";
            this.flpDrink.Size = new System.Drawing.Size(650, 664);
            this.flpDrink.TabIndex = 1;
            // 
            // FoodAndDrink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 749);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tcFoodAndDrink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FoodAndDrink";
            this.Text = "FoodAndDrink";
            this.tcFoodAndDrink.ResumeLayout(false);
            this.tpAll.ResumeLayout(false);
            this.tpFood.ResumeLayout(false);
            this.tpDrink.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcFoodAndDrink;
        private System.Windows.Forms.TabPage tpAll;
        private System.Windows.Forms.TabPage tpFood;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tpDrink;
        private System.Windows.Forms.FlowLayoutPanel flpAll;
        private System.Windows.Forms.FlowLayoutPanel flpFood;
        private System.Windows.Forms.FlowLayoutPanel flpDrink;
    }
}