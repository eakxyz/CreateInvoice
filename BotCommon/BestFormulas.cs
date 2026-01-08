using BotCommon;
using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotMakeMoney {
    public class BestFormulas {
        #region Init
        public string SerialNumber {
            get; set;
        } // GUID
        public DateTime AddDateTime {
            get; set;
        } // GUID
        public string UserID {
            get; set;
        } // GUID
        public string Data {
            get; set;
        } // GUID
        public string Band {
            get; set;
        } // GUID
        #endregion

        #region Wait Method
        public static void BestFormulaMgr_Wait(ref BestFormulas pBest, string pMode) {
            try {
                // UserID = {UserID}_{เครื่องComputerName}
                switch (pMode) {
                    case "ADD": {
                            SetResponse setLicense = ConstantCommon.client.SetAsync($"BestFormulas/{ConstantCommon.FormatData(pBest.AddDateTime)}/{pBest.UserID}", pBest).GetAwaiter().GetResult();
                            //Computers.Refresh_FireBase_Wait();
                            break;
                        }

                    case "EDIT": {
                            FirebaseResponse editLicense = ConstantCommon.client.UpdateAsync($"BestFormulas/{ConstantCommon.FormatData(pBest.AddDateTime)}/{pBest.UserID}", pBest).GetAwaiter().GetResult();
                            //Computers.Refresh_FireBase_Wait();
                            break;
                        }

                    case "DELETE": {
                            FirebaseResponse del = ConstantCommon.client.DeleteAsync($"BestFormulas/{ConstantCommon.FormatData(pBest.AddDateTime)}/{pBest.UserID}").GetAwaiter().GetResult();
                            break;
                        }

                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get($"BestFormulas/{ConstantCommon.FormatData(pBest.AddDateTime)}/{pBest.UserID}");
                            pBest = response.ResultAs<BestFormulas>();
                            break;
                        }
                }
            } catch { }
        }
        public static void Refresh_FireBase_Wait(DateTime pStartDate, DateTime pEndDate, BestFormulas pBest, bool pIsAll = false) {
            try {
                if (pStartDate != DateTime.MinValue
                        && pEndDate != DateTime.MinValue
                        && pStartDate <= pEndDate) {
                    ConstantCommon.BestFormulas.Clear();
                    if (!pIsAll) {
                        BestFormulas.setBestFormulasTable_Wait(pStartDate, pEndDate, null);
                    } else {
                        BestFormulas.setBestFormulasTable_Wait(pStartDate, pEndDate, pBest.UserID);
                        //foreach (DataRow row in ConstantCommon.Users.Rows) {
                        //    BestFormulas.setBestFormulasTable_Wait(pStartDate, pEndDate, row["UserID"].ToString());
                        //}
                    }
                }
            } catch { }

        }
        public static void ClearDataTableFireBase() {
            try {
                ConstantCommon.BestFormulas.Clear();
            } catch { }

        }
        public class RootObject {
            public ResultObject results {
                get; set;
            }
        }

        public class ResultObject {
            public Dictionary<string, BestFormulas> records {
                get; set;
            }
        }
        public static void setBestFormulasTable_Wait(DateTime pStartDate, DateTime pEndDate, string pUserID) {
            try {
                for (; pStartDate <= pEndDate; pStartDate = pStartDate.AddDays(1)) {
                    //FirebaseResponse resLicense = ConstantCommon.client.GetAsync($"BestFormulas/{ConstantCommon.FormatData(pStartDate)}/{pUserID}/").GetAwaiter().GetResult();
                    FirebaseResponse resLicense;

                    if (string.IsNullOrEmpty(pUserID))
                        resLicense = ConstantCommon.client.GetAsync($"BestFormulas/{ConstantCommon.FormatData(pStartDate)}/").GetAwaiter().GetResult();
                    else
                        resLicense = ConstantCommon.client.GetAsync($"BestFormulas/{ConstantCommon.FormatData(pStartDate)}/{pUserID}/").GetAwaiter().GetResult();


                    Dictionary<string, BestFormulas> result = JsonConvert.DeserializeObject<Dictionary<string, BestFormulas>>(resLicense.Body);
                    if (result != null) {
                        foreach (KeyValuePair<string, BestFormulas> entry in result) {
                            // do something with entry.Value or entry.Key
                            DataRow row = ConstantCommon.BestFormulas.NewRow();
                            row["SerialNumber"] = ((BestFormulas)entry.Value).SerialNumber;
                            row["AddDateTime"] = ((BestFormulas)entry.Value).AddDateTime;
                            row["UserID"] = ((BestFormulas)entry.Value).UserID;
                            row["Data"] = ((BestFormulas)entry.Value).Data;
                            row["Band"] = ((BestFormulas)entry.Value).Band;
                            ConstantCommon.BestFormulas.Rows.Add(row);
                        }
                    }
                }
            } catch { }
        }
        #endregion

        #region Not Wait Async Method
        public static async void BestFormulaMgr(BestFormulas pBest, string pMode) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setLicense = await ConstantCommon.client.SetAsync($"BestFormulas/{ConstantCommon.FormatData(pBest.AddDateTime)}/{pBest.UserID}", pBest);
                            //Computers.Refresh_FireBase(null, pCom.LicenseCode);
                            break;
                        }

                    case "EDIT": {
                            FirebaseResponse editLicense = await ConstantCommon.client.UpdateAsync($"BestFormulas/{ConstantCommon.FormatData(pBest.AddDateTime)}/{pBest.UserID}", pBest);
                            //Computers.Refresh_FireBase(null, pCom.LicenseCode);
                            break;
                        }

                    case "DELETE": {
                            FirebaseResponse delLicense = await ConstantCommon.client.DeleteAsync($"BestFormulas/{ConstantCommon.FormatData(pBest.AddDateTime)}/{pBest.UserID}"); //Deletes todos collection
                                                                                                                                                                                //Computers.Refresh_FireBase(null, pCom.LicenseCode);
                            break;
                        }

                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get($"BestFormulas/{ConstantCommon.FormatData(pBest.AddDateTime)}/{pBest.UserID}");
                            pBest = response.ResultAs<BestFormulas>();
                            break;
                        }
                }
            } catch { }
        }

        public static void Refresh_FireBase(DateTime pStartDate, DateTime pEndDate, BestFormulas pBest, bool pIsAll = false) {
            try {
                if (pStartDate != DateTime.MinValue
                        && pEndDate != DateTime.MinValue
                        && pStartDate <= pEndDate) {
                    ConstantCommon.BestFormulas.Clear();
                    if (!pIsAll) {
                        BestFormulas.setBestFormulasTable(pStartDate, pEndDate, pBest.UserID);
                    } else {
                        foreach (DataRow row in ConstantCommon.Users.Rows) {
                            BestFormulas.setBestFormulasTable(pStartDate, pEndDate, row["UserID"].ToString());
                        }
                    }
                }
            } catch { }

        }
        public async static void setBestFormulasTable(DateTime pStartDate, DateTime pEndDate, string pUserID) {
            try {
                for (; pStartDate <= pEndDate; pStartDate.AddDays(1)) {
                    FirebaseResponse resLicense = await ConstantCommon.client.GetAsync($"BestFormulas/{ConstantCommon.FormatData(pStartDate)}/{pUserID}/");
                    dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

                    if (data != null) {
                        foreach (var itemDynamic in data) {
                            BestFormulas best = JsonConvert.DeserializeObject<BestFormulas>(((JProperty)itemDynamic).Value.ToString());
                            DataRow rowCom = ConstantCommon.Computers.NewRow();
                            rowCom["SerialNumber"] = best.SerialNumber;
                            rowCom["AddDateTime"] = best.AddDateTime;
                            rowCom["UserID"] = best.UserID;
                            rowCom["Data"] = best.Data;
                            rowCom["Band"] = best.Band;
                            ConstantCommon.BestFormulas.Rows.Add(rowCom);
                        }
                    }
                }

            } catch { }
        }
        #endregion

    }
}
