using System;
using System.Data;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using FireSharp.Response;

namespace BotCommon {
    // Utilities to load Firebase Invoice data into the typed DataSet generated from Invoice_DB.xsd
    public static class InvoiceCommon {
        public static readonly Invoice_DB Db = new Invoice_DB();

        // Expose strongly-typed tables like ConstantCommon
        public static DataTable products => Db.Tables["products"];
        public static DataTable customers => Db.Tables["customers"];
        public static DataTable invoices => Db.Tables["invoices"];
        public static DataTable log_periads => Db.Tables["log_periads"];
        public static DataTable map_guarantees => Db.Tables["map_guarantees"];
        public static DataTable companys => Db.Tables["companys"];
        public static DataTable address => Db.Tables["address"];
        public static DataTable map_products => Db.Tables["map_products"];
        public static DataTable customer_groups => Db.Tables["customer_groups"];

        // Public refresh entry points (Wait / sync) similar to Computers.cs pattern
        public static void Refresh_products_Wait() => FillTableFromFirebase("products", products, "ProductID");
        public static void Refresh_customers_Wait() => FillTableFromFirebase("customers", customers, "CustomerID");
        public static void Refresh_invoices_Wait() => FillTableFromFirebase("invoices", invoices, "InvoiceID");
        public static void Refresh_log_periads_Wait() => FillTableFromFirebase("log_periads", log_periads, "LogPeriadID");
        public static void Refresh_map_guarantees_Wait() => FillTableFromFirebase("map_guarantees", map_guarantees, "MapGuaranteeID");
        public static void Refresh_companys_Wait() => FillTableFromFirebase("companys", companys, "CompanyID");
        public static void Refresh_address_Wait() => FillTableFromFirebase("address", address, "AddressID");
        public static void Refresh_map_products_Wait() => FillTableFromFirebase("map_products", map_products, "MapProductID");
        public static void Refresh_customer_groups_Wait() => FillTableFromFirebase("customer_groups", customer_groups, "CustomerGroupID");

        public static void RefreshAll_Wait() {
            try { Refresh_products_Wait(); } catch { }
            try { Refresh_customers_Wait(); } catch { }
            try { Refresh_invoices_Wait(); } catch { }
            try { Refresh_log_periads_Wait(); } catch { }
            try { Refresh_map_guarantees_Wait(); } catch { }
            try { Refresh_companys_Wait(); } catch { }
            try { Refresh_address_Wait(); } catch { }
            try { Refresh_map_products_Wait(); } catch { }
            try { Refresh_customer_groups_Wait(); } catch { }
        }

        // Core loader that maps Firebase JSON objects to DataTable rows by column name
        private static void FillTableFromFirebase(string nodePath, DataTable table, string keyColumn) {
            try {
                FirebaseResponse res = ConstantCommon.client.GetAsync(nodePath + "/").GetAwaiter().GetResult();
                dynamic data = JsonConvert.DeserializeObject<dynamic>(res.Body);
                if (data == null) return;

                foreach (var itemDynamic in data) {
                    var obj = ((JProperty)itemDynamic).Value as JObject;
                    if (obj == null) continue;

                    var row = table.NewRow();
                    foreach (DataColumn col in table.Columns) {
                        JToken token;
                        if (!obj.TryGetValue(col.ColumnName, StringComparison.OrdinalIgnoreCase, out token)) {
                            row[col.ColumnName] = DBNull.Value;
                            continue;
                        }
                        row[col.ColumnName] = ConvertToken(token, col.DataType);
                    }

                    // Upsert by primary key
                    var keyVal = row[keyColumn];
                    string filter = BuildFilter(keyColumn, keyVal, table.Columns[keyColumn].DataType);
                    var found = table.Select(filter);
                    if (found.Length == 0) {
                        table.Rows.Add(row);
                    } else {
                        found[0].ItemArray = row.ItemArray;
                    }
                }
            } catch { }
        }

        private static object ConvertToken(JToken token, Type type) {
            if (token == null || token.Type == JTokenType.Null) return DBNull.Value;
            try {
                if (type == typeof(int) || type == typeof(Int32)) return token.Value<int>();
                if (type == typeof(int?)) return token.Type == JTokenType.Null ? (object)DBNull.Value : (object)token.Value<int?>();
                if (type == typeof(long)) return token.Value<long>();
                if (type == typeof(long?)) return token.Type == JTokenType.Null ? (object)DBNull.Value : (object)token.Value<long?>();
                if (type == typeof(decimal)) return token.Value<decimal>();
                if (type == typeof(decimal?)) return token.Type == JTokenType.Null ? (object)DBNull.Value : (object)token.Value<decimal?>();
                if (type == typeof(double)) return token.Value<double>();
                if (type == typeof(double?)) return token.Type == JTokenType.Null ? (object)DBNull.Value : (object)token.Value<double?>();
                if (type == typeof(bool)) return token.Value<bool>();
                if (type == typeof(bool?)) return token.Type == JTokenType.Null ? (object)DBNull.Value : (object)token.Value<bool?>();
                if (type == typeof(DateTime)) return token.Value<DateTime>();
                if (type == typeof(DateTime?)) return token.Type == JTokenType.Null ? (object)DBNull.Value : (object)token.Value<DateTime?>();
                // default to string
                return token.ToString();
            } catch {
                return token.ToString();
            }
        }

        private static string BuildFilter(string columnName, object keyVal, Type dataType) {
            if (keyVal == null || keyVal == DBNull.Value) return "1=0";
            if (dataType == typeof(string)) {
                var s = keyVal.ToString().Replace("'", "''");
                return $"{columnName} = '{s}'";
            }
            return $"{columnName} = {keyVal}";
        }
    }
}
