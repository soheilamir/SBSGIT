using UserFavoriteAirlines = SBSWebProject.Web.Api.Models.UserFavoriteAirlines;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class UserFavoriteAirlineMapper : IMappingObject<Data.Entities.UserFavoriteAirlines, UserFavoriteAirlines>
    {
        public UserFavoriteAirlines Map(Data.Entities.UserFavoriteAirlines objectToMap)
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
