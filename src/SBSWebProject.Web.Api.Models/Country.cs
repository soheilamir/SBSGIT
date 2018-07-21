using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class Country
    {
        public virtual long Id { get; set; }
        public virtual EarthRegion EarthRegionItem { get; set; }
        public virtual Continent ContinentItem { get; set; }
        public virtual string DialingCode { get; set; }
        public virtual string IsoCode { get; set; }
        public virtual string UnCode { get; set; }
        public virtual string UnNum { get; set; }
        public virtual string FlagUrl { get; set; }
        public virtual string CountryName { get; set; }
        //public virtual IList<Airlines> AirlinesS { get; set; }
        //public virtual IList<CountryIpAddresses> CountryIpAddressesS { get; set; }
        //public virtual IList<CountryNameByLanguage> CountryNameByLanguageS { get; set; }
        //public virtual IList<StateProvince> StateProvinceS { get; set; }
        //public virtual IList<UserLoginLog> UserLoginLogS { get; set; }
    }
}
