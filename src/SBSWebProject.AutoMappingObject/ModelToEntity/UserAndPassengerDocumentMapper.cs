using UserAndPassengerDocuments = SBSWebProject.Data.Entities.UserAndPassengerDocuments;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class UserAndPassengerDocumentMapper : IMappingObject<Web.Api.Models.UserAndPassengerDocuments, UserAndPassengerDocuments>
    {
        public UserAndPassengerDocuments Map(Web.Api.Models.UserAndPassengerDocuments objectToMap)
        {
            if (objectToMap == null) return null;
            var passengerMapper = new PassengerMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserAndPassengerDocuments
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                PassengersItem = passengerMapper.Map(objectToMap.PassengersItem),
                RegisteredDate = objectToMap.RegisteredDate,
                DocumentTitle = objectToMap.DocumentTitle,
                DocumentUrl = objectToMap.DocumentTitle
            };
            return outputModel;
        }
        public UserAndPassengerDocuments Map(Web.Api.Models.UserAndPassengerDocuments objectToMap, UserAndPassengerDocuments refObj)
        {
            if (objectToMap == null) return null;
            var passengerMapper = new PassengerMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.UsersItem = usersMapper.Map(objectToMap.UsersItem);
            refObj.PassengersItem = passengerMapper.Map(objectToMap.PassengersItem);
            refObj.RegisteredDate = objectToMap.RegisteredDate;
            refObj.DocumentTitle = objectToMap.DocumentTitle;
            refObj.DocumentUrl = objectToMap.DocumentTitle;
            return refObj;
        }
    }
}
