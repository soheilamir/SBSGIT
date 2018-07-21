using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAndPassengerDocuments = SBSWebProject.Web.Api.Models.UserAndPassengerDocuments;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class UserAndPassengerDocumentMapper : IMappingObject<Data.Entities.UserAndPassengerDocuments, UserAndPassengerDocuments>
    {
        public UserAndPassengerDocuments Map(Data.Entities.UserAndPassengerDocuments objectToMap)
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
    }
}
