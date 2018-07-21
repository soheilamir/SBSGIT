using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class UserLanguagesMap : VersionedClassMap<UserLanguages>
    {
        public UserLanguagesMap()
        {
            Table("UserLanguages");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.LanguagesItem).Column("LANGUAGE_ID");
            References(x => x.UsersItem).Column("USER_ID");
            Map(x => x.Proficiency).Column("PROFICIENCY");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
