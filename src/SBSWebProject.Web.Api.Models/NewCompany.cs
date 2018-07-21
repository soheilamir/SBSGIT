using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Web.Api.Models
{
    public class NewCompany
    {
        public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContractNumber { get; set; }
        public virtual string Address { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Fax { get; set; }
        public virtual DateTime? RegisterDate { get; set; }
    }
}
