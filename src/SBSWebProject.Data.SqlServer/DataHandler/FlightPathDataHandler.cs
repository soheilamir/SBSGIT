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
	public class FlightPathDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.FlightPath>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.FlightPath> de;

		public FlightPathDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.FlightPath> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<FlightPath> Members

		public void Save(SBSWebProject.Data.Entities.FlightPath entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.FlightPath entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.FlightPath entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.FlightPath entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.FlightPath GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.FlightPath)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
