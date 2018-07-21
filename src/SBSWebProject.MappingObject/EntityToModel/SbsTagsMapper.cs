using System.Linq;
using SbsTags = SBSWebProject.Web.Api.Models.SbsTags;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class SbsTagsMapper : IMappingObject<Data.Entities.SbsTags, SbsTags>
    {
        public SbsTags Map(Data.Entities.SbsTags objectToMap)
        {
            if (objectToMap == null) return null;
            var newsTagsMapper = new NewsTagsMapper();
            var outputModel = new SbsTags
            {
                Id = objectToMap.Id,
                //NewsTagsS = objectToMap.NewsTagsS.Where(c => c.State == 0).Select(item => newsTagsMapper.Map(item)).ToList(),
                Title = objectToMap.Title,
            };
            return outputModel;
        }
    }
}
