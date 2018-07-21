using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class SbsTags : Entity
    {
        //public virtual long Id { get; set; }
        public virtual string Title { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<NewsTags> NewsTagsS { get; set; }
    }
}
