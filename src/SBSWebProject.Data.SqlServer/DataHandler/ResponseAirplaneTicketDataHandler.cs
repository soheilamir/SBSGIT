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
	public class ResponseAirplaneTicketDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.ResponseAirplaneTicket>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.ResponseAirplaneTicket> de;

		public ResponseAirplaneTicketDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.ResponseAirplaneTicket> de)
		{

			this.sessionFactory = sessionFactory;
			this.de =de;
		}

		#region IBasicDataHandler<ResponseAirplaneTicket> Members

		public void Save(SBSWebProject.Data.Entities.ResponseAirplaneTicket entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.ResponseAirplaneTicket entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.ResponseAirplaneTicket entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.ResponseAirplaneTicket entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.ResponseAirplaneTicket GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.ResponseAirplaneTicket)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
