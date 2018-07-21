using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class CompanyOrdersConfirmation
    {
        public virtual Orders OrdersItem { get; set; }
        public virtual CompanyEmployee CompanyEmployeeItem { get; set; }
        public virtual byte? ConfirmLevel { get; set; }
        public virtual bool? IsConfirm { get; set; }
    }
}
