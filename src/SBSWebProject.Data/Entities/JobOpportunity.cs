using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class JobOpportunity : Entity
    {
        //public virtual long Id { get; set; }
        public virtual SbsSections SbsSectionsItem { get; set; }
        public virtual short Number { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? SubmitDate { get; set; }
        public virtual DateTime? ExpireDate { get; set; }
        public virtual bool? IsActive { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
