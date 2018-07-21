using System;
using System.Text;
using System.Collections.Generic;


namespace SBSWebProject.Web.Api.Models
{

    public partial class Folders 
    {
        public virtual long Id { get; set; }
        public virtual Users UserItem { get; set; }
        public virtual Folders FolderItem { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Files> FileS { get; set; }
        public virtual IList<Folders> FoldersS { get; set; }
    }
}
