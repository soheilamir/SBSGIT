using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class NewFlightCondition
    {
        public virtual long Id { get; set; }
        public virtual Airlines AirlinesItem { get; set; }
        public virtual ConditionType ConditionTypeItem { get; set; }
    }
}
