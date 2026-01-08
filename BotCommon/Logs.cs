using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace BotCommon {
    public class Logs {

        #region Init
        public string LogID { get; set; } // GUID
        public string UserID { get; set; } // GUID
        public string DateLog { get; set; } // Win
        public DateTime BetDateTime { get; set; } // GUID
        public string IsWin { get; set; } // Win
        public decimal Point { get; set; } // WinRate
        public string FormulaDetail { get; set; } // แผนที่ใช้เล่น
        public string FormulaMoney { get; set; } // แผนเดินเงินที่ใช้
        #endregion

        #region Wait Method
        
        public static void LogMgr_Wait(ref Logs pLog, string pMode, bool pIsNewGet = false) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setLog = ConstantCommon.client.SetAsync($"Logs/{pLog.UserID}/{pLog.DateLog}/{pLog.LogID}", pLog).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                Logs.Refresh_FireBase_Wait(pLog.UserID, pLog.DateLog);
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editUser = ConstantCommon.client.UpdateAsync($"Logs/{pLog.UserID}/{pLog.DateLog}/{pLog.LogID}", pLog).GetAwaiter().GetResult();
                            if (pIsNewGet)
                                Logs.Refresh_FireBase_Wait(pLog.UserID, pLog.DateLog);
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delUser = ConstantCommon.client.DeleteAsync($"Logs/{pLog.UserID}/{pLog.DateLog}").GetAwaiter().GetResult(); //Deletes todos collection
                            if (pIsNewGet)
                                Logs.Refresh_FireBase_Wait(pLog.UserID, pLog.DateLog);
                            break;
                        }
                    case "DELETE_UserID": {
                            FirebaseResponse delLog = ConstantCommon.client.DeleteAsync($"Logs/{pLog.UserID}").GetAwaiter().GetResult(); //Deletes todos collection
                            break;
                        }
                    //case "GETLOG": {
                    //        FirebaseResponse response = ConstantCommon.client.Get($"Logs/{pLog.UserID}/{pLog.DateLog}");
                    //        if (pIsNewGet)
                    //            Logs.Refresh_FireBase_Wait(pLog.UserID, pLog.DateLog);
                    //        break;
                    //    }

                }
            } catch { }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUserID">UserID</param>
        /// <param name="pGetDate">yyyyMMdd Format en-US</param>
        public static void Refresh_FireBase_Wait(string pUserID, string pDateLog, bool pIsClearLog = true) {
            try {
                if (pIsClearLog) {
                    if (ConstantCommon.Logs != null)
                        ConstantCommon.Logs.Clear();
                }
                    
                if (pUserID != null) {
                    Logs.setLogTable_Wait(pUserID, pDateLog);
                } 
                //else {
                    //foreach (DataRow row in ConstantCommon.Users.Rows) {
                    //    Logs.setLogTable_Wait(row["UserID"].ToString(), pDateLog);
                    //}
                //}
            } catch { }
        }
        public static void setLogTable_Wait(string pUserID, string pDateLog) {
            try {

                FirebaseResponse resLog = ConstantCommon.client.GetAsync($"Logs/{pUserID}/{pDateLog}").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resLog.Body);

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
                        row["DateLog"] = l.DateLog;
                        if (ConstantCommon.Logs.Select($"LogID = '{l.LogID}'").Length == 0)
                            ConstantCommon.Logs.Rows.Add(row);

                    }
                }
            } catch { }
        }
        public static void Refresh_FireBase_Wait(string pUserID) {
            try {

                ConstantCommon.Logs.Clear();
                if (pUserID != null) {
                    Logs.setLogTable_Wait(pUserID);
                } else {
                    foreach (DataRow row in ConstantCommon.Users.Rows) {
                        Logs.setLogTable_Wait(row["UserID"].ToString());
                    }
                }
            } catch { }
        }
        public static void setLogTable_Wait(string pUserID) {
            try {

                FirebaseResponse resLog = ConstantCommon.client.GetAsync($"Logs/{pUserID}").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resLog.Body);

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
                        row["DateLog"] = l.DateLog;
                        if (ConstantCommon.Logs.Select($"LogID = '{l.LogID}'").Length == 0)
                            ConstantCommon.Logs.Rows.Add(row);

                    }
                }
            } catch { }
        }

        #endregion

        #region Not Wait Async Method
        public static async void LogMgr(Logs pLog, string pMode, bool pIsNewGet = false) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setLog = await ConstantCommon.client.SetAsync($"Logs/{pLog.UserID}/{pLog.DateLog}/{pLog.LogID}", pLog);
                            if (pIsNewGet)
                                Logs.Refresh_FireBase(pLog.UserID, pLog.DateLog);
                            break;
                        }
                    case "EDIT": {
                            FirebaseResponse editLog = await ConstantCommon.client.UpdateAsync($"Logs/{pLog.UserID}/{pLog.DateLog}/{pLog.LogID}", pLog);
                            if (pIsNewGet)
                                Logs.Refresh_FireBase(pLog.UserID, pLog.DateLog);
                            break;
                        }
                    case "DELETE": {
                            FirebaseResponse delLog = await ConstantCommon.client.DeleteAsync($"Logs/{pLog.UserID}/{pLog.DateLog}/{pLog.LogID}"); //Deletes todos collection
                            if (pIsNewGet)
                                Logs.Refresh_FireBase(pLog.UserID, pLog.DateLog);
                            break;
                        }
                    case "DELETE_UserID": {
                            FirebaseResponse delLog = await ConstantCommon.client.DeleteAsync($"Logs/{pLog.UserID}"); //Deletes todos collection
                            break;
                        }
                    case "DELETE_ALL": {
                            FirebaseResponse delLog = await ConstantCommon.client.DeleteAsync($"Logs"); //Deletes todos collection
                            break;
                        }
                    case "GETLOG": {
                            FirebaseResponse response = ConstantCommon.client.Get($"Logs/{pLog.UserID}/{pLog.DateLog}");
                            if (pIsNewGet)
                                Logs.Refresh_FireBase(pLog.UserID, pLog.DateLog);
                            break;
                        }

                }
            } catch { }
        }
        public static  void Refresh_FireBase(string pUserID, string pDateLog) {
            try {

                ConstantCommon.Logs.Clear();
                if (pUserID != null) {
                    Logs.setLogTable(pUserID, pDateLog);
                } else {
                    foreach (DataRow row in ConstantCommon.Users.Rows) {
                        Logs.setLogTable(row["UserID"].ToString(), pDateLog);
                    }
                }
            } catch { }
        }

        public static async void setLogTable(string pUserID, string pDateLog) {
            try {
                FirebaseResponse resLog = await ConstantCommon.client.GetAsync($"Logs/{pUserID}/{pDateLog}");
                dynamic data = JsonConvert.DeserializeObject<dynamic>(resLog.Body);

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
                        row["DateLog"] = l.DateLog;
                        if (ConstantCommon.Logs.Select($"LogID = '{l.LogID}'").Length == 0)
                            ConstantCommon.Logs.Rows.Add(row);
                    }
                }
            } catch { }
        }
        public static void clearLog() {
            try {
                //ConstantCommon.client.DeleteAsync($"Logs").GetAwaiter().GetResult();
                string[] test2 = new string[] {
"20211113",
"20211114",
"20211115",
"20211116",
"20211117",
"20211118",
"20211119",
"20211120",
"20211121",
"20211122",
"20211123",
"20211124",
"20211125",
"20211126",
"20211127",
"20211128",
"20211129",
"20211130",
"20211201",
"20211202",
"20211203",
"20211204",
"20211205",
"20211206",
"20211207",
"20211208",
"20211209",
"20211210",
"20211211",
"20211212",
"20211213",
"20211214",
"20211215",
"20211216",
"20211217",
"20211218",
"20211219",
"20211220",
"20211221",
"20211222",
"20211223",
"20211224",
"20211225",
"20211226",
"20211227",
"20211228",
"20211229",
"20211230",
"20211231",
"20220101",
"20220102",
"20220103",
"20220104",
"20220105",
"20220106",
"20220107",
"20220108",
"20220109",
"20220110",
"20220111",
"20220112",
"20220113",
"20220114",
"20220115",
"20220116",
"20220117",
"20220118",
"20220119",
"20220120",
"20220121",
"20220122",
"20220123",
"20220124",
"20220125",
"20220126",
"20220127",
"20220128",
"20220129",
"20220130",
"20220131",
"20220201",
"20220202",
"20220203",
"20220204",
"20220205",
"20220206",
"20220207",
"20220208",
"20220209",
"20220210",
"20220211",
"20220212",
"20220213",
"20220214",
"20220215",
"20220216",
"20220217",
"20220218",
"20220219",
"20220220",
"20220221",
"20220222",
"20220223",
"20220224",
"20220225",
"20220226",
"20220227",
"20220228",
"20220301",
"20220302",
"20220303",
"20220304",
"20220305",
"20220306",
"20220307",
"20220308",
"20220311",
"20220312",
"20220314",
"20220315",
"20220316",
"20220317",
"20220318",
"20220318",
"20220319",
"20220320",
"20231205",
"20231206",
"20231207",
"20231208",
"20231209",
"20240126",
"20240127",
"20240128",
"20240129",
"20240130",
"20240131",
"20240205",
"20240206",
"20240207",
"20240217",
"20240218",
"20240219",
"20240220",
"20240221",
"20240222",
"20240223",
"20240224",
"20240225",
"20240226",
"20240227",
"20240228",
"20240229",
"20240301",
"20240302",
"20240303",
"20240304",
"20240305",
"20240306",
"20240307",
"20240308",
"20240309",
"20240310",
"20240316",
"20240317",
"20240318",
"20240319",
"20240320",
"20240321",
"20240322",
"20240323",
"20240324",
"20240325",
"20240326",
"20240327",
"20240328",
"20240329",
"20240330",
"20240331",
"20240401",
"20240402",
"20240403",
"20240404",
"20240405",
"20240406",
"20240407",
"20240628",
"20240629",
"20240630",
"20240701",
"20240702",
"20240703",
"20240704",
"20240705",
"20240706",
"20240707",
"20240708",
"20240802",
"20240803",
"20240804",
"20240805" };
        string[] test = new string[] {
"03f95c2b72f94681b659f2f183b8a4b8",
"03fa16e0d5454f778110b6c80ed89f91",
"03fa210655c7488680ddca1e7def3851",
"03fab2a1d50a4f158ad6311f6d823313",
"03fab2e659f348bf99613a72740a979b",
"03fadc85530a42f5b26809a3c97166a3",
"03fb7f003517486e809fb625f3214103",
"03fb949d895946f4a3f6b36ecc988615",
"03fc3ae9638d45b88186cb03776ed0cc",
"03fca84e55774abea6f076aa24b8880a",
"03fd3991d20f4ef3bcf7e325d1fd4cf1",
"03fd9e3095324137bfb814e3d5091403",
"03fe082b98f94a339f180972d0a3b397",
"03fe822d3c2f47e688ee77c0baa5fb04",
"03fed7845a57430da5ab3554808b3322",
"03ffadcfb17e48e08e8a7299986f2a11",
"03ffd21974984ea79cd356fb1e1e77e1",
"03fff5346d8044628c43e334373d54f9",
"040029a58e53456e8895ba65a5581654",
"04005157fa014229a8b418ee22946c43",
"0400a4774e5349189de51518105e52c0",
"0400b769682e40029e8523ba9c8d92d7",
"04014aafd6a64b9c9f8e65bdc1af3a42",
"040183d0a6b444f29b9381b5c4d67d97",
"0401a0b740c742feb14e56ca581c3eda",
"0401a399812a4dcfbe2abddda24c6bdd",
"0401c47290914be1848e497abc57b900",
"040207bd58aa47b2b784ebd95b910c1c",
"040211f431424df1a57626fad49ad601",
"0402134c9eb44f23a4d01f137ed491a3",
"040227319d534d70947bf54d567604ef",
"040257e980ab4f1d9a2dde5418686d10",
"0402852a821848ba82e431303ae65243",
"0402861b59b649a091c3d12baf66ce64",
"040347a19c8c4bec8fcbdeb2a1552212",
"0403535b6ae2460ab509c8762f6db0ec",
"04036c690dc94d5b8ac54b81571016a6",
"040386266f99413a81647bde99d26bf0",
"0403a2554544442f85ed174f30e0371c",
"0403d03fdaeb4b8aaa8e99ed26237768",
"0403fe79446146e9bc973d99ad6398d8",
"040474cae9f04636b52ed412ad7d79b3",
"040492af94974b2c963749d402a42115",
"04049d342dfd473980fabace1bb82087",
"0404bf1f7af740948a02ed0a07c27467",
"0404c6bd5a554e1b819ed3f9573a2717",
"0404d3b263a6442090915432e96ddf17",
"0404eb1120c74965a56b85670f214d4e",
"040540641c524f9985d8875e67052960",
"0405523989f34e0484551f3fb204b8e1",
"040558c2afc648999037ed738c6300e7",
"04056896d6604a928a1d23a1dac69879",
"04056dad7e2f46fd868a2e5e78cf8db1",
"04057a260bec4467a0fd1e031e97d130",
"04058101d31644dea9f66bb83626d1af",
"04059484549d4dc2b054ad69a693fa44",
"0406463c1e7c475ebd89b4a1be9fea2e",
"0406698a2ec04f5e979c9554b959abc5",
"040677e17fa949c8a300d5faed0a5d2a",
"0406ce1c49eb46c389f8905ae6d2f3b1",
"040743e162584862bae4cf031f9ae14f",
"040763080ba449eeaf9ee7682e4515d8",
"0407c952ac8b49c5bd28a8d5798e638f",
"0408066110824cab90682ffff415c10f",
"04085854509740dd930b44d7430c221b",
"0408924c03a742b98451d84cafd91f6a",
"0408d1d39ce74ca481e67235579054ef",
"0408ecbbc1e24597a5d02f460c4a17a1",
"040921e0c2544d2083c44e7d3c5d1ccb",
"0409253b46c54568a53e48f7a9641a79",
"04096b0e4f744066a799efaa2aa4f7ef",
"0409b85cc2134c248b6a6478a23f6895",
"0409f8c287b4495dbe28200392ab3e2c",
"040a790f3ef94e4db61c67ba68ec2e8d",
"040ac0c93b78464abd066cd81c22c89f",
"040aca18bf154ac580edb363bd9d6a2f",
"040af4e0ebdb4ff7b0a6ba7c39da2030",
"040af6640d4f47b88657b318749b4970",
"040b586ecaeb4b98b1eb5542a241d6e6",
"040b71609f0b48ceacd10bc65e71781d",
"040b93e7a7bd4485ab4bc49da0fae0a8",
"040bd3a759fe426ebb066b63c31975c6",
"040c09430c494188bd1bdd852c7b19ac",
"040c3c1cff694b6588ecacfd9bce2a30",
"040c3cd4e07f41f08ab19db7212f5656",
"040cb03df2294d8fb987cbf6a19ba17b",
"040ced20994f4282a99944eb2218caa3",
"040d7e7af8db4793a77a6015105d47ed",
"040dc1c0be5d4f81a0ff6e7894484967",
"040dc6d773544495a770fd98c0ee326f",
"040e66bec9254b20b4826cb614348ed2",
"040f67d10b9749c7b6ed7e8cdab45208",
"040fc8bb671a4538993dc149f7aa3646",
"04101c2519744f14a638d66d023c2221",
"041046376b234440b2297c7f83cc061b",
"041047f154f4401eaabfd66d1b8f4c9c",
"041153d4dfde417cb52fd725de571532",
"0412ab1c50504f5c807f294d3d983c26",
"0412affaac654b518ef05b3ae227c371",
"0412e233118b4512b8f8aa04dda52237",
"041321805e534262b6aa3959a088fd7a",
"04134c2f51564b66b2d7ad5765b3ffb9",
"04149ce0586642e291ff15cfc37b4335",
"0414c5fe1ae94fae8c94ea39323ff9ea",
"0414cbaae83849d19ccdbcb644a9191c",
"0414d6063f454d9e851f7f7231eb5e49",
"04151d10945945c7925e8513d50c3752",
"04155ab1a39547ba95386624b1d9f637",
"04159ebfea5240df8c83295aec6a9026",
"0415c105bcb04a13aeb7a379785c7363",
"04165b6b7062407cace6e804fb44cdca",
"0416fd94084f47b2a78db87c0bd30808",
"04172da92f014381b8ba3329eda6787e",
"0417373edf804a0b80892c9c6573bf01",
"041769244d47468cbc9274fcf541761a",
"041796e6b8fe41219f31257b30a070c8",
"0417a2584ee54509b81dc5eccb45ebbb",
"041882c1f95848c7badbc7502e4a4416",
"0418a6673c664f93ba60e3122ef3ca48",
"0418d058312342ff83953f6249a53abc",
"04195c4420ec4877aa62cc516fd2bdbe",
"0419e09a9665407f980885f12f7d02f0",
"041a769cc6ce470c9d368711bb6a406c",
"041b4bbc7db3480bbb1e4bb2d076e71a",
"041b7f06f35c4996907225a4ffc6b76e",
"041b9c94d4d24db2be70a505813560ac",
"041ba24b501b4f849734cbac41d53467",
"041c51d13f534f1e8bb6957d54cd3f9d",
"041c523c7134424f979c2d8f25cf0359",
"041c752ed6a84b9292bcd1b19fd2ec54",
"041cb11fd8374f2ebf70880fa13d2756",
"041cc0ec64ce49a3a42030f6b1e0c9fb",
"041cffd8822e4fc98004004412508cef",
"041d03a93d4c424fb62d93c6c8da012e",
"041d35f1bec249fea9e07fbecc1c8dd1",
"041d6fe26f894cb49682e9666f4d7067",
"041de9f925c64d488e5d1da5ede58460",
"041e2131e7bd4fd89cd0132b1ce1559f",
"041e222098ac4334b059c0587e69315a",
"041e93d304b5482c89c2f39d36e8b993",
"041ea1c052ec4534a0cc40368949b249",
"041ec6b17a154ca6961da30013795594",
"041ecf83617b4f059a40ab11af51f40c",
"041ed8055cf04f45aaca20cbdbe5819d",
"041effc120c14830bb5df211109e2804",
"041f25a360e44fc3a5c41c3296ae5301",
"041f6fab63d44e0fb7265ca4ba78cbc3",
"041f99b46343438fa82e987bf7c76d44",
"041fc27e6b914de3bc336b452d5bb91f",
"0420212f534f4f0d8ccb1c39e58417d3",
"042034a319024cf188d36f8b7d827668",
"04204177bfd74399a70d7bd3431af72e",
"04207a537a9a4802a26424211c478273",
"0420b2885f6041ee8f35b0e2987e9b15",
"0420f9f6c3e34ae683b20dba7b2697e8",
"04211459c08644299338b62282d409e5",
"042166cbadaf444588917da46c91a071",
"04219b741f234c29ab5b67f922db2eba",
"0421d16b7bed4267a8504e6e33b2e67c",
"04222f9df41145aa9107811b5f08517c",
"04225e45cedc42039042a32d850ee9da",
"042267747b534434af9f754da7cd0dc5",
"0422c02aa2e04e6fb9af1e1bf518a452",
"04231e224e664484b0c1868a6f007fd8",
"042357c0a09e4b8baed000bec211e659",
"0423be1e1888420e809e9240268cc641",
"042436c66e384af38a83467c7bfef6c0",
"04248f10de9d407fae9a02ddd84485f7",
"04250e1a3362431f87ec651498e43fef",
"04259f87e05943ae83202caf191e9689",
"0425e1a4361546438b7a75c638bebb18",
"0425fb76374a4664a63b0c688a7a97f8",
"04262c39dedf47aeb41e394440b29156",
"0426b39b11b04c99abd6f6562d21eeb0",
"0426f85ca17f4bda8cf23056fe4c4fad",
"042710ad7dd945f3a2e4d50e8c8bf3d1",
"042728024266498d9635203bb9f56caa",
"0427409806b748c59c5e08dcb3883e7a",
"04277a49b74844bb9e856e2da19d3654",
"04278edfe031489ea9d41f72ea81a5d4",
"0427bbeb34b14effa8591a67d34ee448",
"0427c7b53f1f44f9a88fde7c8257d1c0",
"0427ca67de3848679d6afbfbc30e3206",
"0427d0613dec45cfaeb5cd4fc38d2318",
"0427d0d7f3db4b0f8f96490d25c103b5",
"0427e27bc9ac414482b2f49193a2b10e",
"0427e77ddefc42789e5ece9f02eebf3b",
"04282f80b37e4e939cb38d4cb7475c53",
"042895262cf4443abc154f92e6005035",
"0428ccc2fe314b868ec4819816ca2d1c",
"0428ec85c4704558a6d36cd09088fc35",
"04290539bae74999acf9b24d74544e0d",
"042933e08e43417e93b63aecac5cde19",
"04296dd23ab24cde922259f03a77082d",
"042988009d094494814923e09b4ef1cb",
"04298cc9fa084d9fbc515810117af910",
"04299accfe9d45d78ea44190bec674a5",
"0429b3ed483d4ea0b4c72bed23442f08",
"0429bcd4dda94c6096b5e812c944f1cb",
"042a03d47615441e9d406974dbf436a2",
"042a1e87c07c4b20a0fda5d5a777b9c1",
"042a4cc152314683b5af17f956e6274e",
"042a50dcdc4f4c868585e242a9a16df0",
"042ad5dc85954e27815ff982632bc8cf",
"042b7279e1da4fce8807a176cde17056",
"042be56fa2914d6abceaeeda6e4eee18",
"042cb28befd942b1a12e17c206f37473",
"042cf167d53a4aa7b423660a822cbab6",
"042d13096b414a38a4f7b6111bcbe0e5",
"042d20e5abaa4e94aac502654ded747a",
"042d2bfae43b4763a6d50f72fdd2e004",
"042d8e82711a46f39817920be2e26eee",
"042e026346714f41904a9841783952cd",
"042e29649c9e4dcfac8e5e6c0dfad6de",
"042ef3fe54bd4cfd86815f2c92750202",
"042f340ded604f5392785d931684759d",
"042f411438804de599c22bd5b5f12a33",
"042f44374f9544d1a5d84ecaec83ff54",
"042f5ec19e38462f940a2e1c3ebe61c4",
"042f78224e0441debd74cf964ca04832",
"042fd1c060ea4207808dfb824224cbec",
"042fecbc7a8b4bd08820b6794b673147",
"042fee5bfb4741a0bd6b54f7a7bece64",
"042fff8a6bf4444095b0a370649c4e38",
"0430bc40c7fd4389bcde9d18f1d02ded",
"0431216c76cb43d99021012cb9258a5e",
"043134151e5d402e8f4e2b4be0b08e3d",
"043151e89e8c4d46a338368a13be6264",
"04315dff59f248aba492cd785cd81c7c",
"0431ba6a09a3472db3a0b7e31f94fcbe",
"0431ebc90118469c95b506e8afc0bc13",
"043260d2eab044b1a7a0a7a7d60b032e",
"0432a72efe8946c9a7da5942410a07d4",
"0432e58d903144f4a8cfe9dd2966c412",
"0433877d20b34e30aee04004c8139c82",
"0433f1a8bdfb481da04f01c72b2e3b51",
"043429ba923c4e4dbde406ac86c165fd",
"0434686d6fe245759fe24bc811c73f34",
"0434822787e5409085097218e3b7d862",
"04348b9207634ad3ad1064df3a2ac3b7",
"0434dc02f50a40e096f1c7d75fec0568",
"0434febe12d74cc2b672bfc2b831397b",
"04354236a73a4c83b8bbd208bee9aa5d",
"0435f300f0b14d809ce31b3f1ddbd9d4",
"043609fe0e18439cb422365c95ec0fa0",
"04362f1c1e00425682575cb7b33c8ff4",
"04364b7de62842ddaa33f1e207504b4a",
"0436cf1553ef443f8bc224d4a84c6baf",
"043736e6f35a4e5caa6de5f9fa46e071",
"04374cdaef124f39ba9aa4ae4d32b19a",
"043798708636486d858b0fd2191283d3",
"0437bbb8caff4eacae44ca57c3ae4826",
"043814986bbd49d4ae7f2b07006f0c94",
"04381ce5ede940e6bca4a658d87af64f",
"0438549359324067a3007e72f871f130",
"04388529124a4b449e852103366db0ac",
"043888f374a54c259b08951e7a7a9dcb",
"0438cfbc0a4a4348b9b564342df2a1d9",
"0439580998b3473c8e682d423b1cc9c7",
"04398b93794f428ab181cdf7bac16441",
"0439951393144ae6be3061fc9b1e12f0",
"04399626e6ce4e86b025417a99675a86",
"04399de8d76b46738c1422a3d536ca08",
"043a300f53e64017aefe02755d9f7750",
"043a3a9f57a84ceda142c6ba09065267",
"043a63d2ad204fba909a2dfff8d4e39e",
"043a7c153918442eb9398b0c7c27faa5",
"043a7d84f8c641c090eb47ee80464a8b",
"043ad4b35c014e2fb218e03d392a3c66",
"043af0b15c674e97b6953a94ad588863",
"043bc9aea8ec46cdb5083b26c2513845",
"043bd693b1de4b2cb298d19292c4c87e",
"043c94e63548468bb0244e5ad5ed7889",
"043ce304894c4e1b91a266614e39ba0d",
"043d4a23a3d14ba0876e00560acc555d",
"043d4bf1fa3f48afa3518e0650cf72cf",
"043d8db0eb86400fac154ab9c8bc4f3d",
"043d9470d8f6440f897f9e3b8fbede4b",
"043e2c28741c4fddbecc1674932512ac",
"043ea59e37134de7b8d9e618434382a7",
"043ed3b7263b424d96aae79cdabf1845",
"043f2cbd12984224a6a1933e78e4b9f3",
"043f4c08967949c3b99492d9b8756656",
"043f8f81833c4d0487615608ca11c9c2",
"044013a37de94d2ca59c740dbb11bf56",
"04407eee14294cf9a934bdf76f816394",
"04415dce8ec64e5bbd75e717c6a7146e",
"04418b6c64584742b8036e76affd568c",
"04419b247ab34c1cbbfddda7031497c3",
"0441bc1da2dd4da48f0aae796a9a45a3",
"0441d8aa0beb4b098bc5c3023c18d7fa",
"04423a6fc43c4622bedb8eb761fb991d",
"0442b105e4c9413abc79eb289ef4256a",
"0442b5c5e86946d3996dd45b2ccb069a",
"0442b7969b4348c9924853d2329706e4",
"044327a2087d42dfacfef07524b6d2d4",
"04439fbe05d24ed2abe092448048adc1",
"0443eaf7472841f5bed9f974b287f92d",
"044430ee14734a6db1c3504ed862bab4",
"044432a597d44b00b866e29ddf7794f7",
"0444a28032b74b2cb6e000523e767a0a",
"0444be3ce8a74032b5ec33285fd7beb1",
"0444cbc4badd4fdd9ff859c4ef256844",
"044524aaf2e3455fbe7d7afec2e28aa2",
"0445a5b6485e4d81baa5efba39afe811",
"0445ecfc10e04d5ba583b952637309e3",
"04462d0bd6f34445b8280a044efe3c09",
"044745457ed24abcba6808c62d4fcb6e",
"0447e3939adb4140b582e92edc19b9bc",
"044865695b664aa0bfd34346107e32d0",
"04486af08a2b47b18b0cbe095fa3b5b5",
"0448f564b0d54e5492dc3925e8c2aca1",
"0449004828ce4beabbd227c53deff079",
"044901bdcb3847ea960c129f49986112",
"04493a9d8fcc4ceca44031c1880add27",
"0449c476c4574651b0ce3225aa7cf177",
"044a1499ef5444209023afb62a806602",
"044a8c3578104316a8d069be88eaa492",
"044a9e484ec34ba5951f55ca33d07bbd",
"044abded56b84a0fa5fc0b96034d6b94",
"044b170530c64faeb703a8c2456ae928",
"044b30f250e94c43a7144e052e9e3cdd",
"044c1ce822314229ad736585d8082f0c",
"044c459fb44744039f5a5f75cfca270c",
"044c4d1bca88441fbae3da731a9eb9f8",
"044c9e77e4864629aa4fe6f9da607ce5",
"044c9ff378a14f798392a1a3da4509a6",
"044ca3908c4d4a009180eadd5d9e323c",
"044cf7cebe9846aea175f1b42a77d63e",
"044d41e76f04445296fb13f30f558f10",
"044d486444df4c958b75b3572d590d38",
"044d70786c034caabb8389d4634aeb9b",
"044d7fa5602d46e889efb2ed285deb3e",
"044daaedf0a84c3a9add2085886d5eae",
"044e3328ee344a6fa2a983d482a8a63e",
"044ec5139b2041059a1e80481bce5907",
"044f329269ae4e63ad662216bc2285b9",
"044f6338ba444e218e229e59a9a07499",
"044faea90f5245aa9c988804ed07cc33",
"04504c9028e447598fcce079b7b568a0",
"04507ecae4f34fbca3825db951201ac6",
"04509830e2bc4d48af94529a1c470b26",
"0450a1511f4b4cc995130132003c3a5a",
"0450f32e1ec84a6fb7e07c35435beb18",
"04518e1b26dc4850bea3efce6d2f9532",
"0451c621dbf546fdb0745c6c8e7fd780",
"04526a6e8ea446f089f0944c167d8248",
"045285997a12490b992a44221dee92e2",
"04529faf85d34f3b87162761a0c011f4",
"04530a4a460245ed8e8db9969d4da57a",
"04531ec3871c4b57a28936106fdc07c5",
"04532682952b407f871a8dc5f57924a0",
"0453279167e44a72872fcbc41eb5d258",
"0453346faa1e4df38a29c870c757d154",
"04533b096dcc4bbd9faab1e33d93ff65",
"045374ff865540ddae2a097fcd5340f2",
"0453a224669944478614c528a08d1459",
"0454182450394e0cb71ee2110c3e66e0",
"045478e51863467787f805cb2af5b04b",
"04548e1b1697429c89b82762ad415607",
"0454cfe5da0b4bb9812b7ea64a60aa2b",
"0455dd56cd1b4dee9aaf69d382058706",
"045629ac557a4cd3bcfa19e8afa632cb",
"0456ee0ee4f745bb898ccf6b1c92f5bd",
"04570e0017c1474bb6ca508d1aed532c",
"04574b87eb624478a4cb46cc7707dfe6",
"0457c26b505247f7ab38ebd7ae910a46",
"04581069ebac483babfeb583d34614cf",
"04584a3433904eabaa6b721ea9b0b7e6",
"04584d174d5c48bcad8b34aafb5debbe",
"04586cf50da549659dd0fe9490675575",
"0458aff573434428ac0a3c2c0fa68dea",
"0458f47b0c3e4ce49c5c34aa02aadc0f",
"0459553ba7474a13a9cd1ef3466895c3",
"0459785b498d4778a040f2edb59e9cc3",
"04597dd4c8344d41ad4fb807d9d1c64b",
"04599161886b466185a1765a108706c9",
"0459932467f74b98b820923851cba99e",
"0459ccc0988443f199a6cdd88c5220e3",
"045a031f6e1f40d38c029629881fcc87",
"045a51857af242cfbebeaf0289e8b7e2",
"045a96cb5bd8454883960ac8fd713cec",
"045add36c5c6458989c298d45586ad19",
"045b1b7a6c3940009fe4cb53c6328273",
"045b310d68be4ec187e2c97dadf6b5f8",
"045b346680e845ff83dd98caa2e5a93a",
"045b78b6cc1b4c5f9b359ecdd3c0279d",
"045b802c5e0944c38d97ade8fc05247a",
"045cab9438ea4312be4bbf849af47e1d",
"045cd2626fde47aea5fe6bafba9d7cf2",
"045cd316d90a455981ba4540fc52df9a",
"045e1af0079e4f18b3ecd548043bf6af",
"045e287dfc434027adeb85c3588cde37",
"045e4880b14b418888f34a0cd0e48a6b",
"045e6cace2964e139379f230f70646c6",
"045e7f6b7303420cb6750856dff4d700",
"045e8dddac6f43dea98760afece2db22",
"045ea7a830f74f108831a71cf26ba7ec",
"045ee9d93d8844a2b7d793d4bc382177",
"045f10ff2645429f87990f12e686e3eb",
"045f4084c0fa44f9ac30a2d554932590",
"045f50718b624a5c8add21286599bcc4",
"046028c280f148518ad54856298cb412",
"0460d19a0c934ba2b268cf3e5a3fde39",
"04610b2ab7b74a909145a3b03e27d4f7",
"046127f519f64576a55462a2d73fa365",
"046129444d11410f8c096deaa4a8b8fb",
"046154bdbb8a48598d8db86e1931d0c4",
"0461c2090b364d81be91d96aca3cb39f",
"0461e3027d5c4a8fa82dc42464740dad",
"046222e39ecc4cbe95cfd2aee21c2636",
"0462a06d0a034b41b69372a2f2b68da9",
"0462b7bf23bb4f24b965b4270849badb",
"0462d89f38bd4348809ba7c0c863d0e2",
"0462dd7007ce4030a1a3f416d12f6e14",
"046328f307ca4e989df28b3f3720bc1c",
"046350c5fac248fc868420a2dccac96b",
"0463d1f0fcf7424ea2e8a87ccff4c036",
"0463dd8b50cc442db5f0605c390cb745",
"0463ed246d924508bae33ba8bbc4b65b",
"0463fde6fded4ea587b45cfa7d0da880",
"04640e9a3cdf43a1acb49e68c565b3f0",
"046432b3aa954947a01373e39839384c",
"046438a45ea448af90daae7a839c752e",
"04645a343897461481bd0cf368faedbb",
"04648c28779649a8b776a482f8403dfd",
"04648d3e14354ccb834f8b578019043f",
"0464b13007dd4a3596fd1e5b633ca48e",
"0464cf45bc7f4b5fa4e9c381985bcb15",
"0464e185c773431eb4c9d5b8d761022f",
"0464f15ad60c4f3ba64d4bc78f35caac",
"046553cdd8a3414a8bf84c945fb8b8a1",
"04660ba340534fb5b30982b04da410c3",
"0466159806c74b2388991897c997e33e",
"0466303fa3974b4d9a39b678b9086027",
"046643e50c4048c89dcc0760eafd4684",
"0466f63eb09440c1b978de5967a7d17b",
"04675ef1aa974d9e88a1bf73e520f212",
"0467724aa2b940d294f7b4fd8560efb1",
"0467d303886a4f3eb3d341ceebd167b0",
"0468116614174593b78f81768c1b2cf1",
"04682b353c494880805fb5e7df4e2c54",
"046902cf8c274f59be236ad14b423a0c",
"0469a6c8516048158a6fe6c66ca022fa",
"0469f5492fca4ed4825accfa753963e9",
"046a2a519cbf474692cb47fd8455c0a5",
"046a38080f994e81b64a9a468c878d61",
"046a4f10971f439f9899c48a604453e6",
"046a874234c1445585d1dbb13e6217d1",
"046b3e72612947caa4c9abc2c0edaa60",
"046baf80ac2845d38e41f6b09192c2c8",
"046c0b88e23342b6b4c4736f7bcef8c3",
"046c75df1fb44eec912d830641760c3c",
"046cca83e2c948d398fbf7721226b9c7",
"046d2f010beb4bf98659e701e2277e9d",
"046d7fed53604fa9ae12852bcd1b140c",
"046dc49f495042dd9373b99bbe805398",
"046e2762c31f437b8bd874cfe6f99739",
"046e363da81a4b84ab5aa311db5b8660",
"046f8186dcf34b098c09403cd79634ae",
"046f83639efc4592ab38588aed671eaa",
"046fa0bea02c4496991ef104204f9744",
"046fbdfcfb804c91b659f11d00f87be0",
"046fee263ab643abb07a0588c269adb8",
"047015d0f08a495cb1f458daa67f1176",
"047029814e004a29895b0ab297f338d8",
"047052519dcc4aada5a6869d2ef61b06",
"0470793f81b24adab2173cea506cd93c",
"0470b100cba84238b40a473805bff6d9",
"047154d8e7f2467a9c1ecace9338d319",
"04716fe932254fbbafbf46335c795d2d",
"0471727c390548c7aa3b28b64fbf065b",
"04723000b1784a6da603110e0a18f4f0",
"04726ac44a4049fdbabf87dd560b2bc0",
"04728c4b3303452c915867d216f6cf54",
"0472c04f565f4053960abb50f3402119",
"0472f5c6eb974c0cad9e7ed4e22cc452",
"047301786e624ec8a24c4f9d71ff11be",
"047319d72df849b0adabfe0f5b925fd3",
"04736f60724240419b6d0fe1e7715554",
"047405edbbeb4aa3acf304f914b61968",
"04746a6298584fbaaeab52d1c4759fd1",
"0474a7b280334b459ba27b2b6957f431",
"0475423324e044cd8ce27403fb0849f0",
"0477298076af43f0ab8a56aa6949af16",
"04775ee2c3cb41459f530a15d817baa7",
"047766464a8745a7beef17b918a5b615",
"04779b8b1bc645d28da85d0e72ae2c8c",
"0478152a7c83475883e7be2483a2e163",
"0478a678b3d04d59a00baf898e4dbc6f",
"0478b0a97a3e428dacb1e1567d8c1d9f",
"0478c381789349069ba991a0bbee28d4",
"0479e3bd469644a7b687af5fe64a193b",
"0479ee1176d0456789faf2eeaf81c2c0",
"0479fc772637479bb3198b74ab7f51b3",
"047a290c6bed49b29ea45aa093e9f1ab",
"047a31910984426a8ee643e7c6e51797",
"047a4260e56a4cb8a4f5491e09facb8d",
"047a6df02fea479d9f9f87627b12eed9",
"047a777c55434bb9baada52156f5d63a",
"047a7cc36edf4be1b15ee36f2c11c0ea",
"047ab39b7d0d4f1fa9740144e1699971",
"047ae1b44f124401bdf8cdf2b373db27",
"047b4542eb974c5b92900a48d46ce09d",
"047b8cf1506142fa9c9c01c7884f5a9c",
"047c58fdc37b428b9a4e31838fe70e80",
"047c657133c64b8e9dee7577a7907c40",
"047c7414478746619250c7bc59276faf",
"047c8e75264e47618dcaeb907a01fef3",
"047c940869cf4ee78d34b702dc917de5",
"047ca9234ecd4c9ab62ae1bd7e53fc14",
"047d5cc85a2b4d14bb18b2665d77bbe6",
"047d5dbe53b24703a4d13a089b42f9aa",
"047d627d99bb4da7b4c3a6d8b2026b01",
"047d889701b94d958f29c3e7b0f3b161",
"047dc71bf4384727bc802128c97a0a13",
"047e53d076c6490780fe5b9309d987ac",
"047e62ff07664062b9041a7f6278b6c1",
"047e821fe9df40a7ac0c1ad2a3f78c9a",
"047e886b5aa84c6099548afaf96ce333",
"047ecf2fed9f4b3a8850801133e33300",
"047ee204cb564c53a1f122d09f825f57",
"047f3d1ef898414b8e31658c44b564c0",
"047f69591e9842078ff30a6bf3d1b85a",
"047f933684e1411788fa975751cfb807",
"047fcd6e5004469bb6f5377e011d0299",
"047fce3d0e2b4436ab3c9ced152cbb88",
"0480069e9ded4ea09a1c59ccecc89232",
"0480995ca45b4b8dacd863474be4064d",
"0480a3e510954cf1866544c16320b74a",
"0480c0886e4449d0935fa5b45187679c",
"04810b3f0b93439299b33fe01e3695e0",
"048167c76d2a42bba39d336d4521f7d3",
"048182403fff4351910627e3a7a42dac",
"0481f781c84445419e1175b742337064",
"048223a36cf84635abcec5fb345172af",
"048236683ff04ddca0aafb1764de5d24",
"048266a54584435499936967ea3d42c6",
"0482bbeadd0c46a694aa6b0ba414dafc",
"0482c077a77b4ec292e6151df743da33",
"048325efe93f4107ae94deb6ee90291d",
"0483afc9b71d45949eafe72aad7959a1",
"0483b32f8e844aa6b6f272458cfacc2c",
"0483e313e93548baba8616214df81ae7",
"04841ff23cde4b3295b75113a49495de",
"048427cf249d4b30bbd75f067c3e567e",
"04843414bbd34f17a809cfd74624f161",
"048486d2f900436ab97331bc9bef16cb",
"04848d99fad249f689c1019af8b00cfe",
"0484faf18c474e8e8e6368aafda05ad2",
"0485267134714b31bf7834a008bcec4e",
"0485a0356cc44cfe864e790a21387cf1",
"0485cd4c4ca3418d98dd92778865306f",
"04863dcf896a45e0ab216f8fd84a2b0b",
"04867c0e2ebb470fb34be3f71b12a292",
"0487281af4f24a7b90ba7d9b54d5ae3b",
"04873fe34a874d35ac79af1655c687d0",
"04886a0a64b84a9fa414ab646cbaa975",
"04887b0cb9c74960b73454091674fe8d",
"048899a130524fc085c73fe88cb7005a",
"0488a61974a94b248e94c53f3499cb6a",
"0488d3092bbc4b6a8d3eb88feaa9d19b",
"04894c8ca2224629a15c2188080d2f57",
"0489535e463747c99bdf7a5262ae1072",
"04895bfcd6ec4b2d896ecfa55ff6ff55",
"04897276406d4b26bd8ea02a94c9070b",
"04898df33029473bae9e398e2cce1b1f",
"0489a6c003de4abb89bee5e8b635b43b",
"0489ee63ef4e4c4dbcce1fc40c59597f",
"048a0bbcb09c49918c2976eb6c310c44",
"048a1bf8691a4173a6afc0776a4a9c9e",
"048a481d1cc24299b8598a43ecc2336e",
"048a6f1034a040439785b52bcc8d3b94",
"048a927e750b454e8b8d13babb9811a0",
"048abbb4548c428cb5a4983cb4f4f690",
"048b3130eb924140970f164fffd23c3b",
"048b89c7c2c148c8acd2b99bda13cdbc",
"048b9eba990c4807b17c5c57f45a4721",
"048c0360b5e34e77bc4ead40ce451341",
"048c1aae58eb484dbe4ccb967323a113",
"048c25ace12143768f895a0fe67f36f5",
"048c34e17a934448bb94efc7ae5f6f45",
"048c9be7291848a3b262ca6f98d1f90f",
"048cccd2675b42e2956599c9cb438e8a",
"048ce86495e34612983561293652cd1f",
"048d1f9eb53d479ab834bf34527c23c9",
"048d843587614df9a604fe0d887b1516",
"048dd1f40af840a7b214c8a1dfb46f1e",
"048e0a63aaa741659bda915a14ccc32e",
"048e0e732f5646dea3e9a4a8d4d76f75",
"048e1f6ed9d44dd68f4741b42821e402",
"048e46840777481f8535dbd0df5c3df3",
"048ed7555e844fefb9f728e0fda3daf2",
"048f635264e34c59ba345bc6bd421cbb",
"048fd74f91d24b06bfd18a0305b7ef77",
"048fdf1e3f654b7eb9cea3598c2555cf",
"04903bf17c404438a2e42f9df048844d",
"0490408501364b428d03cbd556d3d03d",
"0490a5029d7a4e20b38cfc3cb9c5a034",
"0490c47013374d2581c41bef164a2445",
"0491a443b5a8493099d8ba8208d4b94c",
"049233822e94446db4bdea576b5ba43d",
"049284f407b94816bd76505b559e9497",
"0492b470158e4e9d9da53db95511bc58",
"0492c9200341488ea7bf33e0151b8988",
"0494657114e44ac099fca6eac7aab457",
"049473b8b74f42f9bd3fb66f57c86216",
"0494ff95e09641bfb204f9bab056a358",
"04951a7921954fb6bdbe51fb018c8692",
"04960e9594a24e51bacc70a431fdc846",
"049646f45f1d484f9b72b67bff783b75",
"0496b9389b90443392b5f4b9435127f3",
"0496b97218fe4b5ea6d59a71ac328387",
"0496e3dbe71343438edb938f7c6f5c4c",
"04971882ebd2455fbec32207ad19e8de",
"04973117005e4db6aff62cc08093bc73",
"04973f85286743cd8790d13aa2943422",
"049779435931473999705322ab0c5aa7",
"049818318bb0424689e5a2fc9066d76a",
"0498324733434f4b9bb61bc76c32d433",
"0498a37cd2e34153b568cd5756c03107",
"0498c20012d54eceb8b3dcacd7324201",
"0498df41bb814dd7b06ec8a6c4e16dcb",
"0498f89e3b614944b6642cf24344ea3f",
"04992ef8a81a4a9c9ed94dd368876e80",
"049945b3d0304f988176c12d48bc039e",
"049a4d4138e646a294ed1de085a24b42",
"049a6494c18242d8a92f128c65f81703",
"049ab3517e2f4d2d85c70555e7963f6d",
"049abd000d6144ccb1d2e0a7627aa54b",
"049b9c4964cd4763b43e875cc4b4c6c1",
"049ba366e51248faab95bc72c6ee0e9b",
"049c284a504a43f4a2704d0dd0587838",
"049c8a32a920466f85ad330987d92cb4",
"049c94597877485387ac0b8b1db5d03d",
"049d65ac926746f6b8a8b3f178264614",
"049d8602a7da4ca684600d0c5628993e",
"049e586dda1c4b168201fc14e1b2818d",
"049e5d34968d461c8c34ca07acc09085",
"049e8eeea2644502850c0407dc990029",
"049f639e3667423e943847cb66b808a7",
"049f95a70926455db594efed3f15bd78",
"049fa8bc117548a2afb4a2954281f3bf",
"049fcd4359f0437eab56c772fc7c646f",
"04a041e7117c4f3ea99aed7f58ac4dfc",
"04a0a42562c6478aa1b5086af93087fa",
"04a0b4fdf1b345dfbd720dd2517beb87",
"04a0ba310366457b8ca2326ce0366ffb",
"04a0e7422d0d4fecb34fcadbb5d3b9e0",
"04a0e8347a154265bc023d460717c705",
"04a0f9c95b954dc7817315f4f85a43d7",
"04a17c7837d84978861859ed6bd3918a",
"04a20f2ef8c14b9096d435b5acfee795",
"04a23f0e3fc94cb5ad3d2ed40b09a753",
"04a241b1e879412b94368c39e7fd30bb",
"04a2451af2c14aa28e06e89f1b6088ce",
"04a275c84cc944019c05f52fb59d523b",
"04a2be9945bf4d04b7a24243b2de2fd7",
"04a2e320b4b04939876ab47e3f8b1fe8",
"04a2f62eedb94f0f823539aa04bb10b6",
"04a2f66b3f874da295d3318e9c3038fa",
"04a3006e3fa2443f94476ae526346f10",
"04a3d6fd9f064885b28e9e3b96b1b62a",
"04a4005379e8422494108bea029bdb4f",
"04a401963ecd40bbae2e3547e9440884",
"04a47266ef7649ec875f3aaf59a73a57",
"04a4a170304348f5adfcfb9cef1c6af9",
"04a4f9b3576a44768cf29ee952d9ead4",
"04a5451d8a9c4497a170ec70664cd71e",
"04a55647ffc3496ea966da47e3784ca1",
"04a584d484124eac95eab062792bbdcb",
"04a5d8af2d5d421da2998ab17a5dc858",
"04a602b72042481d8777ec127c8faa2d",
"04a65dfd424d4226981c116e0485abc0",
"04a6757b216846249c27633535f4ca35",
"04a688a53c43429aa72c5d79a12d7318",
"04a6b6dfdb034aa0ab7cffece59a9545",
"04a6d81058d645ddb9609fac4ce7b750",
"04a6f2468f5642adb9f8914d693d9326",
"04a72f25bd9b4345a9306a62b2eab732",
"04a786e2f0ba4ccb98b0fe7dd454d542",
"04a8950b620a408aaff98e5632814fbf",
"04a895a065714f948ad999bb86c462e6",
"04a9037bc7074d3f8a0f248e2667789c",
"04a9b95ec0034a659a623cc2660275ea",
"04a9daebcf934a3a998d4128762f00e9",
"04aa156161544d2e8e07905041d070b0",
"04aaa36d434741f8a1acd073e8d843dc",
"04aab31e83714ff7a61f82fd83d44198",
"04aadba80f9f412e9a937ed143a14159",
"04abd5afb5ed479a8a390b830767cf2d",
"04ac353a3fdd49c88488af4ef89b11d2",
"04ac76b38f50421d9595301c891abe35",
"04ac9df652e0438a9f1d45728d4130d0",
"04aca94f67e4446197bafd4faa22aaf5",
"04acc364b29a44489e6ca4defb4bf9db",
"04acc44dc7554721a14da1ecf9472d83",
"04aceaff96f943ed8c4afb6aa42ae98d",
"04ad0032075149bf91a5fc37c3ebdb48",
"04ad1201629d4ef69006975cbc9b6fa5",
"04ad40e23a7d4985824800cde9af9ee1",
"04ad6a9074ac4acfad42579e2f2acfba",
"04adb18fd94f4307931c11966c2c4d94",
"04adba4ef0ed49519e826ca2560d5083",
"04ade5f6d39749119eb70c38815eefeb",
"04ae0726a9974909a2b9f31304b72fa8",
"04ae426a2cb343bc9a900a55eeba7c53",
"04ae5404442a4cdd9fcc50f43f177d67",
"04ae5a1e62644a3ab3d38451f6adb3a1",
"04ae749dfd5b477987d2249feffed480",
"04ae80912507431e87554b070666ae7e",
"04ae8caa7f2e47278e015ecee80a58ed",
"04aeaf65c2344db8af62fe1ab06c2db4",
"04aeb8e0346446a6bf66c9366c8a24b8",
"04aeef8b55704b499a23919f1429b443",
"04af6fcbf4f04294958ee14b8a58a72c",
"04afb88a016f4fd1a322f37e35c871ea",
"04b0544095884fbba4ce0546cae661fc",
"04b08285efc5455ba04bb5f21b3bebb6",
"04b099fe3bd046af829f9bbf774632c6",
"04b0b2c0847343b2bae60f83dad457a4",
"04b0c17dad3743b5a9c7da143439d044",
"04b1108a502549d5b0293a4b365306be",
"04b14ed10fad4d85b3b7d89e2ffc29ce",
"04b16c581de14b96b4dec8d905e0a43b",
"04b18d2ab0424086a6e7e31a715605b5",
"04b1c0a9aaef411795711c8d15639505",
"04b1f9d08696484ba4ac1989bb7dd33a",
"04b2bc2b5db34abeb7cf3d6b5b7fc925",
"04b2d51c3732471190d5654781a45017",
"04b312bbbf1941c2a9f3cb92165c97bd",
"04b367eb75b14b919c5a4310700b69d7",
"04b36d390dd341a68455b9b2c83099a2",
"04b3aa94c16b4af18578fd2d10161fb4",
"04b41a98a6414ad7951d7c5549c0f228",
"04b44da9d298431483bd99c7877557a5",
"04b4c36d75ee45ad9ab4b7d1496b90d3",
"04b4ee0a72ad43e59bbf05982055b5a8",
"04b5113591424d0e8d6239c1be13fc66",
"04b53889b28644ebac4c1535cc0309bd",
"04b5b30298344c978a99bb1566f16029",
"04b5fe4b8b844f599b658d69850b5e12",
"04b6cdd0e81f401fb4fef86379c2fe21",
"04b6f9be0dcb4008b757ab36819e9bba",
"04b6fbca3be44048b3dda48637eef924",
"04b7396a09254e658c8639004ce28f58",
"04b74d39d2454fef83cd57d774f45ff2",
"04b75239324f4f8086fada50cbe70a76",
"04b7819fa43a43aa938f62a3a990dd7e",
"04b7e4cabcff4d0d98eb95307b0214cb",
"04b83310a19f4805a816d207171cc61b",
"04b8456752544f2a9167dbe816d16aa2",
"04b857cdcf5d422f8f2e1f7a41613d76",
"04b8ca91715a4556ab1c5b5917abda7f",
"04b8efbf64bf47bf92b6bb833838f8b7",
"04b94c7f233b41bb8fe1f5f37a0e84c4",
"04ba0b4666ed48a39ae8cd83158d4146",
"04baafd6e3f3448cabe1fa524de043cf",
"04bb175a893949cda7efd171d3224b6d",
"04bbf2289def45f5b4fc3374b822b3ed",
"04bc33081e3a4fecaa1503edcef6db28",
"04bc5cf06a9745479ef6eba28c84a49c",
"04bc74efd1234e1e9acf7b84fea7c462",
"04bc7d924bbd42b2b7081ef518688ad3",
"04bcb5fb02c64485b1e1a0a29c32275d",
"04bcc907280c42bebe786ba3dd4f5994",
"04bd2b146af04418a948a141cc3ebf7b",
"04bd542e8cf940fe833d3652954c09ab",
"04bd6461534b4d10a74c57c1ecd80372",
"04bd7876f81b494fa10c24696b841dd3",
"04bda18aa8fd48cdbdaaeedc9019cd2e",
"04bdf5e340f24612a64848ebfb65b5c8",
"04be5f7dd0fd4569a449b7e3b2e92724"
        };
                foreach (string item in test) {
                    


                    //mDatabase = FirebaseDatabase.getInstance().getReference();
                    //mDatabase.child("images").child("DCIM").setValue(null);

                    FirebaseResponse delLog = ConstantCommon.client.DeleteAsync($"Logs/{item}").GetAwaiter().GetResult(); //Deletes todos collection
                    //FirebaseResponse resLog = ConstantCommon.client.GetAsync($"Logs/"+ ).GetAwaiter().GetResult();
                    //dynamic data = JsonConvert.DeserializeObject<dynamic>(resLog.Body);
                    ////
                    //if (data != null) {
                    //    foreach (var itemDynamic in data) {
                    //        FirebaseResponse delLog = ConstantCommon.client.DeleteAsync($"Logs/{((JProperty)itemDynamic).Parent}").GetAwaiter().GetResult(); //Deletes todos collection
                    //    }
                    //}
                }
                
            } catch { }
        }
        #endregion
    }

}