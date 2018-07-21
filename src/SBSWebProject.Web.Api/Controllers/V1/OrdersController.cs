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
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Threading;
using System.Linq;

namespace SBSWebProject.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    [UnitOfWorkActionFilter]
    public class OrdersController : ApiController
    {
        private readonly IOrdersMethod _ordersMethod;
        public OrdersController(IOrdersMethod ordersMethod)
        {
            _ordersMethod = ordersMethod;
        }
        [Route("GetOrdersByUser")]
        [HttpGet]
        [Authorize]
        public IList<SBSWebProject.Web.Api.Models.Orders> GetOrdersByUser()
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var name = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();
            var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                               .Select(c => c.Value).SingleOrDefault();
            return _ordersMethod.GetOrdersByUserId(Convert.ToInt64(sid));
            //return _airlinesMethod.GetAllAirlines();
        }
        [Route("SaveOrder")]
        [HttpPost]
        [Authorize]
        public IList<SBSWebProject.Web.Api.Models.Orders> SaveOrder(Orders orderObj)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var name = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();
            var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                   .Select(c => c.Value).SingleOrDefault();
            _ordersMethod.AddOrder(orderObj);
            return _ordersMethod.GetOrdersByUserId(Convert.ToInt64(sid));
            //return _airlinesMethod.GetAllAirlines();
        }
    }
}
