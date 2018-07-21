﻿using System.Linq;
using HotelAccessibility = SBSWebProject.Data.Entities.HotelAccessibility;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class HotelAccessibilityMapper : IMappingObject<Web.Api.Models.HotelAccessibility, HotelAccessibility>
    {
        public HotelAccessibility Map(Web.Api.Models.HotelAccessibility objectToMap)
        {
            if (objectToMap == null) return null;
            var cityPublicPlaceMapper = new CityPublicPlaceMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelAccessibility
            {
                Id = objectToMap.Id,
                CityPublicPlaceItem = cityPublicPlaceMapper.Map(objectToMap.CityPublicPlaceItem),
                Distance = objectToMap.Distance,
                //HotelsItem
                TimeWithCar = objectToMap.TimeWithCar,
                TimeWithWalk = objectToMap.TimeWithWalk,
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
