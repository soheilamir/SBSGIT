using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class FlightCondition
    {
        public virtual long Id { get; set; }
        public virtual Airlines AirlinesItem { get; set; }
        //public virtual FlightNumbers FlightNumberItem { get; set; }
        public virtual ConditionType ConditionTypeItem { get; set; }
        public virtual IList<ConditionValues> ConditionValuesS { get; set; }
    }
}
