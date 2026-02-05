using BotCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CreateInvoice {
    public class CompanyListControl : UserControl {
        private DataGridViewButtonColumn colEdit;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox comboBox1;
        private TextBox textBox3;
        private Button btnSearch;
        private Button btnAddGroup;
        private DataGridView dataGridView1;
        public CompanyControl companyControl;

        private readonly FormMain formMain;

        public CompanyListControl(FormMain pFormMain) {
            Dock = DockStyle.Fill;
            BackColor = Color.White;
            var lbl = new Label {
                Text = "ข้อมูลบริษัท",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            Controls.Add(lbl);
            formMain = pFormMain;
            InitializeComponent();

            InitCompanyGridColumns();
            InitSearchCriteria();
            dataGridView1.DataSource = null;

            dataGridView1.CellClick += dataGridView1_CellClick;
            btnSearch_Click(null, null);
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
            this.dataGridView1.Location = new System.Drawing.Point(35, 238);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(1166, 469);
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
            this.groupBox1.Location = new System.Drawing.Point(35, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1166, 149);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เงื่อนไขการค้นหา";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(655, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 35);
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
            this.textBox3.Location = new System.Drawing.Point(249, 75);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(400, 35);
            this.textBox3.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(55, 52);
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
            "ชื่อบริษัท"});
            this.comboBox1.Location = new System.Drawing.Point(43, 74);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(200, 37);
            this.comboBox1.TabIndex = 14;
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGroup.Location = new System.Drawing.Point(35, 191);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(160, 41);
            this.btnAddGroup.TabIndex = 22;
            this.btnAddGroup.Text = "+ เพิ่มบริษัท";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // CompanyListControl
            // 
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CompanyListControl";
            this.Size = new System.Drawing.Size(1714, 950);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitSearchCriteria() {
            comboBox1.Items.Clear();
            comboBox1.Items.Add("รหัสบริษัท");     // 0
            comboBox1.Items.Add("ชื่อบริษัท");     // 1
            comboBox1.Items.Add("รหัสที่อยู่");     // 2
            comboBox1.SelectedIndex = 0;
        }

        private void InitCompanyGridColumns() {
            if (dataGridView1.Columns.Count > 0)
                return;
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "CompanyID",
                HeaderText = "รหัสบริษัท",
                Name = "colCompanyID",
                ReadOnly = true,
                Visible = false
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "CompanyCode",
                HeaderText = "รหัสบริษัท",
                Name = "colCompanyCode",
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "CompanyName",
                HeaderText = "ชื่อบริษัท",
                Name = "colCompanyName",
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "AddressDetail",
                HeaderText = "ที่อยู่",
                Name = "colAddressDetail",
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "UpdateTime",
                HeaderText = "แก้ไขล่าสุดเมื่อ",
                Name = "colUpdateTime",
                ReadOnly = true
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;
            var grid = dataGridView1;
            var colName = grid.Columns[e.ColumnIndex].Name;
            var row = grid.Rows[e.RowIndex];

            if (colName == "colEdit") {
                var idObj = row.Cells["colCompanyID"].Value;
                if (idObj == null)
                    return;
                string id = idObj.ToString();

                string code = row.Cells["colCompanyCode"].Value?.ToString();
                string name = row.Cells["colCompanyName"].Value?.ToString();

                companyControl = new CompanyControl(formMain, this);
                companyControl.LoadForEdit(id, code, name);
                formMain.ShowView(companyControl);
            } else if (colName == "colDelete") {
                var idObj = row.Cells["colCompanyID"].Value;
                if (idObj == null)
                    return;
                string id = idObj.ToString();

                string name = row.Cells["colCompanyName"].Value?.ToString();
                var confirm = MessageBox.Show($"ยืนยันการลบบริษัท '{name}' ?", "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes) {
                    var cg = new companys { CompanyID = id };
                    companys.CompanysMgr(cg, "DELETE");

                    // ปรับข้อมูลใน DataTable cache แทนการโหลดจาก Firebase ใหม่
                    if (formMain != null && formMain.CompanysTable != null) {
                        DataRow[] rows = formMain.CompanysTable.Select($"CompanyID = '{id}'");
                        foreach (var dr in rows) {
                            formMain.CompanysTable.Rows.Remove(dr);
                        }
                        formMain.CompanysTable.AcceptChanges();
                    }

                    // refresh grid จาก cache ที่อัปเดตแล้ว
                    btnSearch_Click(null, null);
                }
            }
        }
        private void btnSearch_Click(object sender, EventArgs e) {
            try {
                var dtCompany = (formMain != null) ? formMain.CompanysTable : null;
                var dtAddress = (formMain != null) ? formMain.AddressTable : null;

                if (dtCompany == null) {
                    MessageBox.Show("ยังไม่มีข้อมูลบริษัท กรุณาโหลดข้อมูลอีกครั้ง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = new DataTable();
                result.Columns.Add("CompanyID", typeof(string));
                result.Columns.Add("CompanyCode", typeof(string));
                result.Columns.Add("CompanyName", typeof(string));
                result.Columns.Add("AddressID", typeof(string));
                result.Columns.Add("AddressDetail", typeof(string));
                result.Columns.Add("UpdateTime", typeof(string));

                string keyword = (textBox3.Text ?? string.Empty).Trim();
                int searchMode = comboBox1.SelectedIndex;

                foreach (DataRow cRow in dtCompany.Rows) {
                    string companyId = cRow["CompanyID"].ToString();
                    string companyCode = cRow["CompanyCode"].ToString();
                    string companyName = cRow["CompanyName"].ToString();
                    string UpdateTime = cRow["UpdateTime"].ToString();
                    string addressId = cRow.Table.Columns.Contains("AddressID") ? cRow["AddressID"].ToString() : string.Empty;

                    string addressDetail = string.Empty;
                    string addressFull = string.Empty;
                    if (dtAddress != null && !string.IsNullOrEmpty(addressId)) {
                        DataRow[] addrRows = dtAddress.Select("AddressID = '" + addressId.Replace("'", "''") + "'");
                        if (addrRows.Length > 0) {
                            var a = addrRows[0];
                            if (a.Table.Columns.Contains("AddressDetail"))
                                addressDetail = a["AddressDetail"].ToString();

                            // สร้างสตริงที่อยู่แบบรวมจากฟิลด์ต่าง ๆ
                            var parts = new System.Collections.Generic.List<string>();
                            void AddIf(string col) {
                                if (a.Table.Columns.Contains(col)) {
                                    var v = a[col]?.ToString();
                                    if (!string.IsNullOrWhiteSpace(v)) {
                                        switch (col) {
                                            case "RoomNo":
                                                v = "ห้อง " + v.Trim();
                                                break;
                                            case "Flood":
                                                v = "ชั้น " + v.Trim();
                                                break;
                                            case "HouseNo":
                                                v = "เลขที่ " + v.Trim();
                                                break;
                                            case "Moo":
                                                v = "หมู่ " + v.Trim();
                                                break;
                                            case "Soi":
                                                v = "ซ." + v.Trim();
                                                break;
                                            case "Road":
                                                v = "ถ." + v.Trim();
                                                break;
                                            case "SubDistrict":
                                                v = "ต." + v.Trim();
                                                break;
                                            case "District":
                                                v = "อ." + v.Trim();
                                                break;
                                            case "Province":
                                                v = "จ." + v.Trim();
                                                break;
                                            default:
                                                v = v.Trim();
                                                break;
                                        }
                                        parts.Add(v.Trim());
                                    }
                                }
                            }
                            //if (a["AddressDetail"].ToString().Length > 0) {
                            //    AddIf("AddressDetail");
                            //} else {  
                            // ห้อง, ชั้น, เลขที่, หมู่, ซอย, ถนน
                            AddIf("RoomNo");
                            AddIf("Flood");
                            AddIf("HouseNo");
                            AddIf("Moo");
                            AddIf("Soi");
                            AddIf("Road");
                            // ตำบล อำเภอ จังหวัด
                            AddIf("SubDistrict");
                            AddIf("District");
                            AddIf("Province");
                            AddIf("PostCode");
                            //}

                            if (parts.Count > 0)
                                addressFull = string.Join(" ", parts);
                        }
                    }

                    if (!string.IsNullOrEmpty(keyword)) {
                        string target = string.Empty;
                        switch (searchMode) {
                            case 0:
                                target = companyCode;
                                break;
                            case 1:
                                target = companyName;
                                break;
                            case 2:
                                target = addressId;
                                break;
                        }
                        if (string.IsNullOrEmpty(target) || target.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) < 0)
                            continue;
                    }

                    var row = result.NewRow();
                    row["CompanyID"] = companyId;
                    row["CompanyCode"] = companyCode;
                    row["CompanyName"] = companyName;
                    row["AddressID"] = addressId;
                    // แสดงข้อมูลที่อยู่แบบรวมในคอลัมน์ AddressID ตามคำขอ
                    row["AddressID"] = string.IsNullOrEmpty(addressFull) ? addressId : addressFull;
                    row["AddressDetail"] = addressDetail;
                    row["UpdateTime"] = UpdateTime;
                    result.Rows.Add(row);
                }

                InitCompanyGridColumns();
                dataGridView1.DataSource = result;
            } catch (Exception ex) {
                MessageBox.Show("โหลดข้อมูลบริษัทไม่สำเร็จ: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddGroup_Click(object sender, EventArgs e) {
            companyControl = new CompanyControl(formMain, this);
            formMain.ShowView(companyControl);
        }

        public void LoadCompanyList() {
            btnSearch_Click(null, null);
        }
    }
}
