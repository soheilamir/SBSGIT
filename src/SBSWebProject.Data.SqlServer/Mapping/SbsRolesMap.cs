using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class SbsRolesMap : VersionedClassMap<SbsRoles>
    {
        public SbsRolesMap()
        {
            Table("SbsRoles");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.RoleName).Column("ROLE_NAME");
            Map(x => x.Description).Column("DESCRIPTION");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
            HasMany(x => x.RolesInSectionS).KeyColumn("SBS_ROLE_ID");
        }
    }
}
