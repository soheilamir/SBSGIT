using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class Facilities
    {
        public long Id { get; set; }
        public string FacilitiesPersianName { get; set; }
        public FacilitiesCategory FacilitiesCategoryItem { get; set; }
        public IList<FacilitiesNameByLanguage> FacilitiesNameByLanguageS { get; set; }
    }
}
