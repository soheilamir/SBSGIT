using System.Linq;
using ReceivedResume = SBSWebProject.Data.Entities.ReceivedResume;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class ReceivedResumeMapper : IMappingObject<Web.Api.Models.ReceivedResume, ReceivedResume>
    {
        public ReceivedResume Map(Web.Api.Models.ReceivedResume objectToMap)
        {
            if (objectToMap == null) return null;
            var usersMapper = new UsersMapper();
            var filesMapper = new FilesMapper();
            var outputModel = new ReceivedResume
            {
                Id = objectToMap.Id,
                Address = objectToMap.Address,
                Email = objectToMap.Email,
                AttachFileItem = filesMapper.Map(objectToMap.AttachFileItem),
                Family = objectToMap.Family,
                Message = objectToMap.Message,
                Name = objectToMap.Name,
                SubmitDate = objectToMap.SubmitDate,
                Tel = objectToMap.Tel,
                UsersItem = usersMapper.Map(objectToMap.UsersItem)
            };
            return outputModel;
        }
        public ReceivedResume Map(Web.Api.Models.ReceivedResume objectToMap, ReceivedResume refObj)
        {
            if (objectToMap == null) return null;
            var usersMapper = new UsersMapper();
            var filesMapper = new FilesMapper();
            refObj.Id = objectToMap.Id;
            refObj.Address = objectToMap.Address;
            refObj.Email = objectToMap.Email;
            refObj.AttachFileItem = filesMapper.Map(objectToMap.AttachFileItem);
            refObj.Family = objectToMap.Family;
            refObj.Message = objectToMap.Message;
            refObj.Name = objectToMap.Name;
            refObj.SubmitDate = objectToMap.SubmitDate;
            refObj.Tel = objectToMap.Tel;
            refObj.UsersItem = usersMapper.Map(objectToMap.UsersItem);
            return refObj;
        }
    }
}
