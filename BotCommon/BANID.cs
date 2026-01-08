using FireSharp.Response;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BotCommon {
    public class BANID {

        #region Init
        public string SerialNumber { get; set; } // GUID
        public string IsActive {
            get; set;
        } // GUID
        #endregion

        #region Wait Method
        public static void BANIDMgr_Wait(ref BANID pBAN, string pMode) {
            try {

                switch (pMode) {
                    case "ADD": {
                            SetResponse setBAN = ConstantCommon.client.SetAsync("BANID/" + pBAN.SerialNumber, pBAN).GetAwaiter().GetResult();
                            //Computers.Refresh_FireBase_Wait();
                            break;
                        }

                    case "EDIT": {
                            FirebaseResponse editBAN = ConstantCommon.client.UpdateAsync("BANID/" + pBAN.SerialNumber, pBAN).GetAwaiter().GetResult();
                            //Computers.Refresh_FireBase_Wait();
                            break;
                        }

                    case "DELETE": {
                            FirebaseResponse delBAN = ConstantCommon.client.DeleteAsync("BANID/" + pBAN.SerialNumber).GetAwaiter().GetResult(); //Deletes todos collection
                                                                                                                                                //Computers.Refresh_FireBase_Wait();
                            break;
                        }

                    case "GETLAST": {
                            FirebaseResponse res = ConstantCommon.client.Get("BANID/" + pBAN.SerialNumber);
                            pBAN = res.ResultAs<BANID>();
                            break;
                        }
                }
            } catch { }
        }
        #endregion

    }
}
