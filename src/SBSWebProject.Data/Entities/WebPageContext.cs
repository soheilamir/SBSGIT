using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{
    public partial class WebPageContext : Entity
    {
        //public virtual long Id { get; set; }
        public virtual WebPages WebPagesItem { get; set; }
        public virtual string Context { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
    }
}
