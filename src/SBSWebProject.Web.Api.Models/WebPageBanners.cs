using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public partial class WebPageBanners  {
        public virtual long Id { get; set; }
        public virtual WebPages WebPagesItem { get; set; }
        public virtual Files FilesItem { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
    }
}
