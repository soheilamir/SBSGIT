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
	public class RequestStatusDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.RequestStatus>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.RequestStatus> de;

        public RequestStatusDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.RequestStatus>(this.sessionFactory);
        }

        #region IBasicDataHandler<RequestStatus> Members

        public void Save(SBSWebProject.Data.Entities.RequestStatus entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.RequestStatus entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.RequestStatus entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.RequestStatus entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.RequestStatus GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.RequestStatus)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
