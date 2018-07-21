using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class Airplane : Entity
    {
        //public virtual long Id { get; set; }
        public virtual string Company { get; set; }
        public virtual string Name { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<FlightNumbers> FlightNumberS { get; set; }
    }
}
