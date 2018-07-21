using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class City : Entity
    {
        //public virtual long Id { get; set; }
        public virtual StateProvince StateProvinceItem { get; set; }
        public virtual string TelCode { get; set; }
        public virtual string CharCode { get; set; }
        public virtual bool? IsCapital { get; set; }
        public virtual int? Priority { get; set; }
        public virtual string CityMapFile { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<Airports> AirportsS { get; set; }
        public virtual IList<CityNameByLanguage> CityNameByLanguageS { get; set; }
        public virtual IList<CityPublicPlace> CityPublicPlaceS { get; set; }
        public virtual IList<FlightPath> SourceCityFlightPathS { get; set; }
        public virtual IList<FlightPath> DestinationCityFlightPathS { get; set; }
        public virtual IList<FlightStopOver> FlightStopOverS { get; set; }
        public virtual IList<RequestAirplaneTicket> RequestSourceAirplaneTicketS { get; set; }
        public virtual IList<RequestAirplaneTicket> RequestDestinationAirplaneTicketS { get; set; }
        public virtual IList<SbsBranches> Sbsbranches { get; set; }
        public virtual IList<Users> BirthPlaceUserS { get; set; }
        public virtual IList<Users> LeavingPlaceUserS { get; set; }
        public virtual IList<Passengers> BirthPlacePassengerS { get; set; }
    }
}
