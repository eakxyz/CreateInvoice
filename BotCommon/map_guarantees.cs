namespace BotCommon {
    public class map_guarantees {
        public string MapGuaranteeID {
            get; set;
        }
        public string CustomerID {
            get; set;
        }
        public string InvoiceID {
            get; set;
        }
        public string GuaranteeCusID {
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

        public static void MapGuaranteesMgr_Wait(ref map_guarantees mg, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            var res = ConstantCommon.client.SetAsync($"map_guarantees/{mg.MapGuaranteeID}", mg).GetAwaiter().GetResult();
                            break;
                        }
                    case "EDIT": {
                            var res = ConstantCommon.client.UpdateAsync($"map_guarantees/{mg.MapGuaranteeID}", mg).GetAwaiter().GetResult();
                            break;
                        }
                    case "DELETE": {
                            var res = ConstantCommon.client.DeleteAsync($"map_guarantees/{mg.MapGuaranteeID}").GetAwaiter().GetResult();
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"map_guarantees/{mg.MapGuaranteeID}");
                            mg = response.ResultAs<map_guarantees>();
                            break;
                        }
                }
            } catch { }
        }

        public static async void MapGuaranteesMgr(map_guarantees mg, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            var res = await ConstantCommon.client.SetAsync($"map_guarantees/{mg.MapGuaranteeID}", mg);
                            break;
                        }
                    case "EDIT": {
                            var res = await ConstantCommon.client.UpdateAsync($"map_guarantees/{mg.MapGuaranteeID}", mg);
                            break;
                        }
                    case "DELETE": {
                            var res = await ConstantCommon.client.DeleteAsync($"map_guarantees/{mg.MapGuaranteeID}");
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"map_guarantees/{mg.MapGuaranteeID}");
                            mg = response.ResultAs<map_guarantees>();
                            break;
                        }
                }
            } catch { }
        }
    }
}
