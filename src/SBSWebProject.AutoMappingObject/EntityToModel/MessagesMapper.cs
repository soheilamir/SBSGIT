using System.Linq;
using Messages = SBSWebProject.Web.Api.Models.Messages;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class MessagesMapper : IMappingObject<Data.Entities.Messages, Messages>
    {
        public Messages Map(Data.Entities.Messages objectToMap)
        {
            if (objectToMap == null) return null;
            var sbsSectionMapper = new SbsSectionMapper();
            var sbsBranchesMapper = new SbsBranchesMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new Messages
            {
                Id = objectToMap.Id,
                Checked = objectToMap.Checked,
                Answer = objectToMap.Answer,
                ContactNumber = objectToMap.ContactNumber,
                SbsSectionsItem = sbsSectionMapper.Map(objectToMap.SbsSectionsItem),
                Email = objectToMap.Email,
                Family = objectToMap.Family,
                MessageText = objectToMap.MessageText,
                Name = objectToMap.Name,
                SbsBrancheItem = sbsBranchesMapper.Map(objectToMap.SbsBrancheItem),
                CheckedWithPersonnelItem = usersMapper.Map(objectToMap.CheckedWithPersonnelItem),
                SenderUserItem = usersMapper.Map(objectToMap.SenderUserItem)
            };
            return outputModel;
        }
    }
}
