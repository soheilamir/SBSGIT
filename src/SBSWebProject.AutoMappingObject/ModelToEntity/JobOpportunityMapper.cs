using System.Linq;
using JobOpportunity = SBSWebProject.Data.Entities.JobOpportunity;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class JobOpportunityMapper : IMappingObject<Web.Api.Models.JobOpportunity, JobOpportunity>
    {
        public JobOpportunity Map(Web.Api.Models.JobOpportunity objectToMap)
        {
            if (objectToMap == null) return null;
            var sbsSectionMapper = new SbsSectionMapper();
            var outputModel = new JobOpportunity
            {
                Id = objectToMap.Id,
                Description = objectToMap.Description,
                ExpireDate = objectToMap.ExpireDate,
                IsActive = objectToMap.IsActive,
                Number = objectToMap.Number,
                SbsSectionsItem = sbsSectionMapper.Map(objectToMap.SbsSectionsItem),
                SubmitDate = objectToMap.SubmitDate
            };
            return outputModel;
        }
        public JobOpportunity Map(Web.Api.Models.JobOpportunity objectToMap, JobOpportunity refObj)
        {
            if (objectToMap == null) return null;
            var sbsSectionMapper = new SbsSectionMapper();
            refObj.Id = objectToMap.Id;
            refObj.Description = objectToMap.Description;
            refObj.ExpireDate = objectToMap.ExpireDate;
            refObj.IsActive = objectToMap.IsActive;
            refObj.Number = objectToMap.Number;
            refObj.SbsSectionsItem = sbsSectionMapper.Map(objectToMap.SbsSectionsItem);
            refObj.SubmitDate = objectToMap.SubmitDate;
            return refObj;
        }
    }
}
