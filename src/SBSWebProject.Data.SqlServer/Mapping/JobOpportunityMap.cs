using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class JobOpportunityMap : VersionedClassMap<JobOpportunity>
    {
        public JobOpportunityMap()
        {
            Table("JobOpportunity");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.SbsSectionsItem).Column("SECTION_ID");
            Map(x => x.Number).Column("NUMBER");
            Map(x => x.Description).Column("DESCRIPTION");
            Map(x => x.SubmitDate).Column("SUBMIT_DATE");
            Map(x => x.ExpireDate).Column("EXPIRE_DATE");
            Map(x => x.IsActive).Column("IS_ACTIVE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
