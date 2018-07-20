using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text.RegularExpressions;
using UraxUIServiceWebApi.ResourceFiles;

namespace UraxUIServiceWebApi.Models
{
    public static class Common
    {
        public static bool IsNumeric(object Expression)
        {
            double retNum;
            bool isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
            return isNum;
        }
        /// <summary>
        /// Check the string is alphanumeric or not
        /// </summary>
        /// <param name="strToCheck"></param>
        /// <returns></returns>
        public static Boolean isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex("[^a-zA-Z0-9]");

            //if has non AlpahNumeric char, return false, else return true.
            return rg.IsMatch(strToCheck) == true ? false : true;
        }

    }
    public static class Error
    {
        public static List<Errorlist> GetErrorDetails(string Message = "", bool isSuccess = false)
        {
            List<Errorlist> lstError = new List<Errorlist>() { new Errorlist()
            {
                ErrorMsg = isSuccess == false ? Message : "",
                SuccessMsg = isSuccess == true ? Message : ""
            }};
            return lstError;
        }
        public static List<ErrorMessage> ParameterEmpty(string innerMessage = "", string message = "")
        {
            message = (message == string.Empty || message == "") ? Resource.GetResxValueByName("ApplicationError") : message;
            List<ErrorMessage> errorlst = new List<ErrorMessage>();
            List<ModelState> err = InnerError(innerMessage);
            errorlst.Add(new ErrorMessage() { Message = message, ModelState = err });
            return errorlst;
        }
        public static List<ErrorMessage> ModelValidation(ModelState model)
        {
            List<ErrorMessage> errorlst = new List<ErrorMessage>();
            return errorlst;
        }
        private static List<ModelState> InnerError(string message)
        {
            List<ModelState> err = new List<ModelState>() { new ModelState() { Message = message } };
            return err;
        }
    }
    public class ErrorMsgList
    {
        [JsonProperty(PropertyName = "Errorlist")]
        public List<Errorlist> ErrorMessageList { get; set; }
        public ErrorMsgList(List<Errorlist> lst)
        {
            ErrorMessageList = lst;
        }
    }
    public class Errorlist
    {
        [JsonProperty(PropertyName = "errormsg")]
        public string ErrorMsg { get; set; }
        [JsonProperty(PropertyName = "successmsg")]
        public string SuccessMsg { get; set; }
    }
    public class ErrorMessage
    {
        public string Message { get; set; }
        public List<ModelState> ModelState { get; set; }
    }
    public class ModelState
    {
        public string Message { get; set; }
    }
    public static class Resource
    {
        public static string GetResxValueByName(string key)
        {
            ResourceManager myManager = new ResourceManager(typeof(Message));
            return myManager.GetString(key);
        }
    }
    public static class Extension
    {
        #region Locale Extension Methods for converting date,Decimal point,Numeric  comma seperator 
        public static string ToDate(this string inputDateString)
        {
            return DateTime.Parse(inputDateString, CultureInfo.InvariantCulture).ToString(CultureInfo.GetCultureInfo("en-US"));
        }
        public static string ToCultureDate(this string inputDateString, CultureInfo clInfo)
        {
            return DateTime.Parse(inputDateString, CultureInfo.InvariantCulture).ToString(clInfo);
        }
        public static decimal ToDecimal(this string inputValue)
        {
            return decimal.Parse(inputValue, new CultureInfo("es"));
        }
        public static string ToCultureDecimal(this decimal inputValue, NumberFormatInfo numberFormat)
        {
            return inputValue.ToString("N", numberFormat);
        }

        #endregion
    }
    public class List
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}