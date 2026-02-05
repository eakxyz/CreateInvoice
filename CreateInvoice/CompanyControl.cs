using BotCommon;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CreateInvoice {
    public class CompanyControl : UserControl {
        private Label label1;
        private TextBox txtCompanyCode;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox2;
        private Label label5;
        private TextBox txtCompanyNameE;
        private Label label3;
        private TextBox txtCompanyNameT;
        private GroupBox groupBox3;
        private Label label15;
        private TextBox txtFindName2;
        private Label label16;
        private TextBox txtFindName1;
        private GroupBox groupBox5;
        private Label label31;
        private TextBox txtEmail;
        private Label label27;
        private TextBox txtRef;
        private Label label28;
        private TextBox txtTelTo;
        private Label label29;
        private TextBox txtFax;
        private Label label30;
        private TextBox txtTel;
        private Label label33;
        private ComboBox cboLang;
        private Label label32;
        private TextBox txtMobile;
        private Button btnAdd;
        private Label label11;
        private TextBox txtTaxId;
        private GroupBox groupBox6;
        private Label label34;
        private TextBox txtLineContract;
        private Label label35;
        private TextBox txtLineID;
        private Label label36;
        private TextBox txtGPS;
        private Label label37;
        private TextBox txtPostCode;
        private Label label38;
        private ComboBox cboProvince;
        private Label label39;
        private ComboBox cboDistrict;
        private Label label40;
        private ComboBox cboSubDistrict;
        private Label label41;
        private TextBox txtRoad;
        private Label label42;
        private TextBox txtSoi;
        private Label label43;
        private TextBox txtMoo;
        private Label label44;
        private TextBox txtHouseNo;
        private Label label45;
        private TextBox txtFlood;
        private Label label46;
        private TextBox txtRoomNo;
        private Label label47;
        private TextBox txtAddressDetail;
        private GroupBox groupBox1;

        public FormMain formMain = null;
        public CompanyListControl companyList = null;

        private string currentCompanyId = null;
        private string currentAddressId = null;
        private bool isEdit = false;

        public CompanyControl(FormMain pFormMain, CompanyListControl pCompanyListControl) {
            BackColor = Color.White;
            var lbl = new Label {
                Text = "บริษัท",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            Controls.Add(lbl);
            InitializeComponent();

            formMain = pFormMain;
            companyList = pCompanyListControl;

            InitThaiAddressCombo();
            cboProvince.SelectedItem = "เชียงใหม่"; // ตั้งค่าเริ่มต้นเป็นเชียงใหม่
            CboProvince_SelectedIndexChanged(null, null); // โหลดอำเภอสำหรับเชียงใหม่
            // เพิ่ม event สำหรับตำบล
            cboSubDistrict.SelectedIndexChanged += CboSubDistrict_SelectedIndexChanged;
        }

        private void InitThaiAddressCombo() {
            try {
                // ตรวจสอบว่ามีข้อมูล
                if (ThaiAddressData.Data == null || ThaiAddressData.Data.Count == 0) {
                    MessageBox.Show("ยังไม่มีข้อมูลจังหวัด อำเภอ ตำบล\nกรุณาตรวจสอบไฟล์ XML ใน Resources",
                        "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // เติมจังหวัด
                cboProvince.Items.Clear();
                foreach (var prov in ThaiAddressData.Data.Keys.OrderBy(p => p)) {
                    cboProvince.Items.Add(prov);
                }

                // ลงทะเบียน event handlers
                cboProvince.SelectedIndexChanged += CboProvince_SelectedIndexChanged;
                cboDistrict.SelectedIndexChanged += CboDistrict_SelectedIndexChanged;

                System.Diagnostics.Debug.WriteLine($"InitThaiAddressCombo: โหลดจังหวัด {ThaiAddressData.Data.Count} แห่ง");
            } catch (Exception ex) {
                MessageBox.Show($"เกิดข้อผิดพลาดในการโหลดข้อมูลจังหวัด:\n{ex.Message}",
                    "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"InitThaiAddressCombo Error: {ex.Message}");
            }
        }

        private void CboProvince_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                // ล้างข้อมูลอำเภอและตำบล
                cboDistrict.SelectedIndexChanged -= CboDistrict_SelectedIndexChanged; // ปิด event ชั่วคราว

                cboDistrict.Items.Clear();
                cboSubDistrict.Items.Clear();
                var prov = cboProvince.Text?.Trim();
                if (string.IsNullOrEmpty(prov)) {
                    cboDistrict.SelectedIndexChanged += CboDistrict_SelectedIndexChanged; // เปิด event
                    return;
                }

                // โหลดอำเภอตามจังหวัดที่เลือก
                if (ThaiAddressData.Data.TryGetValue(prov, out var districts)) {
                    foreach (var d in districts.Keys.OrderBy(x => x)) {
                        cboDistrict.Items.Add(d);
                    }
                    System.Diagnostics.Debug.WriteLine($"โหลดอำเภอใน {prov}: {districts.Count} อำเภอ");
                }

                cboDistrict.SelectedIndexChanged += CboDistrict_SelectedIndexChanged; // เปิด event
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"CboProvince_SelectedIndexChanged Error: {ex.Message}");
                cboDistrict.SelectedIndexChanged += CboDistrict_SelectedIndexChanged; // ให้แน่ใจว่า event ถูกเปิดกลับ
            }
        }

        private void CboDistrict_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                // ล้างข้อมูลตำบล
                cboSubDistrict.Items.Clear();
                cboSubDistrict.Text = "";

                var prov = cboProvince.Text?.Trim();
                var dist = cboDistrict.Text?.Trim();

                if (string.IsNullOrEmpty(prov) || string.IsNullOrEmpty(dist))
                    return;

                // โหลดตำบลตามจังหวัดและอำเภอที่เลือก
                if (ThaiAddressData.Data.TryGetValue(prov, out var districts) &&
                    districts.TryGetValue(dist, out var subs)) {
                    cboSubDistrict.Items.Add(""); // เพิ่มตัวเลือกว่าง
                    foreach (var s in subs.OrderBy(x => x.Name)) {
                        cboSubDistrict.Items.Add(s); // เพิ่ม SubDistrictInfo object
                    }
                    System.Diagnostics.Debug.WriteLine($"โหลดตำบลใน {prov}/{dist}: {subs.Count} ตำบล");
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"CboDistrict_SelectedIndexChanged Error: {ex.Message}");
            }
        }
        private void CboSubDistrict_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                var selectedItem = cboSubDistrict.SelectedItem;

                if (selectedItem is ThaiAddressData.SubDistrictInfo subInfo) {
                    // ใส่รหัสไปรษณีย์อัตโนมัติ
                    txtPostCode.Text = subInfo.ZipCode;
                    System.Diagnostics.Debug.WriteLine($"ตั้งรหัสไปรษณีย์: {subInfo.Name} -> {subInfo.ZipCode}");
                } else if (string.IsNullOrEmpty(cboSubDistrict.Text)) {
                    // ถ้าเลือกรายการว่าง ให้ล้างรหัสไปรษณีย์
                    txtPostCode.Clear();
                }
            } catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine($"CboSubDistrict_SelectedIndexChanged Error: {ex.Message}");
            }
        }

        public void LoadForEdit(string companyId, string companyCode, string companyName) {
            isEdit = true;
            currentCompanyId = companyId;
            btnAdd.Text = "แก้ไข";

            // ดึงข้อมูล company จาก FormMain cache ถ้ามี
            if (formMain != null && formMain.CompanysTable != null) {
                DataRow[] rows = formMain.CompanysTable.Select("CompanyID = '" + companyId.Replace("'", "''") + "'");
                if (rows.Length > 0) {
                    var r = rows[0];
                    txtCompanyCode.Text = r["CompanyCode"].ToString();
                    txtCompanyNameT.Text = r["CompanyName"].ToString();
                    currentAddressId = r.Table.Columns.Contains("AddressID") ? r["AddressID"].ToString() : null;
                }
            }

            if (!string.IsNullOrEmpty(currentAddressId) && formMain != null && formMain.AddressTable != null) {
                DataRow[] arows = formMain.AddressTable.Select("AddressID = '" + currentAddressId.Replace("'", "''") + "'");
                if (arows.Length > 0) {
                    var a = arows[0];

                    // โหลดข้อมูลที่อยู่ทั่วไป
                    txtAddressDetail.Text = a["AddressDetail"].ToString();
                    txtRoomNo.Text = a["RoomNo"].ToString();
                    txtFlood.Text = a["Flood"].ToString();
                    txtHouseNo.Text = a["HouseNo"].ToString();
                    txtMoo.Text = a["Moo"].ToString();
                    txtSoi.Text = a["Soi"].ToString();
                    txtRoad.Text = a["Road"].ToString();

                    // เก็บค่าจังหวัด อำเภอ ตำบล
                    var province = a["Province"].ToString();
                    var district = a["District"].ToString();
                    var subDistrict = a["SubDistrict"].ToString();

                    // ปิด event handlers ชั่วคราวเพื่อไม่ให้เกิดการ trigger ซ้ำซ้อน
                    cboProvince.SelectedIndexChanged -= CboProvince_SelectedIndexChanged;
                    cboDistrict.SelectedIndexChanged -= CboDistrict_SelectedIndexChanged;
                    cboSubDistrict.SelectedIndexChanged -= CboSubDistrict_SelectedIndexChanged;

                    try {
                        // เลือกจังหวัด
                        if (!string.IsNullOrEmpty(province)) {
                            cboProvince.Text = province;

                            // โหลดอำเภอสำหรับจังหวัดที่เลือก
                            if (ThaiAddressData.Data.TryGetValue(province, out var districts)) {
                                cboDistrict.Items.Clear();
                                cboDistrict.Items.Add("");
                                foreach (var d in districts.Keys.OrderBy(x => x)) {
                                    cboDistrict.Items.Add(d);
                                }
                            }
                        }

                        // เลือกอำเภอ
                        if (!string.IsNullOrEmpty(district)) {
                            cboDistrict.Text = district;

                            // โหลดตำบลสำหรับอำเภอที่เลือก
                            if (!string.IsNullOrEmpty(province) &&
                                ThaiAddressData.Data.TryGetValue(province, out var districts) &&
                                districts.TryGetValue(district, out var subs)) {
                                cboSubDistrict.Items.Clear();
                                cboSubDistrict.Items.Add("");
                                foreach (var s in subs.OrderBy(x => x.Name)) {
                                    cboSubDistrict.Items.Add(s);
                                }
                            }
                        }

                        // เลือกตำบล
                        if (!string.IsNullOrEmpty(subDistrict)) {
                            // ค้นหา SubDistrictInfo ที่ตรงกับชื่อตำบล
                            foreach (var item in cboSubDistrict.Items) {
                                if (item is ThaiAddressData.SubDistrictInfo subInfo && subInfo.Name == subDistrict) {
                                    cboSubDistrict.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                    } finally {
                        // เปิด event handlers อีกครั้ง
                        cboProvince.SelectedIndexChanged += CboProvince_SelectedIndexChanged;
                        cboDistrict.SelectedIndexChanged += CboDistrict_SelectedIndexChanged;
                        cboSubDistrict.SelectedIndexChanged += CboSubDistrict_SelectedIndexChanged;
                    }

                    // โหลดข้อมูลที่เหลือ
                    txtPostCode.Text = a["PostCode"].ToString();
                    txtGPS.Text = a["GPS"].ToString();
                    txtLineID.Text = a["LineID"].ToString();
                    txtLineContract.Text = a["LineContract"].ToString();
                    cboLang.Text = a["Lang"].ToString();
                    txtTel.Text = a["Phone"].ToString();
                    txtMobile.Text = a["Mobile"].ToString();
                    txtTelTo.Text = a["PhoneTo"].ToString();
                    txtFax.Text = a["Fax"].ToString();
                    txtRef.Text = a["RefCode"].ToString();
                }
            }
        }

        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompanyCode = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label32 = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtRef = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtTelTo = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cboLang = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtFindName2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtFindName1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTaxId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCompanyNameE = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCompanyNameT = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txtLineContract = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.txtLineID = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.txtGPS = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.cboProvince = new System.Windows.Forms.ComboBox();
            this.label39 = new System.Windows.Forms.Label();
            this.cboDistrict = new System.Windows.Forms.ComboBox();
            this.label40 = new System.Windows.Forms.Label();
            this.cboSubDistrict = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtRoad = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.txtSoi = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txtMoo = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.txtHouseNo = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.txtFlood = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txtRoomNo = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.txtAddressDetail = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCompanyCode);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.groupBox1.Location = new System.Drawing.Point(63, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1167, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รหัสบริษัท";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสบริษัท";
            // 
            // txtCompanyCode
            // 
            this.txtCompanyCode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCompanyCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.txtCompanyCode.Location = new System.Drawing.Point(41, 60);
            this.txtCompanyCode.Name = "txtCompanyCode";
            this.txtCompanyCode.Size = new System.Drawing.Size(360, 35);
            this.txtCompanyCode.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(63, 171);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1171, 601);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage1.Size = new System.Drawing.Size(1163, 566);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ข้อมูลทั่วไป";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label32);
            this.groupBox5.Controls.Add(this.txtMobile);
            this.groupBox5.Controls.Add(this.label31);
            this.groupBox5.Controls.Add(this.txtEmail);
            this.groupBox5.Controls.Add(this.label27);
            this.groupBox5.Controls.Add(this.txtRef);
            this.groupBox5.Controls.Add(this.label28);
            this.groupBox5.Controls.Add(this.txtTelTo);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.txtFax);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.txtTel);
            this.groupBox5.Controls.Add(this.label33);
            this.groupBox5.Controls.Add(this.cboLang);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(15, 313);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1135, 242);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "การติดต่อ";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(34, 96);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(127, 20);
            this.label32.TabIndex = 37;
            this.label32.Text = "เบอร์โทรศัพท์มือถือ";
            // 
            // txtMobile
            // 
            this.txtMobile.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMobile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(22, 118);
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(360, 35);
            this.txtMobile.TabIndex = 36;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(236, 34);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(61, 20);
            this.label31.TabIndex = 34;
            this.label31.Text = "E - mail";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(219, 56);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(360, 35);
            this.txtEmail.TabIndex = 35;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(768, 156);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 20);
            this.label27.TabIndex = 32;
            this.label27.Text = "รหัสอ้างอิง";
            // 
            // txtRef
            // 
            this.txtRef.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRef.Location = new System.Drawing.Point(754, 178);
            this.txtRef.Name = "txtRef";
            this.txtRef.Size = new System.Drawing.Size(360, 35);
            this.txtRef.TabIndex = 33;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(397, 156);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(56, 20);
            this.label28.TabIndex = 30;
            this.label28.Text = "เบอร์ต่อ";
            // 
            // txtTelTo
            // 
            this.txtTelTo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTelTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelTo.Location = new System.Drawing.Point(388, 178);
            this.txtTelTo.Name = "txtTelTo";
            this.txtTelTo.Size = new System.Drawing.Size(360, 35);
            this.txtTelTo.TabIndex = 31;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(34, 156);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(35, 20);
            this.label29.TabIndex = 28;
            this.label29.Text = "Fax";
            // 
            // txtFax
            // 
            this.txtFax.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFax.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(22, 178);
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(360, 35);
            this.txtFax.TabIndex = 29;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(397, 96);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(92, 20);
            this.label30.TabIndex = 27;
            this.label30.Text = "เบอร์โทรศัพท์";
            // 
            // txtTel
            // 
            this.txtTel.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTel.Location = new System.Drawing.Point(388, 118);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(360, 35);
            this.txtTel.TabIndex = 26;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Location = new System.Drawing.Point(34, 34);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(41, 20);
            this.label33.TabIndex = 21;
            this.label33.Text = "ภาษา";
            // 
            // cboLang
            // 
            this.cboLang.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboLang.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLang.FormattingEnabled = true;
            this.cboLang.Items.AddRange(new object[] {
            "ไทย",
            "อังกฤษ"});
            this.cboLang.Location = new System.Drawing.Point(22, 56);
            this.cboLang.Name = "cboLang";
            this.cboLang.Size = new System.Drawing.Size(191, 37);
            this.cboLang.TabIndex = 20;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.txtFindName2);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.txtFindName1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(15, 193);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1135, 114);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "คำที่ใช้ในการค้นหา";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(397, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 20);
            this.label15.TabIndex = 8;
            this.label15.Text = "คำที่ใช้ค้นหา 2";
            // 
            // txtFindName2
            // 
            this.txtFindName2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFindName2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFindName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindName2.Location = new System.Drawing.Point(388, 59);
            this.txtFindName2.Name = "txtFindName2";
            this.txtFindName2.Size = new System.Drawing.Size(360, 35);
            this.txtFindName2.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(34, 36);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 20);
            this.label16.TabIndex = 6;
            this.label16.Text = "คำที่ใช้ค้นหา 1";
            // 
            // txtFindName1
            // 
            this.txtFindName1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFindName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFindName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFindName1.Location = new System.Drawing.Point(22, 58);
            this.txtFindName1.Name = "txtFindName1";
            this.txtFindName1.Size = new System.Drawing.Size(360, 35);
            this.txtFindName1.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtTaxId);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCompanyNameE);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtCompanyNameT);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1135, 170);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลส่วนตัว";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(400, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "เลขที่เสียภาษี";
            // 
            // txtTaxId
            // 
            this.txtTaxId.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTaxId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaxId.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTaxId.Location = new System.Drawing.Point(388, 49);
            this.txtTaxId.Name = "txtTaxId";
            this.txtTaxId.Size = new System.Drawing.Size(360, 35);
            this.txtTaxId.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "ชื่อ (อังกฤษ)";
            // 
            // txtCompanyNameE
            // 
            this.txtCompanyNameE.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCompanyNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyNameE.Location = new System.Drawing.Point(22, 109);
            this.txtCompanyNameE.Name = "txtCompanyNameE";
            this.txtCompanyNameE.Size = new System.Drawing.Size(360, 35);
            this.txtCompanyNameE.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "ชื่อ (ไทย)";
            // 
            // txtCompanyNameT
            // 
            this.txtCompanyNameT.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCompanyNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompanyNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyNameT.Location = new System.Drawing.Point(22, 49);
            this.txtCompanyNameT.Name = "txtCompanyNameT";
            this.txtCompanyNameT.Size = new System.Drawing.Size(360, 35);
            this.txtCompanyNameT.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1163, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ที่อยู่";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.txtLineContract);
            this.groupBox6.Controls.Add(this.label35);
            this.groupBox6.Controls.Add(this.txtLineID);
            this.groupBox6.Controls.Add(this.label36);
            this.groupBox6.Controls.Add(this.txtGPS);
            this.groupBox6.Controls.Add(this.label37);
            this.groupBox6.Controls.Add(this.txtPostCode);
            this.groupBox6.Controls.Add(this.label38);
            this.groupBox6.Controls.Add(this.cboProvince);
            this.groupBox6.Controls.Add(this.label39);
            this.groupBox6.Controls.Add(this.cboDistrict);
            this.groupBox6.Controls.Add(this.label40);
            this.groupBox6.Controls.Add(this.cboSubDistrict);
            this.groupBox6.Controls.Add(this.label41);
            this.groupBox6.Controls.Add(this.txtRoad);
            this.groupBox6.Controls.Add(this.label42);
            this.groupBox6.Controls.Add(this.txtSoi);
            this.groupBox6.Controls.Add(this.label43);
            this.groupBox6.Controls.Add(this.txtMoo);
            this.groupBox6.Controls.Add(this.label44);
            this.groupBox6.Controls.Add(this.txtHouseNo);
            this.groupBox6.Controls.Add(this.label45);
            this.groupBox6.Controls.Add(this.txtFlood);
            this.groupBox6.Controls.Add(this.label46);
            this.groupBox6.Controls.Add(this.txtRoomNo);
            this.groupBox6.Controls.Add(this.label47);
            this.groupBox6.Controls.Add(this.txtAddressDetail);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(15, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1130, 432);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ที่อยู่";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(35, 340);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(104, 20);
            this.label34.TabIndex = 32;
            this.label34.Text = "Line Contract";
            // 
            // txtLineContract
            // 
            this.txtLineContract.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLineContract.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLineContract.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineContract.Location = new System.Drawing.Point(22, 362);
            this.txtLineContract.Name = "txtLineContract";
            this.txtLineContract.Size = new System.Drawing.Size(360, 35);
            this.txtLineContract.TabIndex = 33;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(412, 280);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(133, 20);
            this.label35.TabIndex = 30;
            this.label35.Text = "Line ID / WebSite";
            // 
            // txtLineID
            // 
            this.txtLineID.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLineID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLineID.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineID.Location = new System.Drawing.Point(388, 302);
            this.txtLineID.Name = "txtLineID";
            this.txtLineID.Size = new System.Drawing.Size(360, 35);
            this.txtLineID.TabIndex = 31;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(35, 280);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(43, 20);
            this.label36.TabIndex = 28;
            this.label36.Text = "GPS";
            // 
            // txtGPS
            // 
            this.txtGPS.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtGPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPS.Location = new System.Drawing.Point(22, 302);
            this.txtGPS.Name = "txtGPS";
            this.txtGPS.Size = new System.Drawing.Size(360, 35);
            this.txtGPS.TabIndex = 29;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(412, 218);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(85, 20);
            this.label37.TabIndex = 27;
            this.label37.Text = "รหัสไปรษณีย์";
            // 
            // txtPostCode
            // 
            this.txtPostCode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtPostCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPostCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostCode.Location = new System.Drawing.Point(388, 241);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(360, 35);
            this.txtPostCode.TabIndex = 26;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Location = new System.Drawing.Point(35, 156);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(49, 20);
            this.label38.TabIndex = 25;
            this.label38.Text = "จังหวัด";
            // 
            // cboProvince
            // 
            this.cboProvince.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboProvince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProvince.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvince.FormattingEnabled = true;
            this.cboProvince.Location = new System.Drawing.Point(22, 178);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(360, 37);
            this.cboProvince.Sorted = true;
            this.cboProvince.TabIndex = 24;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.BackColor = System.Drawing.Color.Transparent;
            this.label39.Location = new System.Drawing.Point(412, 156);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(83, 20);
            this.label39.TabIndex = 23;
            this.label39.Text = "อำเภอ / เขต";
            // 
            // cboDistrict
            // 
            this.cboDistrict.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDistrict.FormattingEnabled = true;
            this.cboDistrict.Location = new System.Drawing.Point(388, 178);
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(360, 37);
            this.cboDistrict.TabIndex = 22;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.BackColor = System.Drawing.Color.Transparent;
            this.label40.Location = new System.Drawing.Point(35, 218);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(92, 20);
            this.label40.TabIndex = 21;
            this.label40.Text = "ตำบล  / แขวน";
            // 
            // cboSubDistrict
            // 
            this.cboSubDistrict.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboSubDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubDistrict.FormattingEnabled = true;
            this.cboSubDistrict.Location = new System.Drawing.Point(22, 240);
            this.cboSubDistrict.Name = "cboSubDistrict";
            this.cboSubDistrict.Size = new System.Drawing.Size(360, 37);
            this.cboSubDistrict.TabIndex = 20;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(565, 96);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(36, 20);
            this.label41.TabIndex = 19;
            this.label41.Text = "ถนน";
            // 
            // txtRoad
            // 
            this.txtRoad.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoad.Location = new System.Drawing.Point(546, 118);
            this.txtRoad.Name = "txtRoad";
            this.txtRoad.Size = new System.Drawing.Size(200, 35);
            this.txtRoad.TabIndex = 18;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(453, 96);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(34, 20);
            this.label42.TabIndex = 17;
            this.label42.Text = "ซอย";
            // 
            // txtSoi
            // 
            this.txtSoi.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtSoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoi.Location = new System.Drawing.Point(440, 118);
            this.txtSoi.Name = "txtSoi";
            this.txtSoi.Size = new System.Drawing.Size(100, 35);
            this.txtSoi.TabIndex = 16;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(345, 96);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(38, 20);
            this.label43.TabIndex = 15;
            this.label43.Text = "หมู่ที่";
            // 
            // txtMoo
            // 
            this.txtMoo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtMoo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoo.Location = new System.Drawing.Point(334, 118);
            this.txtMoo.Name = "txtMoo";
            this.txtMoo.Size = new System.Drawing.Size(100, 35);
            this.txtMoo.TabIndex = 14;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(241, 96);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(42, 20);
            this.label44.TabIndex = 13;
            this.label44.Text = "เลขที่";
            // 
            // txtHouseNo
            // 
            this.txtHouseNo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtHouseNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHouseNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHouseNo.Location = new System.Drawing.Point(228, 118);
            this.txtHouseNo.Name = "txtHouseNo";
            this.txtHouseNo.Size = new System.Drawing.Size(100, 35);
            this.txtHouseNo.TabIndex = 12;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(35, 96);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(27, 20);
            this.label45.TabIndex = 11;
            this.label45.Text = "ชั้น";
            // 
            // txtFlood
            // 
            this.txtFlood.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFlood.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFlood.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFlood.Location = new System.Drawing.Point(22, 118);
            this.txtFlood.Name = "txtFlood";
            this.txtFlood.Size = new System.Drawing.Size(200, 35);
            this.txtFlood.TabIndex = 10;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(405, 36);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(90, 20);
            this.label46.TabIndex = 8;
            this.label46.Text = "หมายเลขห้อง";
            // 
            // txtRoomNo
            // 
            this.txtRoomNo.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtRoomNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoomNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoomNo.Location = new System.Drawing.Point(388, 58);
            this.txtRoomNo.Name = "txtRoomNo";
            this.txtRoomNo.Size = new System.Drawing.Size(200, 35);
            this.txtRoomNo.TabIndex = 9;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(35, 36);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(129, 20);
            this.label47.TabIndex = 6;
            this.label47.Text = "ชื่อโครงการ / อาคาร";
            // 
            // txtAddressDetail
            // 
            this.txtAddressDetail.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtAddressDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddressDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressDetail.Location = new System.Drawing.Point(22, 58);
            this.txtAddressDetail.Name = "txtAddressDetail";
            this.txtAddressDetail.Size = new System.Drawing.Size(360, 35);
            this.txtAddressDetail.TabIndex = 7;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAdd.Location = new System.Drawing.Point(67, 778);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "บันทึก";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // CompanyControl
            // 
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CompanyControl";
            this.Size = new System.Drawing.Size(1381, 862);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        private void tabPage1_Click(object sender, EventArgs e) {
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrWhiteSpace(txtCompanyCode.Text)) {
                    MessageBox.Show("กรุณากรอกรหัสบริษัท", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCompanyNameT.Text)) {
                    MessageBox.Show("กรุณากรอกชื่อบริษัท (ไทย)", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!isEdit) {
                    currentCompanyId = Guid.NewGuid().ToString();
                    currentAddressId = Guid.NewGuid().ToString();
                }

                // ดึงชื่อตำบลจาก SubDistrictInfo
                string subDistrictName = "";
                if (cboSubDistrict.SelectedItem is ThaiAddressData.SubDistrictInfo subInfo) {
                    subDistrictName = subInfo.Name;
                } else {
                    subDistrictName = cboSubDistrict.Text?.Trim();
                }

                var newAddress = new address {
                    AddressID = currentAddressId,
                    AddressDetail = txtAddressDetail.Text?.Trim(),
                    RoomNo = txtRoomNo.Text?.Trim(),
                    Flood = txtFlood.Text?.Trim(),
                    HouseNo = txtHouseNo.Text?.Trim(),
                    Moo = txtMoo.Text?.Trim(),
                    Soi = txtSoi.Text?.Trim(),
                    Road = txtRoad.Text?.Trim(),
                    SubDistrict = subDistrictName,
                    District = cboDistrict.Text?.Trim(),
                    Province = cboProvince.Text?.Trim(),
                    PostCode = txtPostCode.Text?.Trim(),
                    GPS = txtGPS.Text?.Trim(),
                    LineID = txtLineID.Text?.Trim(),
                    LineContract = txtLineContract.Text?.Trim(),
                    Lang = cboLang.Text?.Trim(),
                    Phone = txtTel.Text?.Trim(),
                    Mobile = txtMobile.Text?.Trim(),
                    PhoneTo = txtTelTo.Text?.Trim(),
                    Fax = txtFax.Text?.Trim(),
                    RefCode = txtRef.Text?.Trim(),
                    CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    CreateBy = "System",
                    UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateBy = "System"
                };

                var newCompany = new companys {
                    CompanyID = currentCompanyId,
                    CompanyCode = txtCompanyCode.Text?.Trim(),
                    CompanyName = txtCompanyNameT.Text?.Trim(),
                    AddressID = currentAddressId,
                    CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    CreateBy = "System",
                    UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateBy = "System"
                };

                address.AddressMgr_Wait(ref newAddress, isEdit ? "EDIT" : "ADD");
                companys.CompanysMgr_Wait(ref newCompany, isEdit ? "EDIT" : "ADD");

                // อัปเดต DataTable cache ของ formMain
                if (formMain != null) {
                    try {
                        // ADD: เพิ่มแถวใหม่
                        if (!isEdit) {
                            // เพิ่ม address
                            if (formMain.AddressTable != null) {
                                var addrTable = formMain.AddressTable;
                                var arow = addrTable.NewRow();
                                if (addrTable.Columns.Contains("AddressID"))
                                    arow["AddressID"] = newAddress.AddressID ?? "";
                                if (addrTable.Columns.Contains("AddressDetail"))
                                    arow["AddressDetail"] = newAddress.AddressDetail ?? "";
                                if (addrTable.Columns.Contains("RoomNo"))
                                    arow["RoomNo"] = newAddress.RoomNo ?? "";
                                if (addrTable.Columns.Contains("Flood"))
                                    arow["Flood"] = newAddress.Flood ?? "";
                                if (addrTable.Columns.Contains("HouseNo"))
                                    arow["HouseNo"] = newAddress.HouseNo ?? "";
                                if (addrTable.Columns.Contains("Moo"))
                                    arow["Moo"] = newAddress.Moo ?? "";
                                if (addrTable.Columns.Contains("Soi"))
                                    arow["Soi"] = newAddress.Soi ?? "";
                                if (addrTable.Columns.Contains("Road"))
                                    arow["Road"] = newAddress.Road ?? "";
                                if (addrTable.Columns.Contains("SubDistrict"))
                                    arow["SubDistrict"] = newAddress.SubDistrict ?? "";
                                if (addrTable.Columns.Contains("District"))
                                    arow["District"] = newAddress.District ?? "";
                                if (addrTable.Columns.Contains("Province"))
                                    arow["Province"] = newAddress.Province ?? "";
                                if (addrTable.Columns.Contains("PostCode"))
                                    arow["PostCode"] = newAddress.PostCode ?? "";
                                if (addrTable.Columns.Contains("GPS"))
                                    arow["GPS"] = newAddress.GPS ?? "";
                                if (addrTable.Columns.Contains("LineID"))
                                    arow["LineID"] = newAddress.LineID ?? "";
                                if (addrTable.Columns.Contains("LineContract"))
                                    arow["LineContract"] = newAddress.LineContract ?? "";
                                if (addrTable.Columns.Contains("Lang"))
                                    arow["Lang"] = newAddress.Lang ?? "";
                                if (addrTable.Columns.Contains("Phone"))
                                    arow["Phone"] = newAddress.Phone ?? "";
                                if (addrTable.Columns.Contains("Mobile"))
                                    arow["Mobile"] = newAddress.Mobile ?? "";
                                if (addrTable.Columns.Contains("PhoneTo"))
                                    arow["PhoneTo"] = newAddress.PhoneTo ?? "";
                                if (addrTable.Columns.Contains("Fax"))
                                    arow["Fax"] = newAddress.Fax ?? "";
                                if (addrTable.Columns.Contains("RefCode"))
                                    arow["RefCode"] = newAddress.RefCode ?? "";
                                if (addrTable.Columns.Contains("CreateTime"))
                                    arow["CreateTime"] = newAddress.CreateTime ?? "";
                                if (addrTable.Columns.Contains("CreateBy"))
                                    arow["CreateBy"] = newAddress.CreateBy ?? "";
                                if (addrTable.Columns.Contains("UpdateTime"))
                                    arow["UpdateTime"] = newAddress.UpdateTime ?? "";
                                if (addrTable.Columns.Contains("UpdateBy"))
                                    arow["UpdateBy"] = newAddress.UpdateBy ?? "";
                                addrTable.Rows.Add(arow);
                            }

                            // เพิ่ม company
                            if (formMain.CompanysTable != null) {
                                var compTable = formMain.CompanysTable;
                                var crow = compTable.NewRow();
                                if (compTable.Columns.Contains("CompanyID"))
                                    crow["CompanyID"] = newCompany.CompanyID ?? "";
                                if (compTable.Columns.Contains("CompanyCode"))
                                    crow["CompanyCode"] = newCompany.CompanyCode ?? "";
                                if (compTable.Columns.Contains("CompanyName"))
                                    crow["CompanyName"] = newCompany.CompanyName ?? "";
                                if (compTable.Columns.Contains("AddressID"))
                                    crow["AddressID"] = newCompany.AddressID ?? "";
                                if (compTable.Columns.Contains("CreateTime"))
                                    crow["CreateTime"] = newCompany.CreateTime ?? "";
                                if (compTable.Columns.Contains("CreateBy"))
                                    crow["CreateBy"] = newCompany.CreateBy ?? "";
                                if (compTable.Columns.Contains("UpdateTime"))
                                    crow["UpdateTime"] = newCompany.UpdateTime ?? "";
                                if (compTable.Columns.Contains("UpdateBy"))
                                    crow["UpdateBy"] = newCompany.UpdateBy ?? "";
                                compTable.Rows.Add(crow);
                            }
                        } else {
                            // EDIT: อัปเดตรายการที่มีอยู่
                            // อัปเดต address
                            if (formMain.AddressTable != null && !string.IsNullOrEmpty(currentAddressId)) {
                                try {
                                    DataRow[] arows = formMain.AddressTable.Select("AddressID = '" + currentAddressId.Replace("'", "''") + "'");
                                    if (arows.Length > 0) {
                                        var arow = arows[0];
                                        if (arow.Table.Columns.Contains("AddressDetail"))
                                            arow["AddressDetail"] = newAddress.AddressDetail ?? "";
                                        if (arow.Table.Columns.Contains("RoomNo"))
                                            arow["RoomNo"] = newAddress.RoomNo ?? "";
                                        if (arow.Table.Columns.Contains("Flood"))
                                            arow["Flood"] = newAddress.Flood ?? "";
                                        if (arow.Table.Columns.Contains("HouseNo"))
                                            arow["HouseNo"] = newAddress.HouseNo ?? "";
                                        if (arow.Table.Columns.Contains("Moo"))
                                            arow["Moo"] = newAddress.Moo ?? "";
                                        if (arow.Table.Columns.Contains("Soi"))
                                            arow["Soi"] = newAddress.Soi ?? "";
                                        if (arow.Table.Columns.Contains("Road"))
                                            arow["Road"] = newAddress.Road ?? "";
                                        if (arow.Table.Columns.Contains("SubDistrict"))
                                            arow["SubDistrict"] = newAddress.SubDistrict ?? "";
                                        if (arow.Table.Columns.Contains("District"))
                                            arow["District"] = newAddress.District ?? "";
                                        if (arow.Table.Columns.Contains("Province"))
                                            arow["Province"] = newAddress.Province ?? "";
                                        if (arow.Table.Columns.Contains("PostCode"))
                                            arow["PostCode"] = newAddress.PostCode ?? "";
                                        if (arow.Table.Columns.Contains("GPS"))
                                            arow["GPS"] = newAddress.GPS ?? "";
                                        if (arow.Table.Columns.Contains("LineID"))
                                            arow["LineID"] = newAddress.LineID ?? "";
                                        if (arow.Table.Columns.Contains("LineContract"))
                                            arow["LineContract"] = newAddress.LineContract ?? "";
                                        if (arow.Table.Columns.Contains("Lang"))
                                            arow["Lang"] = newAddress.Lang ?? "";
                                        if (arow.Table.Columns.Contains("Phone"))
                                            arow["Phone"] = newAddress.Phone ?? "";
                                        if (arow.Table.Columns.Contains("Mobile"))
                                            arow["Mobile"] = newAddress.Mobile ?? "";
                                        if (arow.Table.Columns.Contains("PhoneTo"))
                                            arow["PhoneTo"] = newAddress.PhoneTo ?? "";
                                        if (arow.Table.Columns.Contains("Fax"))
                                            arow["Fax"] = newAddress.Fax ?? "";
                                        if (arow.Table.Columns.Contains("RefCode"))
                                            arow["RefCode"] = newAddress.RefCode ?? "";
                                        if (arow.Table.Columns.Contains("UpdateTime"))
                                            arow["UpdateTime"] = newAddress.UpdateTime ?? "";
                                        if (arow.Table.Columns.Contains("UpdateBy"))
                                            arow["UpdateBy"] = newAddress.UpdateBy ?? "";
                                    }
                                } catch (Exception ex) {
                                    System.Diagnostics.Debug.WriteLine($"Error updating AddressTable: {ex.Message}");
                                }
                            }

                            // อัปเดต company
                            if (formMain.CompanysTable != null && !string.IsNullOrEmpty(currentCompanyId)) {
                                try {
                                    DataRow[] crows = formMain.CompanysTable.Select("CompanyID = '" + currentCompanyId.Replace("'", "''") + "'");
                                    if (crows.Length > 0) {
                                        var crow = crows[0];
                                        if (crow.Table.Columns.Contains("CompanyCode"))
                                            crow["CompanyCode"] = newCompany.CompanyCode ?? "";
                                        if (crow.Table.Columns.Contains("CompanyName"))
                                            crow["CompanyName"] = newCompany.CompanyName ?? "";
                                        if (crow.Table.Columns.Contains("AddressID"))
                                            crow["AddressID"] = newCompany.AddressID ?? "";
                                        if (crow.Table.Columns.Contains("UpdateTime"))
                                            crow["UpdateTime"] = newCompany.UpdateTime ?? "";
                                        if (crow.Table.Columns.Contains("UpdateBy"))
                                            crow["UpdateBy"] = newCompany.UpdateBy ?? "";
                                    }
                                } catch (Exception ex) {
                                    System.Diagnostics.Debug.WriteLine($"Error updating CompanysTable: {ex.Message}");
                                }
                            }
                        }
                    } catch (Exception ex) {
                        System.Diagnostics.Debug.WriteLine($"Error updating DataTables: {ex.Message}");
                    }
                }

                MessageBox.Show("บันทึกข้อมูลบริษัทเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                isEdit = false;
                currentCompanyId = null;
                currentAddressId = null;
                companyList.LoadCompanyList();
                formMain.ShowView(companyList);

            } catch (Exception ex) {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm() {
            txtCompanyCode.Clear();
            txtCompanyNameT.Clear();
            txtCompanyNameE.Clear();
            txtTaxId.Clear();
            txtFindName1.Clear();
            txtFindName2.Clear();

            cboLang.SelectedIndex = -1;
            txtEmail.Clear();
            txtMobile.Clear();
            txtTel.Clear();
            txtFax.Clear();
            txtTelTo.Clear();
            txtRef.Clear();

            txtAddressDetail.Clear();
            txtRoomNo.Clear();
            txtFlood.Clear();
            txtHouseNo.Clear();
            txtMoo.Clear();
            txtSoi.Clear();
            txtRoad.Clear();
            cboSubDistrict.SelectedIndex = -1;
            cboDistrict.SelectedIndex = -1;
            cboProvince.SelectedIndex = -1;
            txtPostCode.Clear();
            txtGPS.Clear();
            txtLineID.Clear();
            txtLineContract.Clear();
        }

    }
}
