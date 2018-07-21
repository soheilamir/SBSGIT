using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class WebsiteCategoryMap : VersionedClassMap<WebsiteCategory>
    {
        public WebsiteCategoryMap()
        {
            Table("WebsiteCategory");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.WebsiteCategoryItem).Column("CATEGORY_ID");
            References(x => x.WebPagesItem).Column("WEB_PAGE_ID");
            Map(x => x.Title).Column("TITLE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.BlogsS).KeyColumn("WEBSITE_CATEGORY_ID");
            HasMany(x => x.NewsS).KeyColumn("WEBSITE_CATEGORY_ID");
            HasMany(x => x.WebsiteCategoryS).KeyColumn("CATEGORY_ID");
            HasMany(x => x.WebsiteFAQsS).KeyColumn("CATEGORY_ID");
        }
    }
}
