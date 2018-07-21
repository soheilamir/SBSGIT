using System.Linq;
using Services = SBSWebProject.Web.Api.Models.Services;

namespace SBSWebProject.MappingObject.EntityToModel
{
    public class ServicesMapper : IMappingObject<Data.Entities.Services, Services>
    {
        public Services Map(Data.Entities.Services objectToMap)
        {
            if (objectToMap == null) return null;
            var companyServiceFeeMapper = new CompanyServiceFeeMapper();
            var outputModel = new Services
            {
                Id = objectToMap.Id,
                ServiceName = objectToMap.ServiceName,
                //CompanyServiceFeeS = objectToMap.CompanyServiceFeeS.Where(c => c.State == 0).Select(item => companyServiceFeeMapper.Map(item)).ToList()
            };
            return outputModel;
        }
    }
}
