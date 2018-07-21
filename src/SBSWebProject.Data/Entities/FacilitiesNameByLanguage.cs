using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{

    public partial class FacilitiesNameByLanguage : Entity
    {
        public virtual Languages LanguagesItem { get; set; }
        public virtual Facilities FacilitiesItem { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
    }
}
