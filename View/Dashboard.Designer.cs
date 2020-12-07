
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSales = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCreateInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.menuInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProducts = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSalesReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusUserInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSales,
            this.menuInventory,
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
            this.menuCreateInvoice});
            this.menuSales.Name = "menuSales";
            this.menuSales.Size = new System.Drawing.Size(45, 20);
            this.menuSales.Text = "Sales";
            // 
            // menuCreateInvoice
            // 
            this.menuCreateInvoice.Name = "menuCreateInvoice";
            this.menuCreateInvoice.Size = new System.Drawing.Size(180, 22);
            this.menuCreateInvoice.Text = "Create Invoice";
            this.menuCreateInvoice.Click += new System.EventHandler(this.menuCreateInvoice_Click);
            // 
            // menuInventory
            // 
            this.menuInventory.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProducts});
            this.menuInventory.Name = "menuInventory";
            this.menuInventory.Size = new System.Drawing.Size(69, 20);
            this.menuInventory.Text = "Inventory";
            // 
            // menuProducts
            // 
            this.menuProducts.Name = "menuProducts";
            this.menuProducts.Size = new System.Drawing.Size(180, 22);
            this.menuProducts.Text = "Products";
            this.menuProducts.Click += new System.EventHandler(this.menuProducts_Click);
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
            this.menuSalesReport.Size = new System.Drawing.Size(180, 22);
            this.menuSalesReport.Text = "Sales Report";
            this.menuSalesReport.Click += new System.EventHandler(this.menuSalesReport_Click);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusUserInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 410);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(698, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusUserInfo
            // 
            this.statusUserInfo.Name = "statusUserInfo";
            this.statusUserInfo.Size = new System.Drawing.Size(86, 17);
            this.statusUserInfo.Text = "test@user.com";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(82, 17);
            this.toolStripStatusLabel1.Text = "Logged In As: ";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 432);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales and Inventory Management System : Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Dashboard_FormClosed);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSales;
        private System.Windows.Forms.ToolStripMenuItem menuCreateInvoice;
        private System.Windows.Forms.ToolStripMenuItem menuInventory;
        private System.Windows.Forms.ToolStripMenuItem menuProducts;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuSalesReport;
        private System.Windows.Forms.ToolStripMenuItem menuLogOut;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusUserInfo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}