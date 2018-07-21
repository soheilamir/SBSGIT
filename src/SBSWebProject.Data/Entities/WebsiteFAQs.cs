using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public partial class WebsiteFAQs : Entity
    {
        //public virtual long Id { get; set; }
        public virtual WebsiteCategory WebsiteCategoryItem { get; set; }
        public virtual string Question { get; set; }
        public virtual string Answer { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
