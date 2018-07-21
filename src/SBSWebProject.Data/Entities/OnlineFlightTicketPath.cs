using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Data.Entities
{
    public partial class OnlineFlightTicketPath : Entity
    {
        //public virtual long Id { get; set; }
        public virtual OnlineFlightTicket OnlineFlightTicketItem { get; set; }
        public virtual AirlineClassPathFee AirlineClassPathFeeItem { get; set; }
        public virtual DateTime? DeparturDate { get; set; }
        public virtual IList<OnlineFlightTicketPassengers> OnlineFlightTicketPassengersS { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
