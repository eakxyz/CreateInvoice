using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class MapSupportUsers {

        #region Init
        public string MapID {
            get; set;
        } // GUID
        public string MemberLicenseCode {
            get; set;
        } // GUID
        public string LicenseCode {
            get; set;
        } // UserName
        public decimal GetMoney {
            get; set;
        } // PassWord
        public DateTime Date {
            get; set;
        } // LevelUser
        public string IsPayToMember {
            get; set;
        } // LevelUser
        public decimal Price {
            get; set;
        } // PassWord

        #endregion

        #region Wait Method
        public static void MapSupportUserMgr_Wait(ref MapSupportUsers pUser, string pMode, bool pIsNewGet = false) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setUser = ConstantCommon.client.SetAsync("MapSupportUsers/" + pUser.LicenseCode, pUser).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                MapSupportUsers.Refresh_FireBase_Wait();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editUser = ConstantCommon.client.UpdateAsync("MapSupportUsers/" + pUser.LicenseCode, pUser).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                MapSupportUsers.Refresh_FireBase_Wait();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delUser = ConstantCommon.client.DeleteAsync("MapSupportUsers/" + pUser.LicenseCode).GetAwaiter().GetResult(); //Deletes todos collection
                            if (pIsNewGet)
                                MapSupportUsers.Refresh_FireBase_Wait();
                            break;
                        }
                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get("MapSupportUsers/" + pUser.LicenseCode);
                            pUser = response.ResultAs<MapSupportUsers>();
                            break;
                        }

                }
            } catch { }
        }
        public static void Refresh_FireBase_Wait() {
            try {

                FirebaseResponse resUser = ConstantCommon.client.GetAsync("MapSupportUsers/").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resUser.Body);

                if (data != null) {
                    ConstantCommon.MapSupportUsers.Clear();
                    foreach (var itemDynamic in data) {
                        MapSupportUsers u = JsonConvert.DeserializeObject<MapSupportUsers>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.MapSupportUsers.NewRow();
                        row["MapID"] = u.MapID;
                        row["MemberLicenseCode"] = u.MemberLicenseCode;
                        row["LicenseCode"] = u.LicenseCode;
                        row["GetMoney"] = u.GetMoney;
                        row["Date"] = u.Date;
                        row["IsPayToMember"] = u.IsPayToMember;
                        row["Price"] = u.Price;
                        if (ConstantCommon.MapSupportUsers.Select($"MapID = '{u.MapID}'").Length == 0)
                            ConstantCommon.MapSupportUsers.Rows.Add(row);

                    }
                }
            } catch { }
        }

        #endregion

        #region Not Wait Async Method
        public static async void MapSupportUserMgr(MapSupportUsers pUser, string pMode, bool pIsNewGet = false) {
            try {
                switch (pMode) {
                    case "ADD": {
                            SetResponse setUser = await ConstantCommon.client.SetAsync("MapSupportUsers/" + pUser.LicenseCode, pUser);
                            if (pIsNewGet)
                                MapSupportUsers.Refresh_FireBase();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editUser = await ConstantCommon.client.UpdateAsync("MapSupportUsers/" + pUser.LicenseCode, pUser);
                            if (pIsNewGet)
                                MapSupportUsers.Refresh_FireBase();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delUser = await ConstantCommon.client.DeleteAsync($"MapSupportUsers/{pUser.LicenseCode}"); //Deletes todos collection
                            if (pIsNewGet)
                                MapSupportUsers.Refresh_FireBase();
                            break;
                        }

                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get("MapSupportUsers/" + pUser.LicenseCode);
                            pUser = response.ResultAs<MapSupportUsers>();
                            break;
                        }

                }
            } catch { }
        }
        public static async void Refresh_FireBase() {
            try {

                FirebaseResponse resUser = await ConstantCommon.client.GetAsync("MapSupportUsers/");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resUser.Body);

                if (data != null) {
                    ConstantCommon.MapSupportUsers.Clear();
                    foreach (var itemDynamic in data) {
                        MapSupportUsers u = JsonConvert.DeserializeObject<MapSupportUsers>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.MapSupportUsers.NewRow();
                        row["MapID"] = u.MapID;
                        row["LicenseCode"] = u.LicenseCode;
                        row["GetMoney"] = u.GetMoney;
                        row["Date"] = u.Date;
                        row["IsPayToMember"] = u.IsPayToMember;
                        row["MemberLicenseCode"] = u.MemberLicenseCode;
                        row["Price"] = u.Price;
                        if (ConstantCommon.MapSupportUsers.Select($"MapID = '{u.MapID}'").Length == 0)
                            ConstantCommon.MapSupportUsers.Rows.Add(row);

                    }
                }
            } catch { }
        }

        #endregion
    }

}