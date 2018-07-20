#region NameSpace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Web;
using EF = UraxUIServiceWebApi.EF;
using UraxUIServiceWebApi.Models;
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles; 
#endregion

namespace UraxUIServiceWebApi.Models
{
    public class UserRoles
    {

        #region UserRoles Property

        [JsonProperty(PropertyName = "userRoleId")]
        public long UserRoleId { get; set; }
        [JsonProperty(PropertyName = "uDetailsId")]
        public Nullable<long> UDetailsId { get; set; }
        [JsonProperty(PropertyName = "countryCodeId")]
        public Nullable<long> CountryCodeID { get; set; }
        [JsonProperty(PropertyName = "accessLevelId")]
        public Nullable<int> AccessLevelId { get; set; }
        [JsonProperty(PropertyName = "authorization")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "AuthorizationReq")]
        public string Authorization { get; set; }
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

        #region Get all UserRole Details
        /// <summary>
        /// To get all User Role Details
        /// </summary>
        /// <returns>List of UserRole Details</returns>
        public List<EF.UserRole> GetUserRole()
        {
            try
            {
                using (var user = new UnitofWork())
                {
                    return user.UserRoleRepository.GetAll().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Get User Role Details by UserRole Id
        /// <summary>
        /// To get User Role Details by User Role Id
        /// </summary>
        /// <param name="userroleId">an integer which represents UserRoleId</param>
        /// <returns>List of UserRole Details</returns>
        public List<UserRoles> GetUserroleById(int userroleId)
        {
            List<UserRoles> lstUserRole = new List<UserRoles>();
            try
            {
                using (var userrole = new UnitofWork())
                {
                    var result = userrole.UserRoleRepository.Find(p => p.UserRoleId == userroleId).ToList();
                    foreach (var data in result)
                    {
                        lstUserRole.Add(new UserRoles()
                        {
                            UserRoleId = data.UserRoleId,
                            UDetailsId = data.UDetailsId,
                            CountryCodeID = data.CountryCodeID,
                            AccessLevelId = data.AccessLevelId,
                            Authorization = data.Authorization,
                            IsActive = (bool)data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = (DateTime)data.CreatedOn,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = (DateTime)data.UpdatedOn

                        });
                    }

                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
            return lstUserRole;
        }
        #endregion

        #region Get User RoleDetails by CDSId
        /// <summary>
        /// To get User Role Details by CDSId
        /// </summary>
        /// <param name="CDSId">an integer which represents CDSId</param>
        /// <returns>List of UserRole Details</returns>
        internal List<UserRoles> GetUserroleByCDSId(string CDSId)
        {
            List<UserRoles> lstUserRole = new List<UserRoles>();
            try
            {
                using (var userrole = new UnitofWork())
                {
                    var resultUserDetails = userrole.UserDetailRepository.Find(p => p.CDSID == CDSId).ToList();
                    int DetailsId = resultUserDetails.Count > 0 ? (int)resultUserDetails.First().UDetailsId : 0;
                    var result = userrole.UserRoleRepository.Find(p => p.UDetailsId == DetailsId).ToList();
                    foreach (var data in result)
                    {
                        lstUserRole.Add(new UserRoles()
                        {
                            UserRoleId = data.UserRoleId,
                            UDetailsId = data.UDetailsId,
                            CountryCodeID = data.CountryCodeID,
                            AccessLevelId = data.AccessLevelId,
                            Authorization = data.Authorization,
                            IsActive = (bool)data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = (DateTime)data.CreatedOn,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = (DateTime)data.UpdatedOn

                        });
                    }

                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
            return lstUserRole;
        }
        #endregion

        #region Add UserRole Details
        /// <summary>
        /// To add UserRole Details
        /// </summary>
        /// <param name="userRole">List of User Role Details to add</param>
        public void AddUserRole(IEnumerable<UserRoles> userRole)
        {
            try
            {
                using (var user = new UnitofWork())
                {
                    foreach (var item in userRole)
                    {
                        long userRoleId = item.UserRoleId;
                        if (user.UserRoleRepository.Find(x => x.UserRoleId == userRoleId).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("User exists"));
                        }
                    }
                    List<EF.UserRole> lstUserRole = new List<EF.UserRole>();
                    foreach (var data in userRole)
                    {
                        lstUserRole.Add(new EF.UserRole()
                        {
                            UserRoleId = data.UserRoleId,
                            UDetailsId = data.UDetailsId,
                            CountryCodeID = data.CountryCodeID,
                            AccessLevelId = data.AccessLevelId,
                            Authorization = data.Authorization,
                            IsActive = data.IsActive,
                            CreatedBy = data.CreatedBy,
                            CreatedOn = DateTime.UtcNow,
                            UpdatedBy = data.UpdatedBy,
                            UpdatedOn = DateTime.UtcNow
                        });
                    }
                    user.UserRoleRepository.AddRange(lstUserRole);
                }
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }


        }
        #endregion

        #region Update UserRole Details
        /// <summary>
        /// To Update UserRole Details
        /// </summary>
        /// <param name="userRole">List of User Role Details to Update</param>
        public List<EF.UserRole> UpdateUserRole(IEnumerable<UserRoles> userRole)
        {
            try
            {
                using (var user = new UnitofWork())
                {
                    foreach (var data in userRole)
                    {
                        long UId = data.UserRoleId;
                        if (user.UserRoleRepository.Find(X => X.UserRoleId == UId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }

                    }
                }
                List<EF.UserRole> lstUserRole = new List<EF.UserRole>();
                List<string> lstField = new List<string>();
                foreach (var data in userRole)
                {
                    lstUserRole.Add(new EF.UserRole()
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
                        UpdatedOn = DateTime.UtcNow
                    });
                }
                lstField.Add("AccessLevelId");
                lstField.Add("Authorization");
                lstField.Add("IsActive");
                lstField.Add("UDetailsId");
                lstField.Add("CountryCodeID");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");

                using (var userObj = new UnitofWork())
                {
                    userObj.UserRoleRepository.UpdateRange(lstUserRole, lstField);
                }
                return lstUserRole;




            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        }
        #endregion

        #region Delete UserRole Details
        /// <summary>
        /// To Delete UserRole Details
        /// </summary>
        /// <param name="userId"> An integer which represents User Id</param>
        public void DeleteUserRole(int userId)
        {
            try
            {
                using (var user = new UnitofWork())
                {
                    List<EF.UserRole> lstUserRole = user.UserRoleRepository.Find(p => p.UserRoleId == userId).ToList();
                    if (lstUserRole.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }

                    user.UserRoleRepository.RemoveRange(lstUserRole);

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