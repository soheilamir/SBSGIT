using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public partial class Blogs
    {
        public virtual long Id { get; set; }
        public virtual WebsiteCategory WebsiteCategoryItem { get; set; }
        public virtual Files FilesItem { get; set; }
        public virtual SbsBranchTeam SbsBranchTeamItem { get; set; }
        public virtual string Title { get; set; }
        public virtual string Context { get; set; }
        public virtual DateTime? PublishDate { get; set; }
    }
}
