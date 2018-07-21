using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public partial class Messages {
        public virtual long Id { get; set; }
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
    }
}
