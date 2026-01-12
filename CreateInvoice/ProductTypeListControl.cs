using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CreateInvoice {
    public class ProductTypeListControl : UserControl {
        private DataGridViewButtonColumn colEdit;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cboProductType;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnAddGroup;
        private DataGridView dataGridView1;
        public FormMain formMain = null;
        public ProductTypeControl productTypeControl = null;

        public ProductTypeListControl(FormMain pFormMain) {
            Dock = DockStyle.Fill;
            BackColor = Color.White;
            var lbl = new Label {
                Text = "กลุ่มลูกค้า",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };

            formMain = pFormMain;

            Controls.Add(lbl);
            InitializeComponent();

            InitCustomerGroupGridColumns();

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboProductType = new System.Windows.Forms.ComboBox();
            this.btnAddGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(35, 243);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(1474, 512);
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
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboProductType);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1474, 154);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เงื่อนไขการค้นหา";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(812, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 41);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(393, 77);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 35);
            this.txtSearch.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(29, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "ค้นหาโดย";
            // 
            // cboProductType
            // 
            this.cboProductType.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProductType.FormattingEnabled = true;
            this.cboProductType.Items.AddRange(new object[] {
            "ประเภทสินค้า",
            "ชื่อสินค้า"});
            this.cboProductType.Location = new System.Drawing.Point(17, 77);
            this.cboProductType.Name = "cboProductType";
            this.cboProductType.Size = new System.Drawing.Size(360, 37);
            this.cboProductType.TabIndex = 14;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGroup.Location = new System.Drawing.Point(35, 196);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(120, 41);
            this.btnAddGroup.TabIndex = 21;
            this.btnAddGroup.Text = "+ เพิ่มกลุ่ม";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // ProductTypeListControl
            // 
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ProductTypeListControl";
            this.Size = new System.Drawing.Size(1714, 950);
            this.Load += new System.EventHandler(this.ProductTypeListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitCustomerGroupGridColumns() {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // ให้คอลัมน์ยืดเต็มความกว้างของ grid
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "ProductTypeID",
                HeaderText = "ID",
                Name = "colProductTypeID",
                ReadOnly = true,
                Visible = false,
                Width = 80
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "ProductTypeCode",
                HeaderText = "รหัสกลุ่ม",
                Name = "colProductTypeCode",
                ReadOnly = true,
                Width = 150
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "ProductTypeName",
                HeaderText = "ชื่อกลุ่ม",
                Name = "colProductTypeName",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "UpdateTime",
                HeaderText = "แก้ไขล่าสุดเมื่อ",
                Name = "colUpdateTime",
                ReadOnly = true,
                Width = 150
            });

            try {
                // เตรียมรูปขนาดเล็กจาก Resource (16x16)
                int iconSize = 16;
                var editSrc = global::CreateInvoice.Properties.Resources.Edit.ToBitmap();
                var deleteSrc = global::CreateInvoice.Properties.Resources.Remove.ToBitmap();

                Image editSmall = new Bitmap(editSrc, new Size(iconSize, iconSize));
                Image deleteSmall = new Bitmap(deleteSrc, new Size(iconSize, iconSize));

                // คอลัมน์ Edit icon
                var colEditImg = new DataGridViewImageColumn {
                    Name = "colEdit",
                    HeaderText = "แก้ไข",
                    Image = editSmall,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                    Width = iconSize + 8
                };
                colEditImg.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns.Add(colEditImg);

                // คอลัมน์ Delete icon
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
                if (DesignMode || formMain == null)
                    return;   // อย่าทำงานตอนออกแบบ หรือถ้า formMain ยังไม่มี

                var dt = formMain.ProductTypesTable;
                if (dt == null) {
                    formMain.LoadProductTypes();
                    dt = formMain.ProductTypesTable;
                }

                DataView view = dt.DefaultView;
                var keyword = txtSearch.Text.Trim();

                if (cboProductType.SelectedIndex == 1) {
                    // ค้นหาจากชื่อกลุ่ม
                    if (!string.IsNullOrEmpty(keyword)) {
                        view.RowFilter = $"ProductTypeName LIKE '%{keyword.Replace("'", "''")}%'";
                    } else {
                        view.RowFilter = string.Empty;
                    }
                } else {
                    // ค้นหาจากรหัสกลุ่ม (default)
                    view.RowFilter = string.Empty;
                    view.RowFilter = !string.IsNullOrEmpty(keyword) ? $"ProductTypeCode LIKE '%{keyword.Replace("'", "''")}%'"
                                                                 : string.Empty;
                }


                dataGridView1.DataSource = view.ToTable();

            } catch (Exception ex) {
                MessageBox.Show("โหลดข้อมูลกลุ่มลูกค้าไม่สำเร็จ: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e) {
            productTypeControl = new ProductTypeControl(formMain);
            formMain.ShowView(productTypeControl);
        }

        private void ProductTypeListControl_Load(object sender, EventArgs e) {
            dataGridView1.DataSource = null;
            cboProductType.SelectedIndex = 0;
            btnSearch_Click(null, null);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0) return;

            var grid = dataGridView1;
            var colName = grid.Columns[e.ColumnIndex].Name;
            var row = grid.Rows[e.RowIndex];

            if (colName == "colEdit") {
                var idObj = row.Cells["colProductTypeID"].Value;
                if (idObj == null) return;
                if (!int.TryParse(idObj.ToString(), out int id)) return;

                string code = row.Cells["colProductTypeCode"].Value?.ToString();
                string name = row.Cells["colProductTypeName"].Value?.ToString();

                productTypeControl = new ProductTypeControl(formMain);
                productTypeControl.LoadForEdit(id, code, name);
                formMain.ShowView(productTypeControl);
            }
            else if (colName == "colDelete") {
                var idObj = row.Cells["colProductTypeID"].Value;
                if (idObj == null) return;
                if (!int.TryParse(idObj.ToString(), out int id)) return;

                string name = row.Cells["colProductTypeName"].Value?.ToString();
                var confirm = MessageBox.Show($"ยืนยันการลบกลุ่ม '{name}' ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes) {
                    var pt = new BotCommon.product_types { ProductTypeID = id };
                    BotCommon.product_types.ProductTypesMgr(pt, "DELETE");

                    // ปรับข้อมูลใน DataTable cache แทนการโหลดจาก Firebase ใหม่
                    if (formMain != null && formMain.ProductTypesTable != null) {
                        DataRow[] rows = formMain.ProductTypesTable.Select($"ProductTypeID = {id}");
                        foreach (var dr in rows) {
                            formMain.ProductTypesTable.Rows.Remove(dr);
                        }
                        formMain.ProductTypesTable.AcceptChanges();
                    }

                    // refresh grid จาก cache ที่อัปเดตแล้ว
                    btnSearch_Click(null, null);
                }
            }
        }
    }
}
