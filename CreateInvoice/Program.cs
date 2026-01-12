using BotCommon;
using System;
using System.Windows.Forms;

namespace CreateInvoice {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize Firebase before update check
            try {

                //AuthSecret = "Y6o5IkvpUtaiS6m51mNa4VWXdh16Uf8ZB9K3DZDI",
                //BasePath = "https://invoice-22921-default-rtdb.firebaseio.com"
                // TODO: fill your Firebase base path and secret, or load from config
                ConstantCommon.Initial("https://invoice-22921-default-rtdb.firebaseio.com"
                                     , "Y6o5IkvpUtaiS6m51mNa4VWXdh16Uf8ZB9K3DZDI");
            } catch { }

            //using (var login = new LoginForm()) {
            //    if (login.ShowDialog() == DialogResult.OK) {
            //        // Check version from Firebase and update if needed
            UpdateManager.CheckAndUpdateFromFirebase();
            Application.Run(new FormMain());
            //    }
            //}
        }
    }
}
