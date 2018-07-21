using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class AirlineMembersMap : VersionedClassMap<AirlineMembers>
    {

        public AirlineMembersMap()
        {
            Table("AirlineMembers");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.UsersItem).Column("USER_ID");
            References(x => x.PassengersItem).Column("PASSENGER_ID");
            References(x => x.AirlinesItem).Column("AIRLINE_ID");
            Map(x => x.MembershipNumber).Column("MEMBERSHIP_NUMBER");
            Map(x => x.RegisteredDate).Column("REGISTERED_DATE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Version).Column("TS");
        }
    }
}
