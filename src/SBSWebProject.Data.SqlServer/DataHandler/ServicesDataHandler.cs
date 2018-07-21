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
	public class ServicesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Services>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Services> de;

		public ServicesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Services> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<Services> Members

		public void Save(SBSWebProject.Data.Entities.Services entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Services entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Services entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Services entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Services GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.Services)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
