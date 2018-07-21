using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Data.Entities
{

    public partial class Folders : Entity
    {
        //public virtual long Id { get; set; }
        public virtual Users UserItem { get; set; }
        public virtual Folders FolderItem { get; set; }
        public virtual string Name { get; set; }
        //public virtual short State { get; set; }
        //public virtual byte[] Version { get; set; }
        public virtual IList<Files> FileS { get; set; }
        public virtual IList<Folders> FoldersS { get; set; }
    }
}
