using BotCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CreateInvoice {
    public class ProductListControl : UserControl {
        private DataGridViewButtonColumn colEdit;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private Button btnSearch;
        private Button btnAddProduct;
        private DataGridView dataGridView1;
        public FormMain formMain = null;
        public ProductDetailControl productDetial = null;

        public ProductListControl(FormMain pFormMain) {
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

            InitProductGridColumns();
            dataGridView1.DataSource = null;

            formMain = pFormMain;
            comboBox1.SelectedIndex = 0;
        }

        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 232);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(1184, 525);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // colEdit
            // 
            this.colEdit.MinimumWidth = 6;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 125;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(39, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1184, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เงื่อนไขการค้นหา";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(609, 68);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 39);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(243, 70);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(360, 35);
            this.textBox3.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(49, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "ค้นหาโดย";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "ประเภทสินค้า",
            "ชื่อสินค้า"});
            this.comboBox1.Location = new System.Drawing.Point(37, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 37);
            this.comboBox1.TabIndex = 14;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProduct.Location = new System.Drawing.Point(39, 185);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(120, 41);
            this.btnAddProduct.TabIndex = 21;
            this.btnAddProduct.Text = "+ เพิ่มสินค้า";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProductListControl
            // 
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProductListControl";
            this.Size = new System.Drawing.Size(1714, 950);
            this.Load += new System.EventHandler(this.ProductListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitProductGridColumns() {
            if (dataGridView1.Columns.Count > 0)
                return;
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "ProductID",
                HeaderText = "รหัสสินค้า",
                Name = "colProductID",
                ReadOnly = true,
                Visible = false
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "ProductCode",
                HeaderText = "รหัสสินค้า",
                Name = "colProductCode",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "ProductName",
                HeaderText = "ชื่อสินค้า",
                Name = "colProductName",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "Price",
                HeaderText = "ราคา",
                Name = "colPrice",
                ReadOnly = true,
                Width = 100
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "Net",
                HeaderText = "Net",
                Name = "colNet",
                ReadOnly = true,
                Width = 100
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "RefID",
                HeaderText = "RefID",
                Name = "colRefID",
                ReadOnly = true,
                Width = 120,
                Visible = false
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "GainPrice",
                HeaderText = "กำไร (บาท)",
                Name = "colGainPrice",
                ReadOnly = true,
                Width = 120
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "GainPercentage",
                HeaderText = "กำไร (%)",
                Name = "colGainPercentage",
                ReadOnly = true,
                Width = 120
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "CompanyName",   // เดิม CompanyID
                HeaderText = "บริษัท",
                Name = "colCompanyName",           // เดิม colCompanyID
                ReadOnly = true,
                Width = 150
            });

            try {
                int iconSize = 16;
                var editSrc = global::CreateInvoice.Properties.Resources.Edit.ToBitmap();
                var deleteSrc = global::CreateInvoice.Properties.Resources.Remove.ToBitmap();

                Image editSmall = new Bitmap(editSrc, new Size(iconSize, iconSize));
                Image deleteSmall = new Bitmap(deleteSrc, new Size(iconSize, iconSize));

                var colEditImg = new DataGridViewImageColumn {
                    Name = "colEdit",
                    HeaderText = "แก้ไข",
                    Image = editSmall,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    Width = iconSize + 8
                };
                colEditImg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Add(colEditImg);

                var colDeleteImg = new DataGridViewImageColumn {
                    Name = "colDelete",
                    HeaderText = "ลบ",
                    Image = deleteSmall,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    Width = iconSize + 8
                };
                colDeleteImg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Add(colDeleteImg);
            } catch (Exception ex) {
                MessageBox.Show("เกิดข้อผิดพลาดในการกำหนดค่าคอลัมน์: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            try {
                // ตารางสินค้าและบริษัทจาก FormMain
                var dtProduct = (formMain != null) ? formMain.ProductsTable : null;
                var dtCompany = (formMain != null) ? formMain.CompanysTable : null;

                if (dtProduct == null) {
                    MessageBox.Show("ไม่พบข้อมูลสินค้าในระบบ", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // เตรียม DataTable สำหรับ bind เข้า grid ให้ตรงกับคอลัมน์ใน InitProductGridColumns
                var dt = new DataTable();
                dt.Columns.Add("ProductID", typeof(string));
                dt.Columns.Add("ProductCode", typeof(string));
                dt.Columns.Add("ProductName", typeof(string));
                dt.Columns.Add("Price", typeof(string));
                dt.Columns.Add("Net", typeof(string));
                dt.Columns.Add("RefID", typeof(string));
                dt.Columns.Add("GainPrice", typeof(string));
                dt.Columns.Add("GainPercentage", typeof(string));
                dt.Columns.Add("CompanyID", typeof(string));
                dt.Columns.Add("CompanyName", typeof(string));   // แสดงใน grid

                // เตรียม map CompanyID -> CompanyName จาก CompanysTable
                var companyMap = new System.Collections.Generic.Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                if (dtCompany != null && dtCompany.Columns.Contains("CompanyID")) {
                    foreach (DataRow crow in dtCompany.Rows) {
                        var cid = crow["CompanyID"]?.ToString();
                        var cname = dtCompany.Columns.Contains("CompanyName")
                            ? crow["CompanyName"]?.ToString()
                            : string.Empty;

                        if (!string.IsNullOrEmpty(cid) && !companyMap.ContainsKey(cid)) {
                            companyMap[cid] = cname ?? string.Empty;
                        }
                    }
                }

                // รับค่าเงื่อนไขค้นหา (ถ้ามี)
                string keyword = (textBox3.Text ?? string.Empty).Trim();
                int searchMode = comboBox1.SelectedIndex; // 0 = ประเภทสินค้า, 1 = ชื่อสินค้า (ตามที่ตั้งไว้ใน Designer)

                foreach (DataRow pRow in dtProduct.Rows) {
                    // อ่านค่าจาก ProductsTable (เช็คว่ามีคอลัมน์ก่อน)
                    string productId = dtProduct.Columns.Contains("ProductID") ? pRow["ProductID"]?.ToString() ?? "" : "";
                    string productCode = dtProduct.Columns.Contains("ProductCode") ? pRow["ProductCode"]?.ToString() ?? "" : "";
                    string productName = dtProduct.Columns.Contains("ProductName") ? pRow["ProductName"]?.ToString() ?? "" : "";
                    string productType = dtProduct.Columns.Contains("ProductTypeID") ? pRow["ProductTypeID"]?.ToString() ?? "" : "";
                    string refId = dtProduct.Columns.Contains("RefID") ? pRow["RefID"]?.ToString() ?? "" : "";
                    string companyId = dtProduct.Columns.Contains("CompanyID") ? pRow["CompanyID"]?.ToString() ?? "" : "";

                    decimal price = 0m;
                    decimal net = 0m;
                    decimal gain = 0m;
                    decimal gainPct = 0m;

                    if (dtProduct.Columns.Contains("Price"))
                        decimal.TryParse(pRow["Price"]?.ToString(), out price);
                    if (dtProduct.Columns.Contains("Net"))
                        decimal.TryParse(pRow["Net"]?.ToString(), out net);
                    if (dtProduct.Columns.Contains("GainPrice"))
                        decimal.TryParse(pRow["GainPrice"]?.ToString(), out gain);
                    if (dtProduct.Columns.Contains("GainPercentage"))
                        decimal.TryParse(pRow["GainPercentage"]?.ToString(), out gainPct);

                    // หา CompanyName จาก map
                    string companyName = "";
                    if (!string.IsNullOrEmpty(companyId)) {
                        companyMap.TryGetValue(companyId, out companyName);
                    }

                    // กรองตาม keyword ถ้าผู้ใช้กรอก
                    if (!string.IsNullOrEmpty(keyword)) {
                        string target = string.Empty;
                        switch (searchMode) {
                            case 0: // ประเภทสินค้า (ค้นจาก ProductTypeID)
                                target = productType;
                                break;
                            case 1: // ชื่อสินค้า
                                target = productName;
                                break;
                            default:
                                target = productName;
                                break;
                        }

                        if (string.IsNullOrEmpty(target) ||
                            target.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) < 0) {
                            continue;
                        }
                    }

                    var row = dt.NewRow();
                    row["ProductID"] = productId;
                    row["ProductCode"] = productCode;
                    row["ProductName"] = productName;
                    row["Price"] = price.ToString("0.00");
                    row["Net"] = net.ToString("0.00");
                    row["RefID"] = refId;
                    row["GainPrice"] = gain.ToString("0.00");
                    row["GainPercentage"] = gainPct.ToString("0.00");
                    row["CompanyID"] = companyId;
                    row["CompanyName"] = companyName;

                    dt.Rows.Add(row);
                }

                // ให้คอลัมน์ใน grid ตรงกับ dt
                InitProductGridColumns();
                dataGridView1.DataSource = dt;
            } catch (Exception ex) {
                MessageBox.Show("โหลดข้อมูลสินค้าไม่สำเร็จ: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;

            var grid = dataGridView1;
            var colName = grid.Columns[e.ColumnIndex].Name;
            var row = grid.Rows[e.RowIndex];

            if (colName == "colEdit") {
                // แก้ไขสินค้า
                var idObj = row.Cells["colProductID"].Value;
                if (idObj == null)
                    return;

                string productId = idObj.ToString();

                // หา DataRow ของสินค้านี้จาก DataSource หรือจาก ProductsTable
                DataRow productRow = null;

                var bs = grid.DataSource as DataTable;
                if (bs != null) {
                    DataRow[] rows = bs.Select($"ProductID = '{productId.Replace("'", "''")}'");
                    if (rows.Length > 0)
                        productRow = rows[0];
                } else if (formMain != null && formMain.ProductsTable != null) {
                    DataRow[] rows = formMain.ProductsTable.Select($"ProductID = '{productId.Replace("'", "''")}'");
                    if (rows.Length > 0)
                        productRow = rows[0];
                }

                if (productRow == null)
                    return;

                productDetial = new ProductDetailControl(formMain, this);
                productDetial.LoadForEdit(productRow);
                formMain.ShowView(productDetial);
            } else if (colName == "colDelete") {
                // ลบสินค้า
                var idObj = row.Cells["colProductID"].Value;
                if (idObj == null)
                    return;

                string productId = idObj.ToString();
                string productName = row.Cells["colProductName"].Value?.ToString();

                var confirm = MessageBox.Show($"ยืนยันการลบสินค้า '{productName}' ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                try {
                    // ลบจาก backend ถ้าต้องการ
                    var p = new products { ProductID = productId };
                    products.ProductsMgr(p, "DELETE");

                    // ลบจาก DataTable cache ของ FormMain
                    if (formMain != null && formMain.ProductsTable != null) {
                        DataRow[] rows = formMain.ProductsTable.Select($"ProductID = '{productId.Replace("'", "''")}'");
                        foreach (var dr in rows) {
                            formMain.ProductsTable.Rows.Remove(dr);
                        }
                        formMain.ProductsTable.AcceptChanges();
                    }

                    // ลบจาก DataSource ปัจจุบันของ grid ถ้าเป็น DataTable ชั่วคราวจากการค้นหา
                    var dt = grid.DataSource as DataTable;
                    if (dt != null) {
                        DataRow[] rows = dt.Select($"ProductID = '{productId.Replace("'", "''")}'");
                        foreach (var dr in rows) {
                            dt.Rows.Remove(dr);
                        }
                        dt.AcceptChanges();
                    }

                    // refresh grid จาก cache ที่อัปเดตแล้ว
                    btnSearch_Click(null, null);
                } catch (Exception ex) {
                    MessageBox.Show("เกิดข้อผิดพลาดในการลบสินค้า: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            productDetial = new ProductDetailControl(formMain, this);
            formMain.ShowView(productDetial);
        }

        private void ProductListControl_Load(object sender, EventArgs e) {
            dataGridView1.DataSource = null;
            btnSearch_Click(null, null);
        }
    }
}
