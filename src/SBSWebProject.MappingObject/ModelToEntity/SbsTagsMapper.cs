using System.Linq;
using SbsTags = SBSWebProject.Data.Entities.SbsTags;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class SbsTagsMapper : IMappingObject<Web.Api.Models.SbsTags, SbsTags>
    {
        public SbsTags Map(Web.Api.Models.SbsTags objectToMap)
        {
            if (objectToMap == null) return null;
            var newsTagsMapper = new NewsTagsMapper();
            var outputModel = new SbsTags
            {
                Id = objectToMap.Id,
                //NewsTagsS = objectToMap.NewsTagsS.Select(item => newsTagsMapper.Map(item)).ToList(),
                Title = objectToMap.Title,
            };
            return outputModel;
        }
    }
}
