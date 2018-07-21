using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface ICompanyMethod
    {
        Company RegisterComopany(long userId, NewCompany companyObj);
        IList<CompanyEmployee> GetAllCompanyEmployee(long userId, long companyId);
        void SendJoinToCompanyRequest(long userId, Company company);
    }
}
