using System.Linq;
using CompanyEmployee = SBSWebProject.Data.Entities.CompanyEmployee;

namespace SBSWebProject.AutoMappingObject.ModelToEntity
{
    public class CompanyEmployeeMapper : IMappingObject<Web.Api.Models.CompanyEmployee, CompanyEmployee>
    {
        public CompanyEmployee Map(Web.Api.Models.CompanyEmployee objectToMap)
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
                //AlternativeResponsibleForConfirmationS = objectToMap.AlternativeResponsibleForConfirmationS.Select(item => responsibleForConfirmationMapper.Map(item)).ToList(),
                //ResponsibleForConfirmationS = objectToMap.ResponsibleForConfirmationS.Select(item => responsibleForConfirmationMapper.Map(item)).ToList()
            };
            return outputModel;
        }
        public CompanyEmployee Map(Web.Api.Models.CompanyEmployee objectToMap, CompanyEmployee refObj)
        {
            if (objectToMap == null) return null;
            var usersMapper = new UsersMapper();
            var companyMapper = new CompanyMapper();
            refObj.Id = objectToMap.Id;
            refObj.CompanyItem = companyMapper.Map(objectToMap.CompanyItem);
            refObj.IsManager = objectToMap.IsManager;
            refObj.IsSeo = objectToMap.IsSeo;
            //Position = objectToMap.Position,
            refObj.UserItem = usersMapper.Map(objectToMap.UserItem);
            //AlternativeResponsibleForConfirmationS = objectToMap.AlternativeResponsibleForConfirmationS.Select(item => responsibleForConfirmationMapper.Map(item)).ToList(),
            //ResponsibleForConfirmationS = objectToMap.ResponsibleForConfirmationS.Select(item => responsibleForConfirmationMapper.Map(item)).ToList()
            return refObj;
        }
    }
}
