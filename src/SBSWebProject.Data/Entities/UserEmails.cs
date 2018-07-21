using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class UserEmails : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual string Email { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
