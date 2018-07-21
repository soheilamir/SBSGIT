using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class UserLoginLog : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Country CountryItem { get; set; }
        public virtual DateTime? Date { get; set; }
        public virtual string LocationIp { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
