using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.AutoMappingObject;
using SBSWebProject.Data.SqlServer.NewDataHandler;
using Newtonsoft.Json.Linq;

namespace SBSWebProject.Web.NewApi.Controllers
{
    public class CMSServicesWebSiteController : ApiController
    {
        #region webpages

        [Route("webpages/SaveData")]
        [HttpPost]
        public Api.Models.WebPages SaveWebpagesData(Api.Models.WebPages webPagesData)
        {
            WebPagesDataHandler webPagesDataHandler = new WebPagesDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.WebPagesMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.WebPagesMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.WebPagesMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPagesMapper();
            SBSWebProject.Data.Entities.WebPages obj = mapperModelToEntity.Map(webPagesData);

            webPagesDataHandler.Save(obj);


            return mapperEntityToModel.Map(obj);
        }
        [Route("webpages/UpdateData")]
        [HttpPost]
        public Api.Models.WebPages UpdateWebpagesData(Api.Models.WebPages webPagesData)
        {
            WebPagesDataHandler webPagesDataHandler = new WebPagesDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.WebPagesMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.WebPagesMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.WebPagesMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPagesMapper();

            SBSWebProject.Data.Entities.WebPages obj = mapperModelToEntity.Map(webPagesData, webPagesDataHandler.GetEntity(webPagesData.Id));

            webPagesDataHandler.Update(obj);


            return mapperEntityToModel.Map(obj);
        }
        [Route("webpages/DeleteData")]
        [HttpPost]
        public string DeleteWebpagesData(Api.Models.WebPages webPagesData)
        {
            WebPagesDataHandler webPagesDataHandler = new WebPagesDataHandler(WebApiApplication.SessionFactory);

            SBSWebProject.Data.Entities.WebPages obj = webPagesDataHandler.GetEntity(webPagesData.Id);

            webPagesDataHandler.Delete(obj);

            return "Deleted";
        }

        [Route("webpages/GetWebpagesData")]
        [HttpGet]
        public IList<Api.Models.WebPages> GetWebpagesData()
        {
            WebPagesDataHandler webPagesDataHandler = new WebPagesDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.EntityToModel.WebPagesMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPagesMapper();

            IList<Api.Models.WebPages> lstWebPages = new List<Api.Models.WebPages>();
            foreach (Data.Entities.WebPages itemWebPages in webPagesDataHandler.SelectAll())
            {
                lstWebPages.Add(mapperEntityToModel.Map(itemWebPages));
            }

            return lstWebPages;
        }

        #endregion  

        #region webpagesCat

        [Route("webpagesCat/SaveData")]
        [HttpPost]
        public Api.Models.WebsiteCategory SaveWebpagesCatData(Api.Models.WebsiteCategory websiteCatData)
        {
            if (websiteCatData.WebsiteCategoryItem.Id == 0)
                websiteCatData.WebsiteCategoryItem = null;
            WebsiteCategoryDataHandler websiteCategoryDataHandler = new WebsiteCategoryDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.WebsiteCategoryMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.WebsiteCategoryMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.WebsiteCategoryMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebsiteCategoryMapper();
            SBSWebProject.Data.Entities.WebsiteCategory obj = mapperModelToEntity.Map(websiteCatData);

            websiteCategoryDataHandler.Save(obj);

            return mapperEntityToModel.Map(obj);
            //return null;

        }
        [Route("webpagesCat/UpdateData")]
        [HttpPost]
        public Api.Models.WebsiteCategory UpdateWebpagesCatData(Api.Models.WebsiteCategory webPagesCatData)
        {
            WebsiteCategoryDataHandler websiteCategoryDataHandler = new WebsiteCategoryDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.WebsiteCategoryMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.WebsiteCategoryMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.WebsiteCategoryMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebsiteCategoryMapper();

            SBSWebProject.Data.Entities.WebsiteCategory obj = mapperModelToEntity.Map(webPagesCatData, websiteCategoryDataHandler.GetEntity(webPagesCatData.Id));

            websiteCategoryDataHandler.Update(obj);


            return mapperEntityToModel.Map(obj);
        }
        [Route("webpagesCat/DeleteData")]
        [HttpPost]
        public string DeleteWebpagesCatData(Api.Models.WebsiteCategory webPagesCatData)
        {
            WebsiteCategoryDataHandler websiteCategoryDataHandler = new WebsiteCategoryDataHandler(WebApiApplication.SessionFactory);

            SBSWebProject.Data.Entities.WebsiteCategory obj = websiteCategoryDataHandler.GetEntity(webPagesCatData.Id);

            websiteCategoryDataHandler.Delete(obj);
            //basecat is not deleted becuse have subcategory.
            return "Deleted";
        }

