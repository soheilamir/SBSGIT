using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class RolesInSectionMap : VersionedClassMap<Entities.RolesInSection>
    {

        public RolesInSectionMap()
        {
            Table("RolesInSection");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.SbsSectionItem).Column("SBS_SECTION_ID");
            References(x => x.SbsRoleItem).Column("SBS_ROLE_ID");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
