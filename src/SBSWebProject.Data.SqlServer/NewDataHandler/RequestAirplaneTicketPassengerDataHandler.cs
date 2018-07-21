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
	public class RequestAirplaneTicketPassengerDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger> de;

        public RequestAirplaneTicketPassengerDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger>(this.sessionFactory);
        }

        #region IBasicDataHandler<RequestAirplaneTicketPassenger> Members

        public void Save(SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.RequestAirplaneTicketPassenger)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
