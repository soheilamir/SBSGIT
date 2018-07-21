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
	public class ExtensionsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Extensions>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Extensions> de;

		public ExtensionsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Extensions> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<Extensions> Members

		public void Save(SBSWebProject.Data.Entities.Extensions entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Extensions entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Extensions entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Extensions entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Extensions GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.Extensions)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
