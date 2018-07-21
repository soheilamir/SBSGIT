using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class WebsiteFAQsMap : VersionedClassMap<WebsiteFAQs>
    {
        public WebsiteFAQsMap()
        {
            Table("WebsiteFaqs");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.WebsiteCategoryItem).Column("CATEGORY_ID");
            Map(x => x.Question).Column("QUESTION");
            Map(x => x.Answer).Column("ANSWER");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
