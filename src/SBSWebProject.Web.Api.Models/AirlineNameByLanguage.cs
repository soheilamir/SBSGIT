using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class AirlineNameByLanguage {
        public virtual long Id { get; set; }
        public virtual Languages LanguagesItem { get; set; }
        public virtual Airlines AirlinesItem { get; set; }
        public virtual string AirlineName { get; set; }
    }
}
