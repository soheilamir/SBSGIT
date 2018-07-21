using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class RequestStatus : Entity
    {
        //public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<Orders> OrdersS { get; set; }
        public virtual IList<RequestAirplaneService> RequestAirplaneServiceS { get; set; }
        public virtual IList<RequestAirplaneTicket> RequestAirplaneTicketS { get; set; }
    }
}
