using System;
using System.Text;
using System.Collections.Generic;

namespace SBSWebProject.Web.Api.Models
{
    public class CompanyEmployee
    {
        public virtual long Id { get; set; }
        public virtual Company CompanyItem { get; set; }
        public virtual Users UserItem { get; set; }
        public virtual bool? IsManager { get; set; }
        public virtual string Position { get; set; }
        public virtual bool? IsSeo { get; set; }

        public virtual IList<CompanyOrdersConfirmation> CompanyOrdersConfirmationS { get; set; }
        public virtual IList<ResponsibleForConfirmation> ResponsibleForConfirmationS { get; set; }
        public virtual IList<ResponsibleForConfirmation> AlternativeResponsibleForConfirmationS { get; set; }
    }
}
