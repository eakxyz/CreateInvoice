using System;
using System.Drawing;
using System.Windows.Forms;
using BotCommon;
using System.Data;

namespace CreateInvoice {
    public class ProductDetailControl : UserControl {
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox groupBox2;
        private Label label7;
        private ComboBox cboProductGroup;
        private Label label3;
        private TextBox txtProductName;
        private TabPage tabPage2;
        private Label label1;
        private TextBox txtProductCode;
        private Label label2;
        private Button btnAddProduct;
        private DataGridViewButtonColumn colEdit;
        private Button btnCancel;
        public FormMain formMain = null;
        private Label label4;
        private TextBox txtTotal;
        private TextBox txtPrice;
        private TextBox txtGainPrice;
        private Label label8;
        private Label label6;
        private ComboBox cboRefProduct;
        private TextBox txtGainPercent;
        private Label label9;
        private GroupBox groupBox1;
        private Label label10;
        private ComboBox cboCompany;
        public ProductControl productControl = null;

        public ProductDetailControl(FormMain pFormMain) {
            this.formMain = pFormMain;
            Dock = DockStyle.Fill;
            BackColor = Color.White;
            var lbl = new Label {
                Text = "สินค้า",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            Controls.Add(lbl);
            InitializeComponent();
            
            // โหลดข้อมูลใน ComboBox
            LoadComboBoxData();
            
            // ผูก event สำหรับคำนวณอัตโนมัติ
            txtPrice.TextChanged += CalculateTotal;
            txtGainPrice.TextChanged += CalculateGainPercentage;
            txtGainPercent.TextChanged += CalculateGainPrice;
        }

        private void InitializeComponent() {
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProductCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboProductGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboRefProduct = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtGainPrice = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGainPercent = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colEdit
            // 
            this.colEdit.MinimumWidth = 6;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 125;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(39, 170);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1101, 489);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage1.Size = new System.Drawing.Size(1093, 454);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ชื่อสินค้า";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtGainPercent);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtGainPrice);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboRefProduct);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnAddProduct);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtProductCode);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtProductName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1065, 424);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1. ชื่อ";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(531, 354);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 41);
            this.btnCancel.TabIndex = 25;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "ราคาสินค้า (บาท)";
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(405, 354);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(120, 41);
            this.btnAddProduct.TabIndex = 21;
            this.btnAddProduct.Text = "เพิ่ม";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "รหัสสินค้า";
            // 
            // txtProductCode
            // 
            this.txtProductCode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProductCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductCode.Location = new System.Drawing.Point(39, 50);
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Size = new System.Drawing.Size(360, 35);
            this.txtProductCode.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(76, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "ประเภทสินค้า";
            // 
            // cboProductGroup
            // 
            this.cboProductGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboProductGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductGroup.FormattingEnabled = true;
            this.cboProductGroup.Location = new System.Drawing.Point(58, 55);
            this.cboProductGroup.Name = "cboProductGroup";
            this.cboProductGroup.Size = new System.Drawing.Size(360, 37);
            this.cboProductGroup.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "ชื่อสินค้า";
            // 
            // txtProductName
            // 
            this.txtProductName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductName.Location = new System.Drawing.Point(39, 110);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(360, 35);
            this.txtProductName.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1547, 624);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ข้อมูล";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.Info;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.Location = new System.Drawing.Point(39, 170);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(360, 35);
            this.txtPrice.TabIndex = 26;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Info;
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(39, 230);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(360, 35);
            this.txtTotal.TabIndex = 27;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "ราคารวม (บาท)";
            // 
            // cboRefProduct
            // 
            this.cboRefProduct.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboRefProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRefProduct.FormattingEnabled = true;
            this.cboRefProduct.Location = new System.Drawing.Point(405, 50);
            this.cboRefProduct.Name = "cboRefProduct";
            this.cboRefProduct.Size = new System.Drawing.Size(360, 37);
            this.cboRefProduct.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(423, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "เป็นสินค้าลูกของ *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "กำไร (บาท)";
            // 
            // txtGainPrice
            // 
            this.txtGainPrice.BackColor = System.Drawing.SystemColors.Info;
            this.txtGainPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGainPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGainPrice.Location = new System.Drawing.Point(39, 290);
            this.txtGainPrice.Name = "txtGainPrice";
            this.txtGainPrice.Size = new System.Drawing.Size(200, 35);
            this.txtGainPrice.TabIndex = 32;
            this.txtGainPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 268);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "กำไร ( % )";
            // 
            // txtGainPercent
            // 
            this.txtGainPercent.BackColor = System.Drawing.SystemColors.Info;
            this.txtGainPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGainPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGainPercent.Location = new System.Drawing.Point(245, 290);
            this.txtGainPercent.Name = "txtGainPercent";
            this.txtGainPercent.Size = new System.Drawing.Size(200, 35);
            this.txtGainPercent.TabIndex = 34;
            this.txtGainPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cboCompany);
            this.groupBox1.Controls.Add(this.cboProductGroup);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(39, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1097, 115);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูล";
            // 
            // cboCompany
            // 
            this.cboCompany.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Location = new System.Drawing.Point(424, 55);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(360, 37);
            this.cboCompany.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(442, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 20);
            this.label10.TabIndex = 13;
            this.label10.Text = "สินค้าของ บริษัท";
            // 
            // ProductDetailControl
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "ProductDetailControl";
            this.Size = new System.Drawing.Size(1714, 950);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void LoadComboBoxData() {
            // โหลดข้อมูล Product Types
            if (formMain != null && formMain.ProductTypesTable != null) {
                cboProductGroup.DataSource = null;
                cboProductGroup.DisplayMember = "ProductTypeName";
                cboProductGroup.ValueMember = "ProductTypeID";
                cboProductGroup.DataSource = formMain.ProductTypesTable;
            }
            
            // โหลดข้อมูล Companies
            if (formMain != null && formMain.CompanysTable != null) {
                cboCompany.DataSource = null;
                cboCompany.DisplayMember = "CompanyName";
                cboCompany.ValueMember = "CompanyID";
                cboCompany.DataSource = formMain.CompanysTable;
            }
            
            // โหลดข้อมูล Products สำหรับ RefProduct (สินค้าลูก)
            if (formMain != null && formMain.ProductsTable != null) {
                cboRefProduct.DataSource = null;
                cboRefProduct.DisplayMember = "ProductName";
                cboRefProduct.ValueMember = "ProductID";
                cboRefProduct.DataSource = formMain.ProductsTable;
                
                // เพิ่ม item ว่างเป็นตัวเลือกแรก
                if (cboRefProduct.Items.Count > 0) {
                    cboRefProduct.SelectedIndex = -1;
                }
            }
        }

