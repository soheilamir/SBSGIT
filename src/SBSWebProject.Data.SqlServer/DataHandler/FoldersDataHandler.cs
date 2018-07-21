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
	public class FoldersDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Folders>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Folders> de;

		public FoldersDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Folders> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<Folders> Members

		public void Save(SBSWebProject.Data.Entities.Folders entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Folders entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Folders entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Folders entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Folders GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.Folders)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
