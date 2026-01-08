using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class Registers {
        #region Init
        public string UserID { get; set; }
        public string LineID { get; set; }
        public string Data { get; set; }
        public string CloseBot { get; set; }
        public string LogData { get; set; }
        public string Formula { get; set; }
        public string Step { get; set; }
        public int StopWin { get; set; }
        public int StopLose { get; set; }
        #endregion

        #region Wait Method
        public static void RegisterMgr_Wait(ref Registers pRegister, string pMode) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setRegister = ConstantCommon.client.SetAsync("Registers/" + pRegister.LineID, pRegister).GetAwaiter().GetResult();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editRegister = ConstantCommon.client.UpdateAsync("Registers/" + pRegister.LineID, pRegister).GetAwaiter().GetResult();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delRegister = ConstantCommon.client.DeleteAsync("Registers/" + pRegister.LineID).GetAwaiter().GetResult(); //Deletes todos collection
                            break;
                        }
                    case "GETLAST": {
                            //Task.Run(() => ConstantCommon.client.GetAsync("Licenses/" + pLic.LicenseCode.Replace("@", "/"))).GetAwaiter().GetResult();
                            FirebaseResponse response = ConstantCommon.client.Get("Registers/" + pRegister.LineID);
                            pRegister = response.ResultAs<Registers>();
                            break;
                        }
                }
            } catch { }
        }

        public static void Refresh_FireBase_Wait() {
            try {

                FirebaseResponse resRegister = ConstantCommon.client.GetAsync("Registers/").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resRegister.Body);

                if (data != null) {
                    ConstantCommon.Registers.Clear();
                    foreach (var itemDynamic in data) {
                        Registers regis = JsonConvert.DeserializeObject<Registers>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Registers.NewRow();
                        row["UserID"] = regis.UserID;
                        row["LineID"] = regis.LineID;
                        row["Data"] = regis.Data;
                        row["CloseBot"] = regis.CloseBot;
                        row["LogData"] = regis.LogData;
                        row["Formula"] = regis.Formula;
                        row["Step"] = regis.Step;
                        row["StopWin"] = regis.StopWin;
                        row["StopLose"] = regis.StopLose;
                        ConstantCommon.Registers.Rows.Add(row);
                    }
                }
            } catch { }
        }

        #endregion

        #region Not Wait Async Method
        public static async void RegisterMgr(Registers pRegister, string pMode) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setRegister = await ConstantCommon.client.SetAsync("Registers/" + pRegister.LineID, pRegister);
                            //Registers.Refresh_FireBase();
                            break;
                        }

                    case "EDIT": {
                            FirebaseResponse editRegister = await ConstantCommon.client.UpdateAsync("Registers/" + pRegister.LineID, pRegister);
                            //Registers.Refresh_FireBase();
                            break;
                        }

                    case "DELETE": {
                            FirebaseResponse delLicense = await ConstantCommon.client.DeleteAsync("Registers/" + pRegister.LineID); //Deletes todos collection
                                                                                                                                    //Registers.Refresh_FireBase();
                            break;
                        }

                    case "GETLAST": {
                            //Task.Run(() => ConstantCommon.client.GetAsync("Licenses/" + pLic.LicenseCode.Replace("@", "/"))).GetAwaiter().GetResult();
                            FirebaseResponse response = ConstantCommon.client.Get("Registers/" + pRegister.LineID);
                            pRegister = response.ResultAs<Registers>();
                            break;
                        }
                }
            } catch { }
        }

        public async static void Refresh_FireBase() {
            try {

                FirebaseResponse resRegister = await ConstantCommon.client.GetAsync("Registers/");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resRegister.Body);

                if (data != null) {
                    ConstantCommon.Registers.Clear();

                    List<Registers> item = new List<Registers>();
                    foreach (var itemDynamic in data) {
                        Registers regis = JsonConvert.DeserializeObject<Registers>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Registers.NewRow();
                        row["UserID"] = regis.UserID;
                        row["LineID"] = regis.LineID;
                        row["Data"] = regis.Data;
                        row["CloseBot"] = regis.CloseBot;
                        row["LogData"] = regis.LogData;
                        row["Formula"] = regis.Formula;
                        row["Step"] = regis.Step;
                        row["StopWin"] = regis.StopWin;
                        row["StopLose"] = regis.StopLose;
                        ConstantCommon.Registers.Rows.Add(row);
                    }
                }
            } catch { }
        }
        #endregion

    }
}
