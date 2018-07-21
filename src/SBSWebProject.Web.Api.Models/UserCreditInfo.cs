using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{
    public class UserCreditInfo
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
    }
}
