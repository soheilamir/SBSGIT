using SBSWebProject.Data.Entities;

namespace SBSWebProject.Data.QueryProcessors
{
    public interface IUsersQueryProcessor
    {
        Users FindUser(long userId);
        Users CheckLogin(string userName, string password);
    }
}
