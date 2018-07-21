using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class ExcelReaderCountry
    {
        public virtual EarthRegion EarthRegionItem { get; set; }
        public virtual Continent ContinentItem { get; set; }
        public virtual string DialingCode { get; set; }
        public virtual string IsoCode { get; set; }
        public virtual string UnCode { get; set; }
        public virtual string UnNum { get; set; }
    }
}
