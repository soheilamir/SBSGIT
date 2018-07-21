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
	public class SbsBranchImagesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.SbsBranchImages>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.SbsBranchImages> de;

		public SbsBranchImagesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.SbsBranchImages> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<SbsBranchImages> Members

		public void Save(SBSWebProject.Data.Entities.SbsBranchImages entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.SbsBranchImages entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.SbsBranchImages entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.SbsBranchImages entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.SbsBranchImages GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.SbsBranchImages)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
