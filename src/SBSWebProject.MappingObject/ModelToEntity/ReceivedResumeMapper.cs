using System.Linq;
using ReceivedResume = SBSWebProject.Data.Entities.ReceivedResume;

namespace SBSWebProject.MappingObject.ModelToEntity
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
    }
}
