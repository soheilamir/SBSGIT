using RolesInSection = SBSWebProject.Web.Api.Models.RolesInSection;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class RolesInSectionMapper : IMappingObject<Data.Entities.RolesInSection, RolesInSection>
    {
        public RolesInSection Map(Data.Entities.RolesInSection objectToMap)
        {
            if (objectToMap == null) return null;
            var sbsSectionMapper = new SbsSectionMapper();
            var userRoleMapper = new SbsRoleMapper();
            var outputModel = new RolesInSection
            {
                Id = objectToMap.Id,
                SbsSectionItem = sbsSectionMapper.Map(objectToMap.SbsSectionItem),
                SbsRoleItem = userRoleMapper.Map(objectToMap.SbsRoleItem)
            };
            return outputModel;
        }
    }
}
