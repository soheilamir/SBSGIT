using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class ReceivedResumeMap : VersionedClassMap<ReceivedResume>
    {
        public ReceivedResumeMap()
        {
            Table("ReceivedResume");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("USER_ID");
            References(x => x.AttachFileItem).Column("ATTACH_FILE_ID");
            Map(x => x.Name).Column("NAME");
            Map(x => x.Family).Column("FAMILY");
            Map(x => x.Tel).Column("TEL");
            Map(x => x.Email).Column("EMAIL");
            Map(x => x.Address).Column("ADDRESS");
            Map(x => x.Message).Column("MESSAGE");
            Map(x => x.SubmitDate).Column("SUBMIT_DATE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
