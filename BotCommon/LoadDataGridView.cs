using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotCommon {
    public class LoadDataGridView {
        public static DataTable Get_GridMain() {
            try {

                //var rowDataLeftOuter = from rowLeft in ConstantCommon.db_firebase.Tables["Users"].AsEnumerable()
                //                       join rowRight in ConstantCommon.db_firebase.Tables["Licenses"].AsEnumerable() on rowLeft["UserID"] equals rowRight["UserID"] into gj
                //                       from subRight in gj.DefaultIfEmpty()
                //                       select rowLeft.ItemArray.Concat((subRight == null) ? (ConstantCommon.db_firebase.Tables["Licenses"].NewRow().ItemArray) : subRight.ItemArray).ToArray();

                //DataTable tbl = new DataTable();
                //tbl.Columns.Add("LicenseCode", typeof(string));
                //tbl.Columns.Add("UserName", typeof(string));
                //tbl.Columns.Add("LicenseType", typeof(string));
                //tbl.Columns.Add("StartDate", typeof(DateTime));
                //tbl.Columns.Add("EndDate", typeof(DateTime));
                //tbl.Columns.Add("LimitNo", typeof(int));
                //tbl.Columns.Add("IsActive", typeof(string));
                //tbl.Columns.Add("WinRate", typeof(int));
                //tbl.Columns.Add("LoseRate", typeof(int));
                //tbl.Columns.Add("CreditLimit", typeof(int));
                ConstantCommon.db_firebase.Tables["GridMain"].Clear();
                //Add row data to dtblResult
                foreach (DataRow dr in ConstantCommon.db_firebase.Tables["Users"].Rows) {
                    DataRow row = ConstantCommon.db_firebase.Tables["GridMain"].NewRow();
                    row["UserID"] = dr["UserID"].ToString();
                    row["UserName"] = dr["Name"].ToString();
                    row["WinRate"] = Convert.ToDecimal(dr["WinRate"]);
                    row["LoseRate"] = Convert.ToDecimal(dr["LoseRate"]);
                    row["CreditLimit"] = Convert.ToDecimal(dr["CreditLimit"]);
                    if (ConstantCommon.db_firebase.Tables["Licenses"].Select("UserID='" + dr["UserID"] + "'").Length > 0) {
                        DataRow rowLic = ConstantCommon.db_firebase.Tables["Licenses"].Select("UserID='" + dr["UserID"] + "'")[0];
                        row["LicenseCode"] = rowLic["LicenseCode"].ToString();
                        row["LicenseType"] = rowLic["LicenseType"].ToString();
                        row["Hour"] = (int)rowLic["Hour"];
                        row["Min"] = (int)rowLic["Min"];
                        row["Sec"] = (int)rowLic["Sec"];
                        row["StartDate"] = ((DateTime)rowLic["StartDate"]).ToString("dd/MM/yyyy");
                        row["EndDate"] = ((DateTime)rowLic["EndDate"]).ToString("dd/MM/yyyy");
                        row["LimitNo"] = (int)rowLic["LimitNo"];
                        row["IsActive"] = rowLic["IsActive"].ToString();
                    }
                    ConstantCommon.db_firebase.Tables["GridMain"].Rows.Add(row);
                }

                //var results = from Users in ConstantCommon.db_firebase.Tables["Users"].AsEnumerable()
                //              join Licenses in ConstantCommon.db_firebase.Tables["Licenses"].AsEnumerable() on Users["UserID"] equals Licenses["UserID"] into gj
                //              from subRight in gj.DefaultIfEmpty()
                //              select new {
                //                  LicenseCode = Licenses["LicenseCode"],
                //                  UserName = Users["Name"],
                //                  LicenseType = Licenses["LicenseType"],
                //                  StartDate = (DateTime)Licenses["StartDate"],
                //                  EndDate = (DateTime)Licenses["EndDate"],
                //                  LimitNo = (int)Licenses["LimitNo"],
                //                  IsActive = Licenses["IsActive"],
                //                  WinRate = (int)Users["WinRate"],
                //                  LoseRate = (int)Users["LoseRate"],
                //                  CreditLimit = (int)Users["CreditLimit"],
                //              };



                //foreach (var item in results) {
                //    DataRow row = ConstantCommon.db_firebase.Tables["GridMain"].NewRow();
                //    row["LicenseCode"] = item.LicenseCode;
                //    row["UserName"] = item.UserName;
                //    row["LicenseType"] = item.LicenseType;
                //    row["StartDate"] = item.StartDate.ToString("dd/MM/yyyy");
                //    row["EndDate"] = item.EndDate.ToString("dd/MM/yyyy");
                //    row["LimitNo"] = item.LimitNo;
                //    row["IsActive"] = item.IsActive;
                //    row["WinRate"] = item.WinRate;
                //    row["LoseRate"] = item.LoseRate;
                //    row["CreditLimit"] = item.CreditLimit;
                //    ConstantCommon.db_firebase.Tables["GridMain"].Rows.Add(row);
                //}
            } catch { }
            return ConstantCommon.db_firebase.Tables["GridMain"];
        }

        public static DataTable Get_GridDetail(string pLicenseCode) {
            try {

                var results = from Licenses in ConstantCommon.db_firebase.Tables["Licenses"].AsEnumerable()
                              join Computers in ConstantCommon.db_firebase.Tables["Computers"].AsEnumerable() on Licenses["LicenseCode"] equals Computers["LicenseCode"]
                              select new {
                                  LicenseCode = Licenses["LicenseCode"],
                                  SerialNumber = Computers["SerialNumber"],
                                  Win = Computers["Win"],
                                  Lose = Computers["Lose"],
                                  WinPoint = Computers["WinPoint"],
                                  LosePoint = Computers["LosePoint"],
                                  Total = Computers["Total"],
                                  FormulaDetail = Computers["FormulaDetail"],
                              };

                ConstantCommon.db_firebase.Tables["GridDetail"].Clear();

                foreach (var item in results) {
                    DataRow row = ConstantCommon.db_firebase.Tables["GridDetail"].NewRow();
                    row["LicenseCode"] = item.LicenseCode;
                    row["SerialNumber"] = item.SerialNumber;
                    row["Win"] = item.Win;
                    row["Lose"] = item.Lose;
                    row["WinPoint"] = item.WinPoint;
                    row["LosePoint"] = item.LosePoint;
                    row["Total"] = item.Total;
                    row["FormulaDetail"] = item.FormulaDetail;
                    ConstantCommon.db_firebase.Tables["GridDetail"].Rows.Add(row);
                }
                if (pLicenseCode != null && ConstantCommon.db_firebase.Tables["GridDetail"].Select("LicenseCode='" + pLicenseCode + "'").Length > 0)
                    return ConstantCommon.db_firebase.Tables["GridDetail"].Select("LicenseCode='" + pLicenseCode + "'").CopyToDataTable();
                else
                    ConstantCommon.db_firebase.Tables["GridDetail"].Clear();
            } catch { }
            return ConstantCommon.db_firebase.Tables["GridDetail"];
        }
        public static void LoadGrid(DataGridView pGrid = null, string pLicenseCode = null) {
            try {

                if (pGrid != null) {
                    switch (pGrid.Name) {
                        case "gridMain":
                            pGrid.DataSource = LoadDataGridView.Get_GridMain();
                            pGrid.Refresh();
                            break;
                        case "gridDetail":
                            pGrid.DataSource = LoadDataGridView.Get_GridDetail(pLicenseCode);
                            pGrid.Refresh();
                            break;
                    }
                }
            } catch { }
        }
        public static DataTable LoadGridHistory(DataTable pData, DateTime pDateFrom, DateTime pDateTo, string pUserID) {
            try {

                pData.Rows.Clear();
                //ConstantCommon.db_firebase.Tables["Logs"].AsEnumerable()
                //                       where w.Field<DateTime>("BetDateTime") >= pDateFrom
                //                            && w.Field<DateTime>("BetDateTime") <= pDateTo
                //var data = ConstantCommon.db_firebase.Tables["Logs"].AsEnumerable()
                //                                .Where(w => w.Field<DateTime>("BetDateTime") >= pDateFrom.ToString("MM/dd/yyyy hh:mm:ss tt")
                //                                            && w.Field<DateTime>("BetDateTime") <= pDateTo).ToList();

                //var data = ConstantCommon.db_firebase.Tables["Logs"].AsEnumerable()
                //                                .Where(w => System.Convert.ToDateTime(w["BetDateTime"]) >= pDateFrom
                //                                            && System.Convert.ToDateTime(w["BetDateTime"]) <= pDateTo).ToList();

                //if (data.c > 0) {
                //    DataTable tbl = ConstantCommon.db_firebase.Tables["Logs"].AsEnumerable()
                //                                .Where(w => System.Convert.ToDateTime(w["BetDateTime"]) >= pDateFrom
                //                                            && System.Convert.ToDateTime(w["BetDateTime"]) <= pDateTo).CopyToDataTable();
                //DataTable tbl = null;
                //if (!string.IsNullOrEmpty(pUserID)) {
                //    if (ConstantCommon.db_firebase.Tables["Logs"].Select().Where(p => (Convert.ToDateTime(p["BetDateTime"]).Date >= pDateFrom.Date)
                //                                                                     && (Convert.ToDateTime(p["BetDateTime"]).Date <= pDateTo.Date)
                //                                                                     && (p["UserID"].ToString() == pUserID)).Count() > 0) {
                //        tbl = ConstantCommon.db_firebase.Tables["Logs"].Select().Where(p => (Convert.ToDateTime(p["BetDateTime"]).Date >= pDateFrom.Date)
                //                                                                    && (Convert.ToDateTime(p["BetDateTime"]).Date <= pDateTo.Date)
                //                                                                    && (p["UserID"].ToString() == pUserID)).OrderBy(r => Convert.ToDateTime(r["BetDateTime"])).CopyToDataTable();
                //    }
                //}
                //else {
                //    if (ConstantCommon.db_firebase.Tables["Logs"].Select().Where(p => (Convert.ToDateTime(p["BetDateTime"]).Date >= pDateFrom.Date)
                //                                                                    && (Convert.ToDateTime(p["BetDateTime"]).Date <= pDateTo.Date)).Count() > 0) {

                //        tbl = ConstantCommon.db_firebase.Tables["Logs"].Select().Where(p => (Convert.ToDateTime(p["BetDateTime"]).Date >= pDateFrom.Date)
                //                                                                                         && (Convert.ToDateTime(p["BetDateTime"]).Date <= pDateTo.Date)).OrderBy(r => Convert.ToDateTime(r["BetDateTime"])).CopyToDataTable();
                //    }

                //}



                if (ConstantCommon.db_firebase.Tables["Logs"].Select().Where(p => (Convert.ToDateTime(p["BetDateTime"]).Date >= pDateFrom.Date)
                                                                                    && (Convert.ToDateTime(p["BetDateTime"]).Date <= pDateTo.Date)
                                                                                    && (p["UserID"].ToString() == pUserID)).Count() > 0) {
                    DataTable data = ConstantCommon.db_firebase.Tables["Logs"].Select().Where(p => (Convert.ToDateTime(p["BetDateTime"]).Date >= pDateFrom.Date)
                                                                                && (Convert.ToDateTime(p["BetDateTime"]).Date <= pDateTo.Date)
                                                                                && (p["UserID"].ToString() == pUserID)).OrderBy(r => Convert.ToDateTime(r["BetDateTime"])).CopyToDataTable();
                    decimal countTotal = 0;
                    int index = 1;
                    pData.Rows.Clear();
                    foreach (DataRow row in data.Rows) {
                        /*  tblHistory.Columns.Add("No", typeof(int));
                            tblHistory.Columns.Add("BetDateTime", typeof(string));
                            tblHistory.Columns.Add("Result", typeof(string));
                            tblHistory.Columns.Add("BetPoint", typeof(int));
                            tblHistory.Columns.Add("Total", typeof(int));
                            tblHistory.Columns.Add("FormulaDetail", typeof(string));
                            tblHistory.Columns.Add("FormulaMoney", typeof(string));
                         */
                        DataRow dr = pData.NewRow();
                        dr["No"] = index++;
                        dr["BetDateTime"] = System.Convert.ToDateTime(row["BetDateTime"]).ToString("dd/MM/yyyy HH:mm:ss");
                        dr["BetPoint"] = System.Convert.ToDecimal(row["Point"]).ToString("N2");
                        if (row["IsWin"].ToString() == "Y") {
                            countTotal += System.Convert.ToDecimal(row["Point"]);
                            dr["Result"] = "Win";
                            dr["Total"] = System.Convert.ToDecimal(countTotal).ToString("N2");
                        } else {
                            countTotal -= System.Convert.ToDecimal(row["Point"]);
                            dr["Result"] = "Lose";
                            dr["Total"] = System.Convert.ToDecimal(countTotal).ToString("N2");
                        }
                        dr["FormulaDetail"] = row["FormulaDetail"].ToString();
                        dr["FormulaMoney"] = row["FormulaMoney"].ToString();
                        pData.Rows.Add(dr);

                    }
                }
            } catch { }
            return pData;


        }
        public static DataTable Get_GridMapSupportUser(string pLicenseCode) {
            DataTable dtResult = new DataTable();
            dtResult.Columns.Add("MemberLicense", typeof(string));
            dtResult.Columns.Add("Name", typeof(string));
            dtResult.Columns.Add("GetMoney", typeof(decimal));
            dtResult.Columns.Add("Price", typeof(decimal));
            dtResult.Columns.Add("Date", typeof(DateTime));
            dtResult.Columns.Add("IsPayToMember", typeof(string));
            try {

                var results = from MapSupport in ConstantCommon.db_firebase.Tables["MapSupportUsers"].AsEnumerable()
                              join LicenseUser in ConstantCommon.db_firebase.Tables["Licenses"].AsEnumerable() on MapSupport.Field<string>("LicenseCode") equals LicenseUser.Field<string>("LicenseCode")
                              join User in ConstantCommon.db_firebase.Tables["Users"].AsEnumerable() on LicenseUser.Field<string>("UserID") equals User.Field<string>("UserID")

                              select dtResult.LoadDataRow(new object[]
                                 {
                                    MapSupport.Field<string>("MemberLicenseCode"),
                                    LicenseUser.Field<string>("LicenseCode"),
                                    User.Field<string>("Name"),
                                    MapSupport.Field<int>("GetMoney"),
                                    MapSupport.Field<int>("Price"),
                                    MapSupport.Field<int>("Date"),
                                    MapSupport.Field<int>("IsPayToMember"),
                                  }, true);
                results.CopyToDataTable();

                if (pLicenseCode != null && dtResult.Select($"LicenseCode='{pLicenseCode}'").Length > 0)
                    return dtResult.Select($"LicenseCode='{pLicenseCode}'").CopyToDataTable();
                dtResult.Clear();

            } catch { }
            return dtResult;
        }
    }
}
