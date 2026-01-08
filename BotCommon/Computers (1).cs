using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class Computers {

        #region Init
        public string SerialNumber { get; set; } // GUID
        public string LicenseCode { get; set; } // GUID
        public decimal Win { get; set; } // GUID
        public decimal Lose { get; set; } // GUID
        public decimal WinPoint { get; set; } // GUID
        public decimal LosePoint { get; set; } // GUID
        public decimal Total { get; set; } // GUID
        public string FormulaDetail { get; set; } // GUID
        #endregion

        #region Wait Method
        public static void ComputerMgr_Wait(ref Computers pCom, string pMode) {
            switch (pMode) {
                case "ADD": {
                        SetResponse setLicense = ConstantCommon.client.SetAsync("Computers/" + pCom.LicenseCode.Replace("/", "@") + "/" + pCom.SerialNumber, pCom).GetAwaiter().GetResult();
                        //Computers.Refresh_FireBase_Wait();
                        break;
                    }

                case "EDIT": {
                        FirebaseResponse editLicense = ConstantCommon.client.UpdateAsync("Computers/" + pCom.LicenseCode.Replace("/", "@") + "/" + pCom.SerialNumber, pCom).GetAwaiter().GetResult();
                        //Computers.Refresh_FireBase_Wait();
                        break;
                    }

                case "DELETE": {
                        FirebaseResponse delLicense = ConstantCommon.client.DeleteAsync("Computers/" + pCom.LicenseCode.Replace("/", "@") + "/" + pCom.SerialNumber).GetAwaiter().GetResult(); //Deletes todos collection
                        //Computers.Refresh_FireBase_Wait();
                        break;
                    }
                case "DELETE_LICENSE": {
                        FirebaseResponse delLicense = ConstantCommon.client.DeleteAsync("Computers/" + pCom.LicenseCode.Replace("/", "@")).GetAwaiter().GetResult(); //Deletes todos collection
                        //Licenses.Refresh_FireBase_Wait();
                        //Computers.Refresh_FireBase(null, pCom.LicenseCode);
                        break;
                    }

                case "GETLAST": {
                        FirebaseResponse response = ConstantCommon.client.GetAsync("Computers/" + pCom.LicenseCode.Replace("/", "@") + "/" + pCom.SerialNumber).GetAwaiter().GetResult();
                        pCom = response.ResultAs<Computers>();
                        if (pCom != null)
                            pCom.LicenseCode = pCom.LicenseCode.Replace("@", "/");
                        break;
                    }
            }
        }
        public static void Refresh_FireBase_Wait(string pLicenseCode = null) {
            ConstantCommon.Computers.Clear();

            if (pLicenseCode != null) {
                Computers.setComputersTable_Wait(pLicenseCode);
            } else {
                foreach (DataRow row in ConstantCommon.Licenses.Rows) {
                    Computers.setComputersTable_Wait(row["LicenseCode"].ToString());
                }
            }
            
            
        }
        public static void setComputersTable_Wait(string pLicenseCode) {
            FirebaseResponse resLicense = ConstantCommon.client.GetAsync("Computers/" + pLicenseCode.Replace("/", "@") + "/").GetAwaiter().GetResult();
            dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

            if (data != null) {
                foreach (var itemDynamic in data) {
                    Computers com = JsonConvert.DeserializeObject<Computers>(((JProperty)itemDynamic).Value.ToString());
                    DataRow rowCom = ConstantCommon.Computers.NewRow();
                    rowCom["SerialNumber"] = com.SerialNumber;
                    rowCom["LicenseCode"] = com.LicenseCode.Replace("@", "/");
                    rowCom["Win"] = com.Win;
                    rowCom["Lose"] = com.Lose;
                    rowCom["WinPoint"] = com.WinPoint;
                    rowCom["LosePoint"] = com.LosePoint;
                    rowCom["Total"] = com.Total;
                    rowCom["FormulaDetail"] = com.FormulaDetail;
                    if (ConstantCommon.Computers.Select($"SerialNumber = '{com.SerialNumber}' AND LicenseCode = '{com.LicenseCode.Replace("@", "/")}'").Length == 0)
                        ConstantCommon.Computers.Rows.Add(rowCom);
                }
            }
        }
        #endregion

        #region Not Wait Async Method
        public static async void ComputerMgr(Computers pCom, string pMode, DataGridView pGrid = null) {
            switch (pMode) {
                case "ADD": {
                        SetResponse setLicense = await ConstantCommon.client.SetAsync("Computers/" + pCom.LicenseCode.Replace("/", "@") + "/" + pCom.SerialNumber, pCom);
                        //Computers.Refresh_FireBase(null, pCom.LicenseCode);
                        break;
                    }

                case "EDIT": {
                        FirebaseResponse editLicense = await ConstantCommon.client.UpdateAsync("Computers/" + pCom.LicenseCode.Replace("/", "@") + "/" + pCom.SerialNumber, pCom);
                        //Computers.Refresh_FireBase(null, pCom.LicenseCode);
                        break;
                    }

                case "DELETE": {
                        FirebaseResponse delLicense = await ConstantCommon.client.DeleteAsync("Computers/" + pCom.LicenseCode.Replace("/", "@") + "/" + pCom.SerialNumber); //Deletes todos collection
                        //Computers.Refresh_FireBase(null, pCom.LicenseCode);
                        break;
                    }
                case "DELETE_LICENSE": {
                        FirebaseResponse delLicense = await ConstantCommon.client.DeleteAsync("Computers/" + pCom.LicenseCode.Replace("/", "@")); //Deletes todos collection
                        //Licenses.Refresh_FireBase_Wait();
                        //Computers.Refresh_FireBase(null, pCom.LicenseCode);
                        break;
                    }

                case "GETLAST": {
                        FirebaseResponse response = await ConstantCommon.client.GetAsync("Computers/" + pCom.LicenseCode.Replace("/", "@") + "/" + pCom.SerialNumber);
                        pCom = response.ResultAs<Computers>();
                        break;
                    }
            }
            LoadDataGridView.LoadGrid(pGrid);
        }

        public static void Refresh_FireBase(DataGridView pGrid = null, string pLicenseCode = null) {
            ConstantCommon.Users.Clear();
            if (pLicenseCode != null) {
                Computers.setComputersTable(pLicenseCode);
            } else {
                foreach (DataRow row in ConstantCommon.Licenses.Rows) {
                    Computers.setComputersTable(row["LicenseCode"].ToString());
                }
            }
            
            LoadDataGridView.LoadGrid(pGrid);



        }
        public async static void setComputersTable(string pLicenseCode) {
            FirebaseResponse resLicense = await ConstantCommon.client.GetAsync("Computers/" + pLicenseCode.Replace("/", "@") + "/");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

            if (data != null) {
                List<Computers> item = new List<Computers>();
                foreach (var itemDynamic in data) {
                    Computers com = JsonConvert.DeserializeObject<Computers>(((JProperty)itemDynamic).Value.ToString());
                    DataRow rowCom = ConstantCommon.Computers.NewRow();
                    rowCom["SerialNumber"] = com.SerialNumber;
                    rowCom["LicenseCode"] = com.LicenseCode.Replace("@", "/");
                    rowCom["Win"] = com.Win;
                    rowCom["Lose"] = com.Lose;
                    rowCom["WinPoint"] = com.WinPoint;
                    rowCom["LosePoint"] = com.LosePoint;
                    rowCom["Total"] = com.Total;
                    rowCom["FormulaDetail"] = com.FormulaDetail;
                    if (ConstantCommon.Computers.Select($"SerialNumber = '{com.SerialNumber}' AND LicenseCode = '{com.LicenseCode.Replace("@", "/")}'").Length == 0)
                        ConstantCommon.Computers.Rows.Add(rowCom);

                }
            }
        }
        #endregion

    }
}
