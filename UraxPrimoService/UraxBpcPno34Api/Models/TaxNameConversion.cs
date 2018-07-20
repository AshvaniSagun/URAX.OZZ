using System;
using System.Collections.Generic;
using System.Linq;
using UraxBpcPno34Api.EF;
using UraxBPCPNO34Api.Models;

namespace UraxBpcPno34Api.Models
{
    public class TaxNameConversion
    {
        private const string CacheTaxNameKey = "availableTaxName";

        /// <summary>
        /// Get Locale Tax Name
        /// </summary>
        /// <param name="TaxLocaleName"></param>
        /// <param name="outResult"></param>
        /// <returns></returns>
        public static List<ResultVatDetails> GetConvertTaxName(List<TaxNameDetails> TaxLocaleName, List<ResultVatDetails> outResult)
        {
            try
            {
                var FeatureWithVatRate = outResult.SelectMany
               (
                   x => TaxLocaleName.Where(y => x.TaxId == y.TaxMasterId).DefaultIfEmpty(),
                   (x, y) => new ResultVatDetails
                   {
                       TaxName = y != null ? y.TaxName : x.TaxName,
                       SequenceId = x.SequenceId,
                        TaxId = x.TaxId,
                       Value = x.Value,
                       VatPosition = x.VatPosition,
                       VatPositionId = x.VatPositionId,
                       Pno34 = x.Pno34
                   }
               ).ToList();
                return FeatureWithVatRate;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Tax Name By Locale
        /// </summary>
        /// <param name="Locale"></param>
        /// <returns></returns>
        public static List<TaxNameDetails> GetTaxNameByLocale(string Locale)
        {
            // RedisCache objRedish = RedisCache.Instance;
            List<TaxNameDetails> lstavailableTaxName = new List<TaxNameDetails>();
            try
            {
                CacheFound:
                var result = RedisCache.GetCache<List<TaxNameDetails>>(CacheTaxNameKey);
                if (result == null)
                {
                    GetAllTaxName();
                    goto CacheFound;
                }
                else
                {
                    lstavailableTaxName = result.Where(x => x.LanguageCountrycode == Locale).ToList();
                }
                return lstavailableTaxName;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Get Locale TaxName with Redis 
        /// </summary>
        public static void GetAllTaxName()
        {
            // RedisCache objRedish = RedisCache.Instance;
            try
            {
                using (URAXEntities context = new URAXEntities())
                {
                    string CommandText = @"SELECT DISTINCT ld.TaxName,UPPER(l.LanguageCountrycode) LanguageCountrycode,ld.IsDefault,CAST(tm.TaxMasterId AS INT)  TaxMasterId FROM dbo.LanguageDetails ld
												INNER JOIN dbo.TaxVersion tv ON tv.TaxMasterId = ld.TaxMasterId
												INNER JOIN dbo.Tax t ON t.TaxVersionId = tv.TaxVersionId
                                                INNER JOIN dbo.Languages l ON ld.LanguageId = l.LanguageId
                                                INNER JOIN TaxMaster tm ON tm.TaxMasterId = ld.TaxMasterId";
                    var availableTaxName = context.Database.SqlQuery<TaxNameDetails>(CommandText).ToList();
                    RedisCache.AddCache(CacheTaxNameKey, availableTaxName, 365);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
