using System.Linq;
using HotelPhotos = SBSWebProject.Data.Entities.HotelPhotos;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class HotelPhotosMapper : IMappingObject<Web.Api.Models.HotelPhotos, HotelPhotos>
    {
        public HotelPhotos Map(Web.Api.Models.HotelPhotos objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var hotelsMapper = new HotelsMapper();
            var outputModel = new HotelPhotos
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                FileItem = filesMapper.Map(objectToMap.FileItem),
                HotelItem = hotelsMapper.Map(objectToMap.HotelItem),
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public HotelPhotos Map(Web.Api.Models.HotelPhotos objectToMap, HotelPhotos refObj)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var hotelsMapper = new HotelsMapper();
            refObj.Id = objectToMap.Id;
            refObj.Description = objectToMap.Description;
            refObj.FileItem = filesMapper.Map(objectToMap.FileItem);
            refObj.HotelItem = hotelsMapper.Map(objectToMap.HotelItem);
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
