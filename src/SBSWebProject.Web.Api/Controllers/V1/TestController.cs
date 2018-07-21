using SBSWebProject.Web.Api.Models;
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
using SBSWebProject.Data.DataHandlers;

namespace SBSWebProject.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    public class TestController : ApiController
    {
        private readonly IBasicDataHandler<Data.Entities.AirlineClassPathFee> _handler;
        public TestController(IBasicDataHandler<Data.Entities.AirlineClassPathFee> handler)
        {
            _handler = handler;

        }
        [Route("handler/test")]
        [HttpGet]
        public void test()
        {
            int k = 1;
        }
    }
}
