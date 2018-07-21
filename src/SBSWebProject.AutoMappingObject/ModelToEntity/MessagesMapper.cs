using System.Linq;
using Messages = SBSWebProject.Data.Entities.Messages;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
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
        public Messages Map(Web.Api.Models.Messages objectToMap, Messages refObj)
        {
            if (objectToMap == null) return null;
            var sbsSectionMapper = new SbsSectionMapper();
            var sbsBranchesMapper = new SbsBranchesMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.Checked = objectToMap.Checked;
            refObj.Answer = objectToMap.Answer;
            refObj.ContactNumber = objectToMap.ContactNumber;
            refObj.SbsSectionsItem = sbsSectionMapper.Map(objectToMap.SbsSectionsItem);
            refObj.Email = objectToMap.Email;
            refObj.Family = objectToMap.Family;
            refObj.MessageText = objectToMap.MessageText;
            refObj.Name = objectToMap.Name;
            refObj.SbsBrancheItem = sbsBranchesMapper.Map(objectToMap.SbsBrancheItem);
            refObj.CheckedWithPersonnelItem = usersMapper.Map(objectToMap.CheckedWithPersonnelItem);
            refObj.SenderUserItem = usersMapper.Map(objectToMap.SenderUserItem);
            return refObj;
        }
    }
}
