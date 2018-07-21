using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{

    public partial class Messages : Entity
    {
        //public virtual long Id { get; set; }
        public virtual SbsBranches SbsBrancheItem { get; set; }
        public virtual SbsSections SbsSectionsItem { get; set; }
        public virtual Users SenderUserItem { get; set; }
        public virtual Users CheckedWithPersonnelItem { get; set; }
        public virtual string Name { get; set; }
        public virtual string Family { get; set; }
        public virtual string ContactNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual string MessageText { get; set; }
        public virtual bool? Checked { get; set; }
        public virtual string Answer { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
