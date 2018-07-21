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
	public class WebPageBannersDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.WebPageBanners>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.WebPageBanners> de;

		public WebPageBannersDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.WebPageBanners> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<WebPageBanners> Members

		public void Save(SBSWebProject.Data.Entities.WebPageBanners entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.WebPageBanners entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.WebPageBanners entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.WebPageBanners entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.WebPageBanners GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.WebPageBanners)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
