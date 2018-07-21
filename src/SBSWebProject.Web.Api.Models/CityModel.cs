using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class CityModel
    {
        public long Id { set; get; }
        public string CityName { set; get; }
        public string OriginIATACODE { set; get; }
    }
}
