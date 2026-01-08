using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class LineBots {
        #region Init
        public string LineID { get; set; }
        public string UserID { get; set; }
        public string Data { get; set; }
        #endregion

        #region Wait Method
        public static void LineBotMgr_Wait(ref LineBots pLineBot, string pMode) {
            switch (pMode) {
                case "ADD": {
                        SetResponse setLineBot = ConstantCommon.client.SetAsync("LineBots/" + pLineBot.LineID, pLineBot).GetAwaiter().GetResult();
                        break;
                    }
                case "EDIT": {
                        FirebaseResponse editLineBot = ConstantCommon.client.UpdateAsync("LineBots/" + pLineBot.LineID, pLineBot).GetAwaiter().GetResult();
                        break;
                    }
                case "DELETE": {
                        FirebaseResponse delLineBot = ConstantCommon.client.DeleteAsync("LineBots/" + pLineBot.LineID).GetAwaiter().GetResult(); //Deletes todos collection
                        break;
                    }
                case "GETLAST": {
                        //Task.Run(() => ConstantCommon.client.GetAsync("Licenses/" + pLic.LicenseCode.Replace("@", "/"))).GetAwaiter().GetResult();
                        FirebaseResponse response = ConstantCommon.client.GetAsync("LineBots/" + pLineBot.LineID).GetAwaiter().GetResult();
                        pLineBot = response.ResultAs<LineBots>();
                        break;
                    }
            }
        }

        public static void Refresh_FireBase_Wait() {
            FirebaseResponse resLineBot = ConstantCommon.client.GetAsync("LineBots/").GetAwaiter().GetResult();
            dynamic data = JsonConvert.DeserializeObject<dynamic>(resLineBot.Body);

            if (data != null) {
                ConstantCommon.LineBots.Clear();
                foreach (var itemDynamic in data) {
                    LineBots line = JsonConvert.DeserializeObject<LineBots>(((JProperty)itemDynamic).Value.ToString());
                    DataRow row = ConstantCommon.LineBots.NewRow();
                    row["LineID"] = line.LineID;
                    row["UserID"] = line.UserID;
                    row["data"] = line.Data;
                    ConstantCommon.LineBots.Rows.Add(row);
                }
            }
        }

        #endregion

        #region Not Wait Async Method
        public static async void LineBotMgr(LineBots pLineBot, string pMode) {
            switch (pMode) {
                case "ADD": {
                        SetResponse setLineBot = await ConstantCommon.client.SetAsync("LineBots/" + pLineBot.LineID, pLineBot);
                        LineBots.Refresh_FireBase_Wait();
                        break;
                    }

                case "EDIT": {
                        FirebaseResponse editLineBot = await ConstantCommon.client.UpdateAsync("LineBots/" + pLineBot.LineID, pLineBot);
                        LineBots.Refresh_FireBase();
                        break;
                    }

                case "DELETE": {
                        FirebaseResponse delLineBot = await ConstantCommon.client.DeleteAsync("LineBots/" + pLineBot.LineID); //Deletes todos collection
                        LineBots.Refresh_FireBase_Wait();
                        break;
                    }

                case "GETLAST": {
                        //Task.Run(() => ConstantCommon.client.GetAsync("Licenses/" + pLic.LicenseCode.Replace("@", "/"))).GetAwaiter().GetResult();
                        FirebaseResponse response = await ConstantCommon.client.GetAsync("LineBots/" + pLineBot.LineID);
                        pLineBot = response.ResultAs<LineBots>();
                        break;
                    }
            }
        }

        public async static void Refresh_FireBase() {
            FirebaseResponse resLineBot = await ConstantCommon.client.GetAsync("LineBots/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(resLineBot.Body);

            if (data != null) {
                ConstantCommon.LineBots.Clear();

                List<LineBots> item = new List<LineBots>();
                foreach (var itemDynamic in data) {
                    LineBots line = JsonConvert.DeserializeObject<LineBots>(((JProperty)itemDynamic).Value.ToString());
                    DataRow row = ConstantCommon.LineBots.NewRow();
                    row["LineID"] = line.LineID;
                    row["UserID"] = line.UserID;
                    row["data"] = line.Data;
                    ConstantCommon.LineBots.Rows.Add(row);
                }
            }
        }
        #endregion

    }
}
