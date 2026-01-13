using BotCommon;
using System;
using System.Collections.Generic;
using System.Data;
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
        private readonly CustomerListControl customerListControl = null;
        private readonly CashControl cashControl = new CashControl();
        private readonly CompanyListControl companyControl = new CompanyListControl();
        private readonly CreateSaleControl createSaleControl = null;
        private readonly ProductControl productControl = null;
        private readonly EmployeeGroupListControl employeeGroupControl = null;
        private readonly ProductTypeListControl productTypeControl = null;

        public DataTable ProductTypesTable {
            get; private set;
        }
        public DataTable ProductsTable {
            get; private set;
        }
        public DataTable CustomerGroupsTable {
            get; private set;
        }

        // DataTable อื่น ๆ ที่ต้องการใช้งานจาก invoice_DB
        public DataTable MapProductsTable {
            get; private set;
        }
        public DataTable MapGuaranteesTable {
            get; private set;
        }
        public DataTable InvoicesTable {
            get; private set;
        }
        public DataTable CustomersTable {
            get; private set;
        }
        public DataTable LogPeriadsTable {
            get; private set;
        }
        public DataTable CompanysTable {
            get; private set;
        }
        public DataTable AddressTable {
            get; private set;
        }

        public FormMain() {
            InitializeComponent();

            createSaleControl = new CreateSaleControl((FormMain)this);
            customerListControl = new CustomerListControl((FormMain)this);
            employeeGroupControl = new EmployeeGroupListControl((FormMain)this);
            productControl = new ProductControl((FormMain)this);
            productTypeControl = new ProductTypeListControl((FormMain)this);
            // Start with expanded menu
            menuExpanded = true;
            panelMenu.Width = MenuExpandedWidth;
            UpdateMenuVisuals();

            InitToolTips();
            InitContentViews();
            ShowView(customerListControl);

            LoadAllMasterData();
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
                btnProductType.TextAlign = ContentAlignment.MiddleCenter;
                btnCash.TextAlign = ContentAlignment.MiddleCenter;
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

            panelContent.Controls.Add(customerListControl);
            panelContent.Controls.Add(createSaleControl);
            panelContent.Controls.Add(productControl);
            panelContent.Controls.Add(employeeGroupControl);
            panelContent.Controls.Add(productTypeControl);
        }

        public void ShowView(UserControl view) {
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
            ShowView(customerListControl);
        }

        private void btnCreateSale_Click(object sender, EventArgs e) {
            ShowView(createSaleControl);
        }

        private void btnProducts_Click(object sender, EventArgs e) {
            ShowView(productControl);
        }

        private void btnMaster_Click(object sender, EventArgs e) {
            // toggle สถานะ ซ่อน/แสดง ปุ่มกลุ่มลูกค้า เมื่อกดปbuttonนี้
            customerGroupHidden = !customerGroupHidden;

            // ถ้า flag เป็น true = ต้องการซ่อนปbutton -> ซ่อนตัวเอง
            // ถ้า flag เป็น false = ต้องการแสดงปbutton -> แสดงตัวเอง
            btnCustomerGroup.Visible = !customerGroupHidden;
            btnProducts.Visible = !customerGroupHidden;
            btnCompany.Visible = !customerGroupHidden;
            btnProductType.Visible = !customerGroupHidden;

            //// เมื่อปbuttonยังมองเห็น ให้แสดงหน้าข้อมูลทั่วไปด้วย
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

        private void btnProductType_Click(object sender, EventArgs e) {
            ShowView(productTypeControl);
        }

        private void LoadAllMasterData() {
            LoadProductTypes();
            LoadCustomerGroups();
            LoadProducts();
            LoadCustomers();
            LoadInvoices();
            LoadLogPeriads();
            LoadCompanys();
            LoadAddress();
            LoadMapProducts();
            LoadMapGuarantees();
        }

        public void LoadProductTypes() {
            var response = ConstantCommon.client.Get("product_types");

            // พยายามอ่านแบบ Dictionary ก่อน
            Dictionary<string, product_types> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, product_types>>();
            } catch {
                dict = null;
            }

            var dt = new DataTable();
            dt.Columns.Add("ProductTypeID", typeof(string));
            dt.Columns.Add("ProductTypeCode", typeof(string));
            dt.Columns.Add("ProductTypeName", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            if (dict != null) {
                // กรณีเก็บแบบ object: { "1": {...}, "2": {...} }
                foreach (var kv in dict) {
                    var g = kv.Value;
                    if (g == null)
                        continue;

                    var row = dt.NewRow();
                    row["ProductTypeID"] = g.ProductTypeID ?? "";
                    row["ProductTypeCode"] = g.ProductTypeCode ?? "";
                    row["ProductTypeName"] = g.ProductTypeName ?? "";
                    row["CreateTime"] = g.CreateTime ?? "";
                    row["CreateBy"] = g.CreateBy ?? "";
                    row["UpdateTime"] = g.UpdateTime ?? "";
                    row["UpdateBy"] = g.UpdateBy ?? "";
                    dt.Rows.Add(row);
                }
            } else {
                // กรณีเก็บแบบ array: [ {...}, {...} ]
                try {
                    var list = response.ResultAs<List<product_types>>();
                    if (list != null) {
                        foreach (var g in list) {
                            if (g == null)
                                continue;

                            var row = dt.NewRow();
                            row["ProductTypeID"] = g.ProductTypeID ?? "";
                            row["ProductTypeCode"] = g.ProductTypeCode ?? "";
                            row["ProductTypeName"] = g.ProductTypeName ?? "";
                            row["CreateTime"] = g.CreateTime ?? "";
                            row["CreateBy"] = g.CreateBy ?? "";
                            row["UpdateTime"] = g.UpdateTime ?? "";
                            row["UpdateBy"] = g.UpdateBy ?? "";
                            dt.Rows.Add(row);
                        }
                    }
                } catch {
                    // ถ้าอ่านไม่ได้เลย ปล่อย dt ว่าง
                }
            }

            ProductTypesTable = dt;
        }

        public void LoadCustomerGroups() {
            var response = ConstantCommon.client.Get("customer_groups");

            Dictionary<string, customer_groups> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, customer_groups>>();
            } catch {
                dict = null;
            }

            var dt = new DataTable();
            dt.Columns.Add("CustomerGroupID", typeof(string));
            dt.Columns.Add("CustomerGroupCode", typeof(string));
            dt.Columns.Add("CustomerGroupName", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            if (dict != null) {
                foreach (var kv in dict) {
                    var g = kv.Value;
                    if (g == null)
                        continue;
                    var row = dt.NewRow();
                    row["CustomerGroupID"] = g.CustomerGroupID ?? "";
                    row["CustomerGroupCode"] = g.CustomerGroupCode ?? "";
                    row["CustomerGroupName"] = g.CustomerGroupName ?? "";
                    row["CreateTime"] = g.CreateTime ?? "";
                    row["CreateBy"] = g.CreateBy ?? "";
                    row["UpdateTime"] = g.UpdateTime ?? "";
                    row["UpdateBy"] = g.UpdateBy ?? "";
                    dt.Rows.Add(row);
                }
            } else {
                try {
                    var list = response.ResultAs<List<customer_groups>>();
                    if (list != null) {
                        foreach (var g in list) {
                            if (g == null)
                                continue;
                            var row = dt.NewRow();
                            row["CustomerGroupID"] = g.CustomerGroupID ?? "";
                            row["CustomerGroupCode"] = g.CustomerGroupCode ?? "";
                            row["CustomerGroupName"] = g.CustomerGroupName ?? "";
                            row["CreateTime"] = g.CreateTime ?? "";
                            row["CreateBy"] = g.CreateBy ?? "";
                            row["UpdateTime"] = g.UpdateTime ?? "";
                            row["UpdateBy"] = g.UpdateBy ?? "";
                            dt.Rows.Add(row);
                        }
                    }
                } catch { }
            }

            CustomerGroupsTable = dt;
        }

        public void LoadProducts() {
            var response = ConstantCommon.client.Get("products");
            Dictionary<string, products> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, products>>();
            } catch { dict = null; }

            var dt = new DataTable();
            dt.Columns.Add("ProductID", typeof(string));
            dt.Columns.Add("ProductCode", typeof(string));
            dt.Columns.Add("ProductName", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Net", typeof(decimal));
            dt.Columns.Add("RefID", typeof(string));
            dt.Columns.Add("GainPrice", typeof(decimal));
            dt.Columns.Add("GainPercentage", typeof(decimal));
            dt.Columns.Add("CompanyID", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            if (dict != null) {
                foreach (var kv in dict) {
                    var p = kv.Value;
                    if (p == null)
                        continue;
                    var row = dt.NewRow();
                    row["ProductID"] = p.ProductID ?? "";
                    row["ProductCode"] = p.ProductCode ?? "";
                    row["ProductName"] = p.ProductName ?? "";
                    row["Price"] = p.Price;
                    row["Net"] = p.Net;
                    row["RefID"] = p.RefID ?? "";
                    row["GainPrice"] = p.GainPrice;
                    row["GainPercentage"] = p.GainPercentage;
                    row["CompanyID"] = p.CompanyID ?? "";
                    row["CreateTime"] = p.CreateTime ?? "";
                    row["CreateBy"] = p.CreateBy ?? "";
                    row["UpdateTime"] = p.UpdateTime ?? "";
                    row["UpdateBy"] = p.UpdateBy ?? "";
                    dt.Rows.Add(row);
                }
            } else {
                try {
                    var list = response.ResultAs<List<products>>();
                    if (list != null) {
                        foreach (var p in list) {
                            if (p == null)
                                continue;
                            var row = dt.NewRow();
                            row["ProductID"] = p.ProductID ?? "";
                            row["ProductCode"] = p.ProductCode ?? "";
                            row["ProductName"] = p.ProductName ?? "";
                            row["Price"] = p.Price.ToString();
                            row["Net"] = p.Net.ToString();
                            row["RefID"] = p.RefID ?? "";
                            row["GainPrice"] = p.GainPrice.ToString();
                            row["GainPercentage"] = p.GainPercentage.ToString();
                            row["CompanyID"] = p.CompanyID ?? "";
                            row["CreateTime"] = p.CreateTime ?? "";
                            row["CreateBy"] = p.CreateBy ?? "";
                            row["UpdateTime"] = p.UpdateTime ?? "";
                            row["UpdateBy"] = p.UpdateBy ?? "";
                            dt.Rows.Add(row);
                        }
                    }
                } catch { }
            }

            ProductsTable = dt;
        }

        public void LoadCustomers() {
            var response = ConstantCommon.client.Get("customers");
            Dictionary<string, customers> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, customers>>();
            } catch { dict = null; }

            var dt = new DataTable();
            dt.Columns.Add("CustomerID", typeof(string));
            dt.Columns.Add("CustomerCode", typeof(string));
            dt.Columns.Add("CustomerName", typeof(string));

            dt.Columns.Add("FNameT", typeof(string));
            dt.Columns.Add("LNameT", typeof(string));
            dt.Columns.Add("Sex", typeof(string));
            dt.Columns.Add("PrefixT", typeof(string));
            dt.Columns.Add("ShortNameT", typeof(string));

            dt.Columns.Add("FNameE", typeof(string));
            dt.Columns.Add("LNameE", typeof(string));
            dt.Columns.Add("PrefixE", typeof(string));
            dt.Columns.Add("ShortNameE", typeof(string));

            dt.Columns.Add("FindName1", typeof(string));
            dt.Columns.Add("FindName2", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("RefCode", typeof(string));
            dt.Columns.Add("IdentityCard", typeof(string));

            dt.Columns.Add("CompanyID", typeof(string));
            dt.Columns.Add("AddressID", typeof(string));
            dt.Columns.Add("CustomerGroupID", typeof(string));

            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            Action<customers> addRow = c => {
                if (c == null)
                    return;
                var row = dt.NewRow();
                row["CustomerID"] = c.CustomerID ?? "";
                row["CustomerCode"] = c.CustomerCode ?? "";
                row["CustomerName"] = c.CustomerName ?? "";

                row["FNameT"] = c.FNameT ?? "";
                row["LNameT"] = c.LNameT ?? "";
                row["Sex"] = c.Sex ?? "";
                row["PrefixT"] = c.PrefixT ?? "";
                row["ShortNameT"] = c.ShortNameT ?? "";

                row["FNameE"] = c.FNameE ?? "";
                row["LNameE"] = c.LNameE ?? "";
                row["PrefixE"] = c.PrefixE ?? "";
                row["ShortNameE"] = c.ShortNameE ?? "";

                row["FindName1"] = c.FindName1 ?? "";
                row["FindName2"] = c.FindName2 ?? "";
                row["Address"] = c.Address ?? "";
                row["RefCode"] = c.RefCode ?? "";
                row["IdentityCard"] = c.IdentityCard ?? "";

                row["CompanyID"] = c.CompanyID ?? "";
                row["AddressID"] = c.AddressID ?? "";
                row["CustomerGroupID"] = c.CustomerGroupID ?? "";

                row["Email"] = c.Email ?? "";
                row["CreateTime"] = c.CreateTime ?? "";
                row["CreateBy"] = c.CreateBy ?? "";
                row["UpdateTime"] = c.UpdateTime ?? "";
                row["UpdateBy"] = c.UpdateBy ?? "";

                dt.Rows.Add(row);
            };

            if (dict != null) {
                foreach (var kv in dict) {
                    addRow(kv.Value);
                }
            } else {
                try {
                    var list = response.ResultAs<List<customers>>();
                    if (list != null) {
                        foreach (var c in list) {
                            addRow(c);
                        }
                    }
                } catch { }
            }

            CustomersTable = dt;
        }

        public void LoadInvoices() {
            var response = ConstantCommon.client.Get("invoices");
            Dictionary<string, invoices> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, invoices>>();
            } catch { dict = null; }

            var dt = new DataTable();
            dt.Columns.Add("InvoiceID", typeof(string));
            dt.Columns.Add("InvoiceCode", typeof(string));
            dt.Columns.Add("CustomerID", typeof(string));
            dt.Columns.Add("PeriodNo", typeof(string));
            dt.Columns.Add("PayStatus", typeof(string));
            dt.Columns.Add("Balance", typeof(decimal));
            dt.Columns.Add("PayFinePercentage", typeof(decimal));
            dt.Columns.Add("StartDate", typeof(string));
            dt.Columns.Add("EndDate", typeof(string));
            dt.Columns.Add("CompanyID", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            Action<invoices> addRow = inv => {
                if (inv == null)
                    return;
                var row = dt.NewRow();
                row["InvoiceID"] = inv.InvoiceID ?? "";
                row["InvoiceCode"] = inv.InvoiceCode ?? "";
                row["CustomerID"] = inv.CustomerID ?? "";
                row["PeriodNo"] = inv.PeriodNo ?? "";
                row["PayStatus"] = inv.PayStatus ?? "";
                row["Balance"] = inv.Balance;
                row["PayFinePercentage"] = inv.PayFinePercentage;
                row["StartDate"] = inv.StartDate ?? "";
                row["EndDate"] = inv.EndDate ?? "";
                row["CompanyID"] = inv.CompanyID ?? "";
                row["CreateTime"] = inv.CreateTime ?? "";
                row["CreateBy"] = inv.CreateBy ?? "";
                row["UpdateTime"] = inv.UpdateTime ?? "";
                row["UpdateBy"] = inv.UpdateBy ?? "";
                dt.Rows.Add(row);
            };

            if (dict != null) {
                foreach (var kv in dict)
                    addRow(kv.Value);
            } else {
                try {
                    var list = response.ResultAs<List<invoices>>();
                    if (list != null) {
                        foreach (var inv in list)
                            addRow(inv);
                    }
                } catch { }
            }

            InvoicesTable = dt;
        }

        public void LoadLogPeriads() {
            var response = ConstantCommon.client.Get("log_periads");
            Dictionary<string, log_periads> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, log_periads>>();
            } catch { dict = null; }

            var dt = new DataTable();
            dt.Columns.Add("LogPeriadID", typeof(string));
            dt.Columns.Add("InvoiceID", typeof(string));
            dt.Columns.Add("PeriadNo", typeof(string));
            dt.Columns.Add("Remark", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("GainPrice", typeof(decimal));
            dt.Columns.Add("GainPercentage", typeof(decimal));
            dt.Columns.Add("CustomerID", typeof(string));
            dt.Columns.Add("PayFine", typeof(decimal));
            dt.Columns.Add("PayDate", typeof(string));
            dt.Columns.Add("PeriadDateFrom", typeof(string));
            dt.Columns.Add("PeriadDateTo", typeof(string));
            dt.Columns.Add("CompanyID", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            Action<log_periads> addRow = l => {
                if (l == null)
                    return;
                var row = dt.NewRow();
                row["LogPeriadID"] = l.LogPeriadID ?? "";
                row["InvoiceID"] = l.InvoiceID ?? "";
                row["PeriadNo"] = l.PeriadNo ?? "";
                row["Remark"] = l.Remark ?? "";
                row["Price"] = l.Price;
                row["GainPrice"] = l.GainPrice;
                row["GainPercentage"] = l.GainPercentage;
                row["CustomerID"] = l.CustomerID ?? "";
                row["PayFine"] = l.PayFine;
                row["PayDate"] = l.PayDate ?? "";
                row["PeriadDateFrom"] = l.PeriadDateFrom ?? "";
                row["PeriadDateTo"] = l.PeriadDateTo ?? "";
                row["CompanyID"] = l.CompanyID ?? "";
                row["CreateTime"] = l.CreateTime ?? "";
                row["CreateBy"] = l.CreateBy ?? "";
                row["UpdateTime"] = l.UpdateTime ?? "";
                row["UpdateBy"] = l.UpdateBy ?? "";
                dt.Rows.Add(row);
            };

            if (dict != null) {
                foreach (var kv in dict)
                    addRow(kv.Value);
            } else {
                try {
                    var list = response.ResultAs<List<log_periads>>();
                    if (list != null) {
                        foreach (var l in list)
                            addRow(l);
                    }
                } catch { }
            }

            LogPeriadsTable = dt;
        }

        public void LoadCompanys() {
            var response = ConstantCommon.client.Get("companys");
            Dictionary<string, companys> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, companys>>();
            } catch { dict = null; }

            var dt = new DataTable();
            dt.Columns.Add("CompanyID", typeof(string));
            dt.Columns.Add("CompanyName", typeof(string));
            dt.Columns.Add("CompanyCode", typeof(string));
            dt.Columns.Add("Logo", typeof(string));
            dt.Columns.Add("AddressID", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            Action<companys> addRow = c => {
                if (c == null)
                    return;
                var row = dt.NewRow();
                row["CompanyID"] = c.CompanyID ?? "";
                row["CompanyName"] = c.CompanyName ?? "";
                row["CompanyCode"] = c.CompanyCode ?? "";
                row["Logo"] = c.Logo ?? "";
                row["AddressID"] = c.AddressID ?? "";
                row["CreateTime"] = c.CreateTime ?? "";
                row["CreateBy"] = c.CreateBy ?? "";
                row["UpdateTime"] = c.UpdateTime ?? "";
                row["UpdateBy"] = c.UpdateBy ?? "";
                dt.Rows.Add(row);
            };

            if (dict != null) {
                foreach (var kv in dict)
                    addRow(kv.Value);
            } else {
                try {
                    var list = response.ResultAs<List<companys>>();
                    if (list != null) {
                        foreach (var c in list)
                            addRow(c);
                    }
                } catch { }
            }

            CompanysTable = dt;
        }

        public void LoadAddress() {
            var response = ConstantCommon.client.Get("address");
            Dictionary<string, address> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, address>>();
            } catch { dict = null; }

            var dt = new DataTable();
            dt.Columns.Add("AddressID", typeof(string));
            dt.Columns.Add("AddressDetail", typeof(string));
            dt.Columns.Add("RoomNo", typeof(string));
            dt.Columns.Add("Flood", typeof(string));
            dt.Columns.Add("HouseNo", typeof(string));
            dt.Columns.Add("Moo", typeof(string));
            dt.Columns.Add("Soi", typeof(string));
            dt.Columns.Add("Road", typeof(string));
            dt.Columns.Add("SubDistrict", typeof(string));
            dt.Columns.Add("District", typeof(string));
            dt.Columns.Add("Province", typeof(string));
            dt.Columns.Add("PostCode", typeof(string));
            dt.Columns.Add("GPS", typeof(string));
            dt.Columns.Add("Lang", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Mobile", typeof(string));
            dt.Columns.Add("PhoneTo", typeof(string));
            dt.Columns.Add("Fax", typeof(string));
            dt.Columns.Add("FaxTo", typeof(string));
            dt.Columns.Add("RefCode", typeof(string));
            dt.Columns.Add("LineID", typeof(string));
            dt.Columns.Add("LineContract", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            Action<address> addRow = a => {
                if (a == null)
                    return;
                var row = dt.NewRow();
                row["AddressID"] = a.AddressID ?? "";
                row["AddressDetail"] = a.AddressDetail ?? "";
                row["RoomNo"] = a.RoomNo ?? "";
                row["Flood"] = a.Flood ?? "";
                row["HouseNo"] = a.HouseNo ?? "";
                row["Moo"] = a.Moo ?? "";
                row["Soi"] = a.Soi ?? "";
                row["Road"] = a.Road ?? "";
                row["SubDistrict"] = a.SubDistrict ?? "";
                row["District"] = a.District ?? "";
                row["Province"] = a.Province ?? "";
                row["PostCode"] = a.PostCode ?? "";
                row["GPS"] = a.GPS ?? "";
                row["Lang"] = a.Lang ?? "";
                row["Phone"] = a.Phone ?? "";
                row["Mobile"] = a.Mobile ?? "";
                row["PhoneTo"] = a.PhoneTo ?? "";
                row["Fax"] = a.Fax ?? "";
                row["FaxTo"] = a.FaxTo ?? "";
                row["RefCode"] = a.RefCode ?? "";
                row["LineID"] = a.LineID ?? "";
                row["LineContract"] = a.LineContract ?? "";
                row["CreateTime"] = a.CreateTime ?? "";
                row["CreateBy"] = a.CreateBy ?? "";
                row["UpdateTime"] = a.UpdateTime ?? "";
                row["UpdateBy"] = a.UpdateBy ?? "";
                dt.Rows.Add(row);
            };

            if (dict != null) {
                foreach (var kv in dict)
                    addRow(kv.Value);
            } else {
                try {
                    var list = response.ResultAs<List<address>>();
                    if (list != null) {
                        foreach (var a in list)
                            addRow(a);
                    }
                } catch { }
            }

            AddressTable = dt;
        }

        public void LoadMapProducts() {
            var response = ConstantCommon.client.Get("map_products");
            Dictionary<string, map_products> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, map_products>>();
            } catch { dict = null; }

            var dt = new DataTable();
            dt.Columns.Add("MapProductID", typeof(string));
            dt.Columns.Add("ProductID", typeof(string));
            dt.Columns.Add("InvoiceID", typeof(string));
            dt.Columns.Add("Qty", typeof(int));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Net", typeof(decimal));
            dt.Columns.Add("GainPrice", typeof(decimal));
            dt.Columns.Add("GainPercentage", typeof(decimal));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            Action<map_products> addRow = m => {
                if (m == null)
                    return;
                var row = dt.NewRow();
                row["MapProductID"] = m.MapProductID ?? "";
                row["ProductID"] = m.ProductID ?? "";
                row["InvoiceID"] = m.InvoiceID ?? "";
                row["Qty"] = m.Qty;
                row["Price"] = m.Price;
                row["Net"] = m.Net;
                row["GainPrice"] = m.GainPrice;
                row["GainPercentage"] = m.GainPercentage;
                row["CreateTime"] = m.CreateTime ?? "";
                row["CreateBy"] = m.CreateBy ?? "";
                row["UpdateTime"] = m.UpdateTime ?? "";
                row["UpdateBy"] = m.UpdateBy ?? "";
                dt.Rows.Add(row);
            };

            if (dict != null) {
                foreach (var kv in dict)
                    addRow(kv.Value);
            } else {
                try {
                    var list = response.ResultAs<List<map_products>>();
                    if (list != null) {
                        foreach (var m in list)
                            addRow(m);
                    }
                } catch { }
            }

            MapProductsTable = dt;
        }

        public void LoadMapGuarantees() {
            var response = ConstantCommon.client.Get("map_guarantees");
            Dictionary<string, map_guarantees> dict = null;
            try {
                dict = response.ResultAs<Dictionary<string, map_guarantees>>();
            } catch { dict = null; }

            var dt = new DataTable();
            dt.Columns.Add("MapGuaranteeID", typeof(string));
            dt.Columns.Add("CustomerID", typeof(string));
            dt.Columns.Add("InvoiceID", typeof(string));
            dt.Columns.Add("GuaranteeCusID", typeof(string));
            dt.Columns.Add("CreateTime", typeof(string));
            dt.Columns.Add("CreateBy", typeof(string));
            dt.Columns.Add("UpdateTime", typeof(string));
            dt.Columns.Add("UpdateBy", typeof(string));

            Action<map_guarantees> addRow = m => {
                if (m == null)
                    return;
                var row = dt.NewRow();
                row["MapGuaranteeID"] = m.MapGuaranteeID ?? "";
                row["CustomerID"] = m.CustomerID ?? "";
                row["InvoiceID"] = m.InvoiceID ?? "";
                row["GuaranteeCusID"] = m.GuaranteeCusID ?? "";
                row["CreateTime"] = m.CreateTime ?? "";
                row["CreateBy"] = m.CreateBy ?? "";
                row["UpdateTime"] = m.UpdateTime ?? "";
                row["UpdateBy"] = m.UpdateBy ?? "";
                dt.Rows.Add(row);
            };

            if (dict != null) {
                foreach (var kv in dict)
                    addRow(kv.Value);
            } else {
                try {
                    var list = response.ResultAs<List<map_guarantees>>();
                    if (list != null) {
                        foreach (var m in list)
                            addRow(m);
                    }
                } catch { }
            }

            MapGuaranteesTable = dt;
        }
    }
}
