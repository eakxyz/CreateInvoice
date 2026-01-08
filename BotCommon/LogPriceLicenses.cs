using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCommon {
    class LogPriceLicenses {

        #region Init
        public string LogID {
            get; set;
        } // LogID
        public string LicenseCode {
            get; set;
        } // LicenseCode
        public string SupportUserID {
            get; set;
        } // SupportUserID
        public decimal Price {
            get; set;
        } // Price
        public DateTime PriceDate {
            get; set;
        } // PriceDate
        public decimal GetPrice {
            get; set;
        } // GetPrice
        public int Ranking {
            get; set;
        } // Ranking
        #endregion

        #region Wait Method
        public static void LogPriceLicenseMgr_Wait(ref LogPriceLicenses pLog, string pMode, bool pIsNewGet = false) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setUser = ConstantCommon.client.SetAsync("LogPriceLicenses/" + pLog.LogID, pLog).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                LogPriceLicenses.Refresh_FireBase_Wait();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editUser = ConstantCommon.client.UpdateAsync("LogPriceLicenses/" + pLog.LogID, pLog).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                LogPriceLicenses.Refresh_FireBase_Wait();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delUser = ConstantCommon.client.DeleteAsync("LogPriceLicenses/" + pLog.LogID).GetAwaiter().GetResult(); //Deletes todos collection
                            if (pIsNewGet)
                                LogPriceLicenses.Refresh_FireBase_Wait();
                            break;
                        }
                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get("LogPriceLicenses/" + pLog.LogID);
                            pLog = response.ResultAs<LogPriceLicenses>();
                            break;
                        }

                }
            } catch { }
        }
        public static void Refresh_FireBase_Wait() {
            try {

                FirebaseResponse resUser = ConstantCommon.client.GetAsync("LogPriceLicenses/").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resUser.Body);

                if (data != null) {
                    ConstantCommon.LogPriceLicenses.Clear();
                    foreach (var itemDynamic in data) {
                        LogPriceLicenses u = JsonConvert.DeserializeObject<LogPriceLicenses>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.LogPriceLicenses.NewRow();
                        row["LogID"] = u.LogID;
                        row["SupportUserID"] = u.SupportUserID;
                        row["LicenseCode"] = u.LicenseCode;
                        row["Price"] = u.Price;
                        row["PriceDate"] = u.PriceDate;
                        row["GetPrice"] = u.GetPrice;
                        row["Ranking"] = u.Ranking;

                        if (ConstantCommon.LogPriceLicenses.Select($"LogID = '{u.LogID}'").Length == 0)
                            ConstantCommon.LogPriceLicenses.Rows.Add(row);

                    }
                }
            } catch { }
        }

        #endregion

        #region Not Wait Async Method
        public static async void LogPriceLicenseMgr(LogPriceLicenses pUser, string pMode, bool pIsNewGet = false) {
            try {
                switch (pMode) {
                    case "ADD": {
                            SetResponse setUser = await ConstantCommon.client.SetAsync("LogPriceLicenses/" + pUser.LogID, pUser);
                            if (pIsNewGet)
                                LogPriceLicenses.Refresh_FireBase();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editUser = await ConstantCommon.client.UpdateAsync("LogPriceLicenses/" + pUser.LogID, pUser);
                            if (pIsNewGet)
                                LogPriceLicenses.Refresh_FireBase();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delUser = await ConstantCommon.client.DeleteAsync("LogPriceLicenses/" + pUser.LogID); //Deletes todos collection
                            if (pIsNewGet)
                                LogPriceLicenses.Refresh_FireBase();
                            break;
                        }

                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get("LogPriceLicenses/" + pUser.LogID);
                            pUser = response.ResultAs<LogPriceLicenses>();
                            break;
                        }

                }
                
            } catch { }
        }
        public static async void Refresh_FireBase() {
            try {

                FirebaseResponse resUser = await ConstantCommon.client.GetAsync("LogPriceLicenses/");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resUser.Body);

                if (data != null) {
                    ConstantCommon.LogPriceLicenses.Clear();
                    foreach (var itemDynamic in data) {
                        LogPriceLicenses u = JsonConvert.DeserializeObject<LogPriceLicenses>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.LogPriceLicenses.NewRow();
                        row["LogID"] = u.LogID;
                        row["SupportUserID"] = u.SupportUserID;
                        row["LicenseCode"] = u.LicenseCode;
                        row["Price"] = u.Price;
                        row["PriceDate"] = u.PriceDate;
                        row["GetPrice"] = u.GetPrice;
                        row["Ranking"] = u.Ranking;

                        if (ConstantCommon.LogPriceLicenses.Select($"LogID = '{u.LogID}'").Length == 0)
                            ConstantCommon.LogPriceLicenses.Rows.Add(row);

                    }
                }
            } catch { }
        }

        #endregion
    }
}
