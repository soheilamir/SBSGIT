using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SBSWebProject.Web.NewApi.Models
{
    public class FileViewModel
    {
        public long Id { get; set; }
        public string FileUrl { set; get; }
        public string FileName { set; get; }
        public DateTime? UploadeDate { get; set; }
        public string FileSize { set; get; }
        public string Extension { set; get; }
        public bool selected { get; set; }
    }
}