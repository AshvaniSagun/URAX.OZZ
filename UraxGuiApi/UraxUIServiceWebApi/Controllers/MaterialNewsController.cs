using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UraxUIServiceWebApi.Models;

namespace UraxUIServiceWebApi.Controllers
{
    // [Authorize] // security integration  

    public class MaterialNewsController : ApiController
    {
        readonly MaterialNews materialNewsObj = new MaterialNews();

       
        [HttpGet]
        [Route("api/MaterialNews/GetHomeMaterialNews")]
        public HttpResponseMessage GetHomeMaterialNews()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, materialNewsObj.GetHomeMaterialNews());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        [HttpGet]
        public HttpResponseMessage GetMaterialNewsByContentTypeID(int ContentTypeID)
        {
            try
            {
                List<MaterialNews> lstMaterialNews = materialNewsObj.GetMaterialNewsByContentTypeID(ContentTypeID);
                if (lstMaterialNews.Count != 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstMaterialNews);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + ContentTypeID);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }

        [HttpGet]
        [Route("api/MaterialNews/GetCurrentMaterialNews")]
        public HttpResponseMessage GetCurrentMaterialNews()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new MaterialNews().GetCurrentMaterialNews());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }
        [HttpPost]
        [Route("api/MaterialNews/PostBaseMaterialNews")]
        public HttpResponseMessage PostBaseMaterialNews(MaterialNewsBase materialNews)
        {
            try
            {
                if (ModelState.IsValid && materialNews != null)
                {
                    materialNewsObj.PostBaseMaterialNews(materialNews);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sInsertSuccess, true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                         Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                 .SelectMany(x => x.Errors)
                                                 .Select(x => x.ErrorMessage))));

                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }


        [HttpPost]
        [Route("api/MaterialNews/PostPreviewMaterialNews")]
        public HttpResponseMessage PostPreviewMaterialNews(MaterialNewsBase materialNews)
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, new MaterialNews().GetCurrentPreviewMaterialNews(materialNews));
            }
            catch (Exception ex)
            {
                string message = String.Empty;
                string error = Resource.GetResxValueByName("CmnDataNotFound");
                if (ex.Message.Contains(error))
                {
                    message = error;
                }
                else
                {
                    message = ex.Message.ToString();
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(message));
            }
        }

        [HttpPut]
        [Route("api/MaterialNews/UpdateBaseMaterialNews")]
        public HttpResponseMessage UpdateBaseMaterialNews(MaterialNewsBase MaterialNewsValue)
        {
            try
            {
                if (ModelState.IsValid && MaterialNewsValue != null)
                {
                    materialNewsObj.UpdateBaseMaterialNews(MaterialNewsValue);
                    return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(Helper.sUpdateSuccess, true));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                         Error.GetErrorDetails(string.Join(", ", ModelState.Values
                                                 .SelectMany(x => x.Errors)
                                                 .Select(x => x.ErrorMessage))));

                }
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, Error.GetErrorDetails(ex.Message.ToString()));
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int MaterialNewsId)
        {
            try
            {
                materialNewsObj.DeleteMaterialNews(MaterialNewsId);
                return Request.CreateResponse(HttpStatusCode.OK, Helper.sDeleteSuccess);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

     
    }
}
