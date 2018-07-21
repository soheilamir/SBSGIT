using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.MethodsInterface
{
    public interface IUsersMethod
    {
        Users AddUser(NewUser user);
        Users GetUserByUsername(string username);
        IList<Company> GetUserCompanyAccounts(long userId);
        Data.Entities.Users IsUserExist(long userId);
    }
}
