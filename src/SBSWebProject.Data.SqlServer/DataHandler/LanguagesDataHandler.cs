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
	public class LanguagesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Languages>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Languages> de;

		public LanguagesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Languages> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<Languages> Members

		public void Save(SBSWebProject.Data.Entities.Languages entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Languages entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Languages entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Languages entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Languages GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.Languages)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
