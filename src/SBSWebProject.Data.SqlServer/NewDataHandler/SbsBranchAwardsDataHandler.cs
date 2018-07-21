using System; 
using System.Collections.Generic; 
using System.Collections; 
using System.Linq; 
using System.Text;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
	public class SbsBranchAwardsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.SbsBranchAwards>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.SbsBranchAwards> de;

        public SbsBranchAwardsDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.SbsBranchAwards>(this.sessionFactory);
        }

        #region IBasicDataHandler<SbsBranchAwards> Members

        public void Save(SBSWebProject.Data.Entities.SbsBranchAwards entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.SbsBranchAwards entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.SbsBranchAwards entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.SbsBranchAwards entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.SbsBranchAwards GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.SbsBranchAwards)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
