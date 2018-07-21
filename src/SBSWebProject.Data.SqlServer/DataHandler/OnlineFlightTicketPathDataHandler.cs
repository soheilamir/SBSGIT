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
	public class OnlineFlightTicketPathDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.OnlineFlightTicketPath>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.OnlineFlightTicketPath> de;

		public OnlineFlightTicketPathDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.OnlineFlightTicketPath> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<OnlineFlightTicketPath> Members

		public void Save(SBSWebProject.Data.Entities.OnlineFlightTicketPath entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.OnlineFlightTicketPath entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.OnlineFlightTicketPath entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.OnlineFlightTicketPath entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.OnlineFlightTicketPath GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.OnlineFlightTicketPath)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
