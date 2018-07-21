using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities {
    
    public class Sysdiagrams : IVersionedEntity {
        public virtual int DiagramId { get; set; }
        public virtual string Name { get; set; }
        public virtual int PrincipalId { get; set; }
        public virtual short State { get; set; }
        public virtual byte[] Version { get; set; }
        public virtual byte[] Definition { get; set; }
    }
}
