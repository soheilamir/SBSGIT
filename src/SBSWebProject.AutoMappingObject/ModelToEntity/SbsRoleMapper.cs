using System.Linq;
using SbsRoles = SBSWebProject.Data.Entities.SbsRoles;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class SbsRoleMapper : IMappingObject<Web.Api.Models.SbsRoles, SbsRoles>
    {
        public SbsRoles Map(Web.Api.Models.SbsRoles objectToMap)
        {
            if (objectToMap == null) return null;
            var rolesInSectionMapper = new RolesInSectionMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new SbsRoles
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                //RolesInSectionS = objectToMap.RolesInSectionS.Select(item=> rolesInSectionMapper.Map(item)).ToList(),
                RoleName = objectToMap.RoleName
            };
            return outputModel;
        }
        public SbsRoles Map(Web.Api.Models.SbsRoles objectToMap, SbsRoles refObj)
        {
            if (objectToMap == null) return null;
            var rolesInSectionMapper = new RolesInSectionMapper();
            var usersMapper = new UsersMapper();
            refObj.Id = objectToMap.Id;
            refObj.Description = objectToMap.Description;
            //RolesInSectionS = objectToMap.RolesInSectionS.Select(item=> rolesInSectionMapper.Map(item)).ToList(),
            refObj.RoleName = objectToMap.RoleName;
            return refObj;
        }
    }
}
