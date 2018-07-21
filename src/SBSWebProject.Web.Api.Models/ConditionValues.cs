using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class ConditionValues
    {
        public virtual long Id { get; set; }
        public virtual FlightCondition FlightConditionItem { get; set; }
        public virtual string ConditionKey { get; set; }
        public virtual string ConditionValue { get; set; }
    }
}
