using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class UserLoginLog
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Country CountryItem { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual string LocationIp { get; set; }
    }
}
