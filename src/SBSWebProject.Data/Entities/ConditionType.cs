using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class ConditionType : Entity
    {
        //public virtual long Id { get; set; }
        public virtual string TypeName { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<FlightCondition> FlightConditionS { get; set; }
    }
}
