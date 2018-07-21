using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class AirportNameByLanguage
    {
        public virtual long Id { get; set; }
        public virtual Languages LanguagesItem { get; set; }
        public virtual Airports AirportsItem { get; set; }
        public virtual string AirportName { get; set; }
    }
}
