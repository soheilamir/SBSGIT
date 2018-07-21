using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class TicketNumbers
    {
        public virtual long Id { get; set; }
        public virtual ResponseAirplaneTicket ResponseAirplaneTicketItem { get; set; }
        public virtual Passengers PassengersItem { get; set; }
        public virtual string TicketNumber { get; set; }
    }
}
