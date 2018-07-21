using System.Linq;
using Messages = SBSWebProject.Data.Entities.Messages;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class MessagesMapper : IMappingObject<Web.Api.Models.Messages, Messages>
    {
        public Messages Map(Web.Api.Models.Messages objectToMap)
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
