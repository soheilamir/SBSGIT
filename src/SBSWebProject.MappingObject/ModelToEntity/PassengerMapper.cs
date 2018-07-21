﻿using System.Linq;
using Passengers = SBSWebProject.Data.Entities.Passengers;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class PassengerMapper : IMappingObject<Web.Api.Models.Passengers, Passengers>
    {
        public Passengers Map(Web.Api.Models.Passengers objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMemberMapper = new AirlineMemberMapper();
            var cityMapper = new CityMapper();
            var requestAirplaneTicketPassengerMapper = new RequestAirplaneTicketPassengerMapper();
            var ticketNumberMapper = new TicketNumberMapper();
            var userAndPassengerDocumentMapper = new UserAndPassengerDocumentMapper();
            var userPassengerMapper = new UserPassengerMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new Passengers
            {
                Id = objectToMap.Id,
                BirthPalaceCityItem = cityMapper.Map(objectToMap.BirthPalaceCityItem),
                PassportNumber = objectToMap.PassportNumber,
                Mobile = objectToMap.Mobile,
                BirthDate = objectToMap.BirthDate,
                Tel = objectToMap.Tel,
                NationalCode = objectToMap.NationalCode,
                IdNumber = objectToMap.IdNumber,
                Accepted = objectToMap.Accepted,
                AdultType = objectToMap.AdultType,
                Gender = objectToMap.Gender,
                InternationalFamily = objectToMap.InternationalFamily,
                InternationalFatherName = objectToMap.InternationalFatherName,
                InternationalName = objectToMap.InternationalName,
                NativeFamily = objectToMap.NativeFamily,
                NativeFatherName = objectToMap.NativeFatherName,
                NativeName = objectToMap.NativeName,
                Title = objectToMap.Title,
                OwnerUserItem = usersMapper.Map(objectToMap.OwnerUserItem),
                //AirlineMembersS = objectToMap.AirlineMembersS.Select(item => airlineMemberMapper.Map(item)).ToList(),
                //RequestAirplaneTicketPassengerS = objectToMap.RequestAirplaneTicketPassengerS.Select(item => requestAirplaneTicketPassengerMapper.Map(item)).ToList(),
                //TicketNumbersS = objectToMap.TicketNumbersS.Select(item => ticketNumberMapper.Map(item)).ToList(),
                //UserAndPassengerDocumentsS = objectToMap.UserAndPassengerDocumentsS.Select(item => userAndPassengerDocumentMapper.Map(item)).ToList(),
                //UserPassengerS = objectToMap.UserPassengerS.Select(item => userPassengerMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
