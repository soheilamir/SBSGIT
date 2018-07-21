using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class MessagesMap : VersionedClassMap<Messages>
    {
        public MessagesMap()
        {
            Table("Messages");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.SbsBrancheItem).Column("SBS_BRANCH_ID");
            References(x => x.SbsSectionsItem).Column("SBS_SECTION_ID");
            References(x => x.SenderUserItem).Column("SENDER_USER_ID");
            References(x => x.CheckedWithPersonnelItem).Column("CHECKED_WITH_PERSONNEL_ID");
            Map(x => x.Name).Column("NAME");
            Map(x => x.Family).Column("FAMILY");
            Map(x => x.ContactNumber).Column("CONTACT_NUMBER");
            Map(x => x.Email).Column("EMAIL");
            Map(x => x.MessageText).Column("MESSAGE_TEXT");
            Map(x => x.Checked).Column("CHECKED");
            Map(x => x.Answer).Column("ANSWER");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
        }
    }
}
