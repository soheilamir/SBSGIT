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
    public class OnlineTicketController : ApiController
    {
        [Route("api/flight/reserve")]
        [HttpPost]
        public Api.Models.Orders Test_FlightTicket(ReserveDomesticFlight objReserveFlight)
        {
            OrdersDataHandler ordersDataHandler = new OrdersDataHandler(WebApiApplication.SessionFactory);
            OnlineFlightTicketPassengersDataHandler OnlineFlightTicketPassengersDataHandler = new OnlineFlightTicketPassengersDataHandler(WebApiApplication.SessionFactory);
            OnlineFlightTicketDataHandler OnlineFlightTicketDataHandler = new OnlineFlightTicketDataHandler(WebApiApplication.SessionFactory);
            OnlineFlightTicketPathDataHandler OnlineFlightTicketPathDataHandler = new OnlineFlightTicketPathDataHandler(WebApiApplication.SessionFactory);
            //SBSWebProject.AutoMappingObject.ModelToEntity.WebPagesMapper mapperModelToEntity = new AutoMappingObject.ModelToEntity.WebPagesMapper();
            //SBSWebProject.AutoMappingObject.EntityToModel.WebPagesMapper mapperEntityToModel = new AutoMappingObject.EntityToModel.WebPagesMapper();
            //SBSWebProject.Data.Entities.WebPages obj = mapperModelToEntity.Map(webPagesData);

            //webPagesDataHandler.Save(obj);

            return null;
        }
    }
}
