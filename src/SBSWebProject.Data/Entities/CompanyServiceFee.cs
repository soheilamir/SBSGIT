using System;
using System.Text;
using System.Collections.Generic;

namespace SBSWebProject.Data.Entities
{
    public class CompanyServiceFee : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Company CompanyItem { get; set; }
        public virtual Services ServiceItem { get; set; }
        public virtual long? ServiceFee { get; set; }
        public virtual bool? IsPercent { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
