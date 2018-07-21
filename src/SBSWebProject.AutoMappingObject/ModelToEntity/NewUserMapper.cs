using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using Users = SBSWebProject.Data.Entities.Users;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class NewUserMapper : IMappingObject<Web.Api.Models.NewUser, Users>
    {
        public Users Map(NewUser objectToMap)
        {
            var userTelMapper = new UserTelMapper();
            if (objectToMap == null) return null;
            var outputModel = new Users
            {
                Username = objectToMap.Email,
                Email = objectToMap.Email,
                FaFamily = objectToMap.FaFamily,
                FaName = objectToMap.FaName,
                Password = objectToMap.Password.GetHashCode(),
                //UserTelsS = objectToMap.UserTelsS.Select(item => userTelMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public Users Map(NewUser objectToMap, Users refObj)
        {
            var userTelMapper = new UserTelMapper();
            if (objectToMap == null) return null;
            refObj.Username = objectToMap.Email;
            refObj.Email = objectToMap.Email;
            refObj.FaFamily = objectToMap.FaFamily;
            refObj.FaName = objectToMap.FaName;
            refObj.Password = objectToMap.Password.GetHashCode();
            //UserTelsS = objectToMap.UserTelsS.Select(item => userTelMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
