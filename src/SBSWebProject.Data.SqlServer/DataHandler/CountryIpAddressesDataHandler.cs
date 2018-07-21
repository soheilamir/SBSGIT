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
	public class CountryIpAddressesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CountryIpAddresses>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.CountryIpAddresses> de;

		public CountryIpAddressesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.CountryIpAddresses> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<CountryIpAddresses> Members

		public void Save(SBSWebProject.Data.Entities.CountryIpAddresses entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.CountryIpAddresses entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.CountryIpAddresses entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.CountryIpAddresses entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.CountryIpAddresses GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.CountryIpAddresses)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
