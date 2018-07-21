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
	public class CountryNameByLanguageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CountryNameByLanguage>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.CountryNameByLanguage> de;

		public CountryNameByLanguageDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.CountryNameByLanguage> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<CountryNameByLanguage> Members

		public void Save(SBSWebProject.Data.Entities.CountryNameByLanguage entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.CountryNameByLanguage entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.CountryNameByLanguage entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.CountryNameByLanguage entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.CountryNameByLanguage GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.CountryNameByLanguage)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
