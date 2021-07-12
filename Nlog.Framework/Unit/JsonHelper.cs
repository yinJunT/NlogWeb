using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nlog.Framework.Unit
{
    /// <summary>
    /// <![CDATA[转换类型]]>
    /// </summary>
    public static class JsonHelper
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(JsonHelper));
        public static string ObjToJsonString(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception ex)
            {
                log.DebugFormat($"Went into error:{ex}");
                throw;
            }
        }

        public static string IgnoredNullPropertiesToJson(object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
            catch (Exception ex)
            {
                log.DebugFormat($"Went into error:{ex}");
                throw;
            }
        }

        public static T JsonStringToObj<T>(string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception ex)
            {
                log.ErrorFormat($"Went into error:{ex}. \r\n Context-data: jsonString:{jsonString}", ex);
                throw;
            }
        }

        public static object JsonStringToObj(string jsonString, Type type)
        {
            try
            {
                return JsonConvert.DeserializeObject(jsonString, type);
            }
            catch (Exception ex)
            {
                log.ErrorFormat($"Went into error:{ex}. \r\n Context-data: jsonString:{jsonString}", ex);
                throw;
            }
        }
        public static Dictionary<TKey, TValue> DeserializeStringToDictionary<TKey, TValue>(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return new Dictionary<TKey, TValue>();
            Dictionary<TKey, TValue> jsonDict = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(jsonStr);

            return jsonDict;
        }
    }
}
