using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class RequestAirplaneTicketPassenger
    {
        public virtual long Id { get; set; }
        public virtual RequestAirplaneTicket RequestAirplaneTicketItem { get; set; }
        public virtual Passengers PassengersItem { get; set; }
    }
}
