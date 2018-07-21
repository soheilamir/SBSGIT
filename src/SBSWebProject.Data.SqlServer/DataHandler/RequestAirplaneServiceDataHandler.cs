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
	public class RequestAirplaneServiceDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.RequestAirplaneService>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.RequestAirplaneService> de;

		public RequestAirplaneServiceDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.RequestAirplaneService> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<RequestAirplaneService> Members

		public void Save(SBSWebProject.Data.Entities.RequestAirplaneService entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.RequestAirplaneService entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.RequestAirplaneService entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.RequestAirplaneService entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.RequestAirplaneService GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.RequestAirplaneService)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
