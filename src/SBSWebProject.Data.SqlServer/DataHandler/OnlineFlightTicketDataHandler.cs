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
	public class OnlineFlightTicketDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.OnlineFlightTicket>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.OnlineFlightTicket> de;

		public OnlineFlightTicketDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.OnlineFlightTicket> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<OnlineFlightTicket> Members

		public void Save(SBSWebProject.Data.Entities.OnlineFlightTicket entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.OnlineFlightTicket entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.OnlineFlightTicket entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.OnlineFlightTicket entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.OnlineFlightTicket GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.OnlineFlightTicket)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
