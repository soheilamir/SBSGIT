using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{


    public partial class WebPageBannersMap : VersionedClassMap<WebPageBanners>
    {

        public WebPageBannersMap()
        {
            Table("WebPageBanners");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.WebPagesItem).Column("WEB_PAGE_ID");
            References(x => x.FilesItem).Column("FILE_ID");
            Map(x => x.Title).Column("TITLE");
            Map(x => x.Description).Column("DESCRIPTION");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
