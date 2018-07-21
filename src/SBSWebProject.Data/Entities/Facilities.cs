using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class Facilities : Entity {
        public virtual FacilitiesCategory FacilitiesCategoryItem { get; set; }
        public virtual IList<FacilitiesNameByLanguage> FacilitiesNameByLanguageS { get; set; }
    }
}
