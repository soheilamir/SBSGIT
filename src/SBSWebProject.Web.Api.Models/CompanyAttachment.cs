using System;
using System.Text;
using System.Collections.Generic;

namespace SBSWebProject.Web.Api.Models
{
    public class CompanyAttachment
    {
        public virtual long Id { get; set; }
        public virtual Company CompanyItem { get; set; }
        public virtual Orders OrdersItem { get; set; }
        public virtual Files FilesItem { get; set; }
        public virtual bool? IsDefect { get; set; }
        public virtual string ReasonOfDefect { get; set; }

    }
}
