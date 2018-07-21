using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{

    public class AirlineMembers : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Passengers PassengersItem { get; set; }
        public virtual Airlines AirlinesItem { get; set; }
        public virtual string MembershipNumber { get; set; }
        public virtual DateTime? RegisteredDate { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
