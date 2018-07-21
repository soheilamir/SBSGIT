﻿using UserPassenger = SBSWebProject.Data.Entities.UserPassenger;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class UserPassengerMapper : IMappingObject<Web.Api.Models.UserPassenger, UserPassenger>
    {
        public UserPassenger Map(Web.Api.Models.UserPassenger objectToMap)
        {
            if (objectToMap == null) return null;
            var passengerMapper = new PassengerMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserPassenger
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                PassengersItem = passengerMapper.Map(objectToMap.PassengersItem)
            };
            return outputModel;
        }
        public UserPassenger Map(Web.Api.Models.UserPassenger objectToMap, UserPassenger refObj)
        {
            if (objectToMap == null) return null;
            var passengerMapper = new PassengerMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.UsersItem = usersMapper.Map(objectToMap.UsersItem);
            refObj.PassengersItem = passengerMapper.Map(objectToMap.PassengersItem);

            return refObj;
        }
    }
}
