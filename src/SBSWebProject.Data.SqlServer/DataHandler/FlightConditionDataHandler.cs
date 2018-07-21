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
	public class FlightConditionDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.FlightCondition>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.FlightCondition> de;

		public FlightConditionDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.FlightCondition> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<FlightCondition> Members

		public void Save(SBSWebProject.Data.Entities.FlightCondition entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.FlightCondition entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.FlightCondition entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.FlightCondition entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.FlightCondition GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.FlightCondition)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