        [Route("webpagesCat/GetWebpagesCatData")]
        [HttpGet]
        public IList<Api.Models.WebsiteCategory> GetWebpagesCatData()
        {
            WebsiteCategoryDataHandler websiteCategoryDataHandler = new WebsiteCategoryDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.EntityToModel.WebsiteCategoryMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebsiteCategoryMapper();

            IList<Api.Models.WebsiteCategory> lstWebsiteCategory = new List<Api.Models.WebsiteCategory>();
            foreach (Data.Entities.WebsiteCategory itemWebsiteCategory in websiteCategoryDataHandler.SelectAll())
            {
                lstWebsiteCategory.Add(mapperEntityToModel.Map(itemWebsiteCategory));
            }

            return lstWebsiteCategory;
        }

        #endregion  

        #region webpagesContext

        [Route("webpagesContext/SaveData")]
        [HttpPost]
        public Api.Models.WebPageContext SaveWebpagesContextData(Api.Models.WebPageContext webPagesContextData)
        {
            WebPageContextDataHandler webPageContextDataHandler = new WebPageContextDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.WebPageContextMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.WebPageContextMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.WebPageContextMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPageContextMapper();
            SBSWebProject.Data.Entities.WebPageContext obj = mapperModelToEntity.Map(webPagesContextData);

            webPageContextDataHandler.Save(obj);

            return mapperEntityToModel.Map(obj);
        }
        [Route("webpagesContext/UpdateData")]
        [HttpPost]
        public Api.Models.WebPageContext UpdateWebpagesContextData(Api.Models.WebPageContext webPagesContextData)
        {
            WebPageContextDataHandler webPageContextDataHandler = new WebPageContextDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.WebPageContextMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.WebPageContextMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.WebPageContextMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPageContextMapper();

            SBSWebProject.Data.Entities.WebPageContext obj = mapperModelToEntity.Map(webPagesContextData, webPageContextDataHandler.GetEntity(webPagesContextData.Id));

            webPageContextDataHandler.Update(obj);


            return mapperEntityToModel.Map(obj);
        }
        [Route("webpagesContext/DeleteData")]
        [HttpPost]
        public string DeleteWebpagesContextData(Api.Models.WebPageContext webPagesContextData)
        {
            WebPageContextDataHandler webPageContextDataHandler = new WebPageContextDataHandler(WebApiApplication.SessionFactory);

            SBSWebProject.Data.Entities.WebPageContext obj = webPageContextDataHandler.GetEntity(webPagesContextData.Id);

            webPageContextDataHandler.Delete(obj);

            return "Deleted";
        }

        [Route("webpagesContext/GetWebpagesContextData")]
        [HttpGet]
        public IList<Api.Models.WebPageContext> GetWebpagesContextData()
        {
            WebPageContextDataHandler webPageContextDataHandler = new WebPageContextDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.EntityToModel.WebPageContextMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPageContextMapper();

            IList<Api.Models.WebPageContext> lstWebPageContext = new List<Api.Models.WebPageContext>();
            foreach (Data.Entities.WebPageContext itemWebPageContext in webPageContextDataHandler.SelectAll())
            {
                lstWebPageContext.Add(mapperEntityToModel.Map(itemWebPageContext));
            }

            return lstWebPageContext;
        }

        #endregion  

        #region webpagesBanner

