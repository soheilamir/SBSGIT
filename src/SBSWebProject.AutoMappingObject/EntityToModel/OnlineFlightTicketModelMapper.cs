using System;
using System.Linq;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using OnlineFlightTicketModel = SBSWebProject.Web.Api.Models.OnlineFlightTicketModel;
using System.Collections.Generic;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class OnlineFlightTicketModelMapper : IMappingObject<Data.Entities.OnlineFlightTicket, OnlineFlightTicketModel>
    {
        public OnlineFlightTicketModel Map(Data.Entities.OnlineFlightTicket objectToMap)
        {
            if (objectToMap == null) return null;
            var airlineMapper = new AirlineMapper();
            DateController dc = new DateController();

            var cityMapper = new CityMapper();
            var passengerMapper = new PassengerMapper();
            var ordersMapper = new OrdersMapper();

            string flightClassTemp = objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).ToList()[0].AirlineClassPathFeeItem.AirlineClassPathItem.AirlineSubClassesItem.AirlineSubClassName;

            List<Data.Entities.OnlineFlightTicketPath> lstOnlineFlightTicketPath = objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).ToList();


            Data.Entities.FlightNumbers flightNumberTemp = objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).ToList()[0].AirlineClassPathFeeItem.AirlineClassPathItem.FlightNumbersS.Where(c => c.State == 0 && c.AirlineSubClassesItem.AirlineSubClassName == flightClassTemp).ToList()[0];
            var outputModel = new OnlineFlightTicketModel
            {
                RegistrarFullName = objectToMap.OrdersItem.UsersItem.FaName + " " + objectToMap.OrdersItem.UsersItem.FaFamily,
                AdultFee = objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).ToList()[0].AirlineClassPathFeeItem.AdultFee.ToString(),
                ChildFee = objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).ToList()[0].AirlineClassPathFeeItem.ChildFee.ToString(),
                InfantFee = objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).ToList()[0].AirlineClassPathFeeItem.InfantFee.ToString(),
                Airline = airlineMapper.Map(objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).ToList()[0].AirlineClassPathFeeItem.AirlineClassPathItem.AirlineSubClassesItem.AirlineClassesItem.AirlineItem),
                DepatringDate = dc.ConvertGer2Jalai(objectToMap.TicketDate),
                FlightClass = flightClassTemp,
                PNR = objectToMap.PNR,
                RegisterDate = dc.ConvertGer2Jalai(Convert.ToDateTime(objectToMap.OrdersItem.SubmitDateTime)),
                Source = cityMapper.Map(objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).ToList()[0].AirlineClassPathFeeItem.AirlineClassPathItem.FlightPathItem.SourceCityItem),
                Destination = cityMapper.Map(objectToMap.OnlineFlightTicketPathS.Where(c => c.State == 0).ToList()[0].AirlineClassPathFeeItem.AirlineClassPathItem.FlightPathItem.DestinationCityItem),


                FlightNumber = flightNumberTemp.FlightNumber.ToString(),
                AirplaneName = flightNumberTemp.AirplaneItem.Name,
                LandingTime = Convert.ToDateTime(flightNumberTemp.LandingTime).ToShortTimeString(),
                TakeOffTime = Convert.ToDateTime(flightNumberTemp.TakeOffTime).ToShortTimeString(),


                //PassengerS = objectToMap.OnlineFlightTicketPassengersS.Where(c => c.State == 0).Select(item => passengerMapper.Map(item.PassengersItem)).ToList(),
                PassengerS = objectToMap.OnlineFlightTicketPassengersS.Where(c => c.State == 0).Select(item => new SBSWebProject.Web.Api.Models.PassengerFlight
                {
                    Id = item.PassengersItem.Id,
                    Name_Fa = item.PassengersItem.NativeName,
                    LastName_Fa = item.PassengersItem.NativeFamily,
                    Name_En = item.PassengersItem.NativeName,
                    LastName_En = item.PassengersItem.InternationalFamily,
                    TicketNumber = item.TicketNumber,
                    BD = dc.ConvertGer2Jalai(Convert.ToDateTime(item.PassengersItem.BirthDate)),
                    NationalCode = item.PassengersItem.NationalCode.ToString(),
                    Tel = item.PassengersItem.Tel,
                }).ToList(),
            };
            return outputModel;
        }
    }
}
