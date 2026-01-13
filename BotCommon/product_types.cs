namespace BotCommon {
    public class product_types {
        public string ProductTypeID {
            get; set;
        }
        public string ProductTypeCode {
            get; set;
        }
        public string ProductTypeName {
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

        public static void ProductTypesMgr_Wait(ref product_types pt, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            var res = ConstantCommon.client.SetAsync($"product_types/{pt.ProductTypeID}", pt).GetAwaiter().GetResult();
                            break;
                        }
                    case "EDIT": {
                            var res = ConstantCommon.client.UpdateAsync($"product_types/{pt.ProductTypeID}", pt).GetAwaiter().GetResult();
                            break;
                        }
                    case "DELETE": {
                            var res = ConstantCommon.client.DeleteAsync($"product_types/{pt.ProductTypeID}").GetAwaiter().GetResult();
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"product_types/{pt.ProductTypeID}");
                            pt = response.ResultAs<product_types>();
                            break;
                        }
                }
            } catch { }
        }

        public static async void ProductTypesMgr(product_types pt, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            var res = await ConstantCommon.client.SetAsync($"product_types/{pt.ProductTypeID}", pt);
                            break;
                        }
                    case "EDIT": {
                            var res = await ConstantCommon.client.UpdateAsync($"product_types/{pt.ProductTypeID}", pt);
                            break;
                        }
                    case "DELETE": {
                            var res = await ConstantCommon.client.DeleteAsync($"product_types/{pt.ProductTypeID}");
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"product_types/{pt.ProductTypeID}");
                            pt = response.ResultAs<product_types>();
                            break;
                        }
                }
            } catch { }
        }
    }
}
