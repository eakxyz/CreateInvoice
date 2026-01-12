namespace BotCommon {
    public class products {
        public int? ProductID {
            get; set;
        }
        public string ProductName {
            get; set;
        }
        public string ProductCode {
            get; set;
        }
        public string Price {
            get; set;
        }
        public string Net {
            get; set;
        }
        public string RefID {
            get; set;
        }
        public string GainPrice {
            get; set;
        }
        public string GainPercentage {
            get; set;
        }
        public int? CompanyID {
            get; set;
        }
        public string CreateTime {
            get; set;
        }
        public string CreateBy {
            get; set;
        }
        public string UpdateTime {
            get; set;
        }
        public string UpdateBy {
            get; set;
        }

        // Firebase write helpers (similar to Computers.cs)
        public static void ProductsMgr_Wait(ref products p, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            FireSharp.Response.SetResponse res = ConstantCommon.client.SetAsync($"products/{p.ProductID}", p).GetAwaiter().GetResult();
                            break;
                        }
                    case "EDIT": {
                            FireSharp.Response.FirebaseResponse res = ConstantCommon.client.UpdateAsync($"products/{p.ProductID}", p).GetAwaiter().GetResult();
                            break;
                        }
                    case "DELETE": {
                            FireSharp.Response.FirebaseResponse res = ConstantCommon.client.DeleteAsync($"products/{p.ProductID}").GetAwaiter().GetResult();
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"products/{p.ProductID}");
                            p = response.ResultAs<products>();
                            break;
                        }
                }
            } catch { }
        }

        public static async void ProductsMgr(products p, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            var res = await ConstantCommon.client.SetAsync($"products/{p.ProductID}", p);
                            break;
                        }
                    case "EDIT": {
                            var res = await ConstantCommon.client.UpdateAsync($"products/{p.ProductID}", p);
                            break;
                        }
                    case "DELETE": {
                            var res = await ConstantCommon.client.DeleteAsync($"products/{p.ProductID}");
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"products/{p.ProductID}");
                            p = response.ResultAs<products>();
                            break;
                        }
                }
            } catch { }
        }
    }
}
