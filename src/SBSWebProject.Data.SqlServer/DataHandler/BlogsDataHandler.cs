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
	public class BlogsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Blogs>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Blogs> de;

		public BlogsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Blogs> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<Blogs> Members

		public void Save(SBSWebProject.Data.Entities.Blogs entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Blogs entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Blogs entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Blogs entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Blogs GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.Blogs)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
