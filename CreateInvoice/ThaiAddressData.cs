using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CreateInvoice {
    public static class ThaiAddressData {
        // Province -> District -> SubDistrict list
        public static Dictionary<string, Dictionary<string, List<SubDistrictInfo>>> Data {
            get; private set;
        }
        public static string LoadError {
            get; private set;
        }

        // เก็บข้อมูลตำบลพร้อมรหัสไปรษณีย์
        public class SubDistrictInfo {
            public string Name {
                get; set;
            }
            public string ZipCode {
                get; set;
            }

            public override string ToString() {
                return Name;
            }
        }

        static ThaiAddressData() {
            Data = new Dictionary<string, Dictionary<string, List<SubDistrictInfo>>>();
            LoadError = null;
        }

        /// <summary>
        /// โหลดข้อมูลภูมิศาสตร์จาก DataTable ที่ได้จาก XML
        /// </summary>
        public static void LoadFromDataTables(DataTable provincesTable, DataTable districtsTable, DataTable subDistrictsTable) {
            try {
                if (provincesTable == null || districtsTable == null || subDistrictsTable == null) {
                    LoadError = "ไม่พบข้อมูลจังหวัด อำเภอ หรือตำบล";
                    Data = new Dictionary<string, Dictionary<string, List<SubDistrictInfo>>>();
                    return;
                }

                // สร้าง Dictionary: provinceId -> name_th
                var provinceNames = new Dictionary<string, string>();
                foreach (DataRow row in provincesTable.Rows) {
                    var id = row["id"].ToString().Trim();
                    var nameTh = row["name_th"].ToString().Trim();
                    provinceNames[id] = nameTh;
                }

                // สร้าง Dictionary: districtId -> (name_th, province_id)
                var districtInfos = new Dictionary<string, (string Name, string ProvinceId)>();
                foreach (DataRow row in districtsTable.Rows) {
                    var id = row["id"].ToString().Trim();
                    var nameTh = row["name_th"].ToString().Trim();
                    var provinceId = row["province_id"].ToString().Trim();
                    districtInfos[id] = (nameTh, provinceId);
                }

                // สร้างโครงสร้างข้อมูลหลัก
                var result = new Dictionary<string, Dictionary<string, List<SubDistrictInfo>>>();

                // เติมจังหวัดทั้งหมดก่อน
                foreach (var prov in provinceNames.Values) {
                    if (!result.ContainsKey(prov)) {
                        result[prov] = new Dictionary<string, List<SubDistrictInfo>>();
                    }
                }

                // เติมอำเภอทั้งหมดก่อน
                foreach (var dInfo in districtInfos.Values) {
                    if (!provinceNames.TryGetValue(dInfo.ProvinceId, out var provinceName)) {
                        continue;
                    }

                    if (!result.TryGetValue(provinceName, out var districtDict)) {
                        districtDict = new Dictionary<string, List<SubDistrictInfo>>();
                        result[provinceName] = districtDict;
                    }

                    if (!districtDict.ContainsKey(dInfo.Name)) {
                        districtDict[dInfo.Name] = new List<SubDistrictInfo>();
                    }
                }

                // เติมตำบล/แขวง พร้อมรหัสไปรษณีย์
                foreach (DataRow subRow in subDistrictsTable.Rows) {
                    var districtId = subRow["district_id"].ToString().Trim();
                    var subName = subRow["name_th"].ToString().Trim();
                    var zipCode = subRow.Table.Columns.Contains("zip_code")
                        ? subRow["zip_code"].ToString().Trim()
                        : "";

                    if (!districtInfos.TryGetValue(districtId, out var dInfo)) {
                        continue;
                    }

                    if (!provinceNames.TryGetValue(dInfo.ProvinceId, out var provinceName)) {
                        continue;
                    }

                    var districtName = dInfo.Name;

                    if (!result.TryGetValue(provinceName, out var districtDict)) {
                        districtDict = new Dictionary<string, List<SubDistrictInfo>>();
                        result[provinceName] = districtDict;
                    }

                    if (!districtDict.TryGetValue(districtName, out var subList)) {
                        subList = new List<SubDistrictInfo>();
                        districtDict[districtName] = subList;
                    }

                    var subInfo = new SubDistrictInfo { Name = subName, ZipCode = zipCode };
                    if (!subList.Any(s => s.Name == subName)) {
                        subList.Add(subInfo);
                    }
                }

                // เรียงลำดับข้อมูล
                var sorted = new Dictionary<string, Dictionary<string, List<SubDistrictInfo>>>();
                foreach (var prov in result.Keys.OrderBy(x => x)) {
                    var dDict = result[prov];
                    var newDDict = new Dictionary<string, List<SubDistrictInfo>>();
                    foreach (var d in dDict.Keys.OrderBy(x => x)) {
                        var subs = dDict[d];
                        subs.Sort((a, b) => StringComparer.CurrentCulture.Compare(a.Name, b.Name));
                        newDDict[d] = subs;
                    }
                    sorted[prov] = newDDict;
                }

                Data = sorted;
                LoadError = null;

                System.Diagnostics.Debug.WriteLine($"ThaiAddressData: โหลดข้อมูลสำเร็จ - จังหวัด: {Data.Count} แห่ง");
            } catch (Exception ex) {
                LoadError = $"เกิดข้อผิดพลาดในการโหลดข้อมูล: {ex.Message}";
                Data = new Dictionary<string, Dictionary<string, List<SubDistrictInfo>>>();
                System.Diagnostics.Debug.WriteLine($"ThaiAddressData Error: {LoadError}");
            }
        }

        /// <summary>
        /// ค้นหารหัสไปรษณีย์จากชื่อจังหวัด อำเภอ และตำบล
        /// </summary>
        public static string GetZipCode(string province, string district, string subDistrict) {
            if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(district) || string.IsNullOrEmpty(subDistrict)) {
                return "";
            }

            if (Data.TryGetValue(province, out var districts) &&
                districts.TryGetValue(district, out var subDistricts)) {
                var subInfo = subDistricts.FirstOrDefault(s => s.Name == subDistrict);
                return subInfo?.ZipCode ?? "";
            }

            return "";
        }
    }
}
