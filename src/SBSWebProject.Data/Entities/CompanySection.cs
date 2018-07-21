using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class CompanySection : Entity {
        public virtual CompanySection CompanySectionItem { get; set; }
        public virtual Company CompanyItem { get; set; }
        public virtual string SectionName { get; set; }
        public virtual IList<CompanyEmployee> CompanyEmployeeS { get; set; }
        public virtual IList<CompanySection> CompanySectionS { get; set; }
    }
}
