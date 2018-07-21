using SbsBranchTeam = SBSWebProject.Web.Api.Models.SbsBranchTeam;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class SbsBranchTeamMapper : IMappingObject<Data.Entities.SbsBranchTeam, SbsBranchTeam>
    {
        public SbsBranchTeam Map(Data.Entities.SbsBranchTeam objectToMap)
        {
            if (objectToMap == null) return null;
            var userGroupMapper = new SbsSectionMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new SbsBranchTeam
            {
                Id = objectToMap.Id,
                UserItem = usersMapper.Map(objectToMap.UsersItem),
                SbsSectionItem = userGroupMapper.Map(objectToMap.SbsSectionsItem)
            };
            return outputModel;
        }
    }
}
