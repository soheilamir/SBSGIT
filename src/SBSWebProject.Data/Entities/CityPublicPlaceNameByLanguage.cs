using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class CityPublicPlaceNameByLanguage : Entity {
        public virtual Languages LanguagesItem { get; set; }
        public virtual CityPublicPlace CityPublicPlaceItem { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
