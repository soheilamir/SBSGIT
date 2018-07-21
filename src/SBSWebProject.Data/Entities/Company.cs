using System;
using System.Text;
using System.Collections.Generic;

namespace SBSWebProject.Data.Entities
{
    public class Company : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UsersItem { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual string ContractNumber { get; set; }
        public virtual string Address { get; set; }
        public virtual string Tel { get; set; }
        public virtual string Fax { get; set; }
        public virtual DateTime? StartCooperation { get; set; }
        public virtual DateTime? EndCooperation { get; set; }
        public virtual DateTime? RegisterDate { get; set; }
        public virtual int? CreditDay { get; set; }
        public virtual long? CreditFee { get; set; }
        public virtual byte? DepositPercent { get; set; }
        public virtual bool? HasAttachment { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<CompanyAttachment> CompanyAttachmentS { get; set; }
        public virtual IList<CompanyEmployee> CompanyEmployeeS { get; set; }
        public virtual IList<CompanyServiceFee> CompanyServiceFeeS { get; set; }
        public virtual IList<Orders> OrdersS { get; set; }
    }
}
