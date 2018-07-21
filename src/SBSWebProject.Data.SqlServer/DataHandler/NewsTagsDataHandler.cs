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
	public class NewsTagsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.NewsTags>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.NewsTags> de;

		public NewsTagsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.NewsTags> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<NewsTags> Members

		public void Save(SBSWebProject.Data.Entities.NewsTags entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.NewsTags entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.NewsTags entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.NewsTags entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.NewsTags GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.NewsTags)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
