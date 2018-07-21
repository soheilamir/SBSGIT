using System.Linq;
using Extensions = SBSWebProject.Data.Entities.Extensions;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class ExtensionsMapper : IMappingObject<Web.Api.Models.Extensions, Extensions>
    {
        public Extensions Map(Web.Api.Models.Extensions objectToMap)
        {
            if (objectToMap == null) return null;
            var filesMapper = new FilesMapper();
            var outputModel = new Extensions
            {
                Id = objectToMap.Id,
                Extension = objectToMap.Extension,
                Logo = objectToMap.Logo,
                //FileS = objectToMap.FileS.Select(item => filesMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
