using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using SBSWebProject.Web.NewApi.Extensions;
using SBSWebProject.Web.NewApi.Models;
using SBSWebProject.Web.NewApi.Methods;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.SqlServer.NewDataHandler;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SBSWebProject.Web.NewApi.Controllers
{
    public class FilesController : ApiController
    {
        private readonly string _workingFolder = HttpContext.Current.Server.MapPath(@"\Uploads");

        public async Task<IHttpActionResult> Get()
        {
            var photos = new List<PhotoViewModel>();

            var photoFolder = new DirectoryInfo(_workingFolder);

            await Task.Factory.StartNew(() =>
            {
                photos = photoFolder.EnumerateFiles()
                  .Where(fi => new[] { ".jpg", ".bmp", ".png", ".gif", ".tiff" }
                    .Contains(fi.Extension.ToLower()))
                  .Select(fi => new PhotoViewModel
                  {
                      Name = fi.Name,
                      Created = fi.CreationTime,
                      Modified = fi.LastWriteTime,
                      Size = fi.Length / 1024
                  })
                  .ToList();
            });

            return Ok(new { Photos = photos });
        }
        [Route("fileManager/DeleteFile")]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteFiles(Dictionary<string, IList<FileViewModel>> lstFiles)
        {
            FilesDataHandler filesDataHandler = new FilesDataHandler(WebApiApplication.SessionFactory);
            Dictionary<string, IList<FileViewModel>> dic = lstFiles;
            IList fileList = dic["lstFiles"].ToList();
            int deleteCnt = 0;
            foreach (FileViewModel item in fileList)
            {
                var fileName = Path.GetFileName(item.FileUrl);
                if (!FileExists(fileName))
                {
                    return NotFound();
                }

                try
                {
                    var filePath = Directory.GetFiles(_workingFolder, Path.GetFileName(item.FileUrl)).FirstOrDefault();

                    await Task.Factory.StartNew(() =>
                    {
                        if (filePath != null)
                        {
                            File.Delete(filePath);
                            filesDataHandler.Delete(filesDataHandler.GetEntity(item.Id));
                            deleteCnt++;
                        }
                    });

                }
                catch (Exception ex)
                {
                    var result = new PhotoActionResult
                    {
                        Successful = false,
                        Message = "error deleting fileName " + ex.GetBaseException().Message
                    };
                    return BadRequest(result.Message);
                }
            }
            var result1 = new PhotoActionResult
            {
                Successful = true,
                Message = deleteCnt + " File(s) " + "deleted successfully"
            };
            return Ok(new { result = result1 });

        }
        public async Task<IHttpActionResult> Add()
        {
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                return BadRequest("Unsupported media type");
            }
            try
            {
                var provider = new CustomMultipartFormDataStreamProvider(_workingFolder);

                await Request.Content.ReadAsMultipartAsync(provider);

                long id = Convert.ToInt64(HttpContext.Current.Request.Form["selectedFolderId"]);
                FilesDataHandler filesDataHandler = new FilesDataHandler(WebApiApplication.SessionFactory);
                ExtensionsDataHandler extensionsDataHandler = new ExtensionsDataHandler(WebApiApplication.SessionFactory);
                FoldersDataHandler foldersDataHandler = new FoldersDataHandler(WebApiApplication.SessionFactory);

                Folders folderItem = new Folders();
                if (id == 0)
                {
                    folderItem = null;
                }
                else
                {
                    folderItem = foldersDataHandler.GetEntity(id);
                }

                var obj =
                provider.FileData
                    .Select(file => new FileInfo(file.LocalFileName))
                    .Select(fileInfo => new Files
                    {
                        //ExtensionsItem = extensionsDataHandler.SelectAll().Cast<NetworkMagazineDTO.Domain.Extensions>().Where(c => c.Extension.Trim().ToLower() == fileInfo.Extension.Trim().ToLower()).ToList<NetworkMagazineDTO.Domain.Extensions>()[0],
                        FileName = fileInfo.Name,
                        FileSize = (fileInfo.Length / 1024).ToString(),
                        FoldersItem = folderItem,
                        FileUrl = "http://localhost:15609/Uploads/" + fileInfo.Name,
                        //FileUrl = "http://panel.irannetmag.com/Uploads/" + fileInfo.Name,
                        UploadeDate = DateTime.Now,
                    }).ToList();
                foreach (Files item in obj)
                {
                    filesDataHandler.Save(item);
                }


                var photos =
                  obj
                    .Select(fileInfo => new FileViewModel
                    {
                        //Extension = fileInfo.ExtensionsItem.Extension,
                        selected = false,
                        Id = fileInfo.Id,
                        FileName = fileInfo.FileName,
                        UploadeDate = fileInfo.UploadeDate,
                        FileSize = fileInfo.FileSize,
                        FileUrl = fileInfo.FileUrl
                    }).ToList();
                return Ok(new { Message = "Photos uploaded ok", Photos = photos });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException().Message);
            }
        }
        public bool FileExists(string fileName)
        {
            var file = Directory.GetFiles(_workingFolder, fileName)
              .FirstOrDefault();

            return file != null;
        }

        [Route("fileManager/AddFolders")]
        [HttpPost]
        public FolderViewModel AddFolders(JObject data)
        {
            FoldersDataHandler foldersDataHandler = new FoldersDataHandler(WebApiApplication.SessionFactory);
            FolderViewModel folder = data["folder"].ToObject<FolderViewModel>();
            FolderViewModel folderItem = data["folderItem"].ToObject<FolderViewModel>();
            FmMethods fmMethods = new FmMethods();
            var fldLst = new FolderViewModel();
            Folders obj = new Folders();
            Folders subFolderObj = new Folders();
            if (folderItem.Id > 0)
                subFolderObj = foldersDataHandler.GetEntity(folderItem.Id);
            else
                subFolderObj = null;
            if (fmMethods.IsValidFolderName(folder.Name))
            {
                obj.Name = folder.Name;
                //obj.CreateDate = DateTime.Now;
                obj.FolderItem = subFolderObj;
                foldersDataHandler.Save(obj);
                fldLst = new FolderViewModel
                {
                    Id = obj.Id,
                    Name = obj.Name,
                    //CreateDate = obj.CreateDate,
                    selected = false,
                };
            }
            return fldLst;
        }

        [Route("fileManager/GetFolderItems")]
        [HttpPost]
        public FolrderItemsViewModel GetFolderItems(FolderViewModel selectedFolder)
        {
            FoldersDataHandler foldersDataHandler = new FoldersDataHandler(WebApiApplication.SessionFactory);
            IList<FolderViewModel> lstfolder = new List<FolderViewModel>();
            IList<FileViewModel> lstfiles = new List<FileViewModel>();
            if (selectedFolder.Id > 0)
            {
                var obj = foldersDataHandler.GetEntity(selectedFolder.Id);

                foreach (Folders item in obj.FoldersS.Where(c => c.State == 0))
                {
                    FolderViewModel objFolderView = new FolderViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        //CreateDate = item.CreateDate,
                        selected = false,
                    };
                    lstfolder.Add(objFolderView);
                }

                foreach (Files item in obj.FileS.Where(c => c.State == 0))
                {
                    FileViewModel objFileView = new FileViewModel
                    {
                        //Extension = item.ExtensionsItem.Extension,
                        Id = item.Id,
                        FileName = item.FileName,
                        FileUrl = item.FileUrl,
                        FileSize = item.FileSize,
                        UploadeDate = item.UploadeDate,
                        selected = false,
                    };
                    lstfiles.Add(objFileView);
                }
                var upFolder = new FolderViewModel();
                if (obj.FolderItem == null)
                {
                    upFolder = new FolderViewModel
                    {
                        Id = 0,
                        CreateDate = DateTime.Now,
                        Name = "root",
                        selected = false,
                    };
                }
                else
                {
                    upFolder = new FolderViewModel
                    {
                        Id = obj.FolderItem.Id,
                        //CreateDate = obj.FolderItem.CreateDate,
                        Name = obj.FolderItem.Name,
                        selected = false,
                    };
                }
                FolrderItemsViewModel folderItem = new FolrderItemsViewModel
                {
                    folders = lstfolder,
                    files = lstfiles,
                    selectedFolder = new FolderViewModel(),
                    clipboard = new FolderViewModel(),
                    upFolder = upFolder,
                };
                return folderItem;
            }
            else
            {
                FilesDataHandler filesDataHandler = new FilesDataHandler(WebApiApplication.SessionFactory);
                IList LST = foldersDataHandler.SelectAll();
                var objfolders = foldersDataHandler.SelectAll().Cast<Folders>().Where(c => c.FolderItem == null).ToList();
                var objfiles = filesDataHandler.SelectAll().Cast<Files>().Where(c => c.FoldersItem == null).ToList();

                foreach (Folders item in objfolders)
                {
                    FolderViewModel objFolderView = new FolderViewModel
                    {
                        Id = item.Id,
                        Name = item.Name,
                        //CreateDate = item.CreateDate,
                        selected = false,
                    };
                    lstfolder.Add(objFolderView);
                }

                foreach (Files item in objfiles)
                {
                    FileViewModel objFileView = new FileViewModel
                    {
                        //Extension = item.ExtensionsItem.Extension,
                        Id = item.Id,
                        FileName = item.FileName,
                        FileUrl = item.FileUrl,
                        FileSize = item.FileSize,
                        UploadeDate = item.UploadeDate,
                        selected = false,
                    };
                    lstfiles.Add(objFileView);
                }

                FolrderItemsViewModel folderItem = new FolrderItemsViewModel
                {
                    folders = lstfolder,
                    files = lstfiles,
                    selectedFolder = new FolderViewModel(),
                    clipboard = new FolderViewModel(),
                    upFolder = new FolderViewModel
                    {
                        Id = 0,
                        CreateDate = DateTime.Now,
                        Name = "root",
                        selected = false,
                    },
                };
                return folderItem;
            }

        }

        [Route("fileManager/DeleteFolder")]
        [HttpPost]
        public bool DeleteFolder(FolderViewModel selectedFolder)
        {
            FoldersDataHandler foldersDataHandler = new FoldersDataHandler(WebApiApplication.SessionFactory);
            Folders obj = foldersDataHandler.GetEntity(selectedFolder.Id);
            FmMethods Methods = new FmMethods();
            if (Methods.FolderReadyToDelete(obj))
            {
                foldersDataHandler.Delete(obj);
                return true;
            }
            else
                return false;
        }

        
    }
}
