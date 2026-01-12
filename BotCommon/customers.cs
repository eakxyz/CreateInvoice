namespace BotCommon {
    public class customers {
        public int? CustomerID {
            get; set;
        }
        public string CustomerCode {
            get; set;
        }
        public string CustomerName {
            get; set;
        }
        public string FNameT {
            get; set;
        }
        public string LNameT {
            get; set;
        }
        public string Sex {
            get; set;
        }
        public string PrefixT {
            get; set;
        }
        public string ShortNameT {
            get; set;
        }
        public string FNameE {
            get; set;
        }
        public string LNameE {
            get; set;
        }
        public string PrefixE {
            get; set;
        }
        public string ShortNameE {
            get; set;
        }
        public string FindName1 {
            get; set;
        }
        public string FindName2 {
            get; set;
        }
        public string Address {
            get; set;
        }
        public string RefCode {
            get; set;
        }
        public string IdentityCard {
            get; set;
        }
        public int? CompanyID {
            get; set;
        }
        public int? AddressID {
            get; set;
        }
        public int? CustomerGroupID {
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

        public static void CustomersMgr_Wait(ref customers c, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            var res = ConstantCommon.client.SetAsync($"customers/{c.CustomerID}", c).GetAwaiter().GetResult();
                            break;
                        }
                    case "EDIT": {
                            var res = ConstantCommon.client.UpdateAsync($"customers/{c.CustomerID}", c).GetAwaiter().GetResult();
                            break;
                        }
                    case "DELETE": {
                            var res = ConstantCommon.client.DeleteAsync($"customers/{c.CustomerID}").GetAwaiter().GetResult();
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"customers/{c.CustomerID}");
                            c = response.ResultAs<customers>();
                            break;
                        }
                }
            } catch { }
        }

        public static async void CustomersMgr(customers c, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            var res = await ConstantCommon.client.SetAsync($"customers/{c.CustomerID}", c);
                            break;
                        }
                    case "EDIT": {
                            var res = await ConstantCommon.client.UpdateAsync($"customers/{c.CustomerID}", c);
                            break;
                        }
                    case "DELETE": {
                            var res = await ConstantCommon.client.DeleteAsync($"customers/{c.CustomerID}");
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"customers/{c.CustomerID}");
                            c = response.ResultAs<customers>();
                            break;
                        }
                }
            } catch { }
        }
    }
}
