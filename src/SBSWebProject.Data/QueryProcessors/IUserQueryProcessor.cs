using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.QueryProcessors
{
    public interface IUserQueryProcessor
    {
        User FindUser(long userId);
        User CheckLogin(string userName, string password);
    }
}
