using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public partial class OnlineFlightTicketPassengers
    {
        public virtual long Id { get; set; }
        public virtual OnlineFlightTicket OnlineFlightTicketItem { get; set; }
        public virtual Passengers PassengersItem { get; set; }
        public virtual string TicketNumber { get; set; }
    }
}
