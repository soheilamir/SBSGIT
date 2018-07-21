using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class CountryNameByLanguage
    {
        public virtual long Id { get; set; }
        public virtual string LanguageName { get; set; }
        //public virtual Country CountryItem { get; set; }
        public virtual string ContryName { get; set; }
    }
}
