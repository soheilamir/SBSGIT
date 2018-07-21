using System;
using SBSWebProject.Data.Entities;
using SBSWebProject.Web.Api.Models;
using SbsBranchTeam = SBSWebProject.Data.Entities.SbsBranchTeam;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
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
        public SbsBranchTeam Map(Web.Api.Models.SbsBranchTeam objectToMap, SbsBranchTeam refObj)
        {
            if (objectToMap == null) return null;
            var sbsSectionMapper = new SbsSectionMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.UsersItem = usersMapper.Map(objectToMap.UserItem);
            refObj.SbsSectionsItem = sbsSectionMapper.Map(objectToMap.SbsSectionItem);
            return refObj;
        }
    }
}
