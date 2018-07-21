using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class CityNameByLanguage
    {
        public virtual long Id { get; set; }
        public virtual Languages LanguagesItem { get; set; }
        public virtual City CityItem { get; set; }
        public virtual string Name { get; set; }
    }
}
