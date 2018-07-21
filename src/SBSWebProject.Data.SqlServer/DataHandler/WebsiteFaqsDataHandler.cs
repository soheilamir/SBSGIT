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
	public class WebsiteFaqsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.WebsiteFAQs>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.WebsiteFAQs> de;

		public WebsiteFaqsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.WebsiteFAQs> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<WebsiteFaqs> Members

		public void Save(SBSWebProject.Data.Entities.WebsiteFAQs entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.WebsiteFAQs entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.WebsiteFAQs entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.WebsiteFAQs entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.WebsiteFAQs GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.WebsiteFAQs)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
