using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSWebSiteAPI.Models.ResponseDomesticTicketModel
{
    public class ResponseDomesticTicketModel
    {
        public string AirLine { set; get; }
        public string Name { get; set; }
        public string Origin { set; get; }
        public string OriginIATACODE { set; get; }
        public string Destination { set; get; }
        public string DestinationIATACODE { set; get; }
        public string DepartureDateShamsi { set; get; }
        public string DepartureDateMiladi { set; get; }
        public string DepartureTime { set; get; }
        public string ArrivalTime { set; get; }
        public string PlaneType { set; get; }
        public string PlaneTypeCode { set; get; }
        public string FlightNo { set; get; }

        // Fare with class content properties
        public IList<ClassFare> ClassFareList { set; get; }
        // logo img airline properties
        public string LogoImg { set; get; }
        public bool selected { set; get; }

    }
}