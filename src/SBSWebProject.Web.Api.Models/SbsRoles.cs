using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public partial class SbsRoles{
        public virtual long Id { get; set; }
        public virtual string RoleName { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<RolesInSection> RolesInSectionS { get; set; }
    }
}
