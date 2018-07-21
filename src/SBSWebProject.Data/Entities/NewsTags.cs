using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class NewsTags : Entity
    {
        //public virtual long Id { get; set; }
        public virtual News NewsItem { get; set; }
        public virtual SbsTags SbstagsItem { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
