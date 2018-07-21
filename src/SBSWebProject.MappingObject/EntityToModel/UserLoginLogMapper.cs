using UserLoginLog = SBSWebProject.Web.Api.Models.UserLoginLog;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class UserLoginLogMapper : IMappingObject<Data.Entities.UserLoginLog, UserLoginLog>
    {
        public UserLoginLog Map(Data.Entities.UserLoginLog objectToMap)
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
    }
}
