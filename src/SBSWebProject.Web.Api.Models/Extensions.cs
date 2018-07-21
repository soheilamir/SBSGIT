using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public class Extensions
    {
        public virtual long Id { get; set; }
        public virtual string Extension { get; set; }
        public virtual string Logo { get; set; }
        public virtual IList<Files> FileS { get; set; }
    }
}
