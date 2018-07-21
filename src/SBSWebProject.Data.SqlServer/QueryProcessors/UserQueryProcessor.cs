using NHibernate;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.QueryProcessors;

namespace SBSWebProject.Data.SqlServer.QueryProcessors
{
    public class UserQueryProcessor : IUserQueryProcessor
    {

        private readonly ISession _session;
        public UserQueryProcessor(ISession session)
        {
            _session = session;
        }
        public User FindUser(long userId)
        {
            return null;
            //throw new NotImplementedException();
        }

        public User CheckLogin(string userName, string password)
        {
            var user = _session.QueryOver<User>().Where(x => x.Username == userName && x.Password == password).SingleOrDefault();

            var lst = _session.QueryOver<User>();
            return user;
        }
    }
}
