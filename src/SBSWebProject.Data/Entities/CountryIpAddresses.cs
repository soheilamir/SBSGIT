using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class CountryIpAddresses : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Country CountryItem { get; set; }
        public virtual string FromIp { get; set; }
        public virtual string ToIp { get; set; }
        public virtual string Owner { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
