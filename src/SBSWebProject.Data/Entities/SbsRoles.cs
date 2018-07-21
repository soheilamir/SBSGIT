using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class SbsRoles : Entity
    {
        //public virtual long Id { get; set; }
        public virtual string RoleName { get; set; }
        public virtual string Description { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<RolesInSection> RolesInSectionS { get; set; }
    }
}
