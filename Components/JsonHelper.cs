using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;
using System.Collections;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ZtbSoft
{
    /// <summary>
    /// Json序列化和反序列化辅助类 
    /// </summary>
    public class JsonHelper
    {
        //    public static List<T> JSONStringToList<T>(string JsonStr)
        //    {
        //        JavaScriptSerializer Serializer = new JavaScriptSerializer();
        //        List<T> objs = Serializer.Deserialize<List<T>>(JsonStr);
        //        return objs;
        //    }

        //    // 将 DataTable 序列化成 json 字符串
        //    public static string DataTableToJson(DataTable dt)
        //    {
        //        if (dt == null || dt.Rows.Count == 0)
        //        {
        //            return "\"\"";
        //        }
        //        JavaScriptSerializer myJson = new JavaScriptSerializer();

        //        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();

        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Dictionary<string, object> result = new Dictionary<string, object>();
        //            foreach (DataColumn dc in dt.Columns)
        //            {
        //                result.Add(dc.ColumnName, dr[dc].ToString());
        //            }
        //            list.Add(result);
        //        }
        //        return myJson.Serialize(list);
        //    }

        //    // 将对象序列化成 json 字符串
        //    public static string ObjectToJson(object obj)
        //    {
        //        if (obj == null)
        //        {
        //            return string.Empty;
        //        }
        //        JavaScriptSerializer myJson = new JavaScriptSerializer();

        //        return myJson.Serialize(obj);
        //    }

        //    // 将 json 字符串反序列化成对象
        //    public static object JsonToObject(string json)
        //    {
        //        if (string.IsNullOrEmpty(json))
        //        {
        //            return null;
        //        }
        //        JavaScriptSerializer myJson = new JavaScriptSerializer();

        //        return myJson.DeserializeObject(json);
        //    }

        // 将 json 字符串反序列化成对象
        public static T JsonToObject<T>(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return default(T);
            }
            JavaScriptSerializer myJson = new JavaScriptSerializer();

            return myJson.Deserialize<T>(json);
        }

        #region miniui

        public static string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        /// <summary>
        /// 对象转换为json
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string Encode(object o)
        {
            if (o == null || o.ToString() == "null") return null;

            if (o != null && (o.GetType() == typeof(String) || o.GetType() == typeof(string)))
            {
                return o.ToString();
            }
            IsoDateTimeConverter dt = new IsoDateTimeConverter();
            dt.DateTimeFormat = DateTimeFormat;
            return JsonConvert.SerializeObject(o, dt);
        }

        /// <summary>
        /// json转换为对象
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static object Decode(string json)
        {
            if (String.IsNullOrEmpty(json)) return "";
            object o = JsonConvert.DeserializeObject(json);
            if (o.GetType() == typeof(String) || o.GetType() == typeof(string))
            {
                o = JsonConvert.DeserializeObject(o.ToString());
            }
            object v = toObject(o);
            return v;
        }

        /// <summary>
        /// DataTable转换为ArrayList
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ArrayList DataTableToArrayList(DataTable data)
        {
            ArrayList array = new ArrayList();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];

                Hashtable record = new Hashtable();
                for (int j = 0; j < data.Columns.Count; j++)
                {

                    object cellValue = row[j];

                    if (cellValue.GetType() == typeof(DBNull))
                    {
                        cellValue = null;
                    }
                    else if (cellValue.GetType() == typeof(bool))
                    {
                        cellValue = Convert.ToInt32(cellValue);
                    }
                    record[data.Columns[j].ColumnName] = cellValue;
                }
                array.Add(record);
            }
            return array;
        }

        private static object toObject(object o)
        {
            if (o == null) return null;

            if (o.GetType() == typeof(string))
            {

                string s = o.ToString();
                //判断是否符合2010-09-02T10:00:00的格式
                if (s.Length == 19 && s[10] == 'T' && s[4] == '-' && s[13] == ':')
                {
                    o = System.Convert.ToDateTime(o);
                }
            }
            else if (o is JObject)
            {
                JObject jo = o as JObject;

                Hashtable h = new Hashtable();

                foreach (KeyValuePair<string, JToken> entry in jo)
                {
                    h[entry.Key] = toObject(entry.Value);
                }

                o = h;
            }
            else if (o is IList)
            {

                ArrayList list = new ArrayList();
                list.AddRange((o as IList));
                for (int i = 0; i < list.Count; i++)
                {
                    list[i] = toObject(list[i]);
                }
                o = list;

            }
            else if (typeof(JValue) == o.GetType())
            {
                JValue v = (JValue)o;
                o = toObject(v.Value);
            }
            return o;
        }
        #endregion
    }
}