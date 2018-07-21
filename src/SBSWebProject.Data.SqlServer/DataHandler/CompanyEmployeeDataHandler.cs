using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
	public class CompanyEmployeeDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CompanyEmployee>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.CompanyEmployee> de;

		public CompanyEmployeeDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.CompanyEmployee> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<CompanyEmployee> Members

		public void Save(SBSWebProject.Data.Entities.CompanyEmployee entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.CompanyEmployee entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.CompanyEmployee entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.CompanyEmployee entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.CompanyEmployee GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.CompanyEmployee)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
