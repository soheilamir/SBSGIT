using System; 
using System.Collections.Generic; 
using System.Collections; 
using System.Linq; 
using System.Text;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
	public class UserTelsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UserTels>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.UserTels> de;

        public UserTelsDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.UserTels>(this.sessionFactory);
        }

        #region IBasicDataHandler<UserTels> Members

        public void Save(SBSWebProject.Data.Entities.UserTels entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.UserTels entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.UserTels entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.UserTels entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.UserTels GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.UserTels)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
