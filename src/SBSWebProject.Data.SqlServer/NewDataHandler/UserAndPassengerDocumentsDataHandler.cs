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
	public class UserAndPassengerDocumentsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UserAndPassengerDocuments>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.UserAndPassengerDocuments> de;

        public UserAndPassengerDocumentsDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.UserAndPassengerDocuments>(this.sessionFactory);
        }

        #region IBasicDataHandler<UserAndPassengerDocuments> Members

        public void Save(SBSWebProject.Data.Entities.UserAndPassengerDocuments entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.UserAndPassengerDocuments entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.UserAndPassengerDocuments entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.UserAndPassengerDocuments entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.UserAndPassengerDocuments GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.UserAndPassengerDocuments)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
