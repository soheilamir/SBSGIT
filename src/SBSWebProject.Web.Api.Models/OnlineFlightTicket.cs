using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public partial class OnlineFlightTicket
    {
        public virtual long Id { get; set; }
        public virtual Services ServicesItem { get; set; }
        public virtual Orders OrdersItem { get; set; }
        public virtual string PNR { get; set; }
        public virtual DateTime TicketDate { get; set; }
        public virtual IList<OnlineFlightTicketPath> OnlineFlightTicketPathS { get; set; }
        public virtual IList<OnlineFlightTicketPassengers> OnlineFlightTicketPassengersS { get; set; }
        
    }
}
