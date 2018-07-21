using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class UserLanguages
    {
        public virtual long Id { get; set; }
        public virtual Languages LanguagesItem { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual short Proficiency { get; set; }
    }
}
