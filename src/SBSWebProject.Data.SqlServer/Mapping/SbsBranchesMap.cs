using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class SbsBranchesMap : VersionedClassMap<SbsBranches>
    {
        public SbsBranchesMap()
        {
            Table("SbsBranches");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.CityItem).Column("CITY_ID");
            Map(x => x.Description).Column("DESCRIPTION");
            Map(x => x.Address).Column("ADDRESS");
            Map(x => x.Tel).Column("TEL");
            Map(x => x.Fax).Column("FAX");
            Map(x => x.ZipCode).Column("ZIP_CODE");
            Map(x => x.Email).Column("EMAIL");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.MessagesS).KeyColumn("SBS_BRANCH_ID");
            HasMany(x => x.SbsBranchAwardsS).KeyColumn("SBS_BRANCH_ID");
            HasMany(x => x.SbsBranchImagesS).KeyColumn("SBS_BRANCHE_ID");
            HasMany(x => x.SbsBranchTeamS).KeyColumn("SBS_BRANCH_ID");
        }
    }
}
