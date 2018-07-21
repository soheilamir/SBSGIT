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
	public class FlightNumbersDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.FlightNumbers>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.FlightNumbers> de;

		public FlightNumbersDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.FlightNumbers> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<FlightNumbers> Members

		public void Save(SBSWebProject.Data.Entities.FlightNumbers entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.FlightNumbers entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.FlightNumbers entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.FlightNumbers entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.FlightNumbers GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.FlightNumbers)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
