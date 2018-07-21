using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class UserTels
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual UserAddresses UserAddressesItem { get; set; }
        public virtual string TelNumber { get; set; }
        public virtual long? TelType { get; set; }
    }
}
