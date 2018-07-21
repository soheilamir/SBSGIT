using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class FacilitiesNameByLanguage
    {
        public long Id { get; set; }
        public Languages LanguagesItem { get; set; }
        public Facilities FacilitiesItem { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
