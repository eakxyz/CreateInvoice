namespace BotCommon {
    public class address {
        public int? AddressID {
            get; set;
        }
        public string AddressDetail {
            get; set;
        }
        public string RoomNo {
            get; set;
        }
        public string Flood {
            get; set;
        }
        public string HouseNo {
            get; set;
        }
        public string Moo {
            get; set;
        }
        public string Soi {
            get; set;
        }
        public string Road {
            get; set;
        }
        public string SubDistrict {
            get; set;
        }
        public string District {
            get; set;
        }
        public string Province {
            get; set;
        }
        public string GPS {
            get; set;
        }
        public string Lang {
            get; set;
        }
        public string Phone {
            get; set;
        }
        public string Mobile {
            get; set;
        }
        public string PhoneTo {
            get; set;
        }
        public string Fax {
            get; set;
        }
        public string FaxTo {
            get; set;
        }
        public string RefCode {
            get; set;
        }
        public string Email {
            get; set;
        }
        public string LineID {
            get; set;
        }
        public string LineContract {
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

        public static void AddressMgr_Wait(ref address a, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            var res = ConstantCommon.client.SetAsync($"address/{a.AddressID}", a).GetAwaiter().GetResult();
                            break;
                        }
                    case "EDIT": {
                            var res = ConstantCommon.client.UpdateAsync($"address/{a.AddressID}", a).GetAwaiter().GetResult();
                            break;
                        }
                    case "DELETE": {
                            var res = ConstantCommon.client.DeleteAsync($"address/{a.AddressID}").GetAwaiter().GetResult();
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"address/{a.AddressID}");
                            a = response.ResultAs<address>();
                            break;
                        }
                }
            } catch { }
        }

        public static async void AddressMgr(address a, string mode) {
            try {
                switch (mode) {
                    case "ADD": {
                            var res = await ConstantCommon.client.SetAsync($"address/{a.AddressID}", a);
                            break;
                        }
                    case "EDIT": {
                            var res = await ConstantCommon.client.UpdateAsync($"address/{a.AddressID}", a);
                            break;
                        }
                    case "DELETE": {
                            var res = await ConstantCommon.client.DeleteAsync($"address/{a.AddressID}");
                            break;
                        }
                    case "GETLAST": {
                            var response = ConstantCommon.client.Get($"address/{a.AddressID}");
                            a = response.ResultAs<address>();
                            break;
                        }
                }
            } catch { }
        }
    }
}
