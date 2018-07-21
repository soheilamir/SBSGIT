using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class OnlineFlightTicketModel
    {
        public string RegistrarFullName { set; get; }
        public string DepatringDate { set; get; }
        public string PNR { set; get; }
        public City Source { set; get; }
        public City Destination { set; get; }

        public string TakeOffTime { set; get; }
        public string LandingTime { set; get; }
        public string AirplaneName { set; get; }
        public string FlightNumber { set; get; }
        

        public string AdultFee { set; get; }
        public string ChildFee { set; get; }
        public string InfantFee { set; get; }
        public Airlines Airline { set; get; }
        public string FlightClass { set; get; }
        public string RegisterDate { set; get; }
        public virtual IList<PassengerFlight> PassengerS { get; set; }
    }
}