        private void CalculateTotal(object sender, EventArgs e) {
            decimal price = 0;
            decimal gainPrice = 0;
            
            decimal.TryParse(txtPrice.Text, out price);
            decimal.TryParse(txtGainPrice.Text, out gainPrice);
            
            decimal total = price + gainPrice;
            txtTotal.Text = total.ToString("0.00");
        }

        private void CalculateGainPercentage(object sender, EventArgs e) {
            decimal price = 0;
            decimal gainPrice = 0;
            
            decimal.TryParse(txtPrice.Text, out price);
            decimal.TryParse(txtGainPrice.Text, out gainPrice);
            
            if (price > 0) {
                decimal percentage = (gainPrice / price) * 100;
                txtGainPercent.Text = percentage.ToString("0.00");
            }
            
            CalculateTotal(sender, e);
        }

        private void CalculateGainPrice(object sender, EventArgs e) {
            // ป้องกันการวนซ้ำเมื่อคำนวณ
            if (txtGainPercent.Focused) {
                decimal price = 0;
                decimal percentage = 0;
                
                decimal.TryParse(txtPrice.Text, out price);
                decimal.TryParse(txtGainPercent.Text, out percentage);
                
                if (price > 0 && percentage > 0) {
                    decimal gainPrice = (price * percentage) / 100;
                    txtGainPrice.Text = gainPrice.ToString("0.00");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            productControl = new ProductControl(formMain);
            formMain.ShowView(productControl);
        }

        private void btnAddProduct_Click(object sender, EventArgs e) {
            try {
                // ตรวจสอบข้อมูลที่จำเป็น
                if (string.IsNullOrWhiteSpace(txtProductCode.Text)) {
                    MessageBox.Show("กรุณากรอกรหัสสินค้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductCode.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtProductName.Text)) {
                    MessageBox.Show("กรุณากรอกชื่อสินค้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProductName.Focus();
                    return;
                }

                if (cboProductGroup.SelectedValue == null) {
                    MessageBox.Show("กรุณาเลือกประเภทสินค้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboProductGroup.Focus();
                    return;
                }

                if (cboCompany.SelectedValue == null) {
                    MessageBox.Show("กรุณาเลือกบริษัท", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCompany.Focus();
                    return;
                }

                // แปลงค่าตัวเลข
                decimal price = 0;
                decimal net = 0;
                decimal gainPrice = 0;
                decimal gainPercentage = 0;

                if (!decimal.TryParse(txtPrice.Text, out price)) {
                    MessageBox.Show("กรุณากรอกราคาสินค้าที่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrice.Focus();
                    return;
                }

                decimal.TryParse(txtTotal.Text, out net);
                decimal.TryParse(txtGainPrice.Text, out gainPrice);
                decimal.TryParse(txtGainPercent.Text, out gainPercentage);

                // generate ProductID: หา max id + 1 จาก DataTable
                int maxId = 0;
                if (formMain != null && formMain.ProductsTable != null) {
                    foreach (DataRow row in formMain.ProductsTable.Rows) {
                        if (row["ProductID"] != DBNull.Value) {
                            int id;
                            if (int.TryParse(row["ProductID"].ToString(), out id)) {
                                if (id > maxId)
                                    maxId = id;
                            }
                        }
                    }
                }

                string newProductID = (maxId + 1).ToString();

                // สร้าง object products
                var product = new products {
                    ProductID = newProductID,
                    ProductCode = txtProductCode.Text.Trim(),
                    ProductName = txtProductName.Text.Trim(),
                    ProductTypeID = cboProductGroup.SelectedValue.ToString(),
                    Price = price,
                    Net = net,
                    RefID = cboRefProduct.SelectedValue?.ToString() ?? "",
                    GainPrice = gainPrice,
                    GainPercentage = gainPercentage,
                    CompanyID = cboCompany.SelectedValue.ToString(),
                    CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    CreateBy = Environment.UserName,
                    UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateBy = Environment.UserName
                };

                // บันทึกลง Firebase
                products.ProductsMgr(product, "ADD");

                // เพิ่มข้อมูลใน DataTable cache ของ FormMain
                if (formMain != null && formMain.ProductsTable != null) {
                    var dt = formMain.ProductsTable;
                    var newRow = dt.NewRow();
                    newRow["ProductID"] = product.ProductID;
                    newRow["ProductCode"] = product.ProductCode;
                    newRow["ProductName"] = product.ProductName;
                    newRow["Price"] = product.Price;
                    newRow["Net"] = product.Net;
                    newRow["RefID"] = product.RefID;
                    newRow["GainPrice"] = product.GainPrice;
                    newRow["GainPercentage"] = product.GainPercentage;
                    newRow["CompanyID"] = product.CompanyID;
                    newRow["CreateTime"] = product.CreateTime;
                    newRow["CreateBy"] = product.CreateBy;
                    newRow["UpdateTime"] = product.UpdateTime;
                    newRow["UpdateBy"] = product.UpdateBy;
                    dt.Rows.Add(newRow);
                    dt.AcceptChanges();
                }

                MessageBox.Show("เพิ่มสินค้าเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // กลับไปหน้า ProductControl
                productControl = new ProductControl(formMain);
                productControl.productDetial = this;
                formMain.ShowView(productControl);
                
            } catch (Exception ex) {
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
