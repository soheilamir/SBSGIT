using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using Passengers = SBSWebProject.Data.Entities.Passengers;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class PassengerFlightMapper : IMappingObject<Web.Api.Models.PassengerFlight, Passengers>
    {
        public Passengers Map(PassengerFlight objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMemberMapper = new AirlineMemberMapper();
            var cityMapper = new CityMapper();
            var requestAirplaneTicketPassengerMapper = new RequestAirplaneTicketPassengerMapper();
            var ticketNumberMapper = new TicketNumberMapper();
            var userAndPassengerDocumentMapper = new UserAndPassengerDocumentMapper();
            var userPassengerMapper = new UserPassengerMapper();
            var usersMapper = new UsersMapper();
            DateController DC = new DateController();
            var outputModel = new Passengers
            {
                Id = objectToMap.Id,
                BirthDate = DC.ConvertJalai2Ger(objectToMap.BD),
                InternationalFamily = objectToMap.LastName_En,
                InternationalName = objectToMap.Name_En,
                NativeName = objectToMap.Name_Fa,
                NativeFamily = objectToMap.LastName_Fa,
                NationalCode = Convert.ToInt64(objectToMap.NationalCode),
                Tel = objectToMap.Tel
            };
            return outputModel;
        }
        public Passengers Map(PassengerFlight objectToMap, Passengers refObj)
        {
            if (objectToMap == null) return null;
            var airlineMemberMapper = new AirlineMemberMapper();
            var cityMapper = new CityMapper();
            var requestAirplaneTicketPassengerMapper = new RequestAirplaneTicketPassengerMapper();
            var ticketNumberMapper = new TicketNumberMapper();
            var userAndPassengerDocumentMapper = new UserAndPassengerDocumentMapper();
            var userPassengerMapper = new UserPassengerMapper();
            var usersMapper = new UsersMapper();
            DateController DC = new DateController();
            refObj.Id = objectToMap.Id;
            refObj.BirthDate = DC.ConvertJalai2Ger(objectToMap.BD);
            refObj.InternationalFamily = objectToMap.LastName_En;
            refObj.InternationalName = objectToMap.Name_En;
            refObj.NativeName = objectToMap.Name_Fa;
            refObj.NativeFamily = objectToMap.LastName_Fa;
            refObj.NationalCode = Convert.ToInt64(objectToMap.NationalCode);
            refObj.Tel = objectToMap.Tel;
            return refObj;
        }
    }
}
