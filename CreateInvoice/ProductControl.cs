using BotCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CreateInvoice {
    public class ProductControl : UserControl {
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

        public ProductControl(FormMain pFormMain) {
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
        }

        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 232);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(1184, 525);
            this.dataGridView1.TabIndex = 0;
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
            // ProductControl
            // 
            this.Controls.Add(this.btnAddProduct);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProductControl";
            this.Size = new System.Drawing.Size(1714, 950);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitProductGridColumns() {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "ProductID",
                HeaderText = "ID",
                Name = "colProductID",
                ReadOnly = true,
                Width = 80,
                Visible = false
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "ProductCode",
                HeaderText = "รหัสสินค้า",
                Name = "colProductCode",
                ReadOnly = true,
                Width = 150
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
                DataPropertyName = "CompanyID",
                HeaderText = "บริษัท",
                Name = "colCompanyID",
                ReadOnly = true,
                Width = 100
            });

            dataGridView1.Columns.Add(new DataGridViewButtonColumn {
                HeaderText = "จัดการ",
                Name = "colEditProduct",
                Text = "แก้ไข",
                UseColumnTextForButtonValue = true,
                Width = 100,
                FlatStyle = FlatStyle.Standard
            });
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            try {
                // ดึงข้อมูล products จาก Firebase
                var response = ConstantCommon.client.Get("products");
                var dict = response.ResultAs<Dictionary<string, products>>();

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
                dt.Columns.Add("CreateTime", typeof(string));
                dt.Columns.Add("CreateBy", typeof(string));
                dt.Columns.Add("UpdateTime", typeof(string));
                dt.Columns.Add("UpdateBy", typeof(string));

                // add a column to guarantee button cells have a value (some DataGridView themes can render blank otherwise)
                if (!dt.Columns.Contains("_Action"))
                    dt.Columns.Add("_Action", typeof(string));

                if (dict != null) {
                    foreach (var kv in dict) {
                        var p = kv.Value;
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
                        row["_Action"] = "แก้ไข";
                        dt.Rows.Add(row);
                    }
                }

                // Init columns (field headers)
                InitProductGridColumns();

                dataGridView1.DataSource = dt;
            } catch (Exception ex) {
                MessageBox.Show("โหลดข้อมูลสินค้าไม่สำเร็จ: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            productDetial = new ProductDetailControl(formMain);
            formMain.ShowView(productDetial);
        }
    }
}
