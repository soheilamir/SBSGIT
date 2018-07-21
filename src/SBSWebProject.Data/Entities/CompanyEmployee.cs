using System;
using System.Text;
using System.Collections.Generic;

namespace SBSWebProject.Data.Entities
{
    public class CompanyEmployee : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Company CompanyItem { get; set; }
        public virtual Users UserItem { get; set; }
        public virtual bool? IsManager { get; set; }
        public virtual CompanyEmployeePosition CompanyEmployeePositionItem { get; set; }
        public virtual bool? IsSeo { get; set; }
        public virtual DateTime? RequestDate { get; set; }
        public virtual bool? IsAcceptedUser { get; set; }
        public virtual DateTime? AcceptedUserDate { get; set; }

        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<CompanyOrdersConfirmation> CompanyOrdersConfirmationS { get; set; }
    }
}
