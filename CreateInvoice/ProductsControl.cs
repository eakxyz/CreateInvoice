using System.Drawing;
using System.Windows.Forms;

namespace CreateInvoice {
    public class ProductsControl : UserControl {

        public ProductsControl() {
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
        }

        private void InitializeComponent() {
            this.SuspendLayout();
            // 
            // ProductsControl
            // 
            this.Name = "ProductsControl";
            this.Size = new System.Drawing.Size(1422, 1008);
            this.ResumeLayout(false);

        }
    }
}
