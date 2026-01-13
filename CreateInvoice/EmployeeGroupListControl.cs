using BotCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CreateInvoice {
    public class EmployeeGroupListControl : UserControl {
        private DataGridViewButtonColumn colEdit;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox cboEmployeeGroup;
        private TextBox textBox3;
        private Button btnSearch;
        private Button btnAddGroup;
        private DataGridView dataGridView1;
        public FormMain formMain = null;
        public EmployeeGroupControl employeeControl = null;

        public EmployeeGroupListControl(FormMain pFormMain) {
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
            dataGridView1.DataSource = null;

            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void InitializeComponent() {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEmployeeGroup = new System.Windows.Forms.ComboBox();
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboEmployeeGroup);
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
            this.btnSearch.Location = new System.Drawing.Point(807, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 41);
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
            this.textBox3.Location = new System.Drawing.Point(393, 78);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(400, 35);
            this.textBox3.TabIndex = 17;
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
            // cboEmployeeGroup
            // 
            this.cboEmployeeGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboEmployeeGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEmployeeGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEmployeeGroup.FormattingEnabled = true;
            this.cboEmployeeGroup.Location = new System.Drawing.Point(17, 77);
            this.cboEmployeeGroup.Name = "cboEmployeeGroup";
            this.cboEmployeeGroup.Size = new System.Drawing.Size(360, 37);
            this.cboEmployeeGroup.TabIndex = 14;
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
            // EmployeeGroupListControl
            // 
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "EmployeeGroupListControl";
            this.Size = new System.Drawing.Size(1714, 950);
            this.Load += new System.EventHandler(this.EmployeeGroupListControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitCustomerGroupGridColumns() {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "CustomerGroupID",
                HeaderText = "ID",
                Name = "colCustomerGroupID",
                ReadOnly = true,
                Visible = false,
                Width = 80
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "CustomerGroupCode",
                HeaderText = "รหัสกลุ่ม",
                Name = "colCustomerGroupCode",
                ReadOnly = true,
                Width = 150
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "CustomerGroupName",
                HeaderText = "ชื่อกลุ่ม",
                Name = "colCustomerGroupName",
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
                if (DesignMode || formMain == null)
                    return;

                var dt = formMain.CustomerGroupsTable;
                if (dt == null) {
                    formMain.LoadCustomerGroups();
                    dt = formMain.CustomerGroupsTable;
                }

                DataView view = dt.DefaultView;
                string keyword = textBox3.Text.Trim();

                // escape สำหรับ RowFilter: '  %  [  ]
                string EscapeLike(string value) {
                    if (string.IsNullOrEmpty(value))
                        return value;
                    var s = value.Replace("'", "''");
                    s = s.Replace("[", "[[]");   // escape [
                    s = s.Replace("%", "[%]");   // treat % เป็นตัวอักษรปกติ
                    s = s.Replace("_", "[_]");   // treat _ เป็นตัวอักษรปกติ
                    return s;
                }

                string filter = string.Empty;
                if (!string.IsNullOrEmpty(keyword)) {
                    var safe = EscapeLike(keyword);
                    if (cboEmployeeGroup.SelectedIndex == 1) {
                        // ชื่อกลุ่ม
                        filter = $"CustomerGroupName LIKE '%{safe}%'";
                    } else {
                        // รหัสกลุ่ม (default)
                        filter = $"CustomerGroupCode LIKE '%{safe}%'";
                    }
                }

                view.RowFilter = filter;
                dataGridView1.DataSource = view.ToTable();
            } catch (Exception ex) {
                MessageBox.Show("โหลดข้อมูลกลุ่มลูกค้าไม่สำเร็จ: " + ex.Message,
                                "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;
            var grid = dataGridView1;
            var colName = grid.Columns[e.ColumnIndex].Name;
            var row = grid.Rows[e.RowIndex];

            if (colName == "colEdit") {
                var idObj = row.Cells["colCustomerGroupID"].Value;
                if (idObj == null)
                    return;
                string id = idObj.ToString();

                string code = row.Cells["colCustomerGroupCode"].Value?.ToString();
                string name = row.Cells["colCustomerGroupName"].Value?.ToString();

                employeeControl = new EmployeeGroupControl(formMain);
                employeeControl.LoadForEdit(id, code, name);
                formMain.ShowView(employeeControl);
            } else if (colName == "colDelete") {
                var idObj = row.Cells["colCustomerGroupID"].Value;
                if (idObj == null)
                    return;
                string id = idObj.ToString();

                string name = row.Cells["colCustomerGroupName"].Value?.ToString();
                var confirm = MessageBox.Show($"ยืนยันการลบกลุ่มลูกค้า '{name}' ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes) {
                    var cg = new customer_groups { CustomerGroupID = id };
                    customer_groups.CustomerGroupsMgr(cg, "DELETE");

                    // ปรับข้อมูลใน DataTable cache แทนการโหลดจาก Firebase ใหม่
                    if (formMain != null && formMain.CustomerGroupsTable != null) {
                        DataRow[] rows = formMain.CustomerGroupsTable.Select($"CustomerGroupID = '{id}'");
                        foreach (var dr in rows) {
                            formMain.CustomerGroupsTable.Rows.Remove(dr);
                        }
                        formMain.CustomerGroupsTable.AcceptChanges();
                    }

                    // refresh grid จาก cache ที่อัปเดตแล้ว
                    btnSearch_Click(null, null);
                }
            }
        }

        private void EmployeeGroupListControl_Load(object sender, EventArgs e) {
            cboEmployeeGroup.Items.Clear();
            cboEmployeeGroup.Items.Add("รหัสกลุ่ม");
            cboEmployeeGroup.Items.Add("ชื่อกลุ่ม");
            cboEmployeeGroup.SelectedIndex = 0;
            dataGridView1.DataSource = null;
            btnSearch_Click(null, null);
        }

        private void btnAddGroup_Click(object sender, EventArgs e) {
            employeeControl = new EmployeeGroupControl(formMain);
            formMain.ShowView(employeeControl);
        }
    }
}
