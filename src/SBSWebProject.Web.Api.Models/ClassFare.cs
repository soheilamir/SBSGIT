using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class ClassFare
    {
        public string FlightClass { set; get; }
        public string AdultFare { set; get; }
        public string ChildFare { set; get; }
        public string InfantFare { set; get; }
        public long AirlineClassPathFeeId { set; get; }
        public bool selected { set; get; }
    }
}
