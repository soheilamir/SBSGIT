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
	public class AirLinesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Airlines>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Airlines> de;

		public AirLinesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Airlines> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<AirLines> Members

		public void Save(SBSWebProject.Data.Entities.Airlines entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Airlines entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Airlines entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Airlines entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Airlines GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.Airlines)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
