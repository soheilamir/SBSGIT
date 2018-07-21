using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public partial class CompanyOrdersConfirmation : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Orders OrdersItem { get; set; }
        public virtual CompanyEmployee CompanyEmployeeItem { get; set; }
        public virtual byte? ConfirmLevel { get; set; }
        public virtual bool? IsConfirm { get; set; }
        //public virtual byte? State { get; set; }
        //public virtual DateTime? Ts { get; set; }
    }
}
