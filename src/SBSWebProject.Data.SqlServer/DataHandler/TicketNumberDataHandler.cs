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
	public class TicketNumberDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.TicketNumbers>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.TicketNumbers> de;

		public TicketNumberDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.TicketNumbers> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<TicketNumber> Members

		public void Save(SBSWebProject.Data.Entities.TicketNumbers entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.TicketNumbers entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.TicketNumbers entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.TicketNumbers entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.TicketNumbers GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.TicketNumbers)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
