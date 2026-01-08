using FireSharp.Response;

namespace BotCommon {
    public class EnvParameter {
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
        public string FixUpdate {
            get; set;
        }
        #endregion

        #region Wait Method
        public static void TestAdd() {
            EnvParameter env = new EnvParameter();
            env.Version = "";
            env.LinkDownloadBeta = "";
            env.LinkDownload = "";
            env.Detail = $@"เพิ่มสูตร 16 แพทเทิน กับ reset เมื่อครบเป้า";
            env.DetailBeta = "";
            SetResponse setENV = ConstantCommon.client.SetAsync("EnvParameter", env).GetAwaiter().GetResult();
        }
        public static void EnvParameterMgr_Wait(ref EnvParameter pEnv) {
            FirebaseResponse res = ConstantCommon.client.Get("EnvParameter/");
            pEnv = res.ResultAs<EnvParameter>();
        }
        #endregion
    }
}
