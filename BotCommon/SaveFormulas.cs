using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotCommon {
    class SaveFormulas {
        #region Init
        public string UserID {
            get; set;
        } // forignkey
        public string KeyName {
            get; set;
        } 
        public int Formula {
            get; set;
        } 
        
        #endregion

        #region Wait Method
        public static void SaveFormulaMgr_Wait(ref SaveFormulas pSaveFormulas, string pMode, bool pIsNewGet = false) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setSaveFormula = ConstantCommon.client.SetAsync($"SaveFormulas/{pSaveFormulas.UserID}/{pSaveFormulas.KeyName}", pSaveFormulas).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                SaveFormulas.Refresh_FireBase_Wait();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editSaveFormula = ConstantCommon.client.UpdateAsync($"SaveFormulas/{pSaveFormulas.UserID}/{pSaveFormulas.KeyName}", pSaveFormulas).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                SaveFormulas.Refresh_FireBase_Wait();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delSaveFormula = ConstantCommon.client.DeleteAsync($"SaveFormulas/{pSaveFormulas.UserID}/{pSaveFormulas.KeyName}").GetAwaiter().GetResult(); //Deletes todos collection
                            if (pIsNewGet)
                                SaveFormulas.Refresh_FireBase_Wait();
                            break;
                        }
                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get($"SaveFormulas/{pSaveFormulas.UserID}/{pSaveFormulas.KeyName}");
                            pSaveFormulas = response.ResultAs<SaveFormulas>();
                            break;
                        }

                }
            } catch { }
        }
        public static void Refresh_FireBase_Wait() {
            try {

                FirebaseResponse resUser = ConstantCommon.client.GetAsync("Users/").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resUser.Body);

                if (data != null) {
                    ConstantCommon.Users.Clear();
                    foreach (var itemDynamic in data) {
                        Users u = JsonConvert.DeserializeObject<Users>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Users.NewRow();
                        row["UserID"] = u.UserID;
                        row["Name"] = u.Name;
                        row["Credit"] = u.Credit;
                        row["WinRate"] = u.WinRate;
                        row["LoseRate"] = u.LoseRate;
                        row["CreditLimit"] = u.CreditLimit;
                        if (ConstantCommon.Users.Select($"UserID = '{u.UserID}'").Length == 0)
                            ConstantCommon.Users.Rows.Add(row);

                    }
                }
            } catch { }
        }

        #endregion

        #region Not Wait Async Method
        public static async void UserMgr(Users pUser, string pMode, DataGridView pGrid = null, bool pIsNewGet = false) {
            try {
                switch (pMode) {
                    case "ADD": {
                            SetResponse setUser = await ConstantCommon.client.SetAsync("Users/" + pUser.UserID, pUser);
                            if (pIsNewGet)
                                Users.Refresh_FireBase();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editUser = await ConstantCommon.client.UpdateAsync("Users/" + pUser.UserID, pUser);
                            if (pIsNewGet)
                                Users.Refresh_FireBase();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delUser = await ConstantCommon.client.DeleteAsync("Users/" + pUser.UserID); //Deletes todos collection
                            if (pIsNewGet)
                                Users.Refresh_FireBase();
                            break;
                        }

                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get("Users/" + pUser.UserID);
                            pUser = response.ResultAs<Users>();
                            break;
                        }

                }
                if (pGrid != null)
                    LoadDataGridView.LoadGrid(pGrid);
            } catch { }
        }
        public static async void Refresh_FireBase(DataGridView pGrid = null) {
            try {

                FirebaseResponse resUser = await ConstantCommon.client.GetAsync("Users/");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resUser.Body);

                if (data != null) {
                    ConstantCommon.Users.Clear();
                    foreach (var itemDynamic in data) {
                        Users u = JsonConvert.DeserializeObject<Users>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Users.NewRow();
                        row["UserID"] = u.UserID;
                        row["Name"] = u.Name;
                        row["Credit"] = u.Credit;
                        row["WinRate"] = u.WinRate;
                        row["LoseRate"] = u.LoseRate;
                        row["CreditLimit"] = u.CreditLimit;
                        if (ConstantCommon.Users.Select($"UserID = '{u.UserID}'").Length == 0)
                            ConstantCommon.Users.Rows.Add(row);

                    }
                }
                if (pGrid != null)
                    LoadDataGridView.LoadGrid(pGrid);
            } catch { }
        }
        public static void getShowUser() {
            try {

                FirebaseResponse resUser = ConstantCommon.client.GetAsync("Users/").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resUser.Body);

                if (data != null) {
                    foreach (var itemDynamic in data) {
                        DataRow row = ConstantCommon.UserShow.NewRow();
                        Users u = JsonConvert.DeserializeObject<Users>(((JProperty)itemDynamic).Value.ToString());
                        row["UserID"] = u.UserID;
                        row["Name"] = u.Name;
                        row["Credit"] = u.Credit;
                        row["WinRate"] = u.WinRate;
                        row["LoseRate"] = u.LoseRate;
                        row["CreditLimit"] = u.CreditLimit;
                        ConstantCommon.UserShow.Rows.Add(row);
                    }

                }
            } catch { }
        }
        #endregion
    }
}
