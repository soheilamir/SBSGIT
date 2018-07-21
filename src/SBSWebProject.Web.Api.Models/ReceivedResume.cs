using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public partial class ReceivedResume
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual string Name { get; set; }
        public virtual string Family { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Email { get; set; }
        public virtual string Address { get; set; }
        public virtual Files AttachFileItem { get; set; }
        public virtual string Message { get; set; }
        public virtual DateTime? SubmitDate { get; set; }
    }
}
