using System.Net.Http;
using System.Web.Http;
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
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace SBSWebProject.Web.Api.Controllers.V1
{

    [ApiVersion1RoutePrefix("")]
    [UnitOfWorkActionFilter]
    //[Authorize(Roles = Constants.RoleNames.SeniorWorker)]
    public class UsersController : ApiController
    {
        private readonly IUsersMethod _usersMethod;
        public UsersController(IUsersMethod usersMethod)
        {
            // GlobalHost.ConnectionManager.GetHubContext<THub>()
            _usersMethod = usersMethod;
        }

        [Route("AddUser")]
        [HttpPost]
        public IHttpActionResult AddUser(NewUser newUser)
        {
            var task = _usersMethod.AddUser(newUser);
            return Ok();

        }
        [Route("test")]
        [HttpPost]

        public IHttpActionResult test()
        {
            return Ok();
        }

        [Route("GetUserByUsername")]
        [HttpGet]
        public Users GetUserByUsername()
        {
            ClaimsPrincipal principal = Request.GetRequestContext().Principal as ClaimsPrincipal;
            return _usersMethod.GetUserByUsername(principal.Identity.Name);

        }
        [Route("GetUserCompanyAccounts")]
        [HttpGet]
        [Authorize]
        public IList<Company> GetUserCompanyAccounts()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                               .Select(c => c.Value).SingleOrDefault();
            return _usersMethod.GetUserCompanyAccounts(Convert.ToInt64(sid));
        }
        public IHttpActionResult Test()
        {
            System.Net.HttpStatusCode statusCode = System.Net.HttpStatusCode.OK;

            return Redirect("http://www.compilemode.com");


        }
    }
}

