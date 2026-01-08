using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class Logs {

        #region Init
        public string LogID { get; set; } // GUID
        public string UserID { get; set; } // GUID
        public DateTime BetDateTime { get; set; } // GUID
        public string IsWin { get; set; } // Win
        public decimal Point { get; set; } // WinRate
        public string FormulaDetail { get; set; } // แผนที่ใช้เล่น
        public string FormulaMoney { get; set; } // แผนเดินเงินที่ใช้
        #endregion

        #region Wait Method
        public static void LogMgr_Wait(ref Logs pLog, string pMode, bool pIsNewGet = false) {
            switch (pMode) {
                case "ADD": {
                        SetResponse setLog = ConstantCommon.client.SetAsync("Logs/" + pLog.UserID + "/" + pLog.LogID, pLog).GetAwaiter().GetResult();
                        if (pIsNewGet)
                            Logs.Refresh_FireBase_Wait(pLog.UserID);
                        break;
                    }
                case "EDIT": {
                        FirebaseResponse editUser = ConstantCommon.client.UpdateAsync("Logs/" + pLog.UserID + "/" + pLog.LogID, pLog).GetAwaiter().GetResult();
                        if (pIsNewGet)
                            Logs.Refresh_FireBase_Wait(pLog.UserID);
                        break;
                    }
                case "DELETE": {
                        FirebaseResponse delUser = ConstantCommon.client.DeleteAsync("Logs/" + pLog.UserID + "/" + pLog.LogID).GetAwaiter().GetResult(); //Deletes todos collection
                        if (pIsNewGet)
                            Logs.Refresh_FireBase_Wait(pLog.UserID);
                        break;
                    }
                case "DELETE_UserID": {
                        FirebaseResponse delLog = ConstantCommon.client.DeleteAsync("Logs/" + pLog.UserID).GetAwaiter().GetResult(); //Deletes todos collection
                        break;
                    }
                case "GETLOG": {
                        FirebaseResponse response = ConstantCommon.client.GetAsync("Logs/" + pLog.UserID).GetAwaiter().GetResult();
                        if (pIsNewGet)
                            Logs.Refresh_FireBase_Wait(pLog.UserID);
                        break;
                    }

            }
        }
        public static void Refresh_FireBase_Wait(string pUserID = null) {
            ConstantCommon.Logs.Clear();
            if (pUserID != null) {
                Logs.setLogTable_Wait(pUserID);
            } else {
                foreach (DataRow row in ConstantCommon.Users.Rows) {
                    Logs.setLogTable_Wait(row["UserID"].ToString());
                }
            }
           
        }
        public static void setLogTable_Wait(string pUserID) {
            FirebaseResponse resLicense = ConstantCommon.client.GetAsync("Logs/" + pUserID).GetAwaiter().GetResult();
            dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

            if (data != null) {
                List<Logs> item = new List<Logs>();
                foreach (var itemDynamic in data) {
                    Logs l = JsonConvert.DeserializeObject<Logs>(((JProperty)itemDynamic).Value.ToString());
                    DataRow row = ConstantCommon.Logs.NewRow();
                    row["LogID"] = l.LogID;
                    row["UserID"] = l.UserID;
                    row["BetDateTime"] = l.BetDateTime;
                    row["IsWin"] = l.IsWin;
                    row["Point"] = l.Point;
                    row["FormulaDetail"] = l.FormulaDetail;
                    row["FormulaMoney"] = l.FormulaMoney;
                    if (ConstantCommon.Logs.Select($"LogID = '{l.LogID}'").Length == 0)
                        ConstantCommon.Logs.Rows.Add(row);

                }
            }
        }
        #endregion

        #region Not Wait Async Method
        public static async void LogMgr(Logs pLog, string pMode, bool pIsNewGet = false) {
            switch (pMode) {
                case "ADD": {
                        SetResponse setLog = await ConstantCommon.client.SetAsync("Logs/" + pLog.UserID + "/" + pLog.LogID, pLog);
                        if (pIsNewGet)
                            Logs.Refresh_FireBase(pLog.UserID);
                        break;
                    }
                case "EDIT": {
                        FirebaseResponse editLog = await ConstantCommon.client.UpdateAsync("Logs/" + pLog.UserID + "/" + pLog.LogID, pLog);
                        if (pIsNewGet)
                            Logs.Refresh_FireBase(pLog.UserID);
                        break;
                    }
                case "DELETE": {
                        FirebaseResponse delLog = await ConstantCommon.client.DeleteAsync("Logs/" + pLog.UserID + "/" + pLog.LogID); //Deletes todos collection
                        if (pIsNewGet)
                            Logs.Refresh_FireBase(pLog.UserID);
                        break;
                    }
                case "DELETE_UserID": {
                        FirebaseResponse delLog = await ConstantCommon.client.DeleteAsync("Logs/" + pLog.UserID); //Deletes todos collection
                        break;
                    }
                case "GETLOG": {
                        FirebaseResponse response = await ConstantCommon.client.GetAsync("Logs/" + pLog.UserID);
                        if (pIsNewGet)
                            Logs.Refresh_FireBase(pLog.UserID);
                        break;
                    }

            }
        }
        public static  void Refresh_FireBase(string pUserID = null) {
            ConstantCommon.Logs.Clear();
            if (pUserID != null) {
                Logs.setLogTable(pUserID);
            } else {
                foreach (DataRow row in ConstantCommon.Users.Rows) {
                    Logs.setLogTable(row["UserID"].ToString());
                }
            }
        }
        public static async void setLogTable(string pUserID) {
            try {
                FirebaseResponse resLicense = await ConstantCommon.client.GetAsync("Logs/" + pUserID);
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

                if (data != null) {
                    foreach (var itemDynamic in data) {
                        Logs l = JsonConvert.DeserializeObject<Logs>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Logs.NewRow();
                        row["LogID"] = l.LogID;
                        row["UserID"] = l.UserID;
                        row["BetDateTime"] = l.BetDateTime;
                        row["IsWin"] = l.IsWin;
                        row["Point"] = l.Point;
                        row["FormulaDetail"] = l.FormulaDetail;
                        row["FormulaMoney"] = l.FormulaMoney;
                        if (ConstantCommon.Logs.Select($"LogID = '{l.LogID}'").Length == 0)
                            ConstantCommon.Logs.Rows.Add(row);
                    }
                }
            } catch { }
        }
        public static void getShowLog() {
            try {
                FirebaseResponse resLicense = ConstantCommon.client.GetAsync("Logs/").GetAwaiter().GetResult();
                JObject json = JObject.Parse(resLicense.Body);

                foreach (DataRow dr in ConstantCommon.UserShow.Rows) {
                    if (!string.IsNullOrEmpty(dr["UserID"].ToString())) {

                        //Logs l = JsonConvert.DeserializeObject<Logs>(((JProperty)json[dr["UserID"]]).Value.ToString());
                        foreach (var x in json[dr["UserID"].ToString()]) { // Where 'obj' and 'obj["otherObject"]' are both JObjects
                            Logs l = JsonConvert.DeserializeObject<Logs>(((JProperty)x).Value.ToString());
                            DataRow row = ConstantCommon.LogShow.NewRow();
                            row["LogID"] = l.LogID;
                            row["UserID"] = l.UserID;
                            row["BetDateTime"] = l.BetDateTime;
                            row["IsWin"] = l.IsWin;
                            row["Point"] = l.Point;
                            row["FormulaDetail"] = l.FormulaDetail;
                            row["FormulaMoney"] = l.FormulaMoney;
                            ConstantCommon.LogShow.Rows.Add(row);
                        }

                    }
                }
            } catch { }
        }
        #endregion
    }

}