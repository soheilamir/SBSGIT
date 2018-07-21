using System.Linq;
using Users = SBSWebProject.Web.Api.Models.Users;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class UsersMapper : IMappingObject<Data.Entities.Users, Users>
    {
        public Users Map(Data.Entities.Users objectToMap)
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
                //SbsBranchTeamS = objectToMap.SbsBranchTeamS.Where(c => c.State == 0).Select(item => sbsBranchTeamMapper.Map(item)).ToList(),
                //RequestAirplaneServiceS = objectToMap.RequestAirplaneServiceS.Where(c => c.State == 0).Select(item => requestAirplaneServiceMapper.Map(item)).ToList(),
                //UserLoginLogS = objectToMap.UserLoginLogS.Where(c => c.State == 0).Select(item => userLoginLogMapper.Map(item)).ToList(),
                //UserPassengerS = objectToMap.UserPassengerS.Where(c => c.State == 0).Select(item => userPassengerMapper.Map(item)).ToList(),
                //UserLanguagesS = objectToMap.UserLanguagesS.Where(c => c.State == 0).Select(item => userLanguageMapper.Map(item)).ToList(),
                //AirlineMembersS = objectToMap.AirlineMembersS.Where(c => c.State == 0).Select(item => airlineMemberMapper.Map(item)).ToList(),
                //OrdersS = objectToMap.OrdersS.Where(c => c.State == 0).Select(item => ordersMapper.Map(item)).ToList(),
                //UserAddressesS = objectToMap.UserAddressesS.Where(c => c.State == 0).Select(item => userAddressMapper.Map(item)).ToList(),
                //UserAndPassengerDocumentsS = objectToMap.UserAndPassengerDocumentsS.Where(c => c.State == 0).Select(item => userAndPassengerDocumentMapper.Map(item)).ToList(),
                //UserCreditInfoS = objectToMap.UserCreditInfoS.Where(c => c.State == 0).Select(item => userCreditInfoMapper.Map(item)).ToList(),
                //UserEmailsS = objectToMap.UserEmailsS.Where(c => c.State == 0).Select(item => userEmailMapper.Map(item)).ToList(),
                //UserFavoriteAirlinesS = objectToMap.UserFavoriteAirlinesS.Where(c => c.State == 0).Select(item => userFavoriteAirlineMapper.Map(item)).ToList(),
                //UserTelsS = objectToMap.UserTelsS.Where(c => c.State == 0).Select(item => userTelMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
