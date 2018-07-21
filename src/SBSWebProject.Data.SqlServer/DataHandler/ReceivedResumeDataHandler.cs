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
	public class ReceivedResumeDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.ReceivedResume>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.ReceivedResume> de;

		public ReceivedResumeDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.ReceivedResume> de)
		{

			this.sessionFactory = sessionFactory;
			this.de =de;
		}

		#region IBasicDataHandler<ReceivedResume> Members

		public void Save(SBSWebProject.Data.Entities.ReceivedResume entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.ReceivedResume entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.ReceivedResume entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.ReceivedResume entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.ReceivedResume GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.ReceivedResume)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
