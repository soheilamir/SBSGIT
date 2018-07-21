using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class UserEmails
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual string Email { get; set; }
    }
}
