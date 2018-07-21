using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class DomFlightTicketModel
    {
        public virtual City SourceItem { get; set; }
        public virtual City DestinationItem { get; set; }
        public Airlines D_Airline { set; get; }
        public Airlines R_Airline { set; get; }
        public virtual PnrModel Pnr { get; set; }
        public virtual List<PassengerFlight> PassengerS { get; set; }
    }
}
