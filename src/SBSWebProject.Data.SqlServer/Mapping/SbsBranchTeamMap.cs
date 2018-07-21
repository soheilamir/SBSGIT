using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class SbsBranchTeamMap : VersionedClassMap<SbsBranchTeam>
    {
        public SbsBranchTeamMap()
        {
            Table("SbsBranchTeam");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.SbsBranchesItem).Column("SBS_BRANCH_ID");
            References(x => x.SbsSectionsItem).Column("SBS_SECTION_ID");
            References(x => x.UsersItem).Column("USERS_ID");
            References(x => x.FilesItem).Column("PERSONNEL_IMAGE_ID");
            Map(x => x.Description).Column("DESCRIPTION");
            Map(x => x.Position).Column("POSITION");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.BlogsS).KeyColumn("SBS_BRANCH_TEAM_ID");
        }
    }
}
