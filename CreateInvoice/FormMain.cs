using System;
using System.Drawing;
using System.Windows.Forms;

namespace CreateInvoice {
    public partial class FormMain : Form {
        private bool menuExpanded = false;
        private const int MenuCollapsedWidth = 50;
        private const int MenuExpandedWidth = 160;
        private readonly ToolTip toolTip = new ToolTip();

        // flag สำหรับจำสถานะ toggle ปุ่มกลุ่มลูกค้า
        private bool customerGroupHidden = false;

        // Persist views so you can place controls in each page and keep their state
        private readonly CustomersControl customersControl = new CustomersControl();
        private readonly CashControl cashControl = new CashControl();
        private readonly CompanyListControl companyControl = new CompanyListControl();
        private readonly CreateSaleControl createSaleControl = null;
        private readonly ProductControl productControl = new ProductControl();
        private readonly EmployeeGroupControl employeeGroupControl = new EmployeeGroupControl();

        public FormMain() {
            InitializeComponent();

            createSaleControl = new CreateSaleControl((FormMain)this);
            // Start with expanded menu
            menuExpanded = true;
            panelMenu.Width = MenuExpandedWidth;
            UpdateMenuVisuals();

            InitToolTips();
            InitContentViews();
            ShowView(customersControl);
        }


        private void InitToolTips() {
            toolTip.SetToolTip(btnCustomers, "ลูกค้า");
            toolTip.SetToolTip(btnCreateSale, "สร้างการขาย");
            toolTip.SetToolTip(btnProducts, "สินค้า");
        }

        private void UpdateMenuVisuals() {
            if (menuExpanded) {
                btnCustomers.Text = "ลูกค้า";
                btnCreateSale.Text = "สร้างการขาย";
                btnProducts.Text = "สินค้า";
                btnMaster.Text = "ข้อมูลทั่วไป";
                btnCash.Text = "การรับชำระ";
                btnToggleMenu.Text = "≡";

                btnCustomers.TextAlign = ContentAlignment.MiddleLeft;
                btnCreateSale.TextAlign = ContentAlignment.MiddleLeft;
                //btnProducts.TextAlign = ContentAlignment.MiddleLeft;
                btnMaster.TextAlign = ContentAlignment.MiddleLeft;
                btnCash.TextAlign = ContentAlignment.MiddleLeft;
            } else {
                btnCustomers.Text = "🧑";
                btnCreateSale.Text = "🧾";
                btnProducts.Text = "📦";
                btnMaster.Text = "ℹ";
                btnToggleMenu.Text = "≡";

                btnCustomers.TextAlign = ContentAlignment.MiddleCenter;
                btnCreateSale.TextAlign = ContentAlignment.MiddleCenter;
                btnProducts.TextAlign = ContentAlignment.MiddleCenter;
                btnMaster.TextAlign = ContentAlignment.MiddleCenter;
            }

            // อัปเดตการแสดงผลปุ่มกลุ่มลูกค้าตาม flag ปัจจุบัน
            btnMaster.Visible = !customerGroupHidden;

            panelContent.Location = new Point(panelMenu.Width, 0);
            panelContent.Size = new Size(this.ClientSize.Width - panelMenu.Width, this.ClientSize.Height);
        }

        private void btnToggleMenu_Click(object sender, EventArgs e) {
            menuExpanded = !menuExpanded;
            menuTimer.Start();
        }

        private void menuTimer_Tick(object sender, EventArgs e) {
            int step = 10;
            int target = menuExpanded ? MenuExpandedWidth : MenuCollapsedWidth;

            if (menuExpanded && panelMenu.Width < target) {
                panelMenu.Width = Math.Min(panelMenu.Width + step, target);
            } else if (!menuExpanded && panelMenu.Width > target) {
                panelMenu.Width = Math.Max(panelMenu.Width - step, target);
            }

            if (panelMenu.Width == target) {
                menuTimer.Stop();
                UpdateMenuVisuals();
            } else {
                panelContent.Location = new Point(panelMenu.Width, 0);
                panelContent.Size = new Size(this.ClientSize.Width - panelMenu.Width, this.ClientSize.Height);
            }
        }

        private void InitContentViews() {
            panelContent.Controls.Clear();

            //customersControl.Dock = DockStyle.Fill;
            //createSaleControl.Dock = DockStyle.Fill;
            //productControl.Dock = DockStyle.Fill;
            //employeeGroupControl.Dock = DockStyle.Fill;

            panelContent.Controls.Add(customersControl);
            panelContent.Controls.Add(createSaleControl);
            panelContent.Controls.Add(productControl);
            panelContent.Controls.Add(employeeGroupControl);
        }

        private void ShowView(UserControl view) {
            foreach (Control ctrl in panelContent.Controls) {
                ctrl.Visible = false;
            }

            if (!panelContent.Controls.Contains(view)) {
                panelContent.Controls.Add(view);
            }

            view.Visible = true;
            //view.Dock = DockStyle.Fill;
            view.BringToFront();
        }

        private void btnCustomers_Click(object sender, EventArgs e) {
            ShowView(customersControl);
        }

        private void btnCreateSale_Click(object sender, EventArgs e) {
            ShowView(createSaleControl);
        }

        private void btnProducts_Click(object sender, EventArgs e) {
            ShowView(productControl);
        }

        private void btnMaster_Click(object sender, EventArgs e) {
            // toggle สถานะ ซ่อน/แสดง ปุ่มกลุ่มลูกค้า เมื่อกดปุ่มนี้
            customerGroupHidden = !customerGroupHidden;

            // ถ้า flag เป็น true = ต้องการซ่อนปุ่ม -> ซ่อนตัวเอง
            // ถ้า flag เป็น false = ต้องการแสดงปุ่ม -> แสดงตัวเอง
            btnCustomerGroup.Visible = !customerGroupHidden;
            btnProducts.Visible = !customerGroupHidden;
            btnCompany.Visible = !customerGroupHidden;

            //// เมื่อปุ่มยังมองเห็น ให้แสดงหน้าข้อมูลทั่วไปด้วย
            //if (!customerGroupHidden) {

            //    ShowView(employeeGroupControl);
            //}
        }

        private void btnCustomerGroupList_Click(object sender, EventArgs e) {
            ShowView(employeeGroupControl);
        }

        protected override void OnResize(EventArgs e) {
            base.OnResize(e);
            panelContent.Location = new Point(panelMenu.Width, 0);
            panelContent.Size = new Size(this.ClientSize.Width - panelMenu.Width, this.ClientSize.Height);

            foreach (Control ctrl in panelContent.Controls) {
                if (ctrl.Visible && ctrl.Dock == DockStyle.Top) {
                    ctrl.Width = panelContent.ClientSize.Width;
                }
            }
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e) {

        }

        private void btnCash_Click(object sender, EventArgs e) {
            ShowView(cashControl);
        }

        private void btnCompany_Click(object sender, EventArgs e) {
            ShowView(companyControl);
        }
    }
}
