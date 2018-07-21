using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.SqlServer.Mapping
{
    public class UsersMap : VersionedClassMap<Users>
    {
        public UsersMap()
        {
            Table("Users");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Increment().Column("ID");
            References(x => x.BirthPalaceCityItem).Column("BIRTH_PALACE_CITY_ID");
            References(x => x.LivingCityItem).Column("LIVING_CITY_ID");
            Map(x => x.IsAdmin).Column("IS_ADMIN");
            Map(x => x.Username).Column("USERNAME").Not.Nullable();
            Map(x => x.Password).Column("PASSWORD");
            Map(x => x.FaName).Column("FA_NAME");
            Map(x => x.FaFamily).Column("FA_FAMILY");
            Map(x => x.EnName).Column("EN_NAME");
            Map(x => x.EnFamily).Column("EN_FAMILY");
            Map(x => x.FatherName).Column("FATHER_NAME");
            Map(x => x.BirthDate).Column("BIRTH_DATE");
            Map(x => x.NationalCode).Column("NATIONAL_CODE");
            Map(x => x.IdNumber).Column("ID_NUMBER");
            Map(x => x.SecurityCode).Column("SECURITY_CODE");
            Map(x => x.PassportNumber).Column("PASSPORT_NUMBER");
            Map(x => x.IsMain).Column("IS_MAIN");
            Map(x => x.Email).Column("EMAIL");
            Map(x => x.Sex).Column("SEX");
            Map(x => x.Mobile).Column("MOBILE");
            Map(x => x.Tel).Column("TEL");
            Map(x => x.NationalityCountryId).Column("NATIONALITY_COUNTRY_ID");
            Map(x => x.PassengerId).Column("PASSENGER_ID");
            Map(x => x.ActivityStatusId).Column("ACTIVITY_STATUS_ID");
            Map(x => x.InfoStatusId).Column("INFO_STATUS_ID");
            HasMany(x => x.AirlineMembersS).KeyColumn("USER_ID");
            HasMany(x => x.CompanyS).KeyColumn("USER_ID");
            HasMany(x => x.CompanyEmployeeS).KeyColumn("USER_ID");
            HasMany(x => x.FilesS).KeyColumn("OWNER_USER_ID");
            HasMany(x => x.FoldersS).KeyColumn("OWNER_USER_ID");
            HasMany(x => x.HotelRoomCommentsS).KeyColumn("USER_ID");
            HasMany(x => x.CheckedWithPersonnelMessagesS).KeyColumn("CHECKED_WITH_PERSONNEL_ID");
            HasMany(x => x.SenderMessagesS).KeyColumn("SENDER_USER_ID");
            HasMany(x => x.OrdersS).KeyColumn("USER_ID");
            HasMany(x => x.PassengersS).KeyColumn("OWNER_USER_ID");
            HasMany(x => x.ReceivedResumeS).KeyColumn("USER_ID");
            HasMany(x => x.RequestAirplaneServiceS).KeyColumn("USER_ID");
            HasMany(x => x.SbsBranchTeamS).KeyColumn("USERS_ID");
            HasMany(x => x.UserAddressesS).KeyColumn("USER_ID");
            HasMany(x => x.UserAndPassengerDocumentsS).KeyColumn("USER_ID");
            HasMany(x => x.UserCreditInfoS).KeyColumn("USER_ID");
            HasMany(x => x.UserEmailsS).KeyColumn("USER_ID");
            HasMany(x => x.UserFavoriteAirlinesS).KeyColumn("USER_ID");
            HasMany(x => x.UserLanguagesS).KeyColumn("USER_ID");
            HasMany(x => x.UserLoginLogS).KeyColumn("USER_ID");
            HasMany(x => x.UserPassengerS).KeyColumn("USER_ID");
            HasMany(x => x.UserTelsS).KeyColumn("USER_ID");
            HasMany(x => x.RequestAirplaneTicketPassengerS).KeyColumn("USER_ID");
        }
    }
}
