using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class FlightCondition : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Airlines AirlinesItem { get; set; }
        //public virtual FlightNumbers FlightNumberItem { get; set; }
        public virtual ConditionType ConditionTypeItem { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<ConditionValues> ConditionValuesS { get; set; }
    }
}
