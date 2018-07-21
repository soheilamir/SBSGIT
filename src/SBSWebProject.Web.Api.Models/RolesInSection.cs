using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public class RolesInSection {
        public virtual long Id { get; set; }
        public virtual SbsSections SbsSectionItem { get; set; }
        public virtual SbsRoles SbsRoleItem { get; set; }
    }
}
