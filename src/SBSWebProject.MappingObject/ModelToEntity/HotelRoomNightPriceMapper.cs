﻿using System;
using System.Linq;
using HotelRoomNightPrice = SBSWebProject.Data.Entities.HotelRoomNightPrice;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class HotelRoomNightPriceMapper : IMappingObject<Web.Api.Models.HotelRoomNightPrice, HotelRoomNightPrice>
    {
        public HotelRoomNightPrice Map(Web.Api.Models.HotelRoomNightPrice objectToMap)
        {
            if (objectToMap == null) return null;
            var hotelRoomMapper = new HotelRoomMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            DateController dc = new DateController();
            var outputModel = new HotelRoomNightPrice
            {
                Id = objectToMap.Id,
                Date = dc.ConvertJalai2Ger(objectToMap.Date),
                Description = objectToMap.Description,
                Price = objectToMap.Price,
                HotelRoomItem = hotelRoomMapper.Map(objectToMap.HotelRoomItem),
                IsActive = objectToMap.IsActive,
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
