using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class Generates {
        #region Init
        public string GUID { get; set; }
        public string UserID { get; set; }
        #endregion

        #region Wait Method
        public static void GenerateMgr_Wait(ref Generates pGenerate, string pMode) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setGen = ConstantCommon.client.SetAsync("Generates/" + pGenerate.GUID, pGenerate).GetAwaiter().GetResult();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editGen = ConstantCommon.client.UpdateAsync("Generates/" + pGenerate.GUID, pGenerate).GetAwaiter().GetResult();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delGen = ConstantCommon.client.DeleteAsync("Generates/" + pGenerate.GUID).GetAwaiter().GetResult(); //Deletes todos collection
                            break;
                        }
                    case "GETLAST": {
                            //Task.Run(() => ConstantCommon.client.GetAsync("Licenses/" + pLic.LicenseCode.Replace("@", "/"))).GetAwaiter().GetResult();
                            FirebaseResponse response = ConstantCommon.client.Get("Generates/" + pGenerate.GUID);
                            pGenerate = response.ResultAs<Generates>();
                            break;
                        }
                }
            } catch { }
        }

        public static void Refresh_FireBase_Wait() {
            try {

                FirebaseResponse resGen = ConstantCommon.client.GetAsync("Generates/").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resGen.Body);

                if (data != null) {
                    ConstantCommon.Generates.Clear();
                    foreach (var itemDynamic in data) {
                        Generates gen = JsonConvert.DeserializeObject<Generates>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Generates.NewRow();
                        row["GUID"] = gen.GUID;
                        row["UserID"] = gen.UserID;
                        ConstantCommon.Generates.Rows.Add(row);
                    }
                }
            } catch { }
        }

        #endregion

        #region Not Wait Async Method
        public static async void GenerateMgr(Generates pGenerate, string pMode) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setGen = await ConstantCommon.client.SetAsync("Generates/" + pGenerate.GUID, pGenerate);
                            //Generates.Refresh_FireBase_Wait();
                            break;
                        }

                    case "EDIT": {
                            FirebaseResponse editGen = await ConstantCommon.client.UpdateAsync("Generates/" + pGenerate.GUID, pGenerate);
                            //Generates.Refresh_FireBase();
                            break;
                        }

                    case "DELETE": {
                            FirebaseResponse delGen = await ConstantCommon.client.DeleteAsync("Generates/" + pGenerate.GUID); //Deletes todos collection
                                                                                                                              //Generates.Refresh_FireBase_Wait();
                            break;
                        }

                    case "GETLAST": {
                            //Task.Run(() => ConstantCommon.client.GetAsync("Licenses/" + pLic.LicenseCode.Replace("@", "/"))).GetAwaiter().GetResult();
                            FirebaseResponse response = ConstantCommon.client.Get("Generates/" + pGenerate.GUID);
                            pGenerate = response.ResultAs<Generates>();
                            break;
                        }
                }
            } catch { }
        }

        public async static void Refresh_FireBase() {
            try {

                FirebaseResponse resGen = await ConstantCommon.client.GetAsync("Generates/");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resGen.Body);

                if (data != null) {
                    ConstantCommon.Generates.Clear();

                    List<Generates> item = new List<Generates>();
                    foreach (var itemDynamic in data) {
                        Generates gen = JsonConvert.DeserializeObject<Generates>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Generates.NewRow();
                        row["GUID"] = gen.GUID;
                        row["UserID"] = gen.UserID;
                        ConstantCommon.Generates.Rows.Add(row);
                    }
                }
            } catch { }
        }
        #endregion

    }
}
