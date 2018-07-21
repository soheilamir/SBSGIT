using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class CountryIpAddresses
    {
        public virtual long Id { get; set; }
        public virtual Country CountryItem { get; set; }
        public virtual string FromIp { get; set; }
        public virtual string ToIp { get; set; }
        public virtual string Owner { get; set; }
    }
}
