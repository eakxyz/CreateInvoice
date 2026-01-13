using System;
using System.Drawing;
using System.Windows.Forms;
using BotCommon;

namespace CreateInvoice {
    public class CustomersControl : UserControl {
        private Label label2;
        private ComboBox comboBox1;
        private Label label1;
        private TextBox txtCustomerCode;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button btnAddCustomerGroup;
        private GroupBox groupBox2;
        private Label label7;
        private ComboBox cboCustomerGroup;
        private Label label6;
        private TextBox txtLNameE;
        private Label label5;
        private TextBox txtFNameE;
        private Label label4;
        private TextBox txtLNameT;
        private Label label3;
        private TextBox txtFNameT;
        private GroupBox groupBox3;
        private Label label15;
        private TextBox txtFindName2;
        private Label label16;
        private TextBox txtFindName1;
        private Label label10;
        private TextBox txtShortNameE;
        private Label label9;
        private TextBox txtShortNameT;
        private RadioButton rdoFamale;
        private RadioButton rdoMale;
        private Label label8;
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
        private TextBox txtIdentityCard;
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

        public CustomersControl() {
            //Dock = DockStyle.Fill;
            BackColor = Color.White;
            var lbl = new Label {
                Text = "ลูกค้า",
                Dock = DockStyle.Top,
                Height = 40,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };
            Controls.Add(lbl);
            InitializeComponent();
            
            // เชื่อมต่อ event handler กับปุ่มเพิ่ม
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        }

        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddCustomerGroup = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
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
            this.label10 = new System.Windows.Forms.Label();
            this.txtShortNameE = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtShortNameT = new System.Windows.Forms.TextBox();
            this.rdoFamale = new System.Windows.Forms.RadioButton();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboCustomerGroup = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLNameE = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFNameE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLNameT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFNameT = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAdd = new System.Windows.Forms.Button();
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
            this.label11 = new System.Windows.Forms.Label();
            this.txtIdentityCard = new System.Windows.Forms.TextBox();
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
            this.groupBox1.Controls.Add(this.btnAddCustomerGroup);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCustomerCode);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(63, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1271, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "รหัส / กลุ่มบัญชีลูกค้า";
            // 
            // btnAddCustomerGroup
            // 
            this.btnAddCustomerGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCustomerGroup.Location = new System.Drawing.Point(773, 59);
            this.btnAddCustomerGroup.Name = "btnAddCustomerGroup";
            this.btnAddCustomerGroup.Size = new System.Drawing.Size(39, 39);
            this.btnAddCustomerGroup.TabIndex = 4;
            this.btnAddCustomerGroup.Text = "+";
            this.btnAddCustomerGroup.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(424, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "กลุ่มบัญชีลูกค้า";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(407, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(360, 37);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสลูกค้าทางธุรกิจ";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtCustomerCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerCode.Location = new System.Drawing.Point(41, 60);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(360, 35);
            this.txtCustomerCode.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(63, 171);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1555, 741);
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
            this.tabPage1.Size = new System.Drawing.Size(1547, 706);
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
            this.groupBox5.Location = new System.Drawing.Point(15, 435);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1514, 242);
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
            this.groupBox3.Location = new System.Drawing.Point(15, 315);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1514, 114);
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
            this.groupBox2.Controls.Add(this.txtIdentityCard);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtShortNameE);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtShortNameT);
            this.groupBox2.Controls.Add(this.rdoFamale);
            this.groupBox2.Controls.Add(this.rdoMale);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboCustomerGroup);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtLNameE);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtFNameE);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtLNameT);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtFNameT);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1514, 292);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลส่วนตัว";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(768, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "ชื่อเล่น (อังกฤษ)";
            // 
            // txtShortNameE
            // 
            this.txtShortNameE.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtShortNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortNameE.Location = new System.Drawing.Point(754, 175);
            this.txtShortNameE.Name = "txtShortNameE";
            this.txtShortNameE.Size = new System.Drawing.Size(360, 35);
            this.txtShortNameE.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(768, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "ชื่อเล่น (ไทย)";
            // 
            // txtShortNameT
            // 
            this.txtShortNameT.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtShortNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtShortNameT.Location = new System.Drawing.Point(754, 115);
            this.txtShortNameT.Name = "txtShortNameT";
            this.txtShortNameT.Size = new System.Drawing.Size(360, 35);
            this.txtShortNameT.TabIndex = 16;
            // 
            // rdoFamale
            // 
            this.rdoFamale.AutoSize = true;
            this.rdoFamale.Location = new System.Drawing.Point(495, 61);
            this.rdoFamale.Name = "rdoFamale";
            this.rdoFamale.Size = new System.Drawing.Size(55, 24);
            this.rdoFamale.TabIndex = 14;
            this.rdoFamale.TabStop = true;
            this.rdoFamale.Text = "หญิง";
            this.rdoFamale.UseVisualStyleBackColor = true;
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Location = new System.Drawing.Point(438, 61);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(51, 24);
            this.rdoMale.TabIndex = 13;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "ชาย";
            this.rdoMale.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(439, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "เพศ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(34, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "กลุ่มบัญชีลูกค้า";
            // 
            // cboCustomerGroup
            // 
            this.cboCustomerGroup.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboCustomerGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCustomerGroup.FormattingEnabled = true;
            this.cboCustomerGroup.Location = new System.Drawing.Point(22, 53);
            this.cboCustomerGroup.Name = "cboCustomerGroup";
            this.cboCustomerGroup.Size = new System.Drawing.Size(360, 37);
            this.cboCustomerGroup.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "นามสกุล (อังกฤษ)";
            // 
            // txtLNameE
            // 
            this.txtLNameE.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLNameE.Location = new System.Drawing.Point(388, 175);
            this.txtLNameE.Name = "txtLNameE";
            this.txtLNameE.Size = new System.Drawing.Size(360, 35);
            this.txtLNameE.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "ชื่อ (อังกฤษ)";
            // 
            // txtFNameE
            // 
            this.txtFNameE.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFNameE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFNameE.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFNameE.Location = new System.Drawing.Point(22, 175);
            this.txtFNameE.Name = "txtFNameE";
            this.txtFNameE.Size = new System.Drawing.Size(360, 35);
            this.txtFNameE.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(396, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "นามสกุล (ไทย)";
            // 
            // txtLNameT
            // 
            this.txtLNameT.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtLNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLNameT.Location = new System.Drawing.Point(388, 115);
            this.txtLNameT.Name = "txtLNameT";
            this.txtLNameT.Size = new System.Drawing.Size(360, 35);
            this.txtLNameT.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "ชื่อ (ไทย)";
            // 
            // txtFNameT
            // 
            this.txtFNameT.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtFNameT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFNameT.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFNameT.Location = new System.Drawing.Point(22, 115);
            this.txtFNameT.Name = "txtFNameT";
            this.txtFNameT.Size = new System.Drawing.Size(360, 35);
            this.txtFNameT.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1547, 706);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ที่อยู่";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(67, 918);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 35);
            this.btnAdd.TabIndex = 21;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
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
            this.groupBox6.Size = new System.Drawing.Size(1514, 304);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ที่อยู่";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(773, 218);
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
            this.txtLineContract.Location = new System.Drawing.Point(754, 240);
            this.txtLineContract.Name = "txtLineContract";
            this.txtLineContract.Size = new System.Drawing.Size(360, 35);
            this.txtLineContract.TabIndex = 33;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(412, 218);
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
            this.txtLineID.Location = new System.Drawing.Point(388, 240);
            this.txtLineID.Name = "txtLineID";
            this.txtLineID.Size = new System.Drawing.Size(360, 35);
            this.txtLineID.TabIndex = 31;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(35, 218);
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
            this.txtGPS.Location = new System.Drawing.Point(22, 240);
            this.txtGPS.Name = "txtGPS";
            this.txtGPS.Size = new System.Drawing.Size(360, 35);
            this.txtGPS.TabIndex = 29;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(1236, 203);
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
            this.txtPostCode.Location = new System.Drawing.Point(1230, 228);
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(229, 35);
            this.txtPostCode.TabIndex = 26;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.BackColor = System.Drawing.Color.Transparent;
            this.label38.Location = new System.Drawing.Point(773, 156);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(49, 20);
            this.label38.TabIndex = 25;
            this.label38.Text = "จังหวัด";
            // 
            // cboProvince
            // 
            this.cboProvince.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboProvince.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboProvince.FormattingEnabled = true;
            this.cboProvince.Location = new System.Drawing.Point(754, 178);
            this.cboProvince.Name = "cboProvince";
            this.cboProvince.Size = new System.Drawing.Size(360, 37);
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
            this.label40.Location = new System.Drawing.Point(35, 156);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(92, 20);
            this.label40.TabIndex = 21;
            this.label40.Text = "ตำบล  / แขวน";
            // 
            // cboSubDistrict
            // 
            this.cboSubDistrict.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.cboSubDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSubDistrict.FormattingEnabled = true;
            this.cboSubDistrict.Location = new System.Drawing.Point(22, 178);
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
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(34, 213);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "เลขที่บัตรประชาชน";
            // 
            // txtIdentityCard
            // 
            this.txtIdentityCard.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtIdentityCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdentityCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentityCard.Location = new System.Drawing.Point(22, 235);
            this.txtIdentityCard.Name = "txtIdentityCard";
            this.txtIdentityCard.Size = new System.Drawing.Size(360, 35);
            this.txtIdentityCard.TabIndex = 20;
            // 
            // CustomersControl
            // 
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "CustomersControl";
            this.Size = new System.Drawing.Size(1722, 1221);
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

        private void tabPage1_Click(object sender, System.EventArgs e) {

        }

        private void btnAdd_Click(object sender, EventArgs e) {
            try {
                // ตรวจสอบข้อมูลที่จำเป็น
                if (string.IsNullOrWhiteSpace(txtCustomerCode.Text)) {
                    MessageBox.Show("กรุณากรอกรหัสลูกค้า", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtFNameT.Text)) {
                    MessageBox.Show("กรุณากรอกชื่อ (ไทย)", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // สร้าง AddressID และ CustomerID
                string addressID = Guid.NewGuid().ToString();
                string customerID = Guid.NewGuid().ToString();

                // สร้าง object address และเก็บข้อมูล
                address newAddress = new address {
                    AddressID = addressID,
                    AddressDetail = txtAddressDetail.Text?.Trim(),
                    RoomNo = txtRoomNo.Text?.Trim(),
                    Flood = txtFlood.Text?.Trim(),
                    HouseNo = txtHouseNo.Text?.Trim(),
                    Moo = txtMoo.Text?.Trim(),
                    Soi = txtSoi.Text?.Trim(),
                    Road = txtRoad.Text?.Trim(),
                    SubDistrict = cboSubDistrict.Text?.Trim(),
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
                    CreateBy = "System", // แก้ไขตามระบบ authentication ของคุณ
                    UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateBy = "System"
                };

                // สร้าง object customers และเก็บข้อมูล
                customers newCustomer = new customers {
                    CustomerID = customerID,
                    CustomerCode = txtCustomerCode.Text?.Trim(),
                    FNameT = txtFNameT.Text?.Trim(),
                    LNameT = txtLNameT.Text?.Trim(),
                    FNameE = txtFNameE.Text?.Trim(),
                    LNameE = txtLNameE.Text?.Trim(),
                    ShortNameT = txtShortNameT.Text?.Trim(),
                    ShortNameE = txtShortNameE.Text?.Trim(),
                    Sex = rdoMale.Checked ? "ชาย" : (rdoFamale.Checked ? "หญิง" : ""),
                    FindName1 = txtFindName1.Text?.Trim(),
                    FindName2 = txtFindName2.Text?.Trim(),
                    IdentityCard = txtIdentityCard.Text?.Trim(),
                    Email = txtEmail.Text?.Trim(),
                    AddressID = addressID,
                    CustomerGroupID = cboCustomerGroup.SelectedValue?.ToString(),
                    CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    CreateBy = "System",
                    UpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    UpdateBy = "System"
                };

                // สร้างชื่อเต็มสำหรับ CustomerName
                newCustomer.CustomerName = $"{newCustomer.FNameT} {newCustomer.LNameT}".Trim();

                // บันทึกข้อมูลที่อยู่
                address.AddressMgr_Wait(ref newAddress, "ADD");

                // บันทึกข้อมูลลูกค้า
                customers.CustomersMgr_Wait(ref newCustomer, "ADD");

                MessageBox.Show("บันทึกข้อมูลลูกค้าเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ล้างข้อมูลในฟอร์ม
                ClearForm();

            } catch (Exception ex) {
                MessageBox.Show($"เกิดข้อผิดพลาด: {ex.Message}", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm() {
            // ล้างข้อมูลส่วนรหัสลูกค้า
            txtCustomerCode.Clear();
            comboBox1.SelectedIndex = -1;

            // ล้างข้อมูลส่วนตัว
            cboCustomerGroup.SelectedIndex = -1;
            txtFNameT.Clear();
            txtLNameT.Clear();
            txtFNameE.Clear();
            txtLNameE.Clear();
            txtShortNameT.Clear();
            txtShortNameE.Clear();
            rdoMale.Checked = false;
            rdoFamale.Checked = false;
            txtIdentityCard.Clear();

            // ล้างคำค้นหา
            txtFindName1.Clear();
            txtFindName2.Clear();

            // ล้างข้อมูลการติดต่อ
            cboLang.SelectedIndex = -1;
            txtEmail.Clear();
            txtMobile.Clear();
            txtTel.Clear();
            txtFax.Clear();
            txtTelTo.Clear();
            txtRef.Clear();

            // ล้างข้อมูลที่อยู่
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
