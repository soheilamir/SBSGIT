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
	public class StateProvinceDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.StateProvince>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.StateProvince> de;

		public StateProvinceDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.StateProvince> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<StateProvince> Members

		public void Save(SBSWebProject.Data.Entities.StateProvince entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.StateProvince entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.StateProvince entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.StateProvince entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.StateProvince GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.StateProvince)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
