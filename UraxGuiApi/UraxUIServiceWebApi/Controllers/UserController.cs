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

    public class UserController : ApiController
    {
       readonly User userObj = new User();

        [HttpGet]
        [Route("api/User/GetUserDetails")]
        public HttpResponseMessage GetUserDetails()
        {
            try
            {

                return Request.CreateResponse(HttpStatusCode.OK, userObj.GetUserDetail());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateUser([FromBody] IEnumerable<User> userValue)
        {
            try
            {
                if (ModelState.IsValid && userValue != null)
                {
                    List<User> lstuser = userObj.UpdateUserDetails(userValue);
                    return Request.CreateResponse(HttpStatusCode.OK, lstuser);
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
                string error = Resource.GetResxValueByName("UserDuplicatemsg");
                if (ex.Message.Contains(error))
                {
                    message = error;
                }else
                {
                    message = ex.Message.ToString();
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(message));
            }
        }
        [HttpPost]
        public HttpResponseMessage AddUser(IEnumerable<User> userValue)
        {
            try
            {

                if (ModelState.IsValid && (userValue != null))
                {
                     userObj.AddUserDetails(userValue);
                    return Request.CreateResponse(HttpStatusCode.Created, userValue);
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
                string error = Resource.GetResxValueByName("UserDuplicatemsg");
                if (ex.Message.Contains(error))
                {
                    message = error;
                }else
                {
                    message = ex.Message.ToString();
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(message));

            }

        }

        [HttpDelete]
        public HttpResponseMessage Delete(int UserId)
        {
            try
            {
                userObj.DeleteUserDetails(UserId);

                return Request.CreateResponse(HttpStatusCode.OK, Helper.sDeleteSuccess);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Error.ParameterEmpty(ex.Message.ToString()));

            }
        }
        [HttpGet]
        public HttpResponseMessage GetUser(int UserId)
        {
            try
            {
                List<User> lstUser = new List<User>();
                var result = userObj.GetUser(UserId);
                if (result.Count != 0)
                {
                    foreach (var value in result)
                    {
                        lstUser.Add(new User()
                        {
                            CDSID = value.CDSID,
                            FirstName = value.FirstName,
                            IsActive = (bool)value.IsActive,
                            LastName = value.LastName,
                            LoggedInDate = (DateTime)value.LoginDateUTC,
                            MiddeName = value.MiddeName,
                            OfficialEmail = value.OfficialEmail,
                            PersionalEMail = value.PersionalEMail,
                            PhoneNo = value.PhoneNo,
                            StatusID = (int)value.StatusID,
                            UDetailsId = value.UDetailsId,
                            UserTypeId = (int)value.UserTypeId
                        });
                    }
                    return Request.CreateResponse(HttpStatusCode.OK, lstUser);
                }
                else
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, Helper.sIdNotFound + UserId);

            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            }
        }
    }
}
