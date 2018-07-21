using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public partial class OnlineFlightTicketPath
    {
        public virtual long Id { get; set; }
        public virtual OnlineFlightTicket OnlineFlightTicketItem { get; set; }
        public virtual AirlineClassPath AirlineClassPathItem { get; set; }
        public virtual long? AdultFee { get; set; }
        public virtual long? ChildFee { get; set; }
        public virtual long? InfantFee { get; set; }
        public virtual DateTime? DeparturDate { get; set; }
    }
}
