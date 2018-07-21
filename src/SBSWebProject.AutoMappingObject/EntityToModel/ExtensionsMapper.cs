using System.Linq;
using Extensions = SBSWebProject.Web.Api.Models.Extensions;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class ExtensionsMapper : IMappingObject<Data.Entities.Extensions, Extensions>
    {
        public Extensions Map(Data.Entities.Extensions objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var outputModel = new Extensions
            {
                Id = objectToMap.Id,
                Extension = objectToMap.Extension,
                Logo = objectToMap.Logo,
               // FileS = objectToMap.FileS.Where(c => c.State == 0).Select(item => filesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
