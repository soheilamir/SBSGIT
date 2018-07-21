using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public partial class SbsBranchAwards 
    {
        public virtual long Id { get; set; }
        public virtual SbsBranches SbsBranchesItem { get; set; }
        public virtual Files FilesItem { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? CatchDate { get; set; }

    }
}
