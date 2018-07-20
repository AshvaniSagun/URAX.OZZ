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
    // [Authorize] // security integration  

    public class TreeStructureController : ApiController
    {
       readonly TreeStructue TreeStructureObj = new TreeStructue();

        [HttpGet]
        public HttpResponseMessage GetTreeStructure(int MktId)
        {
            try { 
                    List<TreeStructue> lstTreeStructureList = TreeStructureObj.GetTreeStructureDetails(MktId);

                if (lstTreeStructureList.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, lstTreeStructureList);
                }

                else
                
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,Helper.sIdNotFound + MktId);

                }

            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }

        }

    }
}
