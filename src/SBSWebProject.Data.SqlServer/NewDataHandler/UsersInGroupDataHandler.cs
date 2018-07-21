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
	public class UsersInGroupDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UsersInGroup>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.UsersInGroup> de;

        public UsersInGroupDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.UsersInGroup>(this.sessionFactory);
        }

        #region IBasicDataHandler<UsersInGroup> Members

        public void Save(SBSWebProject.Data.Entities.UsersInGroup entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.UsersInGroup entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.UsersInGroup entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.UsersInGroup entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.UsersInGroup GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.UsersInGroup)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
