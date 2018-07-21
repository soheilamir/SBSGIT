using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class UserPassenger
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual Passengers PassengersItem { get; set; }
    }
}
