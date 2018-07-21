using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.SqlServer.NewDataHandler;

namespace SBSWebProject.Web.NewApi.Methods
{
    public class FmMethods
    {
        public bool IsValidFolderName(string newFolderName)
        {
            FoldersDataHandler foldersDataHandler = new FoldersDataHandler(WebApiApplication.SessionFactory);
            IList lst = foldersDataHandler.SelectAll().Cast<Folders>().Where(c => c.State == 0 && c.Name == newFolderName).ToList();
            if (lst.Count > 0)
                return false;
            else return true;
        }
        public bool FolderReadyToDelete(Folders selectedFolder)
        {
            if (selectedFolder.FileS.Where(c => c.State == 0).Count() > 0 || selectedFolder.FoldersS.Where(c => c.State == 0).Count() > 0)
                return false;
            else
                return true;
        }
    }
}