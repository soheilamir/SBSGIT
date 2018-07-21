using SBSWebProject.Data.Entities;


namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class NewsTagsMap : VersionedClassMap<NewsTags>
    {
        public NewsTagsMap()
        {
            Table("NewsTags");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.NewsItem).Column("NEWS_ID");
            References(x => x.SbstagsItem).Column("SBS_TAG_ID");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
