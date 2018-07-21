using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public partial class News : Entity
    {
        //public virtual long Id { get; set; }
        public virtual WebsiteCategory WebsiteCategoryItem { get; set; }
        public virtual Files FilesItem { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime? SubmitDate { get; set; }
        public virtual string Context { get; set; }
        public virtual string SourceLink { get; set; }
        public virtual string SourceName { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<NewsTags> NewsTagsS { get; set; }


    }
}
