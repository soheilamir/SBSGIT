using System.Linq;
using Users = SBSWebProject.Data.Entities.Users;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class UsersMapper : IMappingObject<Web.Api.Models.Users, Users>
    {
        public Users Map(Web.Api.Models.Users objectToMap)
        {
            if (objectToMap == null) return null;
            var cityMapping = new CityMapper();
            var sbsBranchTeamMapper = new SbsBranchTeamMapper();
            var requestAirplaneServiceMapper = new RequestAirplaneServiceMapper();
            var userLoginLogMapper = new UserLoginLogMapper();
            var userPassengerMapper = new UserPassengerMapper();
            var userLanguageMapper = new UserLanguageMapper();
            var airlineMemberMapper = new AirlineMemberMapper();
            var ordersMapper = new OrdersMapper();
            var userAddressMapper = new UserAddressMapper();
            var userAndPassengerDocumentMapper = new UserAndPassengerDocumentMapper();
            var userCreditInfoMapper = new UserCreditInfoMapper();
            var userEmailMapper = new UserEmailMapper();
            var userFavoriteAirlineMapper = new UserFavoriteAirlineMapper();
            var userTelMapper = new UserTelMapper();
            var outputModel = new Users
            {
                Id = objectToMap.Id,
                ActivityStatusId = objectToMap.ActivityStatusId,
                BirthDate = objectToMap.BirthDate,
                BirthPalaceCityItem = cityMapping.Map(objectToMap.BirthPalaceCityItem),
                LivingCityItem = cityMapping.Map(objectToMap.LivingCityItem),
                Email = objectToMap.Email,
                EnFamily = objectToMap.EnFamily,
                EnName = objectToMap.EnName,
                FaFamily = objectToMap.FaFamily,
                FaName = objectToMap.FaName,
                FatherName = objectToMap.FatherName,
                IdNumber = objectToMap.IdNumber,
                IsMain = objectToMap.IsMain,
                Mobile = objectToMap.Mobile,
                NationalCode = objectToMap.NationalCode,
                PassportNumber = objectToMap.PassportNumber,
                Sex = objectToMap.Sex,
                Tel = objectToMap.Tel,
                Username = objectToMap.Username,
                InfoStatusId = objectToMap.InfoStatusId,//TODO
                NationalityCountryId = objectToMap.NationalityCountryId,
                PassengerId = objectToMap.PassengerId,//TODO
                //SbsBranchTeamS = objectToMap.SbsBranchTeamS.Select(item => sbsBranchTeamMapper.Map(item)).ToList(),
                //RequestAirplaneServiceS = objectToMap.RequestAirplaneServiceS.Select(item => requestAirplaneServiceMapper.Map(item)).ToList(),
                //UserLoginLogS = objectToMap.UserLoginLogS.Select(item => userLoginLogMapper.Map(item)).ToList(),
                //UserPassengerS = objectToMap.UserPassengerS.Select(item => userPassengerMapper.Map(item)).ToList(),
                //UserLanguagesS = objectToMap.UserLanguagesS.Select(item => userLanguageMapper.Map(item)).ToList(),
                //AirlineMembersS = objectToMap.AirlineMembersS.Select(item => airlineMemberMapper.Map(item)).ToList(),
                //OrdersS = objectToMap.OrdersS.Select(item => ordersMapper.Map(item)).ToList(),
                //UserAddressesS = objectToMap.UserAddressesS.Select(item => userAddressMapper.Map(item)).ToList(),
                //UserAndPassengerDocumentsS = objectToMap.UserAndPassengerDocumentsS.Select(item => userAndPassengerDocumentMapper.Map(item)).ToList(),
                //UserCreditInfoS = objectToMap.UserCreditInfoS.Select(item => userCreditInfoMapper.Map(item)).ToList(),
                //UserEmailsS = objectToMap.UserEmailsS.Select(item => userEmailMapper.Map(item)).ToList(),
                //UserFavoriteAirlinesS = objectToMap.UserFavoriteAirlinesS.Select(item => userFavoriteAirlineMapper.Map(item)).ToList(),
                //UserTelsS = objectToMap.UserTelsS.Select(item => userTelMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
