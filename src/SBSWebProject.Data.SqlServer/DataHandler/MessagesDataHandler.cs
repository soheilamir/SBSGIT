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
	public class MessagesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Messages>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Messages> de;

		public MessagesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Messages> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<Messages> Members

		public void Save(SBSWebProject.Data.Entities.Messages entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Messages entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Messages entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Messages entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Messages GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.Messages)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
