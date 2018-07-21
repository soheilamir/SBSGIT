using System.Linq;
using CompanyEmployee = SBSWebProject.Web.Api.Models.CompanyEmployee;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class CompanyEmployeeMapper : IMappingObject<Data.Entities.CompanyEmployee, CompanyEmployee>
    {
        public CompanyEmployee Map(Data.Entities.CompanyEmployee objectToMap)
        {
            if (objectToMap == null) return null;
            var usersMapper = new UsersMapper();
            var companyMapper = new CompanyMapper();
            var outputModel = new CompanyEmployee
            {
                Id = objectToMap.Id,
                CompanyItem = companyMapper.Map(objectToMap.CompanyItem),
                IsManager = objectToMap.IsManager,
                IsSeo = objectToMap.IsSeo,
                //Position = objectToMap.Position,
                UserItem = usersMapper.Map(objectToMap.UserItem),
                //AlternativeResponsibleForConfirmationS = (objectToMap.AlternativeResponsibleForConfirmationS != null) ? objectToMap.AlternativeResponsibleForConfirmationS.Where(c => c.State == 0).Select(item => responsibleForConfirmationMapper.Map(item)).ToList() : null,
                //ResponsibleForConfirmationS = (objectToMap.ResponsibleForConfirmationS != null) ? objectToMap.ResponsibleForConfirmationS.Where(c => c.State == 0).Select(item => responsibleForConfirmationMapper.Map(item)).ToList() : null
            };
            return outputModel;
        }
    }
}
