﻿using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{

    public class Extensions : Entity
    {
        //public virtual long Id { get; set; }
        public virtual string Extension { get; set; }
        public virtual string Logo { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<Files> FileS { get; set; }
    }
}
