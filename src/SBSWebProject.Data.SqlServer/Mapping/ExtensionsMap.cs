using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class ExtensionsMap : VersionedClassMap<Extensions>
    {
        public ExtensionsMap()
        {
            Table("Extensions");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.Extension).Column("EXTENSION");
            Map(x => x.Logo).Column("LOGO");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.FileS).KeyColumn("FILE_EXTENSION_ID");
        }
    }
}
