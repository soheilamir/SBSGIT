using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class Passengers
    {
        public virtual long Id { get; set; }
        public virtual Users OwnerUserItem { get; set; }
        public virtual City BirthPalaceCityItem { get; set; }
        public virtual bool? Accepted { get; set; }
        public virtual string NativeName { get; set; }
        public virtual string NativeFamily { get; set; }
        public virtual string InternationalName { get; set; }
        public virtual string InternationalFamily { get; set; }
        public virtual string NativeFatherName { get; set; }
        public virtual string InternationalFatherName { get; set; }
        public virtual DateTime? BirthDate { get; set; }
        public virtual byte? Gender { get; set; }
        public virtual byte? AdultType { get; set; }
        public virtual long? NationalCode { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string PassportNumber { get; set; }
        public virtual string Title { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Mobile { get; set; }
        public virtual IList<AirlineMembers> AirlineMembersS { get; set; }
        public virtual IList<OnlineFlightTicketPassengers> OnlineFlightTicketPassengersS { get; set; }
        public virtual IList<RequestAirplaneTicketPassenger> RequestAirplaneTicketPassengerS { get; set; }
        public virtual IList<TicketNumbers> TicketNumbersS { get; set; }
        public virtual IList<UserAndPassengerDocuments> UserAndPassengerDocumentsS { get; set; }
        public virtual IList<UserPassenger> UserPassengerS { get; set; }
    }
}
