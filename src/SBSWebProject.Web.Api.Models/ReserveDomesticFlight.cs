using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class ReserveDomesticFlight
    {
        public City Source { set; get; }
        public City Target { set; get; }

        public string D_Airline { set; get; }
        public string D_FlightClass { set; get; }
        public string D_FlightNo { set; get; }
        public string D_Day { set; get; }
        public string D_Month { set; get; }
        public string D_Date { set; get; }
        public string D_AdultFee { set; get; }
        public string D_ChildFee { set; get; }
        public string D_InfanfFee { set; get; }
        public long D_AirlineClassPathFeeId { set; get; }


        public string R_Airline { set; get; }
        public string R_FlightClass { set; get; }
        public string R_FlightNo { set; get; }
        public string R_Day { set; get; }
        public string R_Month { set; get; }
        public string R_Date { set; get; }
        public string R_AdultFee { set; get; }
        public string R_ChildFee { set; get; }
        public string R_InfanfFee { set; get; }
        public long R_AirlineClassPathFeeId { set; get; }

        public string No { set; get; }
        public List<PassengerFlight> lstAdult { set; get; }
        public List<PassengerFlight> lstChild { set; get; }
        public List<PassengerFlight> lstInfant { set; get; }
    }
}
