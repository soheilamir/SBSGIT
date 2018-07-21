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
	public class WebsiteCategoryDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.WebsiteCategory>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.WebsiteCategory> de;

		public WebsiteCategoryDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.WebsiteCategory> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<WebsiteCategory> Members

		public void Save(SBSWebProject.Data.Entities.WebsiteCategory entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.WebsiteCategory entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.WebsiteCategory entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.WebsiteCategory entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.WebsiteCategory GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.WebsiteCategory)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
