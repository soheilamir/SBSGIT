using System;
using System.Text;
using System.Collections.Generic;

namespace SBSWebProject.Web.Api.Models
{
    public class CompanyServiceFee
    {
        public virtual long Id { get; set; }
        public virtual Company CompanyItem { get; set; }
        public virtual Services ServiceItem { get; set; }
        public virtual long? ServiceFee { get; set; }
        public virtual bool? IsPercent { get; set; }
    }
}
