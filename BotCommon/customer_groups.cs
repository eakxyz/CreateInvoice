namespace BotCommon {
    public class customer_groups {
        public string CustomerGroupID {
            get; set;
        }
        public string CustomerGroupCode {
            get; set;
        }
        public string CustomerGroupName {
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

        public static void CustomerGroupsMgr_Wait(ref customer_groups cg, string mode) {
            try {
                var key = cg.CustomerGroupID != null ? cg.CustomerGroupID : cg.CustomerGroupCode;
                switch (mode) {
                    case "ADD": {
                            var res = ConstantCommon.client.SetAsync($"customer_groups/{key}", cg).GetAwaiter().GetResult();
                            break;
                        }
                    case "EDIT": {
                            var res = ConstantCommon.client.UpdateAsync($"customer_groups/{key}", cg).GetAwaiter().GetResult();
                            break;
                        }
                    case "DELETE": {
                            var res = ConstantCommon.client.DeleteAsync($"customer_groups/{key}").GetAwaiter().GetResult();
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"customer_groups/{key}");
                            cg = response.ResultAs<customer_groups>();
                            break;
                        }
                }
            } catch { }
        }

        public static async void CustomerGroupsMgr(customer_groups cg, string mode) {
            try {
                var key = cg.CustomerGroupID != null ? cg.CustomerGroupID : cg.CustomerGroupCode;
                switch (mode) {
                    case "ADD": {
                            var res = await ConstantCommon.client.SetAsync($"customer_groups/{key}", cg);
                            break;
                        }
                    case "EDIT": {
                            var res = await ConstantCommon.client.UpdateAsync($"customer_groups/{key}", cg);
                            break;
                        }
                    case "DELETE": {
                            var res = await ConstantCommon.client.DeleteAsync($"customer_groups/{key}");
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"customer_groups/{key}");
                            cg = response.ResultAs<customer_groups>();
                            break;
                        }
                }
            } catch { }
        }
    }
}
