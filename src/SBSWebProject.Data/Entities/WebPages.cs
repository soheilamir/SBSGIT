using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class WebPages : Entity
    {
        //public virtual long Id { get; set; }
        public virtual string PageName { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string RoutUrl { get; set; }
        public virtual string SourceUrl { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<WebPageBanners> WebPageBannersS { get; set; }
        public virtual IList<WebPageContext> WebPageContextS { get; set; }
        public virtual IList<WebsiteCategory> WebsiteCategoryS { get; set; }
    }
}
