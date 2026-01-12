using BotCommon;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace CreateInvoice {
    public class ProductTypeControl : UserControl {
        private DataGridViewButtonColumn colEdit;
        private GroupBox groupBox1;
        private Label label1;
        private TextBox txtProductTypeCode;
        private Button btnAdd;
        private TextBox txtProductTypeName;
        private Label label2;
        private Button btnCancel;
        public FormMain formMain = null;

        public ProductTypeListControl employeeControl = null;

        private int? currentId = null;
        private bool isEdit = false;

        public ProductTypeControl(FormMain pFormMain) {
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
            Controls.Add(lbl);
            InitializeComponent();

            formMain = pFormMain;

        }

        private void InitializeComponent() {
            this.colEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtProductTypeName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtProductTypeCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // colEdit
            // 
            this.colEdit.MinimumWidth = 6;
            this.colEdit.Name = "colEdit";
            this.colEdit.Width = 125;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtProductTypeName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.txtProductTypeCode);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 277);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ข้อมูล";
            // 
            // txtProductTypeName
            // 
            this.txtProductTypeName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProductTypeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductTypeName.Location = new System.Drawing.Point(197, 139);
            this.txtProductTypeName.Name = "txtProductTypeName";
            this.txtProductTypeName.Size = new System.Drawing.Size(339, 35);
            this.txtProductTypeName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(205, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 21);
            this.label2.TabIndex = 22;
            this.label2.Text = "ชื่อประเภทสินค้า";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(358, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 41);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "ยกเลิก";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(232, 198);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 41);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtProductTypeCode
            // 
            this.txtProductTypeCode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtProductTypeCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductTypeCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductTypeCode.Location = new System.Drawing.Point(197, 71);
            this.txtProductTypeCode.Name = "txtProductTypeCode";
            this.txtProductTypeCode.Size = new System.Drawing.Size(339, 35);
            this.txtProductTypeCode.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(205, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 28);
            this.label1.TabIndex = 15;
            this.label1.Text = "รหัสประเภทสินค้า";
            // 
            // ProductTypeControl
            // 
            this.Controls.Add(this.groupBox1);
            this.Name = "ProductTypeControl";
            this.Size = new System.Drawing.Size(936, 401);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        public void LoadForAdd() {
            isEdit = false;
            currentId = null;
            btnAdd.Text = "เพิ่ม";
            txtProductTypeCode.Text = string.Empty;
            txtProductTypeName.Text = string.Empty;
        }

        public void LoadForEdit(int id, string code, string name) {
            isEdit = true;
            currentId = id;
            btnAdd.Text = "แก้ไข";
            txtProductTypeCode.Text = code;
            txtProductTypeName.Text = name;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            var code = txtProductTypeCode.Text.Trim();
            var name = txtProductTypeName.Text.Trim();
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(name)) {
                MessageBox.Show("กรุณากรอกรหัสและชื่อประเภทสินค้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var pt = new product_types {
                ProductTypeCode = code,
                ProductTypeName = name,
                UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                UpdateBy = Environment.UserName
            };

            if (isEdit && currentId.HasValue) {
                pt.ProductTypeID = currentId.Value;
                product_types.ProductTypesMgr(pt, "EDIT");

                // อัปเดตแถวใน DataTable cache
                if (formMain != null && formMain.ProductTypesTable != null) {
                    DataRow[] rows = formMain.ProductTypesTable.Select($"ProductTypeID = {pt.ProductTypeID}");
                    foreach (var dr in rows) {
                        dr["ProductTypeCode"] = pt.ProductTypeCode;
                        dr["ProductTypeName"] = pt.ProductTypeName;
                        dr["UpdateTime"] = pt.UpdateTime;
                        dr["UpdateBy"] = pt.UpdateBy;
                    }
                    formMain.ProductTypesTable.AcceptChanges();
                }
            } else {
                // generate new id: max existing + 1 จาก DataTable กลางใน FormMain
                int maxId = 0;
                if (formMain != null && formMain.ProductTypesTable != null) {
                    foreach (DataRow row in formMain.ProductTypesTable.Rows) {
                        if (row["ProductTypeID"] != DBNull.Value) {
                            int id;
                            if (int.TryParse(row["ProductTypeID"].ToString(), out id)) {
                                if (id > maxId)
                                    maxId = id;
                            }
                        }
                    }
                }

                pt.ProductTypeID = maxId + 1;
                pt.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                pt.CreateBy = Environment.UserName;
                product_types.ProductTypesMgr(pt, "ADD");

                // เพิ่มแถวใหม่ใน DataTable cache
                if (formMain != null && formMain.ProductTypesTable != null) {
                    var dt = formMain.ProductTypesTable;
                    var newRow = dt.NewRow();
                    newRow["ProductTypeID"] = pt.ProductTypeID;
                    newRow["ProductTypeCode"] = pt.ProductTypeCode;
                    newRow["ProductTypeName"] = pt.ProductTypeName;
                    newRow["CreateTime"] = pt.CreateTime;
                    newRow["CreateBy"] = pt.CreateBy;
                    newRow["UpdateTime"] = pt.UpdateTime;
                    newRow["UpdateBy"] = pt.UpdateBy;
                    dt.Rows.Add(newRow);
                    dt.AcceptChanges();
                }
            }

            MessageBox.Show("บันทึกข้อมูลเรียบร้อย", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ไม่ต้อง LoadProductTypes อีก แค่กลับไปหน้า list ซึ่งจะใช้ DataTable ที่อัปเดตแล้ว
            formMain.ShowView(employeeControl);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            employeeControl = new ProductTypeListControl(formMain);
            formMain.ShowView(employeeControl);
        }
    }
}
