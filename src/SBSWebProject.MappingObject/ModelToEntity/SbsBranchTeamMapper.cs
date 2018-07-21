using System;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using SbsBranchTeam = SBSWebProject.Data.Entities.SbsBranchTeam;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class SbsBranchTeamMapper : IMappingObject<Web.Api.Models.SbsBranchTeam, SbsBranchTeam>
    {
        public SbsBranchTeam Map(Web.Api.Models.SbsBranchTeam objectToMap)
        {
            if (objectToMap == null) return null;
            var sbsSectionMapper = new SbsSectionMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new SbsBranchTeam
            {
                Id = objectToMap.Id,
                UsersItem = usersMapper.Map(objectToMap.UserItem),
                SbsSectionsItem = sbsSectionMapper.Map(objectToMap.SbsSectionItem)
            };
            return outputModel;
        }
    }
}
