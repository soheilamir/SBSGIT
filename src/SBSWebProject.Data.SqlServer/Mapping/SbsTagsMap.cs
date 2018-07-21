using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public partial class SbsTagsMap : VersionedClassMap<SbsTags>
    {
        public SbsTagsMap()
        {
            Table("SbsTags");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.Title).Column("TITLE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.NewsTagsS).KeyColumn("SBS_TAG_ID");
        }
    }
}
