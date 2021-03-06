﻿using UserTels = SBSWebProject.Data.Entities.UserTels;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class UserTelMapper : IMappingObject<Web.Api.Models.UserTels, UserTels>
    {
        public UserTels Map(Web.Api.Models.UserTels objectToMap)
        {
            if (objectToMap == null) return null;
            var userAddressMapper = new UserAddressMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserTels
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                TelNumber = objectToMap.TelNumber,
                TelType = objectToMap.TelType,
                UserAddressesItem = userAddressMapper.Map(objectToMap.UserAddressesItem)
            };
            return outputModel;
        }
        public UserTels Map(Web.Api.Models.UserTels objectToMap, UserTels refObj)
        {
            if (objectToMap == null) return null;
            var userAddressMapper = new UserAddressMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.UsersItem = usersMapper.Map(objectToMap.UsersItem);
            refObj.TelNumber = objectToMap.TelNumber;
            refObj.TelType = objectToMap.TelType;
            refObj.UserAddressesItem = userAddressMapper.Map(objectToMap.UserAddressesItem);
            return refObj;
        }
    }
}
