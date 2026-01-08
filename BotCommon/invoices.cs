namespace BotCommon {
    public class invoices {
        public int InvoiceID { get; set; }
        public string InvoiceCode { get; set; }
        public int? CustomerID { get; set; }
        public string PeriodNo { get; set; }
        public string PayStatus { get; set; }
        public string Balance { get; set; }
        public string PayFinePercentage { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int? CompanyID { get; set; }
        public string CreateTime { get; set; }
        public string CreateBy { get; set; }
        public string UpdateTime { get; set; }
        public string UpdateBy { get; set; }

        public static void InvoicesMgr_Wait(ref invoices inv, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                        var res = ConstantCommon.client.SetAsync($"invoices/{inv.InvoiceID}", inv).GetAwaiter().GetResult();
                        break;
                    }
                    case "EDIT": {
                        var res = ConstantCommon.client.UpdateAsync($"invoices/{inv.InvoiceID}", inv).GetAwaiter().GetResult();
                        break;
                    }
                    case "DELETE": {
                        var res = ConstantCommon.client.DeleteAsync($"invoices/{inv.InvoiceID}").GetAwaiter().GetResult();
                        break;
                    }
                    case "GETLAST": {
                        var response = ConstantCommon.client.Get($"invoices/{inv.InvoiceID}");
                        inv = response.ResultAs<invoices>();
                        break;
                    }
                }
            } catch { }
        }

        public static async void InvoicesMgr(invoices inv, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                        var res = await ConstantCommon.client.SetAsync($"invoices/{inv.InvoiceID}", inv);
                        break;
                    }
                    case "EDIT": {
                        var res = await ConstantCommon.client.UpdateAsync($"invoices/{inv.InvoiceID}", inv);
                        break;
                    }
                    case "DELETE": {
                        var res = await ConstantCommon.client.DeleteAsync($"invoices/{inv.InvoiceID}");
                        break;
                    }
                    case "GETLAST": {
                        var response = ConstantCommon.client.Get($"invoices/{inv.InvoiceID}");
                        inv = response.ResultAs<invoices>();
                        break;
                    }
                }
            } catch { }
        }
    }
}
