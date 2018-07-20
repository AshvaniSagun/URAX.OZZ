using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Models;

namespace UraxUIServiceWebApi.Controllers
{
    //TODO : need to add Authroze once GUI is ready to take authorize value
   // [Authorize]
    public class LanguagesController : ApiController
    {
        readonly Language languageObj = new Language();

        private  List<LanguageList> GetLanguageList()
        {
            List<LanguageList> lstLanguage = new List<LanguageList>();
            try
            {
                var result = languageObj.GetLanguage();

                foreach (var param in result)
                {
                    lstLanguage.Add(new LanguageList()
                    {
                        LanguageId = (int)param.LanguageId,

                        Language = param.Language1
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstLanguage;
        }


        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetLanguageList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }


       


        [HttpGet]
        public HttpResponseMessage Get(int Id)
        {
            try
            {
                List<Language> lstLanguage = new List<Language>();
                var result = languageObj.GetLanguage(Id);
                if (result.Count != 0)
                {
                    foreach (var param in result)
                    {
                        lstLanguage.Add(new Language()
                        {
                            LanguageId = param.LanguageId,
                            CountryCode = param.CountryCode,
                            LanguageName = param.Language1,
                            LanguageCountryCode = param.LanguageCountrycode,                            
                            IsActive = param.IsActive,
                            CreatedBy = param.CreatedBy,
                            CreatedOn = param.CreatedOn,
                            UpdatedBy = param.UpdatedBy,
                            UpdatedOn = param.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstLanguage);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + Id);

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

    }
}