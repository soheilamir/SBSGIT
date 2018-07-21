using UserFavoriteAirlines = SBSWebProject.Data.Entities.UserFavoriteAirlines;

namespace SBSWebProject.MappingObject.ModelToEntity
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
    }
}
