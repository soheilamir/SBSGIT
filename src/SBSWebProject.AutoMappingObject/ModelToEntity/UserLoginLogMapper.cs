using UserLoginLog = SBSWebProject.Data.Entities.UserLoginLog;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class UserLoginLogMapper : IMappingObject<Web.Api.Models.UserLoginLog, UserLoginLog>
    {
        public UserLoginLog Map(Web.Api.Models.UserLoginLog objectToMap)
        {
            if (objectToMap == null) return null;
            var countryMapper = new CountryMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserLoginLog
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                CountryItem = countryMapper.Map(objectToMap.CountryItem),
                Date = objectToMap.Date,
                LocationIp = objectToMap.LocationIp
            };
            return outputModel;
        }
        public UserLoginLog Map(Web.Api.Models.UserLoginLog objectToMap, UserLoginLog refObj)
        {
            if (objectToMap == null) return null;
            var countryMapper = new CountryMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.UsersItem = usersMapper.Map(objectToMap.UsersItem);
            refObj.CountryItem = countryMapper.Map(objectToMap.CountryItem);
            refObj.Date = objectToMap.Date;
            refObj.LocationIp = objectToMap.LocationIp;
            return refObj;
        }
    }
}
