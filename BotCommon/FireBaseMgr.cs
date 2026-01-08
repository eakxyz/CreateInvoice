using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotCommon {
    public class FireBaseMgr {
        public static void add(string pNode, string pName, string pValue, string pType) {
            try {

                switch (pType) {
                    case "int": {
                            SetResponse setLicense = ConstantCommon.client.SetAsync(pNode + "/" + pName, Convert.ToInt32(pValue)).GetAwaiter().GetResult();
                            break;
                        }
                    case "string": {
                            SetResponse setLicense = ConstantCommon.client.SetAsync(pNode + "/" + pName, pValue).GetAwaiter().GetResult();
                            break;
                        }
                    case "DateTime": {
                            SetResponse setLicense = ConstantCommon.client.SetAsync(pNode + "/" + pName, Convert.ToDateTime(pValue)).GetAwaiter().GetResult();
                            break;
                        }
                    case "decimal": {
                            SetResponse setLicense = ConstantCommon.client.SetAsync(pNode + "/" + pName, Convert.ToDecimal(pValue)).GetAwaiter().GetResult();
                            break;
                        }
                    case "bool": {
                            SetResponse setLicense = ConstantCommon.client.SetAsync(pNode + "/" + pName, Convert.ToBoolean(pValue)).GetAwaiter().GetResult();
                            break;
                        }
                }
            } catch { }
        }
        public static void update(string pNode, string pName, string pValue, string pType) {
            try {

                switch (pType) {
                    case "int": {
                            FirebaseResponse editLicense = ConstantCommon.client.UpdateAsync(pNode + "/" + pName, Convert.ToInt32(pValue)).GetAwaiter().GetResult();
                            break;
                        }
                    case "string": {
                            FirebaseResponse editLicense = ConstantCommon.client.UpdateAsync(pNode + "/" + pName, pValue).GetAwaiter().GetResult();
                            break;
                        }
                    case "DateTime": {
                            FirebaseResponse editLicense = ConstantCommon.client.UpdateAsync(pNode + "/" + pName, Convert.ToDateTime(pValue)).GetAwaiter().GetResult();
                            break;
                        }
                    case "decimal": {
                            FirebaseResponse editLicense = ConstantCommon.client.UpdateAsync(pNode + "/" + pName, Convert.ToDecimal(pValue)).GetAwaiter().GetResult();
                            break;
                        }
                }
            } catch { }
        }
        public static void delete(string pNode, string pName) {
            try {
                FirebaseResponse delLicense = ConstantCommon.client.DeleteAsync(pNode + "/" + pName).GetAwaiter().GetResult();
            } catch { }
        }

    }
}
