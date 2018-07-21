using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class NewUser
    {
        public virtual string FaName { get; set; }
        public virtual string FaFamily { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual IList<UserTels> UserTelsS { get; set; }
    }
}
