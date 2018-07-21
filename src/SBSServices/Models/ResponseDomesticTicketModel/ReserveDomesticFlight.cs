using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSWebSiteAPI.Models.ResponseDomesticTicketModel
{
    public class ReserveDomesticFlight
    {
        public string Source { set; get; }
        public string Target { set; get; }

        public string D_Airline { set; get; }
        public string D_FlightClass { set; get; }
        public string D_FlightNo { set; get; }
        public string D_Day { set; get; }
        public string D_Month { set; get; }

        public string R_Airline { set; get; }
        public string R_FlightClass { set; get; }
        public string R_FlightNo { set; get; }
        public string R_Day { set; get; }
        public string R_Month { set; get; }

        public string No { set; get; }
        public List<PassengerFlight> lstAdult { set; get; }
        public List<PassengerFlight> lstChild { set; get; }
        public List<PassengerFlight> lstInfant { set; get; }
    }
}