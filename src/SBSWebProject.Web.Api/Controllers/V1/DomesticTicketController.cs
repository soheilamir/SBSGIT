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
using Newtonsoft.Json.Linq;
using System.Collections;
using SBSWebProject.MappingObject;

namespace SBSWebProject.Web.Api.Controllers.V1
{
    [ApiVersion1RoutePrefix("")]
    public class DomesticTicketController : ApiController
    {
        private readonly IDomesticFlightTicketMethod _domesticFlightTicketMethod;
        private readonly IMappingObject<Data.Entities.Orders, Orders> _ordersEntityToModel;
        public DomesticTicketController(IDomesticFlightTicketMethod domesticFlightTicketMethod,
            IMappingObject<Data.Entities.Orders, Orders> ordersEntityToModel)
        {
            _domesticFlightTicketMethod = domesticFlightTicketMethod;
            _ordersEntityToModel = ordersEntityToModel;
        }
        [Route("domestic/ticket/getdata")]
        [HttpPost]
        public Dictionary<string, IList<ResponseDomesticTicketModel>> GetTicketData(DomesticFlightTicketModel searchDataItem)
        {
            //DomesticFlightTicketMethod dft = new DomesticFlightTicketMethod();
            DomesticFlightTicketModel domesticFlightTicketModel = searchDataItem;
            return _domesticFlightTicketMethod.GetAllDomesticFlightTicket(domesticFlightTicketModel);
        }
        [Route("domestic/ticket/pnr/reserve")]
        [HttpPost]
        public Orders GetPNR_ReserveFlight(ReserveDomesticFlight objReserveFlight)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var name = identity.Claims.Where(c => c.Type == ClaimTypes.Name)
                   .Select(c => c.Value).SingleOrDefault();
            var sid = identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                               .Select(c => c.Value).SingleOrDefault();
            var email = identity.Claims.Where(c => c.Type == ClaimTypes.Email)
                               .Select(c => c.Value).SingleOrDefault();
            //DomesticFlightTicketMethod dft = new DomesticFlightTicketMethod();
            ReserveDomesticFlight reserveDomesticFlight = objReserveFlight;
            return _ordersEntityToModel.Map(_domesticFlightTicketMethod.GetAllDomesticFlightReserve(reserveDomesticFlight, Convert.ToInt64(sid), email));
        }
        //[Route("domestic/ticket/getTicketNumber")]
        //[HttpPost]
        //public void GetTicketNumber(Airlines airlineModel, string pnr, string email)
        //{
        //    _domesticFlightTicketMethod.GetTicketNumber(airlineModel.IataCode, pnr, email);
        //}
        [Route("domestic/ticket/getTicketNumberTest")]
        [HttpGet]
        public JObject GetTicketNumberTest()
        {
            //_domesticFlightTicketMethod.GetTicketNumberTest();
            //return "{\"AirIssueET\":[\"Error\":\"No Er\",\"ETS\":\"BAGHERKHOJASTEH/FAHIMEH=4912440011443\"]}";
            string str = "{\"AirIssueET\":[{\"Error\":\"No Err\",\"ETS\":\"BAGHERKHOJASTEH/FAHIMEH=4912440011443\rKHODABANDEH/HANIEH=4912440011444\rKHODABANDEH/MOJTABA=4912440011445\"}]}";
            JObject json = JObject.Parse(str);
            return json;
        }

        [Route("domestic/ticket/getPnrTest")]
        [HttpGet]
        public JObject GetPNRTest()
        {
            string str = "{\"AirReserve\":[{\"Error\":\"No Err\",\"PNR\":\"T2CRB\"}]}";
            JObject json = JObject.Parse(str);
            return json;
        }
        [Route("domestic/SavePassenger")]
        [HttpPost]
        public Dictionary<string, List<PassengerFlight>> SavePassenger(JObject PassengersList)
        {
            var identity = (ClaimsPrincipal)Thread.CurrentPrincipal;
            var sid = Convert.ToInt64(identity.Claims.Where(c => c.Type == ClaimTypes.Sid)
                               .Select(c => c.Value).SingleOrDefault());

            List<PassengerFlight> resultAdultList = PassengersList["PassengersList"]["adultList"].ToObject<List<PassengerFlight>>();
            List<PassengerFlight> resultChildList = PassengersList["PassengersList"]["childList"].ToObject<List<PassengerFlight>>();
            List<PassengerFlight> resultInfantList = PassengersList["PassengersList"]["infantList"].ToObject<List<PassengerFlight>>();
            return _domesticFlightTicketMethod.SaveUserPassengers(resultAdultList, resultChildList, resultInfantList, sid);
        }
        [Route("domestic/ticket/{orderId}/GetSavedTicketByOrder")]
        [HttpGet]
        public List<OnlineFlightTicketModel> GetSavedTicketByOrder(long orderId)
        {
            return _domesticFlightTicketMethod.GetSavedTicketByOrderMethod(orderId);
        }

    }
}
