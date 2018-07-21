using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSWebSiteAPI.Models.ResponseDomesticTicketModel
{
    public class ClassFare
    {
        public string FlightClass { set; get; }
        public string AdultFare { set; get; }
        public string ChildFare { set; get; }
        public string InfantFare { set; get; }
        public bool selected { set; get; }
    }
}