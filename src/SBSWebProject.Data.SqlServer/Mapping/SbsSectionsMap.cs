using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class SbsSectionsMap : VersionedClassMap<SbsSections>
    {
        public SbsSectionsMap()
        {
            Table("SbsSections");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            Map(x => x.Name).Column("NAME");
            Map(x => x.Description).Column("DESCRIPTION");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.JobOpportunityS).KeyColumn("SECTION_ID");
            HasMany(x => x.MessagesS).KeyColumn("SBS_SECTION_ID");
            HasMany(x => x.RolesInSectionS).KeyColumn("SBS_SECTION_ID");
            HasMany(x => x.SbsBranchTeamS).KeyColumn("SBS_SECTION_ID");
        }
    }
}
