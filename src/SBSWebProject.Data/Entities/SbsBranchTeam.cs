using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public partial class SbsBranchTeam : Entity
    {
        //public virtual long Id { get; set; }
        public virtual SbsBranches SbsBranchesItem { get; set; }
        public virtual SbsSections SbsSectionsItem { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Files FilesItem { get; set; }
        public virtual string Description { get; set; }
        public virtual string Position { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<Blogs> BlogsS { get; set; }
    }
}
