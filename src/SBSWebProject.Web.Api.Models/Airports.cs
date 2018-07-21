using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class Airports
    {
        public virtual long Id { get; set; }
        public virtual City CityItem { get; set; }
        public virtual string Address { get; set; }
        public virtual IList<AirportNameByLanguage> AirportNamebyLanguageS { get; set; }
    }
}
