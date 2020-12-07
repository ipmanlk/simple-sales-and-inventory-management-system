
namespace sales_and_inventory.View
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSales = new System.Windows.Forms.ToolStripMenuItem();
            this.createInvoiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalesReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreateInvoice = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnSalesReport = new System.Windows.Forms.Button();
            this.btnManageProducts = new System.Windows.Forms.Button();
            this.imgUser = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUser)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSales,
            this.menuProducts,
            this.reportsToolStripMenuItem,
            this.menuLogOut});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(698, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuSales
            // 
            this.menuSales.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createInvoiceToolStripMenuItem});
            this.menuSales.Name = "menuSales";
            this.menuSales.Size = new System.Drawing.Size(45, 20);
            this.menuSales.Text = "Sales";
            // 
            // createInvoiceToolStripMenuItem
            // 
            this.createInvoiceToolStripMenuItem.Name = "createInvoiceToolStripMenuItem";
            this.createInvoiceToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.createInvoiceToolStripMenuItem.Text = "Create Invoice";
            // 
            // menuProducts
            // 
            this.menuProducts.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.productsToolStripMenuItem});
            this.menuProducts.Name = "menuProducts";
            this.menuProducts.Size = new System.Drawing.Size(69, 20);
            this.menuProducts.Text = "Inventory";
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.productsToolStripMenuItem.Text = "Products";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSalesReport});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // menuSalesReport
            // 
            this.menuSalesReport.Name = "menuSalesReport";
            this.menuSalesReport.Size = new System.Drawing.Size(138, 22);
            this.menuSalesReport.Text = "Sales Report";
            // 
            // menuLogOut
            // 
            this.menuLogOut.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.menuLogOut.Name = "menuLogOut";
            this.menuLogOut.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuLogOut.Size = new System.Drawing.Size(62, 20);
            this.menuLogOut.Text = "Log Out";
            this.menuLogOut.Click += new System.EventHandler(this.menuLogOut_Click);
            // 
            // btnCreateInvoice
            // 
            this.btnCreateInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateInvoice.Location = new System.Drawing.Point(34, 219);
            this.btnCreateInvoice.Name = "btnCreateInvoice";
            this.btnCreateInvoice.Size = new System.Drawing.Size(169, 46);
            this.btnCreateInvoice.TabIndex = 1;
            this.btnCreateInvoice.Text = "Create Invoice";
            this.btnCreateInvoice.UseVisualStyleBackColor = true;
            this.btnCreateInvoice.Click += new System.EventHandler(this.btnCreateInvoice_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox4);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.btnSalesReport);
            this.groupBox1.Controls.Add(this.btnManageProducts);
            this.groupBox1.Controls.Add(this.btnCreateInvoice);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(674, 303);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quick Access";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(486, 43);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(141, 150);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(265, 43);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(149, 150);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(44, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(149, 150);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // btnSalesReport
            // 
            this.btnSalesReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesReport.Location = new System.Drawing.Point(472, 219);
            this.btnSalesReport.Name = "btnSalesReport";
            this.btnSalesReport.Size = new System.Drawing.Size(169, 46);
            this.btnSalesReport.TabIndex = 3;
            this.btnSalesReport.Text = "View Sales Report";
            this.btnSalesReport.UseVisualStyleBackColor = true;
            // 
            // btnManageProducts
            // 
            this.btnManageProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageProducts.Location = new System.Drawing.Point(253, 219);
            this.btnManageProducts.Name = "btnManageProducts";
            this.btnManageProducts.Size = new System.Drawing.Size(169, 46);
            this.btnManageProducts.TabIndex = 2;
            this.btnManageProducts.Text = "Manage Products";
            this.btnManageProducts.UseVisualStyleBackColor = true;
            // 
            // imgUser
            // 
            this.imgUser.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.imgUser.Location = new System.Drawing.Point(643, 40);
            this.imgUser.Name = "imgUser";
            this.imgUser.Size = new System.Drawing.Size(43, 43);
            this.imgUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgUser.TabIndex = 4;
            this.imgUser.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(547, 44);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "kasun@gmail.com";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(605, 63);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "kasun";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(698, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(343, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sales and Inventory Management System";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 432);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.imgUser);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(714, 471);
            this.MinimumSize = new System.Drawing.Size(714, 471);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSales;
        private System.Windows.Forms.ToolStripMenuItem createInvoiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuProducts;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSalesReport;
        private System.Windows.Forms.ToolStripMenuItem menuLogOut;
        private System.Windows.Forms.Button btnCreateInvoice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox imgUser;
        private System.Windows.Forms.Button btnSalesReport;
        private System.Windows.Forms.Button btnManageProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
    }
}