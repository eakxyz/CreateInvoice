using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class Licenses {

        #region Init
        public string LicenseCode { get; set; }
        public string LicenseType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int LimitNo { get; set; }
        public int MaxLimitNo { get; set; }
        public int Hour { get; set; }
        public int Min { get; set; }
        public int Sec { get; set; }
        public string UserID { get; set; }
        public bool IsActive { get; set; }
        public bool IsFullLimit { get; set; }
        public bool IsLostCredit { get; set; }
        #endregion
        
        #region Wait Method
        public static void LicenseMgr_Wait(ref Licenses pLic, string pMode) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setLicense = ConstantCommon.client.SetAsync("Licenses/" + pLic.LicenseCode.Replace("/", "@"), pLic).GetAwaiter().GetResult();
                            //Computers.Refresh_FireBase_Wait();
                            break;
                        }

                    case "EDIT": {
                            FirebaseResponse editLicense = ConstantCommon.client.UpdateAsync("Licenses/" + pLic.LicenseCode.Replace("/", "@"), pLic).GetAwaiter().GetResult();
                            //Computers.Refresh_FireBase_Wait();
                            break;
                        }

                    case "DELETE": {
                            FirebaseResponse delLicense = ConstantCommon.client.DeleteAsync("Licenses/" + pLic.LicenseCode.Replace("/", "@")).GetAwaiter().GetResult(); //Deletes todos collection
                                                                                                                                                                        //Computers.Refresh_FireBase_Wait();
                            break;
                        }

                    case "GETLAST": {
                            //Task.Run(() => ConstantCommon.client.GetAsync("Licenses/" + pLic.LicenseCode.Replace("@", "/"))).GetAwaiter().GetResult();
                            FirebaseResponse response = ConstantCommon.client.Get("Licenses/" + pLic.LicenseCode.Replace("/", "@"));
                            pLic = response.ResultAs<Licenses>();
                            if (pLic != null)
                                pLic.LicenseCode = pLic.LicenseCode.Replace("@", "/");
                            break;
                        }
                }
            } catch { }
        }

        public static void Refresh_FireBase_Wait() {
            try {

                FirebaseResponse resLicense = ConstantCommon.client.GetAsync("Licenses/").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

                if (data != null) {
                    ConstantCommon.Licenses.Clear();
                    foreach (var itemDynamic in data) {
                        Licenses lic = JsonConvert.DeserializeObject<Licenses>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Licenses.NewRow();
                        //DataRow row = ConstantCommon.Licenses.NewRow();
                        row["LicenseCode"] = lic.LicenseCode.Replace("@", "/");
                        row["LicenseType"] = lic.LicenseType;
                        row["StartDate"] = lic.StartDate;
                        row["EndDate"] = lic.EndDate;
                        row["LimitNo"] = lic.LimitNo;
                        row["MaxLimitNo"] = lic.MaxLimitNo;
                        row["UserID"] = lic.UserID;
                        row["IsActive"] = lic.IsActive;
                        row["IsFullLimit"] = lic.IsFullLimit;
                        row["IsLostCredit"] = lic.IsLostCredit;
                        row["Hour"] = lic.Hour;
                        row["Min"] = lic.Min;
                        row["Sec"] = lic.Sec;
                        if (ConstantCommon.Licenses.Select($"LicenseCode = '{lic.LicenseCode.Replace("@", "/")}'").Length == 0)
                            ConstantCommon.Licenses.Rows.Add(row);
                    }
                }
            } catch { }
        }

        #endregion

        #region Not Wait Async Method
        public static async void LicenseMgr(Licenses pLic, string pMode, DataGridView pGrid = null) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setLicense = await ConstantCommon.client.SetAsync("Licenses/" + pLic.LicenseCode.Replace("/", "@"), pLic);
                            //Licenses.Refresh_FireBase_Wait();
                            break;
                        }

                    case "EDIT": {
                            FirebaseResponse editLicense = await ConstantCommon.client.UpdateAsync("Licenses/" + pLic.LicenseCode.Replace("/", "@"), pLic);
                            //Licenses.Refresh_FireBase();
                            break;
                        }

                    case "DELETE": {
                            FirebaseResponse delLicense = await ConstantCommon.client.DeleteAsync("Licenses/" + pLic.LicenseCode.Replace("/", "@")); //Deletes todos collection
                            Computers com = new Computers();
                            com.LicenseCode = pLic.LicenseCode;
                            Computers.ComputerMgr(com, "DELETE_LICENSE");
                            //Licenses.Refresh_FireBase_Wait();
                            //Computers.Refresh_FireBase_Wait();
                            break;
                        }

                    case "GETLAST": {
                            //Task.Run(() => ConstantCommon.client.GetAsync("Licenses/" + pLic.LicenseCode.Replace("@", "/"))).GetAwaiter().GetResult();
                            FirebaseResponse response = ConstantCommon.client.Get("Licenses/" + pLic.LicenseCode.Replace("/", "@"));
                            pLic = response.ResultAs<Licenses>();
                            break;
                        }
                }
                LoadDataGridView.LoadGrid(pGrid);
            } catch { }
        }

        public async static void Refresh_FireBase(DataGridView pGrid = null) {
            try {

                FirebaseResponse resLicense = await ConstantCommon.client.GetAsync("Licenses/");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resLicense.Body);

                if (data != null) {
                    ConstantCommon.Licenses.Clear();

                    List<Licenses> item = new List<Licenses>();
                    foreach (var itemDynamic in data) {
                        Licenses lic = JsonConvert.DeserializeObject<Licenses>(((JProperty)itemDynamic).Value.ToString());
                        DataRow row = ConstantCommon.Licenses.NewRow();
                        row["LicenseCode"] = lic.LicenseCode.Replace("@", "/");
                        row["LicenseType"] = lic.LicenseType;
                        row["StartDate"] = lic.StartDate;
                        row["EndDate"] = lic.EndDate;
                        row["LimitNo"] = lic.LimitNo;
                        row["MaxLimitNo"] = lic.MaxLimitNo;
                        row["UserID"] = lic.UserID;
                        row["IsActive"] = lic.IsActive;
                        row["IsFullLimit"] = lic.IsFullLimit;
                        row["IsLostCredit"] = lic.IsLostCredit;
                        row["Hour"] = lic.Hour;
                        row["Min"] = lic.Min;
                        row["Sec"] = lic.Sec;
                        if (ConstantCommon.Licenses.Select($"LicenseCode = '{lic.LicenseCode.Replace("@", "/")}'").Length == 0)
                            ConstantCommon.Licenses.Rows.Add(row);
                    }
                    LoadDataGridView.LoadGrid(pGrid);
                }
            } catch { }
        }
        #endregion


    }
}