using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class UserMap : VersionedClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.UserId);
            Map(x => x.Firstname).Not.Nullable();
            Map(x => x.Lastname).Not.Nullable();
            Map(x => x.Username).Column("USERNAME").Not.Nullable();
            Map(x => x.Password).Column("Password").Nullable();
            Map(x => x.SecurityStamp).Nullable();
            //Map(x => x.State).Column("STATE").Not.Nullable();
        }
    }
}
