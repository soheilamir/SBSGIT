using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public class UserAddresses : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual string Address { get; set; }
        public virtual long? AddressType { get; set; }
        public virtual string PostalCode { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<UserTels> UserTelsS { get; set; }
    }
}
