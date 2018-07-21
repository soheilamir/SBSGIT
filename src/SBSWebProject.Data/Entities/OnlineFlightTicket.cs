using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public partial class OnlineFlightTicket : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Services ServicesItem { get; set; }
        public virtual Orders OrdersItem { get; set; }
        public virtual string PNR { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual DateTime TicketDate { get; set; }
        public virtual IList<OnlineFlightTicketPassengers> OnlineFlightTicketPassengersS { get; set; }
        public virtual IList<OnlineFlightTicketPath> OnlineFlightTicketPathS { get; set; }
    }
}
