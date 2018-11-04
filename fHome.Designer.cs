namespace QuanLyQuanCafe
{
    partial class fHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fHome));
            this.mnInfo = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtTotalPayment = new System.Windows.Forms.TextBox();
            this.nmSwitchtable = new System.Windows.Forms.NumericUpDown();
            this.lblPassword = new System.Windows.Forms.Label();
            this.nmDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnSwitchtable = new System.Windows.Forms.Button();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.nmProductcount = new System.Windows.Forms.NumericUpDown();
            this.btnAddproduct = new System.Windows.Forms.Button();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.mnInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSwitchtable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmProductcount)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnInfo
            // 
            this.mnInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.ProfileToolStripMenuItem});
            this.mnInfo.Location = new System.Drawing.Point(0, 0);
            this.mnInfo.Name = "mnInfo";
            this.mnInfo.Size = new System.Drawing.Size(800, 24);
            this.mnInfo.TabIndex = 0;
            this.mnInfo.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adminToolStripMenuItem.Image")));
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // ProfileToolStripMenuItem
            // 
            this.ProfileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("ProfileToolStripMenuItem.Image")));
            this.ProfileToolStripMenuItem.Name = "ProfileToolStripMenuItem";
            this.ProfileToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.ProfileToolStripMenuItem.Text = "Profile Setting";
            this.ProfileToolStripMenuItem.Click += new System.EventHandler(this.ProfileToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(492, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 261);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.Price,
            this.TotalPrice});
            this.lsvBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvBill.GridLines = true;
            this.lsvBill.Location = new System.Drawing.Point(0, 0);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(296, 261);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 65;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Count";
            this.columnHeader2.Width = 49;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.Width = 77;
            // 
            // TotalPrice
            // 
            this.TotalPrice.Text = "TotalPrice";
            this.TotalPrice.Width = 110;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtTotalPayment);
            this.panel3.Controls.Add(this.nmSwitchtable);
            this.panel3.Controls.Add(this.lblPassword);
            this.panel3.Controls.Add(this.nmDiscount);
            this.panel3.Controls.Add(this.btnSwitchtable);
            this.panel3.Controls.Add(this.btnCheckout);
            this.panel3.Controls.Add(this.btnDiscount);
            this.panel3.Location = new System.Drawing.Point(492, 378);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 95);
            this.panel3.TabIndex = 3;
            // 
            // txtTotalPayment
            // 
            this.txtTotalPayment.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotalPayment.Font = new System.Drawing.Font("Arial Narrow", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPayment.ForeColor = System.Drawing.Color.MediumBlue;
            this.txtTotalPayment.Location = new System.Drawing.Point(88, 1);
            this.txtTotalPayment.Name = "txtTotalPayment";
            this.txtTotalPayment.ReadOnly = true;
            this.txtTotalPayment.Size = new System.Drawing.Size(205, 25);
            this.txtTotalPayment.TabIndex = 6;
            this.txtTotalPayment.Text = "0,00 ₫";
            this.txtTotalPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nmSwitchtable
            // 
            this.nmSwitchtable.BackColor = System.Drawing.SystemColors.Info;
            this.nmSwitchtable.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmSwitchtable.Location = new System.Drawing.Point(3, 64);
            this.nmSwitchtable.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nmSwitchtable.Name = "nmSwitchtable";
            this.nmSwitchtable.Size = new System.Drawing.Size(80, 26);
            this.nmSwitchtable.TabIndex = 4;
            this.nmSwitchtable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(3, 8);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(84, 14);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Total payment:";
            // 
            // nmDiscount
            // 
            this.nmDiscount.BackColor = System.Drawing.SystemColors.Info;
            this.nmDiscount.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmDiscount.Location = new System.Drawing.Point(102, 65);
            this.nmDiscount.Name = "nmDiscount";
            this.nmDiscount.Size = new System.Drawing.Size(79, 26);
            this.nmDiscount.TabIndex = 4;
            this.nmDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSwitchtable
            // 
            this.btnSwitchtable.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSwitchtable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSwitchtable.Location = new System.Drawing.Point(3, 33);
            this.btnSwitchtable.Name = "btnSwitchtable";
            this.btnSwitchtable.Size = new System.Drawing.Size(80, 25);
            this.btnSwitchtable.TabIndex = 6;
            this.btnSwitchtable.Text = "Switch Table";
            this.btnSwitchtable.UseVisualStyleBackColor = false;
            // 
            // btnCheckout
            // 
            this.btnCheckout.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCheckout.Font = new System.Drawing.Font("Candara", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCheckout.Location = new System.Drawing.Point(200, 33);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(93, 58);
            this.btnCheckout.TabIndex = 5;
            this.btnCheckout.Text = "Check Out";
            this.btnCheckout.UseVisualStyleBackColor = false;
            // 
            // btnDiscount
            // 
            this.btnDiscount.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDiscount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnDiscount.Location = new System.Drawing.Point(101, 33);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(80, 25);
            this.btnDiscount.TabIndex = 4;
            this.btnDiscount.Text = "Discount";
            this.btnDiscount.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.nmProductcount);
            this.panel4.Controls.Add(this.btnAddproduct);
            this.panel4.Controls.Add(this.cbProduct);
            this.panel4.Controls.Add(this.cbCategory);
            this.panel4.Location = new System.Drawing.Point(495, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(296, 75);
            this.panel4.TabIndex = 4;
            // 
            // nmProductcount
            // 
            this.nmProductcount.BackColor = System.Drawing.SystemColors.Info;
            this.nmProductcount.Font = new System.Drawing.Font("Candara", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmProductcount.Location = new System.Drawing.Point(213, 6);
            this.nmProductcount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmProductcount.Name = "nmProductcount";
            this.nmProductcount.Size = new System.Drawing.Size(80, 26);
            this.nmProductcount.TabIndex = 3;
            this.nmProductcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmProductcount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddproduct
            // 
            this.btnAddproduct.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddproduct.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnAddproduct.Location = new System.Drawing.Point(213, 40);
            this.btnAddproduct.Name = "btnAddproduct";
            this.btnAddproduct.Size = new System.Drawing.Size(80, 26);
            this.btnAddproduct.TabIndex = 2;
            this.btnAddproduct.Text = "Add";
            this.btnAddproduct.UseVisualStyleBackColor = false;
            // 
            // cbProduct
            // 
            this.cbProduct.BackColor = System.Drawing.SystemColors.Info;
            this.cbProduct.FormattingEnabled = true;
            this.cbProduct.Location = new System.Drawing.Point(0, 43);
            this.cbProduct.Name = "cbProduct";
            this.cbProduct.Size = new System.Drawing.Size(196, 22);
            this.cbProduct.TabIndex = 1;
            // 
            // cbCategory
            // 
            this.cbCategory.BackColor = System.Drawing.SystemColors.Info;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(0, 10);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(197, 22);
            this.cbCategory.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flpTable);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 461);
            this.panel1.TabIndex = 1;
            // 
            // flpTable
            // 
            this.flpTable.AutoScroll = true;
            this.flpTable.BackColor = System.Drawing.SystemColors.Info;
            this.flpTable.Location = new System.Drawing.Point(12, 18);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(463, 425);
            this.flpTable.TabIndex = 0;
            // 
            // fHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowText;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mnInfo);
            this.Font = new System.Drawing.Font("Candara", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnInfo;
            this.Name = "fHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cafe";
            this.mnInfo.ResumeLayout(false);
            this.mnInfo.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSwitchtable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDiscount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmProductcount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnInfo;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProfileToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nmProductcount;
        private System.Windows.Forms.Button btnAddproduct;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.NumericUpDown nmDiscount;
        private System.Windows.Forms.Button btnSwitchtable;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnDiscount;
        private System.Windows.Forms.NumericUpDown nmSwitchtable;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader Price;
        private System.Windows.Forms.ColumnHeader TotalPrice;
        private System.Windows.Forms.TextBox txtTotalPayment;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
    }
}