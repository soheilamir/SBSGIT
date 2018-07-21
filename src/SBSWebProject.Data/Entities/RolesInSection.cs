using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class RolesInSection : Entity
    {
        //public virtual long Id { get; set; }
        public virtual SbsSections SbsSectionItem { get; set; }
        public virtual SbsRoles SbsRoleItem { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
