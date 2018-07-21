using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class EarthRegion
    {
        public virtual long Id { get; set; }
        public virtual string EarthRegionName { get; set; }
        public virtual IList<Country> CountryS { get; set; }
    }
}
