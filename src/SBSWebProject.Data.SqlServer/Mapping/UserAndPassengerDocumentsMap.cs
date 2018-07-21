using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class UserAndPassengerDocumentsMap : VersionedClassMap<UserAndPassengerDocuments>
    {
        public UserAndPassengerDocumentsMap()
        {
            Table("UserAndPassengerDocuments");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("USER_ID");
            References(x => x.PassengersItem).Column("PASSENGER_ID");
            Map(x => x.DocumentTitle).Column("DOCUMENT_TITLE");
            Map(x => x.DocumentUrl).Column("DOCUMENT_URL");
            Map(x => x.RegisteredDate).Column("REGISTERED_DATE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
