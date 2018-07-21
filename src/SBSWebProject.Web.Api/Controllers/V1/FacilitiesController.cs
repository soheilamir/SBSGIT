using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using System.Web.Http.Cors;
using SBSWebProject.Common;
using SBSWebProject.Web.Api.InquiryProcessing;
using SBSWebProject.Web.Api.MaintenanceProcessing;
using SBSWebProject.Web.Api.Models;
using SBSWebProject.Web.Common;
using SBSWebProject.Web.Common.Routing;
using SBSWebProject.Web.Common.Validation;
using System.Security.Claims;
using SBSWebProject.Hubs;
using Microsoft.AspNet.SignalR.Client;
using System;
using SBSWebProject.Web.Api.OperatingMethods;
using SBSWebProject.Web.Api.MethodsInterface;
using System.IO;
using System.Data;
using Excel;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SBSWebProject.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    [UnitOfWorkActionFilter]
    public class FacilitiesController : ApiController
    {
        private readonly IFacilitiesMethod _facilitiesMethod;
        public FacilitiesController(IFacilitiesMethod facilitiesMethod)
        {
            _facilitiesMethod = facilitiesMethod;
        }
        #region FacilitiesCategory
        [Route("facilitiesCategory/add")]
        [HttpPost]
        public FacilitiesCategory AddFacilitiesCategory(FacilitiesCategory newFacilitiesCategory)
        {
            return _facilitiesMethod.AddFacilitiesCategory(newFacilitiesCategory);
        }
        [Route("facilitiesCategory/edit")]
        [HttpPost]
        public FacilitiesCategory EditFacilitiesCategory(FacilitiesCategory newFacilitiesCategory)
        {
            return _facilitiesMethod.EditFacilitiesCategory(newFacilitiesCategory);
        }
        [Route("facilitiesCategory/delete")]
        [HttpPost]
        public void DeleteFacilitiesCategory(FacilitiesCategory newFacilitiesCategory)
        {
            _facilitiesMethod.DeleteFacilitiesCategory(newFacilitiesCategory);
        }
        [Route("facilitiesCategory/getAll")]
        [HttpGet]
        public IList<FacilitiesCategory> GetAllFacilitiesCategory()
        {
            return _facilitiesMethod.GetAllFacilitiesCategory();
        }
        #endregion

        #region FacilitiesSection
        [Route("facilities/getAll")]
        [HttpGet]
        public IList<Facilities> GetAllFacilities()
        {
            return _facilitiesMethod.GetAllFacilities();
        }
        [Route("facilities/add")]
        [HttpPost]
        public Facilities AddFacilities(Facilities newFacilities)
        {
            return _facilitiesMethod.AddFacilities(newFacilities);
        }
        #endregion
    }
}
