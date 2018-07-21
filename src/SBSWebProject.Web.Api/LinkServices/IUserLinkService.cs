using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.LinkServices
{
    public interface IUserLinkService
    {
        void AddSelfLink(User user);
    }
}
