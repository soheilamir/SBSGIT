using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class CompanySection
    {
        public long Id { get; set; }
        public CompanySection CompanySectionItem { get; set; }
        public Company CompanyItem { get; set; }
        public string SectionName { get; set; }
        public IList<CompanyEmployee> CompanyEmployeeS { get; set; }
        public IList<CompanySection> CompanySectionS { get; set; }
    }
}
