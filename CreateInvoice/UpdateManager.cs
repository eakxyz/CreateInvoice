using BotCommon;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CreateInvoice {
    public static class UpdateManager {
        // Path to save installer
        private static string GetInstallerPath(string fileName) {
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            return Path.Combine(userProfile, fileName);
        }

        // Check version info from Firebase via BotCommon.EnvParameter and perform update
        public static bool CheckAndUpdateFromFirebase(bool showThanksIfLatest = false, bool returnVersionOnly = false) {
            try {
                // Fetch env parameters from Firebase
                EnvParameter env = new EnvParameter();
                EnvParameter.EnvParameterMgr_Wait(ref env);

                var currentVersion = Assembly.GetExecutingAssembly().GetName().Version?.ToString();
                var latestVersion = env?.Version;

                if (string.IsNullOrEmpty(latestVersion)) {
                    if (showThanksIfLatest) {
                        MessageBox.Show("ไม่พบข้อมูลเวอร์ชันจากเซิร์ฟเวอร์", "อัปเดตโปรแกรม", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return false;
                }

                bool isUpdate = !string.Equals(latestVersion, currentVersion, StringComparison.OrdinalIgnoreCase) || returnVersionOnly;
                if (isUpdate) {
                    string link = env.LinkDownload;
                    if (string.IsNullOrWhiteSpace(link)) {
                        MessageBox.Show("ไม่พบลิงก์ดาวน์โหลดสำหรับเวอร์ชันใหม่", "อัปเดตโปรแกรม", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    string pathDownload = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                    string installerPath = pathDownload + @"\CreateInvoiceSetup.msi";

                    // Delete old installer
                    try {
                        if (File.Exists(installerPath))
                            File.Delete(installerPath);
                    } catch { }

                    // Show message like BotMakeMoney
                    string detail = env.Detail ?? string.Empty;
                    string msgVersion = "โปรแกรมมีการ Update Version ใหม่\n\n ******รายละเอียด****** \n" + detail;
                    MessageBox.Show(msgVersion, "ตรวจสอบ Version ล่าสุดคือ " + latestVersion, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Show download status form while downloading
                    if (!ShowDownloadForm(link, installerPath)) {
                        MessageBox.Show("ดาวน์โหลดตัวติดตั้งไม่สำเร็จ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    // Run installer via msiexec or direct exe
                    RunInstaller(installerPath);
                    Application.Exit();
                    return true;
                } else {
                    if (showThanksIfLatest) {
                        MessageBox.Show("โปรแกรม CreateInvoice เป็นเวอร์ชันล่าสุดแล้ว", "ตรวจสอบ Version ล่าสุด", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return false;
                }
            } catch (Exception ex) {
                MessageBox.Show("ตรวจสอบอัปเดตผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Show FormDownload and block until it closes; return true if file exists afterward
        private static bool ShowDownloadForm(string url, string path) {
            using (var frm = new FormDownload(url, path, "newinstall")) {
                frm.ShowDialog();
            }
            return File.Exists(path);
        }

        private static void RunInstaller(string installerPath) {
            try {
                string ext = Path.GetExtension(installerPath)?.ToLowerInvariant();
                if (ext == ".msi") {
                    // Use msiexec for MSI
                    Process.Start(new ProcessStartInfo {
                        FileName = "msiexec",
                        Arguments = $"/i \"{installerPath}\" /passive",
                        UseShellExecute = false
                    });
                } else {
                    // EXE installer
                    Process.Start(new ProcessStartInfo {
                        FileName = installerPath,
                        UseShellExecute = true
                    });
                }
            } catch (Exception ex) {
                MessageBox.Show("ไม่สามารถเริ่มการติดตั้ง: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
