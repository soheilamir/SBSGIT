using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Data.Entities
{
    public class CompanyEmployeePosition : Entity
    {
        public virtual string PositionName { get; set; }
        public virtual IList<CompanyEmployee> CompanyEmployeeS { get; set; }
    }
}
