using System;
using System.Collections.Generic;

namespace SBSWebProject.Data.Entities
{
    public class Tasks : Entity
    {
        private readonly IList<User> _users = new List<User>();
        public virtual long TaskId { get; set; }
        public virtual string Subject { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual DateTime? CompletedDate { get; set; }
        public virtual Status Status { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual IList<User> Users
        {
            get { return _users; }
        }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
