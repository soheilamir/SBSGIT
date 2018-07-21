using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSWebProject.Web.NewApi.Models
{
    public class FolrderItemsViewModel
    {
        public IList<FolderViewModel> folders { get; set; }
        public IList<FileViewModel> files { get; set; }
        public FolderViewModel selectedFolder { get; set; }
        public FolderViewModel clipboard { get; set; }
        public FolderViewModel upFolder { get; set; }
    }
}