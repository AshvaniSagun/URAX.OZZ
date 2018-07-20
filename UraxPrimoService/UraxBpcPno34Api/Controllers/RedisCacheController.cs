using System.Collections.Generic;
using System.Web.Http;
using UraxBpcPno34Api.Models;

namespace GCCServiceWebApi.Controllers
{
    
    public class RedisCacheController : ApiController
    {

        #region Redis Cache
        /// <summary>
        /// Refesh the Locale tax name in redis Cache
        /// </summary>
        [HttpGet]
        public string  GetClearLocalTaxNameCache()
        {
            TaxNameConversion.GetAllTaxName();

            return "Local Tax Name Updated Sucessfully";
        }
        #endregion

    }
}
