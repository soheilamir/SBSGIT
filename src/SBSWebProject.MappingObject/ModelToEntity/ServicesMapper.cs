using System.Linq;
using Services = SBSWebProject.Data.Entities.Services;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class ServicesMapper : IMappingObject<Web.Api.Models.Services, Services>
    {
        public Services Map(Web.Api.Models.Services objectToMap)
        {
            if (objectToMap == null) return null;
            var companyServiceFeeMapper = new CompanyServiceFeeMapper();
            var outputModel = new Services
            {
                Id = objectToMap.Id,
                ServiceName = objectToMap.ServiceName,
                //CompanyServiceFeeS = objectToMap.CompanyServiceFeeS.Select(item => companyServiceFeeMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
