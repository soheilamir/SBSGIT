using System.Linq;
using Folders = SBSWebProject.Web.Api.Models.Folders;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class FoldersMapper : IMappingObject<Data.Entities.Folders, Folders>
    {
        public Folders Map(Data.Entities.Folders objectToMap)
        {
            if (objectToMap == null) return null;
            var foldersMapper = new FoldersMapper();
            var filesMapper = new FilesMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new Folders
            {
                Id = objectToMap.Id,
                FolderItem = foldersMapper.Map(objectToMap.FolderItem),
                Name= objectToMap.Name,
                UserItem= usersMapper.Map(objectToMap.UserItem),
                //FileS = objectToMap.FileS.Where(c => c.State == 0).Select(item => filesMapper.Map(item)).ToList(),
                //FoldersS = objectToMap.FoldersS.Where(c => c.State == 0).Select(item => foldersMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
