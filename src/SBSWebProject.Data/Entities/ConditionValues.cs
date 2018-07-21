using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class ConditionValues : Entity
    {
        //public virtual long Id { get; set; }
        public virtual FlightCondition FlightConditionItem { get; set; }
        public virtual string ConditionKey { get; set; }
        public virtual string ConditionValue { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
