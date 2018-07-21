using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class SbsBranchAwardsMap : VersionedClassMap<SbsBranchAwards>
    {
        public SbsBranchAwardsMap()
        {
            Table("SbsBranchAwards");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.SbsBranchesItem).Column("SBS_BRANCH_ID");
            References(x => x.FilesItem).Column("IMAGE_ID");
            Map(x => x.Description).Column("DESCRIPTION");
            Map(x => x.CatchDate).Column("CATCH_DATE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}