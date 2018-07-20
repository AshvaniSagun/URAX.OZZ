using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Models;
using UraxUIServiceWebApi.Repository;

namespace UraxUIServiceWebApi.Controllers
{
    // [Authorize] // security integration  

    public class UserRolesController : ApiController
    {
        readonly UserRoles userRolesObj = new UserRoles();
        [HttpGet]
       
        public HttpResponseMessage GetUserRoleDetails(int Id)
        {
            try
            {
                List<UserRoles> lstUser = new List<UserRoles>();
                var result = userRolesObj.GetUserroleById(Id);
                if (result.Count != 0)
                {
                    foreach (var data in result)
                    {
                        lstUser.Add(new UserRoles()
                        {
                            UserRoleId = data.UserRoleId,
                            UDetailsId = data.UDetailsId,
                            CountryCodeID = data.CountryCodeID,
                            AccessLevelId = data.AccessLevelId,
                            Authorization = data.Authorization,
                            IsActive = data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = data.CreatedOn,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = data.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstUser);
                }
                else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + Id);

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        [HttpGet]
        public HttpResponseMessage GetUserRole(string CDSId)
        {
            try
            {
                List<UserRoles> lstUser = new List<UserRoles>();
                var result = userRolesObj.GetUserroleByCDSId(CDSId);
                if (result.Count != 0)
                {
                    foreach (var data in result)
                    {
                        lstUser.Add(new UserRoles()
                        {
                            UserRoleId = data.UserRoleId,
                            UDetailsId = data.UDetailsId,
                            CountryCodeID = data.CountryCodeID,
                            AccessLevelId = data.AccessLevelId,
                            Authorization = data.Authorization,
                            IsActive = data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = data.CreatedOn,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = data.UpdatedOn
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstUser);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,Helper.sIdNotFound + CDSId);

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
        [HttpDelete]
        public HttpResponseMessage Delete(int userid)
        {
            try
            {
                userRolesObj.DeleteUserRole(userid);

                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));

            }
        }

        [HttpPost]
        public HttpResponseMessage AddUserRoles(IEnumerable<UserRoles> UserValue)
        {
            try
            {

                if (ModelState.IsValid && (UserValue != null))
                {
                    userRolesObj.AddUserRole(UserValue);
                    return Request.CreateResponse(HttpStatusCode.Created, GetUserRoleList());
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                        Error.ParameterEmpty(string.Join(", ", ModelState.Values
                                                .SelectMany(x => x.Errors)
                                                .Select(x => x.ErrorMessage))));
                }
            }
            catch (Exception ex)
            {

                string message = String.Empty;
                string error = Resource.GetResxValueByName("MarketDuplicatemsg");
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

        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, GetUserRoleList());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }
        private List<UserRoles> GetUserRoleList()
        {
            List<UserRoles> lstUser = new List<UserRoles>();
            try
            {
                var result = userRolesObj.GetUserRole();
                foreach (var param in result)
                {
                    lstUser.Add(new UserRoles()
                    {
                        UserRoleId = (int)param.UserRoleId,
                        Authorization = param.Authorization,
                        AccessLevelId = param.AccessLevelId,
                        CountryCodeID = param.CountryCodeID,
                        UDetailsId = param.UDetailsId

                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstUser;
        }
        [HttpPut]
        public HttpResponseMessage UpdateUserRoles([FromBody] IEnumerable<UserRoles> user)
        {
            try
            {
                if (ModelState.IsValid && user != null)
                {
                    List<EF.UserRole> lstupdateformula = userRolesObj.UpdateUserRole(user);
                    return Request.CreateResponse(HttpStatusCode.OK, lstupdateformula);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest,
                         Error.ParameterEmpty(string.Join(", ", ModelState.Values
                                                 .SelectMany(x => x.Errors)
                                                 .Select(x => x.ErrorMessage))));

                }
            }
            catch (Exception ex)
            {

                string message = String.Empty;
                string error = Resource.GetResxValueByName("MarketDuplicatemsg");
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


    }
}
