using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCommon {
    public class EnvParameterLite {
        #region Init
        public string Version {
            get; set;
        }
        public string LinkDownload {
            get; set;
        }
        public string LinkDownloadBeta {
            get; set;
        }
        public string Detail {
            get; set;
        }
        public string DetailBeta {
            get; set;
        }
        #endregion

        #region Wait Method
        public static void TestAdd() {
            EnvParameterLite env = new EnvParameterLite();
            env.Version = "1.0.0.0";
            env.LinkDownloadBeta = "";
            env.LinkDownload = "https://firebasestorage.googleapis.com/v0/b/botmakemoney-a4acd.appspot.com/o/Bot%20Khotr-SeiynBeta.msi?alt=media&token=a36e29f2-4593-4e0b-ba90-6f09e00eaa10";
            env.Detail = $@"Version 1.0.0.0
- Add Program Lite Version";
            env.DetailBeta = "test";
            SetResponse setENV = ConstantCommon.client.SetAsync("EnvParameterLite", env).GetAwaiter().GetResult();
        }
        public static void EnvParameterMgr_Wait(ref EnvParameterLite pEnv) {
            FirebaseResponse res = ConstantCommon.client.Get("EnvParameterLite/");
            pEnv = res.ResultAs<EnvParameterLite>();
        }
        #endregion
    }
}
