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
	public class OnlineFlightTicketPassengersDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.OnlineFlightTicketPassengers>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.OnlineFlightTicketPassengers> de;

		public OnlineFlightTicketPassengersDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.OnlineFlightTicketPassengers> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<OnlineFlightTicketPassengers> Members

		public void Save(SBSWebProject.Data.Entities.OnlineFlightTicketPassengers entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.OnlineFlightTicketPassengers entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.OnlineFlightTicketPassengers entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.OnlineFlightTicketPassengers entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.OnlineFlightTicketPassengers GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.OnlineFlightTicketPassengers)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
