using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{

    public partial class WebsiteCategory : Entity
    {
        //public virtual long Id { get; set; }
        public virtual WebsiteCategory WebsiteCategoryItem { get; set; }
        public virtual WebPages WebPagesItem { get; set; }
        public virtual string Title { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<Blogs> BlogsS { get; set; }
        public virtual IList<News> NewsS { get; set; }
        public virtual IList<WebsiteCategory> WebsiteCategoryS { get; set; }
        public virtual IList<WebsiteFAQs> WebsiteFAQsS { get; set; }
    }
}
