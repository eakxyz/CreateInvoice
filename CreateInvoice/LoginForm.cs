using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CreateInvoice {
    public partial class LoginForm : Form {
        public string Username => txtUsername.Text.Trim();
        public string Password => txtPassword.Text;

        public LoginForm() {
            InitializeComponent();
            ApplyRoundedButtons();
        }

        private void ApplyRoundedButtons() {
            MakeRoundedButton(btnLogin, 8);
            MakeRoundedButton(btnCancel, 8);
        }

        public void MakeRoundedButton(Button btn, int radius) {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;

            GraphicsPath path = GetRoundedRectanglePath(btn.ClientRectangle, radius);
            btn.Region = new Region(path);

            btn.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(btn.BackColor)) {
                    e.Graphics.FillPath(brush, GetRoundedRectanglePath(btn.ClientRectangle, radius));
                }
                TextRenderer.DrawText(e.Graphics, btn.Text, btn.Font, btn.ClientRectangle, btn.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
        }

        public GraphicsPath GetRoundedRectanglePath(Rectangle rect, int radius) {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void BtnLogin_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(Username)) {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(Password)) {
                MessageBox.Show("กรุณากรอกรหัสผ่าน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void panelCard_Paint(object sender, PaintEventArgs e) {
            using (var pen = new Pen(Color.FromArgb(220, 220, 220))) {
                e.Graphics.DrawRectangle(pen, 0, 0, panelCard.Width - 1, panelCard.Height - 1);
            }
        }
    }
}
