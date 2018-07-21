using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class StateProvince
    {
        public virtual long Id { get; set; }
        public virtual Country CountryItem { get; set; }
        public virtual byte? TelCode { get; set; }
        public virtual string CharCode { get; set; }
        public virtual int? Priority { get; set; }
        public virtual string StateProvinceName { get; set; }
        //public virtual IList<StateProvinceNameByLanguage> StateProvinceNameByLanguageS { get; set; }
    }
}
