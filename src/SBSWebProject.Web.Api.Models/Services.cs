using System;
using System.Text;
using System.Collections.Generic;

namespace SBSWebProject.Web.Api.Models
{
    public class Services
    {
        public virtual long Id { get; set; }
        public virtual SbsSections SbssectionsItem { get; set; }
        public virtual string ServiceName { get; set; }
        public virtual IList<CompanyServiceFee> CompanyServiceFeeS { get; set; }
        public virtual IList<OnlineFlightTicket> OnlineFlightTicketS { get; set; }
    }
}
