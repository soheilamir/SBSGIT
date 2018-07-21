using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json.Linq;
using SBSWebSiteAPI.Models.SearchTicketModel;
using SBSWebSiteAPI.AllClasses;
using SBSWebSiteAPI.Models.ResponseDomesticTicketModel;

namespace SBSWebSiteAPI.Controllers.DomesticTicketController
{
    [EnableCors(origins: "http://localhost:24258", headers: "content-type", methods: "*")]
    public class DomesticTicketController : ApiController
    {
        [Route("domestic/ticket/getdata")]
        [HttpPost]
        public Dictionary<string, IList<ResponseDomesticTicketModel>> GetTicketData(DomesticFlightTicketModel searchDataItem)
        {
            DomesticFlightTicketMethod dft = new DomesticFlightTicketMethod();
            DomesticFlightTicketModel domesticFlightTicketModel = searchDataItem;
            return dft.GetAllDomesticFlightTicket(domesticFlightTicketModel);
        }
        [Route("domestic/ticket/pnr/reserve")]
        [HttpPost]
        public IList<AirReserve> GetPNR_ReserveFlight(ReserveDomesticFlight objReserveFlight)
        {
            DomesticFlightTicketMethod dft = new DomesticFlightTicketMethod();
            ReserveDomesticFlight reserveDomesticFlight = objReserveFlight;
            return dft.GetAllDomesticFlightReserve(reserveDomesticFlight);
        }
    }
}
