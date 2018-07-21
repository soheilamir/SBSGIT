using System.Linq;
using SbsRoles = SBSWebProject.Web.Api.Models.SbsRoles;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class SbsRoleMapper : IMappingObject<Data.Entities.SbsRoles, SbsRoles>
    {
        public SbsRoles Map(Data.Entities.SbsRoles objectToMap)
        {
            if (objectToMap == null) return null;
            var rolesInUserGroupMapper = new RolesInSectionMapper();
            var usersMapper = new UsersMapper();
            var outputModel = new SbsRoles
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                RolesInSectionS = objectToMap.RolesInSectionS.Where(c=>c.State==0).Select(item=> rolesInUserGroupMapper.Map(item)).ToList(),
                RoleName = objectToMap.RoleName
            };
            return outputModel;
        }
    }
}
