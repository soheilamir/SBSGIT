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
using System.Threading;
using System.Linq;

namespace SBSWebProject.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    [UnitOfWorkActionFilter]
    public class CompanyController : ApiController
    {
        private readonly ICompanyMethod _companyMethod;
        public CompanyController(ICompanyMethod companyMethod)
        {
            _companyMethod = companyMethod;
        }

        [Route("RegisterCompany")]
        [HttpPost]
        [Authorize]
        public void RegisterCompany(NewCompany companyObject)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                               .Select(c => c.Value).SingleOrDefault();
            _companyMethod.RegisterComopany(Convert.ToInt64(sid), companyObject);
        }

        [Route("GetAllCompanyEmployee")]
        [HttpPost]
        [Authorize]
        public void GetAllCompanyEmployee(NewCompany companyObject)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                               .Select(c => c.Value).SingleOrDefault();
            _companyMethod.GetAllCompanyEmployee(Convert.ToInt64(sid), companyObject.Id);
        }


        [Route("SendJoinToCompanyRequest")]
        [HttpPost]
        [Authorize]
        public void SendJoinToCompanyRequest(Company companyObject)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                               .Select(c => c.Value).SingleOrDefault();
            _companyMethod.SendJoinToCompanyRequest(Convert.ToInt64(sid), companyObject);
        }
        //[Route("ActiveEmployee")]
        //[HttpPost]
        //[Authorize]
        //public void ActiveEmployee(Employee companyObject)
        //{
        //    var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
        //    var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
        //                       .Select(c => c.Value).SingleOrDefault();
        //    _companyMethod.SendJoinToCompanyRequest(Convert.ToInt64(sid), companyObject);
        //}
    }
}
