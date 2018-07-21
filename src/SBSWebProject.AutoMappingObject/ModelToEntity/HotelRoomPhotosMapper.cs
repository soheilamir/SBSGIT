using System.Linq;
using HotelRoomPhotos = SBSWebProject.Data.Entities.HotelRoomPhotos;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class HotelRoomPhotosMapper : IMappingObject<Web.Api.Models.HotelRoomPhotos, HotelRoomPhotos>
    {
        public HotelRoomPhotos Map(Web.Api.Models.HotelRoomPhotos objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var hotelRoomMapper = new HotelRoomMapper();
            var outputModel = new HotelRoomPhotos
            {
                Id = objectToMap.Id,
                Descriptopn = objectToMap.Descriptopn,
                FileItem = filesMapper.Map(objectToMap.FileItem),
                HotelRoomItem = hotelRoomMapper.Map(objectToMap.HotelRoomItem),
                //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public HotelRoomPhotos Map(Web.Api.Models.HotelRoomPhotos objectToMap, HotelRoomPhotos refObj)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var hotelRoomMapper = new HotelRoomMapper();
            refObj.Id = objectToMap.Id;
            refObj.Descriptopn = objectToMap.Descriptopn;
            refObj.FileItem = filesMapper.Map(objectToMap.FileItem);
            refObj.HotelRoomItem = hotelRoomMapper.Map(objectToMap.HotelRoomItem);
            //AirlineSubClassesS = objectToMap.AirlineSubClassesS.Select(item=> airlineSubClassesMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
