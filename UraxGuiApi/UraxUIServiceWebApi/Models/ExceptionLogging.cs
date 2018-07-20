using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UraxUIServiceWebApi.EF;

namespace UraxUIServiceWebApi.Models
{
    public static class ExceptionLogging
    {
        private static String exepurl;
      
        public static void SendExcepToDB(Exception exdb)
        {

            using (URAXEntities context = new URAXEntities())
            {
                exepurl = HttpContext.Current.Request.Url.ToString();
                try
                {
                    SqlParameter ExceptionMsg = new SqlParameter("@ExceptionMsg", exdb.Message.ToString());
                    SqlParameter ExceptionType = new SqlParameter("@ExceptionType", exdb.GetType().Name.ToString());
                    SqlParameter ExceptionURL = new SqlParameter("@ExceptionURL", exepurl);
                    SqlParameter ExceptionSource = new SqlParameter("@ExceptionSource", exdb.StackTrace.ToString());

                    var lstResult = context.Database.SqlQuery<string>("ExceptionLoggingToDataBase  @ExceptionMsg, @ExceptionType ,@ExceptionURL,@ExceptionSource ", ExceptionMsg, ExceptionType, ExceptionURL, ExceptionSource).ToList();
                   
                }
                catch (Exception)
                {

                    throw;
                }
            }

        }
    }
}