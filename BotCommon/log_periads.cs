namespace BotCommon {
    public class log_periads {
        public int LogPeriadID { get; set; }
        public int? InvoiceID { get; set; }
        public string PeriadNo { get; set; }
        public string Remark { get; set; }
        public string Price { get; set; }
        public string GainPrice { get; set; }
        public string GainPercentage { get; set; }
        public int? CustomerID { get; set; }
        public string PayFine { get; set; }
        public string PayDate { get; set; }
        public string PeriadDateFrom { get; set; }
        public string PeriadDateTo { get; set; }
        public int? CompanyID { get; set; }
        public string CreateTime { get; set; }
        public string CreateBy { get; set; }
        public string UpdateTime { get; set; }
        public string UpdateBy { get; set; }

        public static void LogPeriadsMgr_Wait(ref log_periads lp, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                        var res = ConstantCommon.client.SetAsync($"log_periads/{lp.LogPeriadID}", lp).GetAwaiter().GetResult();
                        break;
                    }
                    case "EDIT": {
                        var res = ConstantCommon.client.UpdateAsync($"log_periads/{lp.LogPeriadID}", lp).GetAwaiter().GetResult();
                        break;
                    }
                    case "DELETE": {
                        var res = ConstantCommon.client.DeleteAsync($"log_periads/{lp.LogPeriadID}").GetAwaiter().GetResult();
                        break;
                    }
                    case "GETLAST": {
                        var response = ConstantCommon.client.Get($"log_periads/{lp.LogPeriadID}");
                        lp = response.ResultAs<log_periads>();
                        break;
                    }
                }
            } catch { }
        }

        public static async void LogPeriadsMgr(log_periads lp, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                        var res = await ConstantCommon.client.SetAsync($"log_periads/{lp.LogPeriadID}", lp);
                        break;
                    }
                    case "EDIT": {
                        var res = await ConstantCommon.client.UpdateAsync($"log_periads/{lp.LogPeriadID}", lp);
                        break;
                    }
                    case "DELETE": {
                        var res = await ConstantCommon.client.DeleteAsync($"log_periads/{lp.LogPeriadID}");
                        break;
                    }
                    case "GETLAST": {
                        var response = ConstantCommon.client.Get($"log_periads/{lp.LogPeriadID}");
                        lp = response.ResultAs<log_periads>();
                        break;
                    }
                }
            } catch { }
        }
    }
}
