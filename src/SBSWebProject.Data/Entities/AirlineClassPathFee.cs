using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public class AirlineClassPathFee : Entity
    {
        public virtual AirlineClassPath AirlineClassPathItem { get; set; }
        public virtual long? AdultFee { get; set; }
        public virtual long? ChildFee { get; set; }
        public virtual long? InfantFee { get; set; }
        public virtual bool? IsActive { get; set; }
        public virtual DateTime? RegisterDate { get; set; }

        public virtual IList<OnlineFlightTicketPath> OnlineFlightTicketPathS { get; set; }
    }
}
