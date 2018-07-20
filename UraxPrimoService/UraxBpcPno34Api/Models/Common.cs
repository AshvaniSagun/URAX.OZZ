using System;
using System.Collections.Generic;
using System.Globalization;

namespace UraxBPCPNO34.Models
{

    public static class Extension
    {

        #region Locale Extension Methods for converting date,Decimal point,Numeric  comma seperator 
        /// <summary>
        /// Convert Date string to en_US culture date
        /// </summary>
        /// <param name="inputDateString"></param>
        /// <returns></returns>
        public static string ToDate(this string inputDateString)
        {
            return DateTime.Parse(inputDateString, CultureInfo.InvariantCulture).ToString(CultureInfo.GetCultureInfo("en-US"));
        }

        /// <summary>
        /// Convert string Date to respective culture date
        /// </summary>
        /// <param name="inputDateString"></param>
        /// <param name="clInfo"></param>
        /// <returns></returns>
        public static string ToCultureDate(this string inputDateString, CultureInfo clInfo)
        {
            return DateTime.Parse(inputDateString, CultureInfo.InvariantCulture).ToString(clInfo);
        }

        public static decimal ToDecimal(this string inputValue, NumberFormatInfo numberFormat)
        {
            // return inputValue.ToString("N", numberFormat);
            try
            {
                return decimal.Parse(inputValue, numberFormat);
            }
            catch (Exception )
            {
                return decimal.Parse(inputValue.Replace(" ", string.Empty), new CultureInfo("en-US"));
            }
        }
        /// <summary>
        /// Convert input decimal data to respective culture format 
        /// </summary>
        /// <param name="inputValue"></param>
        /// <param name="numberFormat"></param>
        /// <returns></returns>
        public static string ToCultureDecimal(this decimal inputValue, NumberFormatInfo numberFormat)
        {
            return inputValue.ToString("N", numberFormat);
        }
        #endregion

        public static void CreateNewOrUpdateExistingDic<TKey, TValue>(
    this Dictionary<TKey, TValue> map, Dictionary<TKey, TValue> mapvalue)
        {
            foreach (var data in mapvalue)
            {
                if (map.ContainsKey(data.Key))
                {
                    map[data.Key] = data.Value;
                }
                else
                {
                    map.Add(data.Key, data.Value);
                }
            }

        }

    }

    public static class Resource
    {
        /// <summary>
        /// Get param value from resource file by param key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>key value message</returns>
        //public static string GetResxValueByName(string key)
        //{
        //    ResourceManager myManager = new ResourceManager(typeof(Message));
        //    return myManager.GetString(key);
        //}

    }
}