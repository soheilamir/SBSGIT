using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class AirlineClassPath : Entity
    {
        //public virtual long Id { get; set; }
        public virtual AirlineSubClasses AirlineSubClassesItem { get; set; }
        public virtual FlightPath FlightPathItem { get; set; }
        public virtual bool? IsActive { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<FlightCondition> FlightConditionS { get; set; }
        public virtual IList<FlightNumbers> FlightNumbersS { get; set; }
        public virtual IList<AirlineClassPathFee> AirlineClassPathFeeS { get; set; }
    }
}
