using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Data
{
    public abstract class Entity
    {
        //public virtual long Id { protected set; get; }
        public virtual long Id { set; get; }
        public virtual int State { set; get; }
        public virtual byte[] Version { set; get; }
        //protected virtual byte[] Version { set; get; }
    }
}
