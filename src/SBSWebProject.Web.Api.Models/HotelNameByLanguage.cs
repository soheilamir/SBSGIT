using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class HotelNameByLanguage
    {
        public long Id { get; set; }
        public Languages LanguagesItem { get; set; }
        public Hotels HotelItem { get; set; }
        public string Name { get; set; }
    }
}
