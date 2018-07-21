using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SBSWebProject.ApiTest.Controllers
{
    [Authorize]
    public class TestController : ApiController
    {
        public string Get()
        {
            string str = "salam";
            return str;
        }
    }
}
