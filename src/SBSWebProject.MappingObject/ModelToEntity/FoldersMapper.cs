using System.Linq;
using Folders = SBSWebProject.Data.Entities.Folders;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class FoldersMapper : IMappingObject<Web.Api.Models.Folders, Folders>
    {
        public Folders Map(Web.Api.Models.Folders objectToMap)
        {
            if (objectToMap == null) return null;
            var foldersMapper = new FoldersMapper();
            var filesMapper = new FilesMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new Folders
            {
                Id = objectToMap.Id,
                FolderItem = foldersMapper.Map(objectToMap.FolderItem),
                Name = objectToMap.Name,
                UserItem = usersMapper.Map(objectToMap.UserItem),
                //FileS = objectToMap.FileS.Select(item => filesMapper.Map(item)).ToList(),
                //FoldersS = objectToMap.FoldersS.Select(item => foldersMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
