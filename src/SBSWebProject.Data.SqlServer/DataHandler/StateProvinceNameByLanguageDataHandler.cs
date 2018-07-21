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
	public class StateProvinceNameByLanguageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.StateProvinceNameByLanguage>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.StateProvinceNameByLanguage> de;

		public StateProvinceNameByLanguageDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.StateProvinceNameByLanguage> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<StateProvinceNameByLanguage> Members

		public void Save(SBSWebProject.Data.Entities.StateProvinceNameByLanguage entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.StateProvinceNameByLanguage entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.StateProvinceNameByLanguage entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.StateProvinceNameByLanguage entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.StateProvinceNameByLanguage GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.StateProvinceNameByLanguage)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
