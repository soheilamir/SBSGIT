using System.Linq;
using CompanySection = SBSWebProject.Data.Entities.CompanySection;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class CompanySectionMapper : IMappingObject<Web.Api.Models.CompanySection, CompanySection>
    {
        public CompanySection Map(Web.Api.Models.CompanySection objectToMap)
        {
            if (objectToMap == null) return null;
            var companyMapper = new CompanyMapper();
            var companySectionMapper = new CompanySectionMapper();
            var outputModel = new CompanySection
            {
                Id = objectToMap.Id,
                CompanyItem = (objectToMap.CompanyItem == null) ? null : ((objectToMap.CompanyItem.Id == 0) ? null : companyMapper.Map(objectToMap.CompanyItem)),
                CompanySectionItem = (objectToMap.CompanySectionItem == null) ? null: ((objectToMap.CompanySectionItem.Id == 0) ? null : companySectionMapper.Map(objectToMap.CompanySectionItem)),
                SectionName = objectToMap.SectionName,

            };
            return outputModel;
        }
        public CompanySection Map(Web.Api.Models.CompanySection objectToMap, CompanySection refObj)
        {
            if (objectToMap == null) return null;
            var companyMapper = new CompanyMapper();
            var companySectionMapper = new CompanySectionMapper();
            refObj.Id = objectToMap.Id;
            refObj.CompanyItem = companyMapper.Map(objectToMap.CompanyItem);
            refObj.CompanySectionItem = companySectionMapper.Map(objectToMap.CompanySectionItem);
            refObj.SectionName = objectToMap.SectionName;

            return refObj;
        }
    }
}
