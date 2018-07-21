﻿using System.Linq;
using ResponseAirplaneTicket = SBSWebProject.Data.Entities.ResponseAirplaneTicket;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class ResponseAirplaneTicketMapper : IMappingObject<Web.Api.Models.ResponseAirplaneTicket, ResponseAirplaneTicket>
    {
        public ResponseAirplaneTicket Map(Web.Api.Models.ResponseAirplaneTicket objectToMap)
        {
            if (objectToMap == null) return null;
            var requestAirplaneTicketMapper = new RequestAirplaneTicketMapper();
            var flightNumbersMapper = new FlightNumbersMapper();
            var ticketNumberMapper = new TicketNumberMapper();
            var outputModel = new ResponseAirplaneTicket
            {
                Id = objectToMap.Id,
                RequestAirplaneTicketItem = requestAirplaneTicketMapper.Map(objectToMap.RequestAirplaneTicketItem),
                AdultPrice = objectToMap.AdultPrice,
                Availability = objectToMap.Availability,
                ChildPrice = objectToMap.ChildPrice,
                FlightNumbersItem = flightNumbersMapper.Map(objectToMap.FlightNumbersItem),
                InfantPrice = objectToMap.InfantPrice,
                IsReturning = objectToMap.IsReturning,
                IsSelect = objectToMap.IsSelect,
                SbsRecommend = objectToMap.SbsRecommend,
                TicketDate = objectToMap.TicketDate,
                TicketTime = objectToMap.TicketTime,
                //TicketNumberS = objectToMap.TicketNumberS.Select(item => ticketNumberMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
