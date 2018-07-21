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


namespace SBSWebProject.Web.NewApi.Controllers.CompanyProfileCtrl
{
    public class CompanyProfileController : ApiController
    {
        #region companyOrgChart

        [Route("companyOrgChart/SaveData")]
        [HttpPost]
        public Api.Models.CompanySection SaveCoOrgChartData(Api.Models.CompanySection coSecData)
        {
            //if (coSecData.CompanyItem.Id == 0)
            //    coSecData.CompanyItem = null;
            //if (coSecData.CompanySectionItem.Id == 0)
            //    coSecData.CompanySectionItem = null;
            CompanySectionDataHandler companySectionDataHandler = new CompanySectionDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.ModelToEntity.CompanySectionMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.CompanySectionMapper();
            SBSWebProject.AutoMappingObject.EntityToModel.CompanySectionMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.CompanySectionMapper();
            SBSWebProject.Data.Entities.CompanySection obj = mapperModelToEntity.Map(coSecData);

            companySectionDataHandler.Save(obj);


            return mapperEntityToModel.Map(obj);
        }
        [Route("companyOrgChart/UpdateData")]
        [HttpPost]
        public Api.Models.WebPages UpdateCoOrgChartData()
        {
            return null;
        }
        [Route("companyOrgChart/DeleteData")]
        [HttpPost]
        public string DeleteCoOrgChartData()
        {
            return null;

        }

        [Route("companyOrgChart/GetCoOrgChartData")]
        [HttpGet]
        public IList<Api.Models.CompanySection> GetCoOrgChartData()
        {

            CompanySectionDataHandler companySectionDataHandler = new CompanySectionDataHandler(WebApiApplication.SessionFactory);
            SBSWebProject.AutoMappingObject.EntityToModel.CompanySectionMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.CompanySectionMapper();

            IList<Api.Models.CompanySection> lstCompanySection = new List<Api.Models.CompanySection>();
            foreach (Data.Entities.CompanySection itemCompanySection in companySectionDataHandler.SelectAll())
            {
                lstCompanySection.Add(mapperEntityToModel.Map(itemCompanySection));
            }

            return lstCompanySection;
        }

        #endregion  
    }
}
