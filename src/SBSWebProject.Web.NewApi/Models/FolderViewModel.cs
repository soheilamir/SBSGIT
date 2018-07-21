using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSWebProject.Web.NewApi.Models
{
    public class FolderViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool selected { get; set; }
    }
}