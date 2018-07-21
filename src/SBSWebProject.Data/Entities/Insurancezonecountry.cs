using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class InsuranceZoneCountry : Entity {
        public virtual InsuranceZone InsuranceZoneItem { get; set; }
        public virtual Country CountryItem { get; set; }
    }
}
