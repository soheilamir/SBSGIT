using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class Users : Entity
    {

        //public virtual long Id { get; set; }
        public virtual City BirthPalaceCityItem { get; set; }
        public virtual City LivingCityItem { get; set; }
        public virtual bool? IsAdmin { get; set; }
        public virtual string Username { get; set; }
        public virtual int Password { get; set; }
        public virtual string FaName { get; set; }
        public virtual string FaFamily { get; set; }
        public virtual string EnName { get; set; }
        public virtual string EnFamily { get; set; }
        public virtual string FatherName { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual string NationalCode { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string SecurityCode { get; set; }
        public virtual string PassportNumber { get; set; }
        public virtual bool? IsMain { get; set; }
        public virtual string Email { get; set; }
        public virtual string Sex { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string Tel { get; set; }
        public virtual long? NationalityCountryId { get; set; }
        public virtual long? PassengerId { get; set; }
        public virtual byte? ActivityStatusId { get; set; }
        public virtual byte? InfoStatusId { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<AirlineMembers> AirlineMembersS { get; set; }
        public virtual IList<Company> CompanyS { get; set; }
        public virtual IList<CompanyEmployee> CompanyEmployeeS { get; set; }
        public virtual IList<Files> FilesS { get; set; }
        public virtual IList<Folders> FoldersS { get; set; }
        public virtual IList<HotelRoomComments> HotelRoomCommentsS { get; set; }
        public virtual IList<Messages> CheckedWithPersonnelMessagesS { get; set; }
        public virtual IList<Messages> SenderMessagesS { get; set; }
        public virtual IList<Orders> OrdersS { get; set; }
        public virtual IList<Passengers> PassengersS { get; set; }
        public virtual IList<ReceivedResume> ReceivedResumeS { get; set; }
        public virtual IList<RequestAirplaneService> RequestAirplaneServiceS { get; set; }
        public virtual IList<SbsBranchTeam> SbsBranchTeamS { get; set; }
        public virtual IList<UserAddresses> UserAddressesS { get; set; }
        public virtual IList<UserAndPassengerDocuments> UserAndPassengerDocumentsS { get; set; }
        public virtual IList<UserCreditInfo> UserCreditInfoS { get; set; }
        public virtual IList<UserEmails> UserEmailsS { get; set; }
        public virtual IList<UserFavoriteAirlines> UserFavoriteAirlinesS { get; set; }
        public virtual IList<UserLanguages> UserLanguagesS { get; set; }
        public virtual IList<UserLoginLog> UserLoginLogS { get; set; }
        public virtual IList<UserPassenger> UserPassengerS { get; set; }
        public virtual IList<UserTels> UserTelsS { get; set; }
        public virtual IList<RequestAirplaneTicketPassenger> RequestAirplaneTicketPassengerS { get; set; }



    }
}
