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
using UraxUIServiceWebApi.Repository;
using UraxUIServiceWebApi.ResourceFiles;
using System.Net.Http;
using System.IO; 
#endregion

namespace UraxUIServiceWebApi.Models
{
    public class MaterialNews
    {
        #region MaterialNews Property 

        [JsonProperty(PropertyName = "mnId")]
        public int MNId { get; set; }
        [JsonProperty(PropertyName = "contentTypeId")]
        public int ContentTypeId { get; set; }
        [JsonProperty(PropertyName = "contentTypeName")]
        public string ContentTypeName { get; set; }
        [JsonProperty(PropertyName = "contentHeading")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "ContentHeadingReq")]
        public string ContentHeading { get; set; }
        [JsonProperty(PropertyName = "contextText")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "ContextTextReq")]
        public string ContextText { get; set; }
        [JsonProperty(PropertyName = "publishStartDate")]
        public DateTime PublishStartDate { get; set; }
        [JsonProperty(PropertyName = "publishEndDate")]
        public DateTime? PublishEndDate { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "imageName")]
        public string ImageName { get; set; }
        
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
        public string ImageData { get; set; }
        #endregion

        #region     Get Material News
        /// <summary>
        /// To get Material News
        /// </summary>
        /// <returns>List of Material News/returns>
        public List<MaterialNews> GetMaterialNews()
        {
            try
            {
                List<MaterialNews> lstMaterialNews = new List<MaterialNews>();
                using (var materialNews = new UnitofWork())
                {
                    var lstContentType = materialNews.ParameterDetailsRepository.Find(x => x.ParameterGroupId == 7);
                    var result = (from ld in materialNews.MaterialNewsRepository.GetAll()
                                  join t in lstContentType on ld.ContentTypeId equals t.ParameterId


                                  select new
                                  {
                                      ld.MNId,
                                      ld.ContentTypeId,
                                      ld.ContentText,
                                      ld.IsActive,
                                      ld.CreatedBy,
                                      ld.CreatedOn,
                                      ld.UpdatedBy,
                                      ld.UpdatedOn,
                                      ld.PublishEndDate,
                                      ld.PublishStartDate,
                                      ld.ImageUrl,
                                      ld.ImageData,
                                      ld.ImageName,
                                      ld.ContentHeading,
                                      t.Value
                                  }).ToList();

                    foreach (var param in result)
                    {
                        lstMaterialNews.Add(new MaterialNews()
                        {
                            MNId = param.MNId,
                            ContentHeading = param.ContentHeading,
                            ContentTypeId = (int)param.ContentTypeId,
                            ContentTypeName = (string)param.Value,
                            ContextText = param.ContentText,
                            PublishEndDate = param.PublishEndDate,
                            PublishStartDate = (DateTime)param.PublishStartDate,
                            UpdatedBy = param.UpdatedBy,
                            CreatedBy = param.CreatedBy,
                            UpdatedOn = (DateTime)param.UpdatedOn,
                            CreatedOn = param.CreatedOn,
                            IsActive = param.IsActive,
                            ImageData= "data:image/jpeg;base64," + param.ImageData,
                            ImageUrl = param.ImageUrl,
                            ImageName = param.ImageName
                            
                        });
                    }
                }
                return lstMaterialNews;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }

        public List<MaterialNews> GetHomeMaterialNews()
        {
            try
            {
                List<MaterialNews> lstMaterialNews = new List<MaterialNews>();
                using (var materialNews = new UnitofWork())
                {
                    List<EF.MaterialNew> lstFilteredNews = new List<EF.MaterialNew>();
                    var lstContentType = materialNews.ParameterDetailsRepository.Find(x => x.ParameterGroupId == 7).ToList();
                    var lstActiveNews= materialNews.MaterialNewsRepository.Find(x=>x.IsActive==true).ToList();
                    foreach (var item in lstActiveNews)
                    {
                        if (((item.PublishEndDate == Convert.ToDateTime("0001-01-01"))||(item.PublishEndDate == null))&&(item.PublishStartDate <= DateTime.UtcNow))
                        {
                            lstFilteredNews.Add(item);
                        }
                        else if(item.PublishStartDate <= DateTime.UtcNow && item.PublishEndDate >= DateTime.UtcNow)
                        {
                            lstFilteredNews.Add(item);
                        } 
                    }
                    var result =(from ld in lstFilteredNews
                                 join c in lstContentType on ld.ContentTypeId equals c.ParameterId
                                 orderby ld.UpdatedOn descending, ld.PublishStartDate descending, ld.PublishEndDate descending
                                 select new {
                                      ld.MNId,
                                      ld.ContentTypeId,
                                      ld.ContentText,
                                      ld.IsActive,
                                      ld.CreatedBy,
                                      ld.CreatedOn,
                                      ld.UpdatedBy,
                                      ld.UpdatedOn,
                                      ld.PublishEndDate,
                                      ld.PublishStartDate,
                                      ld.ImageUrl,
                                      ld.ImageData,
                                      ld.ImageName,
                                      ld.ContentHeading,
                                      c.Value
                                  }).ToList();

                    foreach (var param in result)
                    {
                        lstMaterialNews.Add(new MaterialNews()
                        {
                            MNId = param.MNId,
                            ContentHeading = param.ContentHeading,
                            ContentTypeId = (int)param.ContentTypeId,
                            ContentTypeName = (string)param.Value,
                            ContextText = param.ContentText,
                            PublishEndDate = Convert.ToDateTime(param.PublishEndDate),
                            PublishStartDate = (DateTime)param.PublishStartDate,
                            UpdatedBy = param.UpdatedBy,
                            CreatedBy = param.CreatedBy,
                            UpdatedOn = (DateTime)param.UpdatedOn,
                            CreatedOn = param.CreatedOn,
                            IsActive = param.IsActive,
                            ImageData = "data:image/jpeg;base64," + (param.ImageData.Length == 0 ? Helper.sDefaultImage : Convert.ToBase64String(param.ImageData)),
                            ImageUrl = param.ImageUrl,
                            ImageName = param.ImageName

                        });
                    }
                }
                return lstMaterialNews;
            }
            catch (Exception ex)
            {
                
                throw new InvalidOperationException(ex.Message);
            }
        }

        internal List<MaterialNews> GetCurrentPreviewMaterialNews(MaterialNewsBase objMaterialNews)
        {
            try
            {
                List<MaterialNews> lstMaterialNews = new List<MaterialNews>();
                using (var materialNews = new UnitofWork())
                {
                    var lstContentType = materialNews.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Helper.iContentType);
                   
                    var result = (from ld in materialNews.MaterialNewsRepository.GetAll()
                                  join t in lstContentType on ld.ContentTypeId equals t.ParameterId
                                 // where ld.PublishStartDate <= DateTime.UtcNow && ld.PublishEndDate >= DateTime.UtcNow
                                 
                                  select new
                                  {
                                      ld.MNId,
                                      ld.ContentTypeId,
                                      ld.ContentText,
                                      ld.IsActive,
                                      ld.CreatedBy,
                                      ld.CreatedOn,
                                      ld.UpdatedBy,
                                      ld.UpdatedOn,
                                      ld.PublishEndDate,
                                      ld.PublishStartDate,
                                      ld.ImageUrl,
                                      ld.ImageData,
                                      ld.ImageName,
                                      ld.ContentHeading,
                                      t.Value
                                  }).GroupBy(x=>x.ContentTypeId).SelectMany(x=>x.Take(10)).ToList();

                    var result1 = objMaterialNews.ImageData;
                    string converted = result1.Replace("data:image/jpeg;base64,", "");
                    lstMaterialNews.Add(new MaterialNews()
                    {
                        MNId = objMaterialNews.MNId,
                        ContentHeading = objMaterialNews.ContentHeading,
                        ContentTypeId = (int)objMaterialNews.ContentTypeId,
                        ContentTypeName = "",
                        ContextText = objMaterialNews.ContextText,
                        PublishEndDate = (DateTime)objMaterialNews.PublishEndDate,
                        PublishStartDate = (DateTime)objMaterialNews.PublishStartDate,
                        UpdatedBy = objMaterialNews.UpdatedBy,
                        CreatedBy = objMaterialNews.CreatedBy,
                        UpdatedOn = (DateTime)objMaterialNews.UpdatedOn,
                        CreatedOn = objMaterialNews.CreatedOn,
                        IsActive = objMaterialNews.IsActive,
                        ImageData = "data:image/jpeg;base64," + converted,
                        ImageUrl = objMaterialNews.ImageUrl,
                        ImageName = objMaterialNews.ImageName
                    });
                    foreach (var param in result)
                    {
                        lstMaterialNews.Add(new MaterialNews()
                        {
                            MNId = param.MNId,
                            ContentHeading = param.ContentHeading,
                            ContentTypeId = (int)param.ContentTypeId,
                            ContentTypeName = (string)param.Value,
                            ContextText = param.ContentText,
                            PublishEndDate = (DateTime)param.PublishEndDate,
                            PublishStartDate = (DateTime)param.PublishStartDate,
                            UpdatedBy = param.UpdatedBy,
                            CreatedBy = param.CreatedBy,
                            UpdatedOn = (DateTime)param.UpdatedOn,
                            CreatedOn = param.CreatedOn,
                            IsActive = param.IsActive,
                            ImageData =Convert.ToBase64String(param.ImageData),
                            ImageUrl = param.ImageUrl,
                            ImageName = param.ImageName
                        });
                    }
                }
                lstMaterialNews = lstMaterialNews.OrderByDescending(x => x.UpdatedOn).ToList(); ;
                return lstMaterialNews;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion
        #region     Get Material News
        /// <summary>
        /// To get Material News
        /// </summary>
        /// <returns>List of Material News/returns>
        public List<MaterialNews> GetCurrentMaterialNews()
        {
            try
            {
                List<MaterialNews> lstMaterialNews = new List<MaterialNews>();
                using (var materialNews = new UnitofWork())
                {
                    var lstContentType = materialNews.ParameterDetailsRepository.Find(x => x.ParameterGroupId == 7);
                    var result = (from ld in materialNews.MaterialNewsRepository.GetAll()
                                  join t in lstContentType on ld.ContentTypeId equals t.ParameterId
                                 

                                  select new
                                  {
                                      ld.MNId,
                                      ld.ContentTypeId,
                                      ld.ContentText,
                                      ld.IsActive,
                                      ld.CreatedBy,
                                      ld.CreatedOn,
                                      ld.UpdatedBy,
                                      ld.UpdatedOn,
                                      ld.PublishEndDate,
                                      ld.PublishStartDate,
                                      ld.ImageUrl,
                                      ld.ImageData,
                                      ld.ImageName,
                                      ld.ContentHeading,
                                      t.Value
                                  }).ToList();

                    foreach (var param in result)
                    {
                        
                        lstMaterialNews.Add(new MaterialNews()
                        {
                           
                            MNId = param.MNId,
                            ContentHeading = param.ContentHeading,
                            ContentTypeId = (int)param.ContentTypeId,
                            ContentTypeName = (string)param.Value,
                            ContextText = param.ContentText,
                            PublishEndDate = Convert.ToDateTime(param.PublishEndDate),
                            PublishStartDate = (DateTime)param.PublishStartDate,
                            UpdatedBy = param.UpdatedBy,
                            CreatedBy = param.CreatedBy,
                            UpdatedOn = (DateTime)param.UpdatedOn,
                            CreatedOn = param.CreatedOn,
                            IsActive = param.IsActive,
                            ImageData = "data:image/jpeg;base64," + (param.ImageData.Length == 0 ? Helper.sDefaultImage:Convert.ToBase64String(param.ImageData)),
                            ImageUrl = param.ImageUrl,
                            ImageName = param.ImageName
                        });
                    }
                }
                lstMaterialNews = lstMaterialNews.OrderByDescending(x => x.UpdatedOn).ToList(); ;

                return lstMaterialNews;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion
        #region     Get Material News by Id
        /// <summary>
        /// To get Material News by Id
        /// </summary>
        /// <param name="id">An intger which represents MNId</param>
        /// <returns>List of material News</returns>
        public List<EF.MaterialNew> GetMaterialNews(int id)
        {
            try
            {
                using (var materialNews = new UnitofWork())
                {
                    return materialNews.MaterialNewsRepository.Find(p => p.MNId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion





        #region Post Material News with Image as Base64 String

        public void PostBaseMaterialNews(MaterialNewsBase materialnews)
        {
            try
            {
                 using (var db = new UnitofWork())
                {
                   
                    if ((materialnews.PublishEndDate!=Convert.ToDateTime("0001-01-01"))&&(materialnews.PublishStartDate > materialnews.PublishEndDate))
                    {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidEndStartCombmsg"));
                    }
                   var result = materialnews.ImageData;
                    string converted = result.Replace("data:image/jpeg;base64,", "");

                    EF.MaterialNew material = new EF.MaterialNew() {
                    MNId = materialnews.MNId,
                    ContentTypeId = materialnews.ContentTypeId,
                    ContentHeading = materialnews.ContentHeading,
                    ContentText = materialnews.ContextText,
                    ImageName = materialnews.ImageName,
                    ImageData = Convert.FromBase64String(string.IsNullOrEmpty(materialnews.ImageData) ? "" : converted),
                    PublishStartDate = materialnews.PublishStartDate,
                    PublishEndDate = materialnews.PublishEndDate,
                    IsActive = materialnews.IsActive,
                    CreatedBy = materialnews.CreatedBy,
                    UpdatedBy = materialnews.UpdatedBy,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow };
                   

                    db.MaterialNewsRepository.Add(material);
                    
                }
                
            }
            catch (Exception )
            {
                throw ;
            }
        }

        #endregion

        #region Post Material News with Image in HTTP REQUEST

        public void PostMaterialNews()
        {
            try
            {
                MaterialNews materialnews = new MaterialNews();
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                materialnews.ContentTypeId = Convert.ToInt32(HttpContext.Current.Request["ContentTypeId"]);
                materialnews.ContentHeading = HttpContext.Current.Request["ContentHeading"];
                materialnews.ContentTypeName = HttpContext.Current.Request["ContentTypeName"];
                materialnews.ContextText = HttpContext.Current.Request["ContextText"];
                materialnews.PublishStartDate = Convert.ToDateTime(HttpContext.Current.Request["PublishStartDate"]);
                materialnews.PublishEndDate = Convert.ToDateTime(HttpContext.Current.Request["PublishEndDate"]);
                materialnews.IsActive = Convert.ToBoolean(HttpContext.Current.Request["IsActive"]);
                materialnews.CreatedBy = HttpContext.Current.Request["CreatedBy"];
                materialnews.CreatedOn = Convert.ToDateTime(HttpContext.Current.Request["CreatedOn"]);
                materialnews.UpdatedBy = HttpContext.Current.Request["UpdatedBy"];
                materialnews.UpdatedOn = Convert.ToDateTime(HttpContext.Current.Request["UpdatedOn"]);


                if (httpPostedFile != null)
                {
                    materialnews.ImageData = httpPostedFile.ToString();
                }
                using (var db = new UnitofWork())
                {
                    EF.MaterialNew material = new EF.MaterialNew(){
                    MNId = materialnews.MNId,
                    ContentTypeId = materialnews.ContentTypeId,
                    ContentHeading = materialnews.ContentHeading,
                    ContentText = materialnews.ContextText,
                    PublishStartDate = materialnews.PublishStartDate,
                    PublishEndDate = materialnews.PublishEndDate,
                    IsActive = materialnews.IsActive,
                    CreatedBy = materialnews.CreatedBy,
                    UpdatedBy = materialnews.UpdatedBy,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow};
                    if (httpPostedFile!=null)
                    {
                        material.ImageName = httpPostedFile.FileName;
                        material.ImageData =Convert.FromBase64String(materialnews.ImageData); 
                    }

                    db.MaterialNewsRepository.Add(material);
                    }
               }
            catch (Exception )
            {
                throw ;
            }
        }

        #endregion

        

        

        #region     Get Material News by Content Type Id
        /// <summary>
        /// To get Material News by Content Type Id
        /// </summary>
        /// <param name="contentTypeID">An intger which represents Content type Id</param>
        /// <returns>List of Material News</returns>
        internal List<MaterialNews> GetMaterialNewsByContentTypeID(int contentTypeID)
            {
            try
            {
                List<MaterialNews> lstMaterialNews = new List<MaterialNews>();
                using (var materialNews = new UnitofWork())
                {
                    var lstContentType = materialNews.ParameterDetailsRepository.Find(x => x.ParameterGroupId == Helper.iContentType);
                    var result = (from ld in materialNews.MaterialNewsRepository.Find(x => x.ContentTypeId == contentTypeID).ToList()
                                  join t in lstContentType on ld.ContentTypeId equals t.ParameterId


                                  select new
                                  {
                                      ld.MNId,
                                      ld.ContentTypeId,
                                      ld.ContentText,
                                      ld.IsActive,
                                      ld.CreatedBy,
                                      ld.CreatedOn,
                                      ld.UpdatedBy,
                                      ld.UpdatedOn,
                                      ld.PublishEndDate,
                                      ld.PublishStartDate,
                                      ld.ImageUrl,
                                      ld.ImageData,
                                      ld.ImageName,
                                      ld.ContentHeading,
                                      t.Value
                                  }).ToList();

                    foreach (var param in result)
                    {
                        lstMaterialNews.Add(new MaterialNews()
                        {
                            MNId = param.MNId,
                            ContentHeading = param.ContentHeading,
                            ContentTypeId = (int)param.ContentTypeId,
                            ContentTypeName = (string)param.Value,
                            ContextText = param.ContentText,
                            PublishEndDate = (DateTime)param.PublishEndDate,
                            PublishStartDate = (DateTime)param.PublishStartDate,
                            UpdatedBy = param.UpdatedBy,
                            CreatedBy = param.CreatedBy,
                            UpdatedOn = (DateTime)param.UpdatedOn,
                            CreatedOn = param.CreatedOn,
                            IsActive = param.IsActive,
                            ImageUrl = param.ImageUrl,
                            ImageName = param.ImageName,
                            ImageData = "data:image/jpeg;base64,"+Convert.ToBase64String(param.ImageData)
                        });
                    }
                }
                lstMaterialNews = lstMaterialNews.OrderByDescending(x => x.UpdatedOn).ToList(); ;

                return lstMaterialNews;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
        #endregion

        #region     Delete Material News
        /// <summary>
        /// To delete  Material News Details
        /// </summary>
        /// <param name="MaterialNewsId">An intger which represents Material News Id</param>
        public void DeleteMaterialNews(int MaterialNewsId)
        {


            try
            {
                using (var materialNews = new UnitofWork())
                {
                    List<EF.MaterialNew> lstMaterialNews = materialNews.MaterialNewsRepository.Find(p => p.MNId == MaterialNewsId).ToList();
                    if (lstMaterialNews.Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                    List<EF.MaterialNew> lstMaterial = materialNews.MaterialNewsRepository.Find(p => p.MNId == MaterialNewsId).ToList();




                    materialNews.MaterialNewsRepository.RemoveRange(lstMaterial);

                }
            }

            catch (Exception ex)
            {
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }

        }
        #endregion

        #region Get Image Data by MNId
        public byte[] GetImagebyMNId(int MNId)
        {
            try
            {
                using (var materialNews = new UnitofWork())
                {
                    if (materialNews.MaterialNewsRepository.Find(x => x.MNId == MNId).ToList().Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("InvalidMNIdmsg"));
                    }
                    byte[] imgData = materialNews.MaterialNewsRepository.Find(x => x.MNId == MNId).Select(x => x.ImageData).FirstOrDefault();
                    if (imgData == null)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("NullImgmsg"));
                    }
                    return imgData;
                }
            }
            catch (Exception )
            {

                throw ;
            }
        }
        #endregion

        #region Update Material News with Image as Base64 String
        /// <summary>
        /// To  Update Material News with Image as Base64 String
        /// </summary>
        /// <param name="materialnews">updating Data</param>
        public void UpdateBaseMaterialNews(MaterialNewsBase materialnews)
        {
            try
            {
                using (var materialNews = new UnitofWork())
                {

                    long mId = materialnews.MNId;
                    if (materialNews.MaterialNewsRepository.Find(x => x.MNId == mId).ToList().Count == 0)
                    {
                        throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                    }
                   
                    if ((materialnews.PublishEndDate != Convert.ToDateTime("0001-01-01")) &&(materialnews.PublishStartDate > materialnews.PublishEndDate))
                    {
                            throw new InvalidOperationException(Resource.GetResxValueByName("InvalidEndStartCombmsg"));
                    }
                }
                List<EF.MaterialNew> lstMaterialNew = new List<EF.MaterialNew>();
                List<string> lstField = new List<string>();
                using (var db = new UnitofWork())
                {
                    var result = materialnews.ImageData;
                    string converted = result.Replace("data:image/jpeg;base64,", "");

                    EF.MaterialNew material = new EF.MaterialNew() {
                        MNId = materialnews.MNId,
                    ContentTypeId = materialnews.ContentTypeId,
                    ContentHeading = materialnews.ContentHeading,
                    ContentText = materialnews.ContextText,
                    PublishStartDate = materialnews.PublishStartDate,
                    PublishEndDate = materialnews.PublishEndDate,
                    IsActive = materialnews.IsActive,
                    CreatedBy=materialnews.UpdatedBy,
                    UpdatedBy = materialnews.UpdatedBy,
                    CreatedOn=DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow,
                    ImageUrl = materialnews.ImageUrl,
                    ImageName = materialnews.ImageName,
                    ImageData = Convert.FromBase64String(string.IsNullOrEmpty(materialnews.ImageData) ? "": converted)
                    };

                    lstMaterialNew.Add(material);
                }




                lstField.Add("ContentHeading");
                lstField.Add("ContentText");
                lstField.Add("ContentTypeId");
                lstField.Add("PublishStartDate");
                lstField.Add("PublishEndDate");
                lstField.Add("IsActive");
                lstField.Add("UpdatedBy");
                lstField.Add("UpdatedOn");

                if (!string.IsNullOrEmpty(materialnews.ImageData))
                {
                    lstField.Add("ImageUrl");
                    lstField.Add("ImageName");
                    lstField.Add("ImageData");

                }


                using (var materialNewobj = new UnitofWork())
                {
                    materialNewobj.MaterialNewsRepository.UpdateRange(lstMaterialNew, lstField);
                }

            }


            catch (Exception ex)
            {

                throw new InvalidOperationException( ex.Message);
            }
        }
        #endregion

        #region Update Material News with Image
        /// <summary>
        /// To update Material News 
        /// </summary>
        /// <param name="materialNewsValue">Material News Details to Update</param>
        public void UpdateMaterialNews()
        {
            try
            {
                
                MaterialNews materialnews = new MaterialNews();
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];
                materialnews.MNId = Convert.ToInt32(Convert.ToInt32(HttpContext.Current.Request["MNId"]));
                materialnews.ContentTypeId = Convert.ToInt32(HttpContext.Current.Request["ContentTypeId"]);
                materialnews.ContentHeading = HttpContext.Current.Request["ContentHeading"];
                materialnews.ContentTypeName = HttpContext.Current.Request["ContentTypeName"];
                materialnews.ContextText = HttpContext.Current.Request["ContextText"];
                materialnews.PublishStartDate = Convert.ToDateTime(HttpContext.Current.Request["PublishStartDate"]);
                materialnews.PublishEndDate = Convert.ToDateTime(HttpContext.Current.Request["PublishEndDate"]);
                materialnews.IsActive = Convert.ToBoolean(HttpContext.Current.Request["IsActive"]);
                materialnews.UpdatedBy = HttpContext.Current.Request["UpdatedBy"];
                materialnews.UpdatedOn = Convert.ToDateTime(HttpContext.Current.Request["UpdatedOn"]);


                if (httpPostedFile != null)
                {
                    materialnews.ImageData = httpPostedFile.ToString();

                }
                using (var materialNews = new UnitofWork())
                {
                    
                        long mId = materialnews.MNId;
                        string ContentHeadingName = materialnews.ContentHeading;
                        if (materialNews.MaterialNewsRepository.Find(x => x.MNId == mId).ToList().Count == 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("CmnDataNotFound"));
                        }
                        else if (materialNews.MaterialNewsRepository.Find(x => x.MNId != mId && (x.ContentHeading == ContentHeadingName)).ToList().Count > 0)
                        {
                            throw new InvalidOperationException(Resource.GetResxValueByName("MaterialNewsDuplicatemsg"));
                        }
                    
                }
                List<EF.MaterialNew> lstMaterialNew = new List<EF.MaterialNew>();

                using (var db = new UnitofWork())
                {

                    EF.MaterialNew material = new EF.MaterialNew()
                    {
                        MNId = materialnews.MNId,
                        ContentTypeId = materialnews.ContentTypeId,
                        ContentHeading = materialnews.ContentHeading,
                        ContentText = materialnews.ContextText,
                        PublishStartDate = materialnews.PublishStartDate,
                        PublishEndDate = materialnews.PublishEndDate,
                        IsActive = materialnews.IsActive,

                        UpdatedBy = materialnews.UpdatedBy,

                        UpdatedOn = DateTime.UtcNow
                    };
                    if (httpPostedFile != null)
                    {
                        material.ImageUrl = materialnews.ImageUrl;
                        material.ImageName = httpPostedFile.FileName;
                        material.ImageData = Convert.FromBase64String(materialnews.ImageData);
                    }

                    lstMaterialNew.Add(material);
                }
                   
                
                List<string> lstField = new List<string>() { "ContentHeading", "ContentText", "ContentTypeId", "PublishStartDate", "PublishEndDate", "IsActive", "UpdatedBy", "UpdatedOn" };

                    if (httpPostedFile!=null)
                    {
                        lstField.Add("ImageUrl");
                        lstField.Add("ImageName");
                        lstField.Add("ImageData");
                       
                    }


                using (var materialNewobj = new UnitofWork())
                {
                    materialNewobj.MaterialNewsRepository.UpdateRange(lstMaterialNew, lstField);
                }

            }


            catch (Exception ex)
            {
                
                throw new InvalidOperationException(Resource.GetResxValueByName("CmnError") + ex.Message);
            }
        } 
        #endregion
    }


    public class MaterialNewsBase
    {
        #region MaterialNews Property 

        [JsonProperty(PropertyName = "mnId")]
        public int MNId { get; set; }
        [JsonProperty(PropertyName = "contentTypeId")]
        public int ContentTypeId { get; set; }
        [JsonProperty(PropertyName = "contentTypeName")]
        public string ContentTypeName { get; set; }
        [JsonProperty(PropertyName = "contentHeading")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "ContentHeadingReq")]
        public string ContentHeading { get; set; }
        [JsonProperty(PropertyName = "contextText")]
        [Required(ErrorMessageResourceType = typeof(Message), ErrorMessageResourceName = "ContextTextReq")]
        public string ContextText { get; set; }
        [JsonProperty(PropertyName = "publishStartDate")]
        public DateTime PublishStartDate { get; set; }
        [JsonProperty(PropertyName = "publishEndDate")]
        public DateTime? PublishEndDate { get; set; }
        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty(PropertyName = "imageName")]
        public string ImageName { get; set; }

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
        [JsonProperty(PropertyName = "imageData")]
        public string ImageData { get; set; }
        #endregion
    }
   
}