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
	public class CountryDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Country>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Country> de;

		public CountryDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Country> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<Country> Members

		public void Save(SBSWebProject.Data.Entities.Country entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Country entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Country entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Country entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Country GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.Country)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
