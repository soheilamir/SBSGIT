using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.MaintenanceProcessing
{
    public interface IUsersMaintenanceProcessor
    {
        Users AddUser(NewUser user);
        Users GetUserByUsername(string username);
    }
}
