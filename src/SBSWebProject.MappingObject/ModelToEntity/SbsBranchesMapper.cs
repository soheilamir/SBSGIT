using System.Linq;
using SbsBranches = SBSWebProject.Data.Entities.SbsBranches;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class SbsBranchesMapper : IMappingObject<Web.Api.Models.SbsBranches, SbsBranches>
    {
        public SbsBranches Map(Web.Api.Models.SbsBranches objectToMap)
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
                //MessagesS = objectToMap.MessagesS.Select(item => messagesMapper.Map(item)).ToList(),
                //SbsBranchAwardsS = objectToMap.SbsBranchAwardsS.Select(item => sbsBranchAwardsMapper.Map(item)).ToList(),
                //SbsBranchImagesS = objectToMap.SbsBranchImagesS.Select(item => sbsBranchImagesMapper.Map(item)).ToList(),
                //SbsBranchTeamS = objectToMap.SbsBranchTeamS.Select(item => sbsBranchTeamMapper.Map(item)).ToList(),
                Tel = objectToMap.Tel,
                ZipCode = objectToMap.ZipCode
            };
            return outputModel;
        }
    }
}
