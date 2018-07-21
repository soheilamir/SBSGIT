using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class CountryNameByLanguage : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Languages LanguagesItem { get; set; }
        public virtual Country CountryItem { get; set; }
        public virtual string ContryName { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
