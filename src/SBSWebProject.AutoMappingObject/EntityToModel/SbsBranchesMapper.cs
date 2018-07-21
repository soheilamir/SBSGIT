using System.Linq;
using SbsBranches = SBSWebProject.Web.Api.Models.SbsBranches;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class SbsBranchesMapper : IMappingObject<Data.Entities.SbsBranches, SbsBranches>
    {
        public SbsBranches Map(Data.Entities.SbsBranches objectToMap)
        {
            if (objectToMap == null) return null;
            var cityMapper = new CityMapper();
            var messagesMapper = new MessagesMapper();
            var sbsBranchAwardsMapper = new SbsBranchAwardsMapper();
            var sbsBranchImagesMapper = new SbsBranchImagesMapper();
            var sbsBranchTeamMapper = new SbsBranchTeamMapper();
            var outputModel = new SbsBranches
            {
                Id = objectToMap.Id,
                Address = objectToMap.Address,
                CityItem = cityMapper.Map(objectToMap.CityItem),
                Description = objectToMap.Description,
                Email = objectToMap.Email,
                Fax = objectToMap.Fax,
                //MessagesS = objectToMap.MessagesS.Where(c => c.State == 0).Select(item => messagesMapper.Map(item)).ToList(),
                //SbsBranchAwardsS = objectToMap.SbsBranchAwardsS.Where(c => c.State == 0).Select(item => sbsBranchAwardsMapper.Map(item)).ToList(),
                //SbsBranchImagesS = objectToMap.SbsBranchImagesS.Where(c => c.State == 0).Select(item => sbsBranchImagesMapper.Map(item)).ToList(),
                //SbsBranchTeamS = objectToMap.SbsBranchTeamS.Where(c => c.State == 0).Select(item => sbsBranchTeamMapper.Map(item)).ToList(),
                Tel = objectToMap.Tel,
                ZipCode = objectToMap.ZipCode
            };
            return outputModel;
        }
    }
}
