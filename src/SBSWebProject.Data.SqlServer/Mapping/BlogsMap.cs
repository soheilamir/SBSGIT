using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class BlogsMap : VersionedClassMap<Blogs>
    {
        public BlogsMap()
        {
            Table("Blogs");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.WebsiteCategoryItem).Column("WEBSITE_CATEGORY_ID");
            References(x => x.FilesItem).Column("IMAGE_ID");
            References(x => x.SbsBranchTeamItem).Column("SBS_BRANCH_TEAM_ID");
            Map(x => x.Title).Column("TITLE");
            Map(x => x.Context).Column("CONTEXT");
            Map(x => x.PublishDate).Column("PUBLISH_DATE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
