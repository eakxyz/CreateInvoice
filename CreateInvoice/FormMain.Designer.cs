using System.Windows.Forms;

namespace CreateInvoice {
    partial class FormMain {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCash = new System.Windows.Forms.Button();
            this.btnCompany = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnCustomerGroup = new System.Windows.Forms.Button();
            this.btnMaster = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnCreateSale = new System.Windows.Forms.Button();
            this.btnToggleMenu = new System.Windows.Forms.Button();
            this.menuTimer = new System.Windows.Forms.Timer(this.components);
            this.panelContent = new System.Windows.Forms.Panel();
            this.btnSummary = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.panelMenu.Controls.Add(this.btnSummary);
            this.panelMenu.Controls.Add(this.btnCash);
            this.panelMenu.Controls.Add(this.btnCompany);
            this.panelMenu.Controls.Add(this.btnProducts);
            this.panelMenu.Controls.Add(this.btnCustomerGroup);
            this.panelMenu.Controls.Add(this.btnMaster);
            this.panelMenu.Controls.Add(this.btnCustomers);
            this.panelMenu.Controls.Add(this.btnCreateSale);
            this.panelMenu.Controls.Add(this.btnToggleMenu);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(2);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(110, 786);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMenu_Paint);
            // 
            // btnCash
            // 
            this.btnCash.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCash.FlatAppearance.BorderSize = 0;
            this.btnCash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCash.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCash.ForeColor = System.Drawing.Color.White;
            this.btnCash.Location = new System.Drawing.Point(0, 278);
            this.btnCash.Margin = new System.Windows.Forms.Padding(2);
            this.btnCash.Name = "btnCash";
            this.btnCash.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnCash.Size = new System.Drawing.Size(110, 41);
            this.btnCash.TabIndex = 7;
            this.btnCash.Text = "การรับชำระ";
            this.btnCash.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCash.UseVisualStyleBackColor = true;
            this.btnCash.Click += new System.EventHandler(this.btnCash_Click);
            // 
            // btnCompany
            // 
            this.btnCompany.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCompany.FlatAppearance.BorderSize = 0;
            this.btnCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompany.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompany.ForeColor = System.Drawing.Color.White;
            this.btnCompany.Location = new System.Drawing.Point(0, 237);
            this.btnCompany.Margin = new System.Windows.Forms.Padding(2);
            this.btnCompany.Name = "btnCompany";
            this.btnCompany.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnCompany.Size = new System.Drawing.Size(110, 41);
            this.btnCompany.TabIndex = 6;
            this.btnCompany.Text = "ที่อยู่บริษัท";
            this.btnCompany.UseVisualStyleBackColor = true;
            this.btnCompany.Click += new System.EventHandler(this.btnCompany_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProducts.FlatAppearance.BorderSize = 0;
            this.btnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducts.ForeColor = System.Drawing.Color.White;
            this.btnProducts.Location = new System.Drawing.Point(0, 196);
            this.btnProducts.Margin = new System.Windows.Forms.Padding(2);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnProducts.Size = new System.Drawing.Size(110, 41);
            this.btnProducts.TabIndex = 3;
            this.btnProducts.Text = "สินค้า";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // btnCustomerGroup
            // 
            this.btnCustomerGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomerGroup.FlatAppearance.BorderSize = 0;
            this.btnCustomerGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomerGroup.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomerGroup.ForeColor = System.Drawing.Color.White;
            this.btnCustomerGroup.Location = new System.Drawing.Point(0, 155);
            this.btnCustomerGroup.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomerGroup.Name = "btnCustomerGroup";
            this.btnCustomerGroup.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnCustomerGroup.Size = new System.Drawing.Size(110, 41);
            this.btnCustomerGroup.TabIndex = 5;
            this.btnCustomerGroup.Text = "กลุ่มลูกค้า";
            this.btnCustomerGroup.UseVisualStyleBackColor = true;
            this.btnCustomerGroup.Click += new System.EventHandler(this.btnCustomerGroupList_Click);
            // 
            // btnMaster
            // 
            this.btnMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMaster.FlatAppearance.BorderSize = 0;
            this.btnMaster.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaster.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaster.ForeColor = System.Drawing.Color.White;
            this.btnMaster.Location = new System.Drawing.Point(0, 114);
            this.btnMaster.Margin = new System.Windows.Forms.Padding(2);
            this.btnMaster.Name = "btnMaster";
            this.btnMaster.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnMaster.Size = new System.Drawing.Size(110, 41);
            this.btnMaster.TabIndex = 4;
            this.btnMaster.Text = "ข้อมูลทั่วไป";
            this.btnMaster.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMaster.UseVisualStyleBackColor = true;
            this.btnMaster.Click += new System.EventHandler(this.btnMaster_Click);
            // 
            // btnCustomers
            // 
            this.btnCustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomers.FlatAppearance.BorderSize = 0;
            this.btnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomers.ForeColor = System.Drawing.Color.White;
            this.btnCustomers.Location = new System.Drawing.Point(0, 73);
            this.btnCustomers.Margin = new System.Windows.Forms.Padding(2);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnCustomers.Size = new System.Drawing.Size(110, 41);
            this.btnCustomers.TabIndex = 1;
            this.btnCustomers.Text = "ลูกค้า";
            this.btnCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomers.UseVisualStyleBackColor = true;
            this.btnCustomers.Click += new System.EventHandler(this.btnCustomers_Click);
            // 
            // btnCreateSale
            // 
            this.btnCreateSale.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateSale.FlatAppearance.BorderSize = 0;
            this.btnCreateSale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateSale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateSale.ForeColor = System.Drawing.Color.White;
            this.btnCreateSale.Location = new System.Drawing.Point(0, 32);
            this.btnCreateSale.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateSale.Name = "btnCreateSale";
            this.btnCreateSale.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnCreateSale.Size = new System.Drawing.Size(110, 41);
            this.btnCreateSale.TabIndex = 2;
            this.btnCreateSale.Text = "สร้างการขาย";
            this.btnCreateSale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateSale.UseVisualStyleBackColor = true;
            this.btnCreateSale.Click += new System.EventHandler(this.btnCreateSale_Click);
            // 
            // btnToggleMenu
            // 
            this.btnToggleMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnToggleMenu.FlatAppearance.BorderSize = 0;
            this.btnToggleMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleMenu.ForeColor = System.Drawing.Color.White;
            this.btnToggleMenu.Location = new System.Drawing.Point(0, 0);
            this.btnToggleMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnToggleMenu.Name = "btnToggleMenu";
            this.btnToggleMenu.Size = new System.Drawing.Size(110, 32);
            this.btnToggleMenu.TabIndex = 0;
            this.btnToggleMenu.Text = "≡";
            this.btnToggleMenu.UseVisualStyleBackColor = true;
            this.btnToggleMenu.Click += new System.EventHandler(this.btnToggleMenu_Click);
            // 
            // menuTimer
            // 
            this.menuTimer.Interval = 10;
            this.menuTimer.Tick += new System.EventHandler(this.menuTimer_Tick);
            // 
            // panelContent
            // 
            this.panelContent.AutoScroll = true;
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(110, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1403, 786);
            this.panelContent.TabIndex = 0;
            // 
            // btnSummary
            // 
            this.btnSummary.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSummary.FlatAppearance.BorderSize = 0;
            this.btnSummary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSummary.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSummary.ForeColor = System.Drawing.Color.White;
            this.btnSummary.Location = new System.Drawing.Point(0, 319);
            this.btnSummary.Margin = new System.Windows.Forms.Padding(2);
            this.btnSummary.Name = "btnSummary";
            this.btnSummary.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnSummary.Size = new System.Drawing.Size(110, 41);
            this.btnSummary.TabIndex = 8;
            this.btnSummary.Text = "สรุปยอด";
            this.btnSummary.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSummary.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 786);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "โปรแกรมออกใบเสร็จ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnToggleMenu;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnCreateSale;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Timer menuTimer;
        private System.Windows.Forms.Button btnMaster;
        private System.Windows.Forms.Button btnCustomerGroup;
        private System.Windows.Forms.Button btnCompany;
        private System.Windows.Forms.Button btnCash;
        public System.Windows.Forms.Panel panelContent;
        private Button btnSummary;
    }
}
