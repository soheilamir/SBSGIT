using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public partial class WebPageContext
    {
        public virtual long Id { get; set; }
        public virtual WebPages WebPagesItem { get; set; }
        public virtual string Context { get; set; }
    }
}
