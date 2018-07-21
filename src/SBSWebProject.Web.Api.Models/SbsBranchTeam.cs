using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public partial class SbsBranchTeam
    {
        public virtual long Id { get; set; }
        public virtual SbsBranches SbsBrancheItem { get; set; }
        public virtual SbsSections SbsSectionItem { get; set; }
        public virtual Users UserItem { get; set; }
        public virtual Files FileItem { get; set; }
        public virtual string Description { get; set; }
        public virtual string Position { get; set; }
    }
}
