using System.Linq;
using JobOpportunity = SBSWebProject.Web.Api.Models.JobOpportunity;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class JobOpportunityMapper : IMappingObject<Data.Entities.JobOpportunity, JobOpportunity>
    {
        public JobOpportunity Map(Data.Entities.JobOpportunity objectToMap)
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
    }
}
