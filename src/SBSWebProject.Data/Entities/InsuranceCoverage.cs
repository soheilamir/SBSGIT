using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class InsuranceCoverage : Entity {
        public virtual InsuranceZone InsuranceZoneItem { get; set; }
        public virtual string CoverageCase { get; set; }
    }
}
