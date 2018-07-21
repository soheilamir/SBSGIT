using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class DomFlightTicketPassengerModel
    {
        public virtual long Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string Family { get; set; }
        public virtual string NationalCode { get; set; }
        public virtual string TicketNumber { get; set; }
    }
}
