using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace BotCommon {
    public class ConstantCommon {
        public static IFirebaseClient client = null;
        public static void Initial(string pDBPath, string pAuthSecret) {
            client = new FirebaseClient(new FirebaseConfig {

                //invoice
                //AuthSecret = "Y6o5IkvpUtaiS6m51mNa4VWXdh16Uf8ZB9K3DZDI",
                //BasePath = "https://invoice-22921-default-rtdb.firebaseio.com"
                // for test
                //AuthSecret = "hjvjWMFAQtxyZQ84PxrC7Fq60gm9Wn7Qctr3Efj5",
                //BasePath = "https://testbotmakemoney.firebaseio.com"

                // Main bacarat
                //AuthSecret = "WJfnfcwvyAvkiLwaa3I1EqjSkip98uGrXeQS639M",
                //BasePath = "https://botmakemoney-a4acd.firebaseio.com"


                // Production
                AuthSecret = pAuthSecret,
                BasePath = pDBPath

            });



        }

        //AuthSecret = "WJfnfcwvyAvkiLwaa3I1EqjSkip98uGrXeQS639M",
        //BasePath = "https://botmakemoney-a4acd.firebaseio.com"
        //public static IFirebaseClient client = new FirebaseClient(new FirebaseConfig {

        //                                                        AuthSecret = "hjvjWMFAQtxyZQ84PxrC7Fq60gm9Wn7Qctr3Efj5",
        //                                                        BasePath = "https://testbotmakemoney.firebaseio.com"

        //});
        public static FireBase_DB db_firebase = new FireBase_DB();

        public static DataTable GridMain {
            get {
                return db_firebase.Tables["GridMain"];
            }
        }
        public static DataTable GridDetail {
            get {
                return db_firebase.Tables["GridDetail"];
            }
        }
        public static DataTable Licenses {
            get {
                return db_firebase.Tables["Licenses"];
            }
        }
        public static DataTable Users {
            get {
                return db_firebase.Tables["Users"];
            }
        }
        public static DataTable Computers {
            get {
                return db_firebase.Tables["Computers"];
            }
        }
        public static DataTable Logs {
            get {
                return db_firebase.Tables["Logs"];
            }
        }
        public static DataTable LogShow {
            get {
                return db_firebase.Tables["Log_Show"];
            }
        }
        public static DataTable UserShow {
            get {
                return db_firebase.Tables["User_Show"];
            }
        }
        public static DataTable Registers {
            get {
                return db_firebase.Tables["Registers"];
            }
        }
        //public static DataTable LineBots {
        //    get {
        //        return db_firebase.Tables["LineBots"];
        //    }
        //}
        public static DataTable MapSupportUsers {
            get {
                return db_firebase.Tables["MapSupportUsers"];
            }
        }
        public static DataTable SupportUsers {
            get {
                return db_firebase.Tables["SupportUsers"];
            }
        }
        public static DataTable Generates {
            get {
                return db_firebase.Tables["Generates"];
            }
        }

        public static DataTable BestFormulas {
            get {
                return db_firebase.Tables["BestFormulas"];
            }
        }

        public static DataTable LogPriceLicenses {
            get {
                return db_firebase.Tables["LogPriceLicenses"];
            }
        }
        public static string getDateFormat() {
            return DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US", false));
        }
        public static string getDateFormat(DateTime pDate) {
            return pDate.ToString("yyyyMMdd", new CultureInfo("en-US", false));
        }

        public static List<string> getDateLog(DateTime pStart, DateTime pEnd) {
            List<string> listDateLog = new List<string>();
            for (; pStart <= pEnd; pStart = pStart.AddDays(1)) {
                listDateLog.Add(getDateFormat(pStart));
            }
            return listDateLog;
        }


        public const string TYPE_HOUR = "ชั่วโมง";
        public const string TYPE_DAY = "ซื้อ";
        public const string TYPE_CREDIT = "เช่า";
        public const string TYPE_TEST = "ทดสอบ";

        public static string FormatData(DateTime pDate) {
            return pDate.ToString("ddMMyyyy", CultureInfo.CreateSpecificCulture("en-US"));
        }

    }
}
