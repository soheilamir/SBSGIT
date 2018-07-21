using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public partial class JobOpportunity {
        public virtual long Id { get; set; }
        public virtual SbsSections SbsSectionsItem { get; set; }
        public virtual short Number { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? SubmitDate { get; set; }
        public virtual DateTime? ExpireDate { get; set; }
        public virtual bool? IsActive { get; set; }
    }
}
