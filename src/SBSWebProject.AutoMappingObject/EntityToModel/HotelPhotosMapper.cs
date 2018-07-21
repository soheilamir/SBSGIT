using System;
using System.Collections.Generic;
using System.Linq;
using HotelPhotos = SBSWebProject.Web.Api.Models.HotelPhotos;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class HotelPhotosMapper : IMappingObject<Data.Entities.HotelPhotos, HotelPhotos>
    {
        public HotelPhotos Map(Data.Entities.HotelPhotos objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelPhotos
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                FileItem = filesMapper.Map(objectToMap.FileItem),
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
