using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
	public class JobOpportunityDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.JobOpportunity>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.JobOpportunity> de;

		public JobOpportunityDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.JobOpportunity> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<JobOpportunity> Members

		public void Save(SBSWebProject.Data.Entities.JobOpportunity entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.JobOpportunity entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.JobOpportunity entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.JobOpportunity entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.JobOpportunity GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.JobOpportunity)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
