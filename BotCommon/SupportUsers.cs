using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class SupportUsers {

        #region Init
        public string MemberLicenseCode {
            get; set;
        } // GUID
        public string UserName {
            get; set;
        } // UserName
        public string PassWord {
            get; set;
        } // PassWord
        public string LevelUser {
            get; set;
        } // LevelUser
        public int LevelValue {
            get; set;
        } // LevelValue
        public string Email {
            get; set;
        }
        public int CountUser {
            get; set;
        }
        public string BankNumber {
            get; set;
        }
        public string BankName {
            get; set;
        }
        public string Name {
            get; set;
        }
        public string IsRegister {
            get; set;
        }
        public int Ranking {
            get; set;
        }
        public decimal PriceTotal {
            get; set;
        }
        #endregion

        #region Wait Method
        public static void SupportUserMgr_Wait(ref SupportUsers pUser, string pMode, bool pIsNewGet = false) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setUser = ConstantCommon.client.SetAsync("SupportUsers/" + pUser.MemberLicenseCode, pUser).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                SupportUsers.Refresh_FireBase_Wait();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editUser = ConstantCommon.client.UpdateAsync("SupportUsers/" + pUser.MemberLicenseCode, pUser).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                SupportUsers.Refresh_FireBase_Wait();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delUser = ConstantCommon.client.DeleteAsync("SupportUsers/" + pUser.MemberLicenseCode).GetAwaiter().GetResult(); //Deletes todos collection
                            if (pIsNewGet)
                                SupportUsers.Refresh_FireBase_Wait();
                            break;
                        }
                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get("SupportUsers/" + pUser.MemberLicenseCode);
                            pUser = response.ResultAs<SupportUsers>();
                            break;
                        }

                }
            } catch { }
        }
        public static void Refresh_FireBase_Wait() {
            try {

                FirebaseResponse resUser = ConstantCommon.client.GetAsync("SupportUsers/").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resUser.Body);

                if (data != null) {
                    ConstantCommon.SupportUsers.Clear();
                    foreach (var itemDynamic in data) {
                        SupportUsers u = JsonConvert.DeserializeObject<SupportUsers>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.SupportUsers.NewRow();
                        row["MemberLicenseCode"] = u.MemberLicenseCode;
                        row["UserName"] = u.UserName;
                        row["Password"] = u.PassWord;
                        row["Email"] = u.Email;
                        row["CountUser"] = u.CountUser;
                        row["BankNumber"] = u.BankNumber;
                        row["BankName"] = u.BankName;
                        row["Name"] = u.Name;
                        row["Ranking"] = u.Ranking;
                        row["PriceTotal"] = u.PriceTotal;
                        if (ConstantCommon.SupportUsers.Select($"MemberLicenseCode = '{u.MemberLicenseCode}'").Length == 0)
                            ConstantCommon.SupportUsers.Rows.Add(row);

                    }
                }
            } catch { }
        }

        #endregion

        #region Not Wait Async Method
        public static async void SupportUserMgr(SupportUsers pUser, string pMode, bool pIsNewGet = false) {
            try {
                switch (pMode) {
                    case "ADD": {
                            SetResponse setUser = await ConstantCommon.client.SetAsync("SupportUsers/" + pUser.MemberLicenseCode, pUser);
                            if (pIsNewGet)
                                SupportUsers.Refresh_FireBase();
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editUser = await ConstantCommon.client.UpdateAsync("SupportUsers/" + pUser.MemberLicenseCode, pUser);
                            if (pIsNewGet)
                                SupportUsers.Refresh_FireBase();
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delUser = await ConstantCommon.client.DeleteAsync("SupportUsers/" + pUser.MemberLicenseCode); //Deletes todos collection
                            if (pIsNewGet)
                                SupportUsers.Refresh_FireBase();
                            break;
                        }

                    case "GETLAST": {
                            FirebaseResponse response = ConstantCommon.client.Get("SupportUsers/" + pUser.MemberLicenseCode);
                            pUser = response.ResultAs<SupportUsers>();
                            break;
                        }

                }
            } catch { }
        }
        public static async void Refresh_FireBase() {
            try {

                FirebaseResponse resUser = await ConstantCommon.client.GetAsync("SupportUsers/");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resUser.Body);

                if (data != null) {
                    ConstantCommon.SupportUsers.Clear();
                    foreach (var itemDynamic in data) {
                        SupportUsers u = JsonConvert.DeserializeObject<SupportUsers>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Users.NewRow();
                        row["MemberLicenseCode"] = u.MemberLicenseCode;
                        row["UserName"] = u.UserName;
                        row["Password"] = u.PassWord;
                        row["Email"] = u.Email;
                        row["CountUser"] = u.CountUser;
                        row["BankNumber"] = u.BankNumber;
                        row["BankName"] = u.BankName;
                        row["Name"] = u.Name;
                        row["Ranking"] = u.Ranking;
                        row["PriceTotal"] = u.PriceTotal;
                        if (ConstantCommon.SupportUsers.Select($"MemberLicenseCode = '{u.MemberLicenseCode}'").Length == 0)
                            ConstantCommon.SupportUsers.Rows.Add(row);

                    }
                }
            } catch { }
        }
        
        #endregion
    }

}