using System; 
using System.Collections.Generic; 
using System.Collections; 
using System.Linq; 
using System.Text;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
	public class RequestAirplaneTicketDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.RequestAirplaneTicket>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.RequestAirplaneTicket> de;

		public RequestAirplaneTicketDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.RequestAirplaneTicket> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<RequestAirplaneTicket> Members

		public void Save(SBSWebProject.Data.Entities.RequestAirplaneTicket entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.RequestAirplaneTicket entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.RequestAirplaneTicket entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.RequestAirplaneTicket entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.RequestAirplaneTicket GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.RequestAirplaneTicket)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
