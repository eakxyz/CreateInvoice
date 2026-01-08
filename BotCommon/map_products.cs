namespace BotCommon {
    public class map_products {
        public int MapProductID { get; set; }
        public int ProductID { get; set; }
        public int InvoiceID { get; set; }
        public int? Qty { get; set; }
        public string Price { get; set; }
        public string Net { get; set; }
        public string GainPrice { get; set; }
        public string GainPercentage { get; set; }
        public string CreateTime { get; set; }
        public string CreateBy { get; set; }
        public string UpdateTime { get; set; }
        public string UpdateBy { get; set; }

        public static void MapProductsMgr_Wait(ref map_products mp, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                        var res = ConstantCommon.client.SetAsync($"map_products/{mp.MapProductID}", mp).GetAwaiter().GetResult();
                        break;
                    }
                    case "EDIT": {
                        var res = ConstantCommon.client.UpdateAsync($"map_products/{mp.MapProductID}", mp).GetAwaiter().GetResult();
                        break;
                    }
                    case "DELETE": {
                        var res = ConstantCommon.client.DeleteAsync($"map_products/{mp.MapProductID}").GetAwaiter().GetResult();
                        break;
                    }
                    case "GETLAST": {
                        var response = ConstantCommon.client.Get($"map_products/{mp.MapProductID}");
                        mp = response.ResultAs<map_products>();
                        break;
                    }
                }
            } catch { }
        }

        public static async void MapProductsMgr(map_products mp, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                        var res = await ConstantCommon.client.SetAsync($"map_products/{mp.MapProductID}", mp);
                        break;
                    }
                    case "EDIT": {
                        var res = await ConstantCommon.client.UpdateAsync($"map_products/{mp.MapProductID}", mp);
                        break;
                    }
                    case "DELETE": {
                        var res = await ConstantCommon.client.DeleteAsync($"map_products/{mp.MapProductID}");
                        break;
                    }
                    case "GETLAST": {
                        var response = ConstantCommon.client.Get($"map_products/{mp.MapProductID}");
                        mp = response.ResultAs<map_products>();
                        break;
                    }
                }
            } catch { }
        }
    }
}
