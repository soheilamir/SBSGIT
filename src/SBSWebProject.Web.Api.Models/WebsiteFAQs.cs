using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    
    public partial class WebsiteFAQs  {
        public virtual long Id { get; set; }
        public virtual WebsiteCategory WebsiteCategoryItem { get; set; }
        public virtual string Question { get; set; }
        public virtual string Answer { get; set; }
    }
}
