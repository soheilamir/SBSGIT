using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public partial class SbsBranchAwards : Entity
    {
        //public virtual long Id { get; set; }
        public virtual SbsBranches SbsBranchesItem { get; set; }
        public virtual Files FilesItem { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime? CatchDate { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
