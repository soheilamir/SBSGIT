using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class StateProvinceNameByLanguage
    {
        public virtual long Id { get; set; }
        public virtual StateProvince StateProvinceItem { get; set; }
        public virtual Languages LanguagesItem { get; set; }
        public virtual string StateProvinceName { get; set; }
    }
}
