using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class UserCreditInfo : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