        [Route("webpagesBanner/SaveData")]
        [HttpPost]
        public Api.Models.WebPageBanners SaveWebpagesBannerData(Api.Models.WebPageBanners webPagesBannerData)
        {
            WebPageBannersDataHandler webPageBannersDataHandler = new WebPageBannersDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.WebPageBannersMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.WebPageBannersMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.WebPageBannersMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPageBannersMapper();
            SBSWebProject.Data.Entities.WebPageBanners obj = mapperModelToEntity.Map(webPagesBannerData);

            webPageBannersDataHandler.Save(obj);

            return mapperEntityToModel.Map(obj);
        }
        [Route("webpagesBanner/UpdateData")]
        [HttpPost]
        public Api.Models.WebPageBanners UpdateWebpagesBannerData(Api.Models.WebPageBanners webPagesBannerData)
        {
            WebPageBannersDataHandler webPageBannersDataHandler = new WebPageBannersDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.WebPageBannersMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.WebPageBannersMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.WebPageBannersMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPageBannersMapper();

            SBSWebProject.Data.Entities.WebPageBanners obj = mapperModelToEntity.Map(webPagesBannerData, webPageBannersDataHandler.GetEntity(webPagesBannerData.Id));

            webPageBannersDataHandler.Update(obj);


            return mapperEntityToModel.Map(obj);
        }
        [Route("webpagesBanner/DeleteData")]
        [HttpPost]
        public string DeleteWebpagesBannerData(Api.Models.WebPageBanners webPagesBannerData)
        {
            WebPageBannersDataHandler webPageBannersDataHandler = new WebPageBannersDataHandler(WebApiApplication.SessionFactory);

            SBSWebProject.Data.Entities.WebPageBanners obj = webPageBannersDataHandler.GetEntity(webPagesBannerData.Id);

            webPageBannersDataHandler.Delete(obj);

            return "Deleted";
        }

        [Route("webpagesBanner/GetWebpagesBannerData")]
        [HttpGet]
        public IList<Api.Models.WebPageBanners> GetWebpagesBannerData()
        {
            WebPageBannersDataHandler webPageBannersDataHandler = new WebPageBannersDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.EntityToModel.WebPageBannersMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPageBannersMapper();

            IList<Api.Models.WebPageBanners> lstWebPageBanner = new List<Api.Models.WebPageBanners>();
            foreach (Data.Entities.WebPageBanners itemWebPageBanner in webPageBannersDataHandler.SelectAll())
            {
                lstWebPageBanner.Add(mapperEntityToModel.Map(itemWebPageBanner));
            }

            return lstWebPageBanner;
        }

        #endregion

        #region sbsTags
        [Route("sbsTag/SaveData")]
        [HttpPost]
        public Api.Models.SbsTags SaveSbsTagData(Api.Models.SbsTags sbsTagData)
        {
            SbsTagsDataHandler sbsTagsDataHandler = new SbsTagsDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.SbsTagsMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.SbsTagsMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.SbsTagsMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.SbsTagsMapper();
            SBSWebProject.Data.Entities.SbsTags obj = mapperModelToEntity.Map(sbsTagData);

            sbsTagsDataHandler.Save(obj);

            return mapperEntityToModel.Map(obj);
        }
        [Route("sbsTag/UpdateData")]
        [HttpPost]
        public Api.Models.SbsTags UpdateSbsTagData(Api.Models.SbsTags sbsTagData)
        {
            SbsTagsDataHandler sbsTagsDataHandler = new SbsTagsDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.SbsTagsMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.SbsTagsMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.SbsTagsMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.SbsTagsMapper();

            SBSWebProject.Data.Entities.SbsTags obj = mapperModelToEntity.Map(sbsTagData, sbsTagsDataHandler.GetEntity(sbsTagData.Id));

            sbsTagsDataHandler.Update(obj);


            return mapperEntityToModel.Map(obj);
        }
        [Route("sbsTag/DeleteData")]
        [HttpPost]
        public string DeleteSbsTagData(Api.Models.SbsTags sbsTagData)
        {
            SbsTagsDataHandler sbsTagsDataHandler = new SbsTagsDataHandler(WebApiApplication.SessionFactory);

            SBSWebProject.Data.Entities.SbsTags obj = sbsTagsDataHandler.GetEntity(sbsTagData.Id);

            sbsTagsDataHandler.Delete(obj);

            return "Deleted";
        }

        [Route("sbsTag/GetAllTagsData")]
        [HttpGet]
        public IList<Api.Models.SbsTags> GetSbsTagData()
        {
            SbsTagsDataHandler sbsTagsDataHandler = new SbsTagsDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.EntityToModel.SbsTagsMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.SbsTagsMapper();

            IList<Api.Models.SbsTags> lstSbsTags = new List<Api.Models.SbsTags>();
            foreach (Data.Entities.SbsTags itemSbsTag in sbsTagsDataHandler.SelectAll())
            {
                lstSbsTags.Add(mapperEntityToModel.Map(itemSbsTag));
            }

            return lstSbsTags;
        }
        #endregion

    }
}
