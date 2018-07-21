using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class Airlines : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Country CountryItem { get; set; }
        public virtual string Name { get; set; }
        public virtual string FlightStateCode { get; set; }
        public virtual string Type { get; set; }
        public virtual string IataCode { get; set; }
        public virtual string IacoCode { get; set; }
        public virtual bool Include { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<AirlineClasses> AirlineClassesS { get; set; }
        public virtual IList<AirlineMembers> AirlineMembersS { get; set; }
        public virtual IList<AirlineNameByLanguage> AirlineNameByLanguageS { get; set; }
        public virtual IList<AirlineSubClasses> AirlineSubClassesS { get; set; }
        public virtual IList<FlightCondition> FlightConditionS { get; set; }
        public virtual IList<UserFavoriteAirlines> UserFavoriteAirlinesS { get; set; }
        public virtual IList<AirplaneTicketPreferedAirlines> AirplaneTicketPreferedAirlinesS { get; set; }
    }
}
