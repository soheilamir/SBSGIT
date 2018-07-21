using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class FlightFreeServices : Entity
    {
        //public virtual long? Id { get; set; }
        public virtual FlightNumbers FlightNumberItem { get; set; }
        public virtual string ServiceName { get; set; }
        public virtual string ServiceDescription { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
