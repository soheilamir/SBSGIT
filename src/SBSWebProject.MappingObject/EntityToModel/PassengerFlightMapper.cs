using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using PassengerFlight = SBSWebProject.Web.Api.Models.PassengerFlight;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class PassengerFlightMapper : IMappingObject<Data.Entities.Passengers, PassengerFlight>
    {
        public PassengerFlight Map(Data.Entities.Passengers objectToMap)
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
            var outputModel = new PassengerFlight
            {
                Id = objectToMap.Id,
                BD = DC.ConvertGer2Jalai(Convert.ToDateTime(objectToMap.BirthDate)),
                LastName_En = objectToMap.InternationalFamily,
                LastName_Fa = objectToMap.NativeFamily,
                Name_En = objectToMap.InternationalName,
                Name_Fa = objectToMap.NativeName,
                NationalCode = objectToMap.NationalCode.ToString(),
                Tel = objectToMap.Tel

            };
            return outputModel;
        }
    }
}
