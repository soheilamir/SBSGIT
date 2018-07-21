using System;
using System.Text;
using System.Collections.Generic;

namespace SBSWebProject.Data.Entities
{
    public class CompanyAttachment : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Company CompanyItem { get; set; }
        public virtual Orders OrdersItem { get; set; }
        public virtual Files FilesItem { get; set; }
        public virtual bool? IsDefect { get; set; }
        public virtual string ReasonOfDefect { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
