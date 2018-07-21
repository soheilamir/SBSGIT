using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class AirlineClassPathFee
    {
        public virtual long Id { get; set; }
        public AirlineClassPath AirlineClassPathItem { get; set; }
        public long? AdultFee { get; set; }
        public long? ChildFee { get; set; }
        public long? InfantFee { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
        public IList<OnlineFlightTicketPath> OnlineFlightTicketPathS { get; set; }
    }
}
