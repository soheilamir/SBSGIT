using SBSWebProject.Web.Api.OperatingMethods;
using SBSWebProject.Web.Api.MethodsInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SBSWebProject.Web.Common.Routing;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    public class BaseInfoWebSiteController : ApiController
    {
        private readonly IBaseWebSiteInfoMethod _baseInfoWebSiteController;
        public BaseInfoWebSiteController(IBaseWebSiteInfoMethod baseWebSiteInfoMethod)
        {
            _baseInfoWebSiteController = baseWebSiteInfoMethod;
        }
        [Route("LacationInfo/GetInfoCurrency")]
        [HttpGet]
        public string GetInfoCurrency()
        {
            return "IRR";
        }
        [Route("LacationInfo/GetInfoLocation")]
        [HttpGet]
        public string GetInfoLocation()
        {
            return "IR";
        }
        [Route("GetPageInfo/{kind}/HomePage")]
        [HttpGet]
        public async Task<string> GetHomePage(string kind)
        {
            Random rnd = new Random();
            return await Task.FromResult<string>(_baseInfoWebSiteController.FillImgList(kind)[rnd.Next(0, _baseInfoWebSiteController.FillImgList(kind).Count)]);
        }
    }
}