using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class TicketNumbers : Entity {
        //public virtual long Id { get; set; }
        public virtual ResponseAirplaneTicket ResponseAirplaneTicketItem { get; set; }
        public virtual Passengers PassengersItem { get; set; }
        public virtual string TicketNumber { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
