using BotCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CreateInvoice {
    public class CustomerListControl : UserControl {
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox comboBox1;
        private Label label7;
        private ComboBox comboBox2;
        private TextBox textBox3;
        private Button btnSearch;
        private Label label2;
        private ComboBox comboBox3;
        private Button btnAddCustomer;
        private DataGridView dataGridView1;
        public FormMain formMain = null;
        public CustomersControl customersControl = null;

        public CustomerListControl(FormMain pFormMain) {
            Dock = DockStyle.Fill;
            BackColor = Color.White;
            var lbl = new Label {
                Text = "สร้างการขาย",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            Controls.Add(lbl);
            InitializeComponent();

            InitCustomerGridColumns();
            dataGridView1.DataSource = null;

            formMain = pFormMain;
            customersControl = new CustomersControl(formMain, this);

            btnSearch_Click(null, null);
        }

        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnAddCustomer = new System.Windows.Forms.Button();
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
            this.dataGridView1.Location = new System.Drawing.Point(35, 267);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 32;
            this.dataGridView1.Size = new System.Drawing.Size(1474, 477);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1474, 184);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เงื่อนไขการค้นหา";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(813, 124);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(120, 35);
            this.btnSearch.TabIndex = 20;
            this.btnSearch.Text = "ค้นหา";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(406, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 21);
            this.label2.TabIndex = 19;
            this.label2.Text = "การใช้งาน";
            // 
            // comboBox3
            // 
            this.comboBox3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "ใช้งาน",
            "ไม่ใช้งาน"});
            this.comboBox3.Location = new System.Drawing.Point(394, 59);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(209, 37);
            this.comboBox3.TabIndex = 18;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(394, 124);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(400, 35);
            this.textBox3.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(30, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 21);
            this.label1.TabIndex = 15;
            this.label1.Text = "ค้นหาโดย";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(18, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(360, 37);
            this.comboBox1.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(30, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "กลุ่มบัญชีลูกค้า";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(18, 59);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(360, 37);
            this.comboBox2.TabIndex = 12;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomer.Location = new System.Drawing.Point(35, 226);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(120, 35);
            this.btnAddCustomer.TabIndex = 21;
            this.btnAddCustomer.Text = "+ เพิ่มลูกค้า";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // CustomerListControl
            // 
            this.Controls.Add(this.btnAddCustomer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CustomerListControl";
            this.Size = new System.Drawing.Size(1714, 950);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void InitCustomerGridColumns() {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            // ให้คอลัมน์ยืดเต็มความกว้างของ grid
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "CustomerID",
                HeaderText = "รหัสลูกค้า",
                Name = "colCustomerID",
                ReadOnly = true,
                Visible = false
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "CustomerCode",
                HeaderText = "รหัสลูกค้า",
                Name = "colCustomerCode",
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "PrefixT",
                HeaderText = "คำนำหน้า",
                Name = "colPrefixT",
                ReadOnly = true,
                Visible = false
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "FullName",
                HeaderText = "ชื่อ-นามสกุล",
                Name = "colFullName",
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "RefCode",
                HeaderText = "รหัสพนักงาน",
                Name = "colRefCode",
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "IdentityCard",
                HeaderText = "เลขที่บัตร",
                Name = "colIdentityCard",
                ReadOnly = true
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn {
                DataPropertyName = "AddressDetail",
                HeaderText = "บ้านเลขที่",
                Name = "colAddressDetail",
                ReadOnly = true
            });

            //// History buttons
            //dataGridView1.Columns.Add(new DataGridViewButtonColumn {
            //    HeaderText = "ประวัติการซื้อ",
            //    Name = "colPurchaseHistory",
            //    Text = "ดู",
            //    UseColumnTextForButtonValue = true
            //});
            //dataGridView1.Columns.Add(new DataGridViewButtonColumn {
            //    HeaderText = "ประวัติการแก้ไข",
            //    Name = "colEditHistory",
            //    Text = "ดู",
            //    UseColumnTextForButtonValue = true
            //});

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
                if (formMain == null || formMain.CustomersTable == null) {
                    MessageBox.Show("ยังไม่มีข้อมูลลูกค้า กรุณาโหลดข้อมูลก่อน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var customersTable = formMain.CustomersTable;
                var addressTable = formMain.AddressTable; // อาจเป็น null ได้ ถ้ายังไม่โหลด

                DataTable dt = new DataTable();
                dt.Columns.Add("CustomerCode", typeof(string));
                dt.Columns.Add("PrefixT", typeof(string));
                dt.Columns.Add("FullName", typeof(string));
                dt.Columns.Add("RefCode", typeof(string));
                dt.Columns.Add("IdentityCard", typeof(string));
                dt.Columns.Add("AddressDetail", typeof(string));

                foreach (DataRow crow in customersTable.Rows) {
                    DataRow arow = null;
                    if (addressTable != null && crow["AddressID"] != DBNull.Value && !string.IsNullOrEmpty(crow["AddressID"].ToString())) {
                        var addrRows = addressTable.Select("AddressID = '" + crow["AddressID"].ToString().Replace("'", "''") + "'");
                        if (addrRows.Length > 0)
                            arow = addrRows[0];
                    }

                    var row = dt.NewRow();
                    row["CustomerCode"] = crow["CustomerCode"].ToString();
                    row["PrefixT"] = customersTable.Columns.Contains("PrefixT") ? crow["PrefixT"].ToString() : string.Empty;
                    row["FullName"] = ($"{crow["FNameT"]} {crow["LNameT"]}").Trim();
                    row["RefCode"] = customersTable.Columns.Contains("RefCode") ? crow["RefCode"].ToString() : string.Empty;
                    row["IdentityCard"] = customersTable.Columns.Contains("IdentityCard") ? crow["IdentityCard"].ToString() : string.Empty;
                    row["AddressDetail"] = arow != null && arow.Table.Columns.Contains("AddressDetail") ? arow["AddressDetail"].ToString() : string.Empty;
                    dt.Rows.Add(row);
                }

                InitCustomerGridColumns();
                dataGridView1.DataSource = dt;
            } catch (Exception ex) {
                MessageBox.Show("โหลดข้อมูลลูกค้าไม่สำเร็จ: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e) {
            formMain.ShowView(customersControl);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Columns[e.ColumnIndex] == colEdit) {
                // Edit
                var row = dataGridView1.Rows[e.RowIndex];
                var customerIdObj = row.Cells["CustomerID"].Value;
                if (customerIdObj == null)
                    return;

                string customerId = customerIdObj.ToString();
                DataRow[] custRows = formMain.CustomersTable.Select($"CustomerID = '{customerId.Replace("'", "''")}'");
                if (custRows.Length == 0)
                    return;

                var custRow = custRows[0];
                var cust = new customers {
                    CustomerID = customerId,
                    CustomerCode = custRow["CustomerCode"].ToString(),
                    FNameT = custRow["FNameT"].ToString(),
                    LNameT = custRow["LNameT"].ToString(),
                    FNameE = custRow.Table.Columns.Contains("FNameE") ? custRow["FNameE"].ToString() : string.Empty,
                    LNameE = custRow.Table.Columns.Contains("LNameE") ? custRow["LNameE"].ToString() : string.Empty,
                    ShortNameT = custRow.Table.Columns.Contains("ShortNameT") ? custRow["ShortNameT"].ToString() : string.Empty,
                    ShortNameE = custRow.Table.Columns.Contains("ShortNameE") ? custRow["ShortNameE"].ToString() : string.Empty,
                    FindName1 = custRow.Table.Columns.Contains("FindName1") ? custRow["FindName1"].ToString() : string.Empty,
                    FindName2 = custRow.Table.Columns.Contains("FindName2") ? custRow["FindName2"].ToString() : string.Empty,
                    IdentityCard = custRow.Table.Columns.Contains("IdentityCard") ? custRow["IdentityCard"].ToString() : string.Empty,
                    Email = custRow.Table.Columns.Contains("Email") ? custRow["Email"].ToString() : string.Empty,
                    Sex = custRow.Table.Columns.Contains("Sex") ? custRow["Sex"].ToString() : string.Empty,
                    AddressID = custRow.Table.Columns.Contains("AddressID") ? custRow["AddressID"].ToString() : string.Empty,
                    CustomerGroupID = custRow.Table.Columns.Contains("CustomerGroupID") ? custRow["CustomerGroupID"].ToString() : string.Empty
                };

                address addr = null;
                if (!string.IsNullOrEmpty(cust.AddressID) && formMain.AddressTable != null && formMain.AddressTable.Columns.Contains("AddressID")) {
                    var addrRows = formMain.AddressTable.Select($"AddressID = '{cust.AddressID.Replace("'", "''")}'");
                    if (addrRows.Length > 0) {
                        var aRow = addrRows[0];
                        addr = new address {
                            AddressID = cust.AddressID,
                            AddressDetail = aRow.Table.Columns.Contains("AddressDetail") ? aRow["AddressDetail"].ToString() : string.Empty,
                            RoomNo = aRow.Table.Columns.Contains("RoomNo") ? aRow["RoomNo"].ToString() : string.Empty,
                            Flood = aRow.Table.Columns.Contains("Flood") ? aRow["Flood"].ToString() : string.Empty,
                            HouseNo = aRow.Table.Columns.Contains("HouseNo") ? aRow["HouseNo"].ToString() : string.Empty,
                            Moo = aRow.Table.Columns.Contains("Moo") ? aRow["Moo"].ToString() : string.Empty,
                            Soi = aRow.Table.Columns.Contains("Soi") ? aRow["Soi"].ToString() : string.Empty,
                            Road = aRow.Table.Columns.Contains("Road") ? aRow["Road"].ToString() : string.Empty,
                            SubDistrict = aRow.Table.Columns.Contains("SubDistrict") ? aRow["SubDistrict"].ToString() : string.Empty,
                            District = aRow.Table.Columns.Contains("District") ? aRow["District"].ToString() : string.Empty,
                            Province = aRow.Table.Columns.Contains("Province") ? aRow["Province"].ToString() : string.Empty,
                            PostCode = aRow.Table.Columns.Contains("PostCode") ? aRow["PostCode"].ToString() : string.Empty,
                            GPS = aRow.Table.Columns.Contains("GPS") ? aRow["GPS"].ToString() : string.Empty,
                            LineID = aRow.Table.Columns.Contains("LineID") ? aRow["LineID"].ToString() : string.Empty,
                            LineContract = aRow.Table.Columns.Contains("LineContract") ? aRow["LineContract"].ToString() : string.Empty,
                            Lang = aRow.Table.Columns.Contains("Lang") ? aRow["Lang"].ToString() : string.Empty,
                            Phone = aRow.Table.Columns.Contains("Phone") ? aRow["Phone"].ToString() : string.Empty,
                            Mobile = aRow.Table.Columns.Contains("Mobile") ? aRow["Mobile"].ToString() : string.Empty,
                            PhoneTo = aRow.Table.Columns.Contains("PhoneTo") ? aRow["PhoneTo"].ToString() : string.Empty,
                            Fax = aRow.Table.Columns.Contains("Fax") ? aRow["Fax"].ToString() : string.Empty,
                            RefCode = aRow.Table.Columns.Contains("RefCode") ? aRow["RefCode"].ToString() : string.Empty
                        };
                    }
                }

                // แสดง CustomersControl และโหลดข้อมูลเพื่อแก้ไข
                var custControl = new CustomersControl(formMain, this);
                if (custControl != null) {
                    custControl.LoadForEdit(cust, addr);
                }
            } else if (dataGridView1.Columns[e.ColumnIndex] == colDelete) {
                // Delete
                var row = dataGridView1.Rows[e.RowIndex];
                var customerIdObj = row.Cells["CustomerID"].Value;
                if (customerIdObj == null)
                    return;

                if (MessageBox.Show("ต้องการลบข้อมูลลูกค้านี้หรือไม่?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                string customerId = customerIdObj.ToString();

                // ลบจาก DataTable ลูกค้า
                if (formMain.CustomersTable != null) {
                    var rows = formMain.CustomersTable.Select($"CustomerID = '{customerId.Replace("'", "''")}'");
                    foreach (var r in rows) {
                        formMain.CustomersTable.Rows.Remove(r);
                    }
                }

                // ลบที่อยู่ถ้ามี
                if (formMain.AddressTable != null && formMain.CustomersTable != null && formMain.CustomersTable.Columns.Contains("AddressID")) {
                    // หา AddressID จาก row เดิม
                    var rows = formMain.CustomersTable.Select($"CustomerID = '{customerId.Replace("'", "''")}'");
                    if (rows.Length > 0 && rows[0].Table.Columns.Contains("AddressID")) {
                        var addrId = rows[0]["AddressID"].ToString();
                        if (!string.IsNullOrEmpty(addrId)) {
                            var addrRows = formMain.AddressTable.Select($"AddressID = '{addrId.Replace("'", "''")}'");
                            foreach (var ar in addrRows) {
                                formMain.AddressTable.Rows.Remove(ar);
                            }
                        }
                    }
                }

                // อาจเรียก CustomersMgr/AddressMgr ด้วยโหมด DELETE ตามที่ระบบคุณรองรับ
                // customers.CustomersMgr_Wait(ref someCustomer, "DELETE");
                // address.AddressMgr_Wait(ref someAddress, "DELETE");

                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
