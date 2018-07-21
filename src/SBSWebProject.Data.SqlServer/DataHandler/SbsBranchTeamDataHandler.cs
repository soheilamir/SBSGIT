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
	public class SbsBranchTeamDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.SbsBranchTeam>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.SbsBranchTeam> de;

		public SbsBranchTeamDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.SbsBranchTeam> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<SbsBranchTeam> Members

		public void Save(SBSWebProject.Data.Entities.SbsBranchTeam entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.SbsBranchTeam entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.SbsBranchTeam entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.SbsBranchTeam entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.SbsBranchTeam GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.SbsBranchTeam)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
