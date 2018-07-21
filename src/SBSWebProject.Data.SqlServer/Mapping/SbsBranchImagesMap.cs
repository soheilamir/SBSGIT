using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public partial class SbsBranchImagesMap : VersionedClassMap<SbsBranchImages>
    {
        public SbsBranchImagesMap()
        {
            Table("SbsBranchImages");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.SbsBranchesItem).Column("SBS_BRANCHE_ID");
            References(x => x.FilesItem).Column("IMAGE_ID");
            Map(x => x.Title).Column("TITLE");
            Map(x => x.Description).Column("DESCRIPTION");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
