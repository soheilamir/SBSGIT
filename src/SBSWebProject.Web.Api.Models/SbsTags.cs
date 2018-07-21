using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public partial class SbsTags {
        public virtual long Id { get; set; }
        public virtual string Title { get; set; }
        public virtual IList<NewsTags> NewsTagsS { get; set; }
    }
}
