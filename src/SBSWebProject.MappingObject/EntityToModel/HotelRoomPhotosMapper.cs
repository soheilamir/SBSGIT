using System.Linq;
using HotelRoomPhotos = SBSWebProject.Web.Api.Models.HotelRoomPhotos;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class HotelRoomPhotosMapper : IMappingObject<Data.Entities.HotelRoomPhotos, HotelRoomPhotos>
    {
        public HotelRoomPhotos Map(Data.Entities.HotelRoomPhotos objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var airlineSubClassesMapper = new AirlineSubClassesMapper();
            var outputModel = new HotelRoomPhotos
            {
                Id = objectToMap.Id,
                Descriptopn = objectToMap.Descriptopn,
                FileItem = filesMapper.Map(objectToMap.FileItem),
                //AirlineSubClassesS = (objectToMap.AirlineSubClassesS != null) ? objectToMap.AirlineSubClassesS.Where(c => c.State == 0).Select(item => airlineSubClassesMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
