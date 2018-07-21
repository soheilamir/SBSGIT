using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class AirlineMembers
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Passengers PassengersItem { get; set; }
        public virtual Airlines AirlinesItem { get; set; }
        public virtual string MembershipNumber { get; set; }
        public virtual DateTime? RegisteredDate { get; set; }
    }
}
