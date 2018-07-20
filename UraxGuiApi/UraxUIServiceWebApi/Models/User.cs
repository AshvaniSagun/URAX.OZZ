#region NameSpace
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles;
using EF = UraxUIServiceWebApi.EF; 
#endregion
namespace UraxUIServiceWebApi.Models
{
    public class User
    {
        #region User Property
        [JsonProperty(PropertyName = "uDetailsId")]
        public long UDetailsId { get; set; }
        [JsonProperty(PropertyName = "cdsId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CDSIDReq")]
        public string CDSID { get; set; }
        [JsonProperty(PropertyName = "firstName")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "FirstNameReq")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "middleName")]
        public string MiddeName { get; set; }
        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "phoneNo")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "PhoneNoReq")]
        public string PhoneNo { get; set; }
        [JsonProperty(PropertyName = "officialEmail")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "OfficialEmailReq")]
        public string OfficialEmail { get; set; }
        [JsonProperty(PropertyName = "personalEmail")]
        public string PersionalEMail { get; set; }
        [JsonProperty(PropertyName = "statusId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "StatusIDReq")]
        public int StatusID { get; set; }
        [JsonProperty(PropertyName = "userTypeId")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "UserTypeIdReq")]
        public int UserTypeId { get; set; }
        [JsonProperty(PropertyName = "loggedInDate")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "LoggedInDateReq")]
        public DateTime LoggedInDate { get; set; }
        [JsonProperty(PropertyName = "isActive")]
        public bool IsActive { get; set; }

        [JsonProperty(PropertyName = "createdBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "CreatedByReq")]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public System.DateTime CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedBy")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "UpdatedByReq")]
        public string UpdatedBy { get; set; }
        [JsonProperty(PropertyName = "updatedOn")]
        public System.DateTime UpdatedOn { get; set; }
        #endregion

        #region Get All User Details
        /// <summary>
        /// To get all User Details
        /// </summary>
        /// <returns>List of User Details</returns>
        internal List<User> GetUserDetail()
        {
            List<User> lstUser = new List<User>();
            try
            {

                using (var user = new UnitofWork())
                {
                    var result = user.UserDetailRepository.GetAll().ToList<EF.UserDetail>();
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
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lstUser;
        }
        #endregion

        #region Update  User Details
        /// <summary>
        /// To update User Details
        /// </summary>
        /// <param name="userValue">List of User details to update</param>
        /// <returns>List of updated User details</returns>
        internal List<User> UpdateUserDetails(IEnumerable<User> userValue)
        {
            try
            {
                using (var user = new UnitofWork())
                {
                    foreach (var data in userValue)
                    {
                        long Id = data.UDetailsId;
                       
                        if (user.UserDetailRepository.Find(x => x.UDetailsId == Id).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }else if(user.UserDetailRepository.Find(x => x.UDetailsId != Id&&(x.CDSID==data.CDSID)).ToList().Count> 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CDSIDDuplicatemsg"));
                        }
                        
                    }
                }

                List<EF.UserDetail> lstUser = new List<EF.UserDetail>();
                List<string> lstField = new List<string>();
                foreach (var value in userValue)
                {
                    lstUser.Add(new EF.UserDetail()
                    {
                        CDSID = value.CDSID,
                        PersionalEMail = value.PersionalEMail,
                        UDetailsId = value.UDetailsId,
                        FirstName = value.FirstName,
                        LastName = value.LastName,
                        LoginDateUTC = DateTime.UtcNow,
                        MiddeName = value.MiddeName,
                        OfficialEmail = value.OfficialEmail,
                        PhoneNo = value.PhoneNo,
                        StatusID = value.StatusID,
                        UserTypeId = value.UserTypeId,
                        IsActive = value.IsActive,
                        CreatedBy = value.CreatedBy,
                        CreatedOn = value.CreatedOn,
                        UpdatedBy = value.UpdatedBy,
                        UpdatedOn = DateTime.UtcNow




                    });
                }

                lstField.Add("PersionalEMail");
                lstField.Add("CDSID");
                lstField.Add("FirstName");
                lstField.Add("LastName");
                lstField.Add("MiddeName");
                lstField.Add("OfficialEmail");
                lstField.Add("PhoneNo");
                lstField.Add("StatusID");
                lstField.Add("UserTypeId");
                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");


                using (var userObj = new UnitofWork())
                {
                    userObj.UserDetailRepository.UpdateRange(lstUser, lstField);
                }
                List<User> lstuserdetail = new User().GetUserDetail();
                return lstuserdetail;
            }


            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Add User Details
        /// <summary>
        /// To add User Details
        /// </summary>
        /// <param name="userValue">List of User Details to add</param>
        internal List<User> AddUserDetails(IEnumerable<User> userValue)
        {
            try
            {
                using (var user = new UnitofWork())
                {
                    foreach (var item in userValue)
                    {
                        string UserCDSID = item.CDSID;
                        if (user.UserDetailRepository.Find(x => x.CDSID == UserCDSID).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CDSIDDuplicatemsg"));
                        }
                    }
                    List<EF.UserDetail> lstUserDetails = new List<EF.UserDetail>();
                    foreach (var item in userValue)
                    {
                        lstUserDetails.Add(new EF.UserDetail()
                        {
                            CDSID = item.CDSID,
                            UDetailsId = item.UDetailsId,
                            CreatedBy = item.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            FirstName = item.FirstName,
                            IsActive = item.IsActive,
                            LastName = item.LastName,
                            LoginDateUTC = DateTime.UtcNow,
                            MiddeName = item.MiddeName,
                            OfficialEmail = item.OfficialEmail,
                            PersionalEMail = item.PersionalEMail,
                            PhoneNo = item.PhoneNo,
                            StatusID = item.StatusID,
                            UpdatedBy = item.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow,
                            UserTypeId = item.UserTypeId
                        });
                    }

                    user.UserDetailRepository.AddRange(lstUserDetails);
                    List<User> lstUser = new List<User>();

                    using (var userResponse = new UnitofWork())
                    {
                        foreach (var data in lstUserDetails)
                        {
                            int udId = (int)data.UDetailsId;

                            using (var user1 = new UnitofWork())
                            {

                                var result = user.UserDetailRepository.Find(x => x.UDetailsId == udId).ToList<EF.UserDetail>();
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
                            }
                        }
                    }
                    return lstUser;
                }

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Delete  User Details
        /// <summary>
        /// To delete User Details
        /// </summary>
        /// <param name="userId">An Integer which represents User Id</param>
        internal void DeleteUserDetails(int userId)
        {
            try
            {
                using (var user = new UnitofWork())
                {
                    List<EF.UserDetail> lstuser = user.UserDetailRepository.Find(p => p.UDetailsId == userId).ToList();
                    if (lstuser.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    List<EF.UserDetail> lstUserDetail= user.UserDetailRepository.Find(p => p.UDetailsId == userId).ToList();
                    int UserDetailsId = (int)lstUserDetail[0].UDetailsId;
                    List<EF.UserRole> lstUserRole = user.UserRoleRepository.Find(p => p.UDetailsId == UserDetailsId).ToList();
                    user.UserRoleRepository.RemoveRange(lstUserRole);
                    user.UserDetailRepository.RemoveRange(lstUserDetail);
                }
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Get User by UserId
        /// <summary>
        /// To get User by User Id
        /// </summary>
        /// <param name="UserId">An integer which represents User Id</param>
        /// <returns>List of User Details</returns>
        public List<EF.UserDetail> GetUser(int UserId)
        {
            try
            {
                using (var user = new UnitofWork())
                {
                    return user.UserDetailRepository.Find(p => p.UDetailsId == UserId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        } 
        #endregion



    }
}