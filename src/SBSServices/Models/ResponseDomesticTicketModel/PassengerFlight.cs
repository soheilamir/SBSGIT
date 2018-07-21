using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSWebSiteAPI.Models.ResponseDomesticTicketModel
{
    public class PassengerFlight
    {
        public string Name_Fa { set; get; }
        public string LastName_Fa { set; get; }
        public string Name_En { set; get; }
        public string LastName_En { set; get; }
        public string BD { set; get; }
        public string NationalCode { set; get; }
        public string Tel { set; get; }
    }
}