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
	public class SbsTagsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.SbsTags>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.SbsTags> de;

		public SbsTagsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.SbsTags> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<SbsTags> Members

		public void Save(SBSWebProject.Data.Entities.SbsTags entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.SbsTags entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.SbsTags entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.SbsTags entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.SbsTags GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.SbsTags)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
