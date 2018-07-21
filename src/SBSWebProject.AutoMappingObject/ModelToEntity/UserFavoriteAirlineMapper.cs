using UserFavoriteAirlines = SBSWebProject.Data.Entities.UserFavoriteAirlines;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class UserFavoriteAirlineMapper : IMappingObject<Web.Api.Models.UserFavoriteAirlines, UserFavoriteAirlines>
    {
        public UserFavoriteAirlines Map(Web.Api.Models.UserFavoriteAirlines objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new UserFavoriteAirlines
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UsersItem),
                AirlinesItem = airlineMapper.Map(objectToMap.AirlinesItem),
                FromCityId = objectToMap.FromCityId,
                ToCityId = objectToMap.ToCityId
                //TODO 
            };
            return outputModel;
        }
        public UserFavoriteAirlines Map(Web.Api.Models.UserFavoriteAirlines objectToMap, UserFavoriteAirlines refObj)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.UsersItem = usersMapper.Map(objectToMap.UsersItem);
            refObj.AirlinesItem = airlineMapper.Map(objectToMap.AirlinesItem);
            refObj.FromCityId = objectToMap.FromCityId;
            refObj.ToCityId = objectToMap.ToCityId;
            //TODO 
            return refObj;
        }
    }
}
