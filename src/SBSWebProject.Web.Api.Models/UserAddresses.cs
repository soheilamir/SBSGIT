using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class UserAddresses
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual string Address { get; set; }
        public virtual long? AddressType { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual IList<UserTels> UserTelsS { get; set; }
    }
}
