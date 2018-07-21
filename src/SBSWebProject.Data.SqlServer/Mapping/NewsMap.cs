using SBSWebProject.Data.Entities;


namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class NewsMap : VersionedClassMap<News>
    {
        public NewsMap()
        {
            Table("News");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.WebsiteCategoryItem).Column("WEBSITE_CATEGORY_ID");
            References(x => x.FilesItem).Column("IMAGE_ID");
            Map(x => x.Title).Column("TITLE");
            Map(x => x.SubmitDate).Column("SUBMIT_DATE");
            Map(x => x.Context).Column("CONTEXT");
            Map(x => x.SourceLink).Column("SOURCE_LINK");
            Map(x => x.SourceName).Column("SOURCE_NAME");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.NewsTagsS).KeyColumn("NEWS_ID");
        }
    }
}
