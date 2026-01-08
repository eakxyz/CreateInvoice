using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class Users {

        #region Init
        public string UserID { get; set; } // GUID
        public string Name { get; set; } // GUID
        public int Credit { get; set; } // GUID
        public decimal WinRate { get; set; } // GUID
        public decimal LoseRate { get; set; } // GUID
        public int CreditLimit { get; set; } // GUID
        #endregion

        #region Wait Method
        public static void UserMgr_Wait(ref Users pUser, string pMode, bool pIsNewGet = false) {
            switch (pMode) {
                case "ADD": {
                        SetResponse setUser = ConstantCommon.client.SetAsync("Users/" + pUser.UserID, pUser).GetAwaiter().GetResult();
                        if (pIsNewGet)
                            Users.Refresh_FireBase_Wait();
                        break;
                    }
                case "EDIT": {
                        FirebaseResponse editUser = ConstantCommon.client.UpdateAsync("Users/" + pUser.UserID, pUser).GetAwaiter().GetResult();
                        if (pIsNewGet)
                            Users.Refresh_FireBase_Wait();
                        break;
                    }
                case "DELETE": {
                        FirebaseResponse delUser = ConstantCommon.client.DeleteAsync("Users/" + pUser.UserID).GetAwaiter().GetResult(); //Deletes todos collection
                        if (pIsNewGet)
                            Users.Refresh_FireBase_Wait();
                        break;
                    }
                case "GETLAST": {
                        FirebaseResponse response = ConstantCommon.client.GetAsync("Users/" + pUser.UserID).GetAwaiter().GetResult();
                        pUser = response.ResultAs<Users>();
                        break;
                    }

            }
        }
        public static void Refresh_FireBase_Wait(DataGridView pGrid = null) {
            FirebaseResponse resLicense = ConstantCommon.client.GetAsync("Users/").GetAwaiter().GetResult();
            dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

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
        }
        
        #endregion

        #region Not Wait Async Method
        public static async void UserMgr(Users pUser, string pMode, DataGridView pGrid = null, bool pIsNewGet = false) {
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
                        FirebaseResponse response = await ConstantCommon.client.GetAsync("Users/" + pUser.UserID);
                        pUser = response.ResultAs<Users>();
                        break;
                    }

            }
            if(pGrid != null)
                LoadDataGridView.LoadGrid(pGrid);
        }
        public static async void Refresh_FireBase(DataGridView pGrid = null) {
            FirebaseResponse resLicense = await ConstantCommon.client.GetAsync("Users/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

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
            if(pGrid != null)
                LoadDataGridView.LoadGrid(pGrid);
        }
        public static void getShowUser() {
            FirebaseResponse resLicense = ConstantCommon.client.GetAsync("Users/").GetAwaiter().GetResult();
            dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

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
        }
        #endregion
    }

}