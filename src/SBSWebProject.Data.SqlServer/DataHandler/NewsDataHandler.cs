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
	public class NewsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.News>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.News> de;

		public NewsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.News> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<News> Members

		public void Save(SBSWebProject.Data.Entities.News entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.News entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.News entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.News entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.News GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.News)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
