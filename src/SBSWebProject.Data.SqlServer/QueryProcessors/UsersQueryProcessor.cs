using NHibernate;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.QueryProcessors;

namespace SBSWebProject.Data.SqlServer.QueryProcessors
{
    public class UsersQueryProcessor : IUsersQueryProcessor
    {
        private readonly ISession _session;
        public UsersQueryProcessor(ISession session)
        {
            _session = session;
        }
        public Users FindUser(long userId)
        {
            return null;
            //throw new NotImplementedException();
        }

        public Users CheckLogin(string userName, string password)
        {
            int id = password.GetHashCode();
            var users = _session.QueryOver<Users>().Where(x => x.Username == userName && x.Password == password.GetHashCode()).SingleOrDefault();

            var lst = _session.QueryOver<Users>();
            return users;
        }
    }
}
