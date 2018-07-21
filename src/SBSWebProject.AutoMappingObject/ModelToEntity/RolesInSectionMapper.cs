using RolesInSection = SBSWebProject.Data.Entities.RolesInSection;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class RolesInSectionMapper : IMappingObject<Web.Api.Models.RolesInSection, RolesInSection>
    {
        public RolesInSection Map(Web.Api.Models.RolesInSection objectToMap)
        {
            if (objectToMap == null) return null;
            var userGroupMapper = new SbsSectionMapper();
            var userRoleMapper = new SbsRoleMapper();
            var outputModel = new RolesInSection
            {
                Id = objectToMap.Id,
                SbsSectionItem = userGroupMapper.Map(objectToMap.SbsSectionItem),
                SbsRoleItem = userRoleMapper.Map(objectToMap.SbsRoleItem)
            };
            return outputModel;
        }
        public RolesInSection Map(Web.Api.Models.RolesInSection objectToMap, RolesInSection refObj)
        {
            if (objectToMap == null) return null;
            var userGroupMapper = new SbsSectionMapper();
            var userRoleMapper = new SbsRoleMapper();
            refObj.Id = objectToMap.Id;
            refObj.SbsSectionItem = userGroupMapper.Map(objectToMap.SbsSectionItem);
            refObj.SbsRoleItem = userRoleMapper.Map(objectToMap.SbsRoleItem);
            return refObj;
        }
    }
}
