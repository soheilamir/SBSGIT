using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public partial class SbsSections {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<JobOpportunity> JobOpportunityS { get; set; }
        public virtual IList<Messages> MessagesS { get; set; }
        public virtual IList<RolesInSection> RolesInSectionS { get; set; }
        public virtual IList<SbsBranchTeam> SbsBranchTeamS { get; set; }
    }
}
