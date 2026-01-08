namespace BotCommon {
    public class companys {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string Logo { get; set; }
        public int? AddressID { get; set; }
        public string CreateTime { get; set; }
        public string CreateBy { get; set; }
        public string UpdateTime { get; set; }
        public string UpdateBy { get; set; }

        public static void CompanysMgr_Wait(ref companys c, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                        var res = ConstantCommon.client.SetAsync($"companys/{c.CompanyID}", c).GetAwaiter().GetResult();
                        break;
                    }
                    case "EDIT": {
                        var res = ConstantCommon.client.UpdateAsync($"companys/{c.CompanyID}", c).GetAwaiter().GetResult();
                        break;
                    }
                    case "DELETE": {
                        var res = ConstantCommon.client.DeleteAsync($"companys/{c.CompanyID}").GetAwaiter().GetResult();
                        break;
                    }
                    case "GETLAST": {
                        var response = ConstantCommon.client.Get($"companys/{c.CompanyID}");
                        c = response.ResultAs<companys>();
                        break;
                    }
                }
            } catch { }
        }

        public static async void CompanysMgr(companys c, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                        var res = await ConstantCommon.client.SetAsync($"companys/{c.CompanyID}", c);
                        break;
                    }
                    case "EDIT": {
                        var res = await ConstantCommon.client.UpdateAsync($"companys/{c.CompanyID}", c);
                        break;
                    }
                    case "DELETE": {
                        var res = await ConstantCommon.client.DeleteAsync($"companys/{c.CompanyID}");
                        break;
                    }
                    case "GETLAST": {
                        var response = ConstantCommon.client.Get($"companys/{c.CompanyID}");
                        c = response.ResultAs<companys>();
                        break;
                    }
                }
            } catch { }
        }
    }
}
