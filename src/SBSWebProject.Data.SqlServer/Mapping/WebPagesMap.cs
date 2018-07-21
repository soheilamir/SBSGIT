using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public partial class WebPagesMap : VersionedClassMap<WebPages>
    {
        public WebPagesMap()
        {
            Table("WebPages");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.PageName).Column("PAGE_NAME");
            Map(x => x.Title).Column("TITLE");
            Map(x => x.Description).Column("DESCRIPTION");
            Map(x => x.RoutUrl).Column("ROUT_URL");
            Map(x => x.SourceUrl).Column("SOURCE_URL");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.WebPageBannersS).KeyColumn("WEB_PAGE_ID");
            HasMany(x => x.WebPageContextS).KeyColumn("WEB_PAGE_ID");
            HasMany(x => x.WebsiteCategoryS).KeyColumn("WEB_PAGE_ID");
        }
    }
}
