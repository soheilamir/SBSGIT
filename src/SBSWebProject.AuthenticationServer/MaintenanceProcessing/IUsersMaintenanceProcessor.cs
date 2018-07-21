using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.AuthenticationServer.MaintenanceProcessing
{
    public interface IUsersMaintenanceProcessor
    {
        Users CheckUser(string userName, string password);
    }
}
