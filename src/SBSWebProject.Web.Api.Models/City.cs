using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class City
    {
        public virtual long Id { get; set; }
        public string CityName { set; get; }
        //public string OriginIATACODE { set; get; }
        //public virtual StateProvince StateProvinceItem { get; set; }
        //public virtual long? ProvinceId { get; set; }
        //public virtual string TelCode { get; set; }
        public virtual string CharCode { get; set; }
        //public virtual bool? IsCapital { get; set; }
        //public virtual int? Priority { get; set; }
        //public virtual string CityMapFile { get; set; }
        //public virtual string CityName { get; set; }

        //public virtual IList<Airports> AirportsS { get; set; }
        //public virtual IList<CityNameByLanguage> CityNameByLanguageS { get; set; }
        //public virtual IList<FlightPath> SourceCityFlightPathS { get; set; }
        //public virtual IList<FlightPath> DestinationCityFlightPathS { get; set; }
        //public virtual IList<FlightStopOver> FlightStopOverS { get; set; }
        //public virtual IList<RequestAirplaneTicket> RequestSourceAirplaneTicketS { get; set; }
        //public virtual IList<RequestAirplaneTicket> RequestDestinationAirplaneTicketS { get; set; }
        //public virtual IList<SbsBranches> Sbsbranches { get; set; }
        //public virtual IList<Users> BirthPlaceUserS { get; set; }
        //public virtual IList<Users> LeavingPlaceUserS { get; set; }
        //public virtual IList<Passengers> BirthPlacePassengerS { get; set; }
    }
}
