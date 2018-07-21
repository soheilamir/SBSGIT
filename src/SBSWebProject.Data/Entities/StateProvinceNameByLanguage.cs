using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class StateProvinceNameByLanguage : Entity
    {
        //public virtual long Id { get; set; }
        public virtual StateProvince StateProvinceItem { get; set; }
        public virtual Languages LanguagesItem { get; set; }
        public virtual string StateProvinceName { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
