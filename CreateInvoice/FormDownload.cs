using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace CreateInvoice {
    public partial class FormDownload : Form {
        FormMain formMain = null;
        string url = "";
        string pathInstall = "";
        double percentage = 0;
        string mode = "";

        // ใช้ตอนเรียกจาก UpdateManager (ไม่มี FormMain)
        public FormDownload(string pUrl, string pPathFile, string pMode) {
            url = pUrl;
            pathInstall = pPathFile;
            mode = pMode;
            InitializeComponent();
        }

        // ใช้ตอนเรียกจาก FormMain ถ้าต้องการส่ง FormMain มาด้วย
        public FormDownload(string pUrl, string pPathFile, FormMain pFormMain, string pMode) {
            url = pUrl;
            pathInstall = pPathFile;
            formMain = pFormMain;
            mode = pMode;
            InitializeComponent();
        }

        // สำหรับ Designer เท่านั้น
        public FormDownload() {
            InitializeComponent();
        }

        // ใน Load ให้กันโหมดออกแบบ (กัน Designer ล้ม)
        private void FormDownload_Load(object sender, EventArgs e) {
            if (DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            try {
                this.loadFileUpdate();
            } catch (Exception ex) {
                if (formMain == null) {
                    MessageBox.Show("Update error: " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //this.loadFileUpdate();
                DialogResult dr = MessageBox.Show("การ Update มีปัญหาต้องการ Update อีกครั้งหรือไม่", "ยืนยัน", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if (dr == DialogResult.Yes) {
                    this.loadFileUpdate();
                } else {
                    this.BeginInvoke((MethodInvoker)(() => {
                        formMain.WindowState = FormWindowState.Normal;
                        formMain.ShowInTaskbar = true;
                        formMain.Show();
                        this.Hide();
                    }));

                }
            }
        }

        public void loadFileUpdate() {
            if (File.Exists(pathInstall))
                File.Delete(pathInstall);
            using (WebClient wb = new WebClient()) {
                wb.DownloadProgressChanged += new DownloadProgressChangedEventHandler(client_DownloadProgressChanged);
                wb.DownloadFileCompleted += new AsyncCompletedEventHandler(client_DownloadFileCompleted);
                if (!string.IsNullOrEmpty(url)) {
                    wb.DownloadFileAsync(new Uri(url), pathInstall);
                }

            }
        }
        void client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            try {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                percentage = (bytesIn / 5000) * 100;
                if (percentage > 100)
                    percentage = 100;
                lblStatus.Text = "Downloaded " + percentage.ToString("N0") + " %";
                progressBar1.Value = Convert.ToInt32(percentage);
            } catch (Exception ex) {
                if (formMain != null)
                    MessageBox.Show(formMain, ex.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message, "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) {
            if (File.Exists(pathInstall)) {
                byte[] array = File.ReadAllBytes(pathInstall);
                if (2000 < array.Length) {
                    //ProcessStartInfo startArgs = new ProcessStartInfo();
                    //Process.Start(new ProcessStartInfo() {
                    //    FileName = pathInstall,
                    //    UseShellExecute = true
                    //});

                    Process p = new Process();
                    p.StartInfo.FileName = "msiexec";
                    if (mode == "reinstall") {
                        p.StartInfo.Arguments = $" /fav \"{pathInstall}\"";
                    } else {
                        p.StartInfo.Arguments = $" /i \"{pathInstall}\"";
                    }
                    p.Start();

                    //startArgs.FileName = pathInstall;
                    //startArgs.UseShellExecute = true;
                    //startArgs.Verb = "runas";
                    //startArgs.Arguments = null;

                    // Process process = new Process();
                    //process.StartInfo = startArgs;
                    //process.Start();

                    //Process startedProcess = CheckIfProcessStarted(process);
                    Application.Exit();
                } else {
                    this.Close();
                    FormDownload download = new FormDownload(url, pathInstall, formMain, mode);
                    download.Show();
                    //DialogResult dr = MessageBox.Show("การ Update มีปัญหาต้องการ Update อีกครั้งหรือไม่", "ยืนยัน", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                    //if (dr == DialogResult.Yes) {
                    //    progressBar1.Value = 0;
                    //    this.loadFileUpdate();
                    //} else {
                    //    this.BeginInvoke((MethodInvoker)(() => {
                    //        formMain.WindowState = FormWindowState.Normal;
                    //        formMain.ShowInTaskbar = true;
                    //        formMain.Show();
                    //        this.Hide();
                    //    }));

                    //}

                }
            }



            //if (totalBytes ) {
            //    lblStatus.Text = "Completed!";
            //    if (File.Exists(pathInstall)) {

            //    }
            //} else {
            //    if (File.Exists(pathInstall))
            //        File.Delete(pathInstall);
            //    this.loadFileUpdate();
            //}

        }
        private Process CheckIfProcessStarted(Process process) {
            return Process.GetProcessById(process.Id);
        }
    }
}
