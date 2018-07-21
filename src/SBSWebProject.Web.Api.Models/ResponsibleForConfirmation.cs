using System;
using System.Text;
using System.Collections.Generic;

namespace SBSWebProject.Web.Api.Models
{
    public class ResponsibleForConfirmation
    {
        public virtual long Id { get; set; }
        public virtual CompanyEmployee CompanyEmployeeItem { get; set; }
        public virtual CompanyEmployee AlternativeEmployeeItem { get; set; }
        public virtual short ConfirmationLevel { get; set; }
    }
}
