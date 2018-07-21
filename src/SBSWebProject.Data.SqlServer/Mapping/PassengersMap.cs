using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class PassengersMap : VersionedClassMap<Passengers>
    {

        public PassengersMap()
        {
            Table("Passengers");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.OwnerUserItem).Column("OWNER_USER_ID");
            References(x => x.BirthPalaceCityItem).Column("BIRTH_PALACE_CITY_ID");
            Map(x => x.Accepted).Column("ACCEPTED");
            Map(x => x.NativeName).Column("NATIVE_NAME");
            Map(x => x.NativeFamily).Column("NATIVE_FAMILY");
            Map(x => x.InternationalName).Column("INTERNATIONAL_NAME");
            Map(x => x.InternationalFamily).Column("INTERNATIONAL_FAMILY");
            Map(x => x.NativeFatherName).Column("NATIVE_FATHER_NAME");
            Map(x => x.InternationalFatherName).Column("INTERNATIONAL_FATHER_NAME");
            Map(x => x.BirthDate).Column("BIRTH_DATE");
            Map(x => x.Gender).Column("GENDER");
            Map(x => x.AdultType).Column("ADULT_TYPE");
            Map(x => x.NationalCode).Column("NATIONAL_CODE");
            Map(x => x.IdNumber).Column("ID_NUMBER");
            Map(x => x.PassportNumber).Column("PASSPORT_NUMBER");
            Map(x => x.Title).Column("TITLE");
            Map(x => x.Tel).Column("TEL");
            Map(x => x.Mobile).Column("MOBILE");
            //Map(x => x.State).Column("STATE");
            //Map(x => x.Ts).Column("TS");
            HasMany(x => x.AirlineMembersS).KeyColumn("PASSENGER_ID");
            HasMany(x => x.OnlineFlightTicketPassengersS).KeyColumn("PASSENGERS_ID");
            HasMany(x => x.RequestAirplaneTicketPassengerS).KeyColumn("PASSENGER_ID");
            HasMany(x => x.TicketNumbersS).KeyColumn("PASSENGER_ID");
            HasMany(x => x.UserAndPassengerDocumentsS).KeyColumn("PASSENGER_ID");
            HasMany(x => x.UserPassengerS).KeyColumn("PASSENGER_ID");
        }
    }
}
