using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public partial class ReceivedResume : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual string Name { get; set; }
        public virtual string Family { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual Files AttachFileItem { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime? SubmitDate { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
