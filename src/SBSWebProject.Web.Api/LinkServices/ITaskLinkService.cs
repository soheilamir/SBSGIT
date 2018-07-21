using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.LinkServices
{
    public interface ITaskLinkService
    {
        Link GetAllTasksLink();
        void AddSelfLink(Task task);
        void AddLinksToChildObjects(Task task);
    }
}
