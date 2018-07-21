using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class ConditionType
    {
        public virtual long Id { get; set; }
        public virtual string TypeName { get; set; }
        public virtual IList<FlightCondition> FlightConditionS { get; set; }
    }
}
