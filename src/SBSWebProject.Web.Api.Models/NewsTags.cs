using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class NewsTags
    {
        public virtual long Id { get; set; }
        public virtual News NewsItem { get; set; }
        public virtual SbsTags SbstagsItem { get; set; }
    }
}
