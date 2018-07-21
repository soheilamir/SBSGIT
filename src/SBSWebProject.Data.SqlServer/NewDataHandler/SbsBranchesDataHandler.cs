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
	public class SbsBranchesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.SbsBranches>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.SbsBranches> de;

        public SbsBranchesDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.SbsBranches>(this.sessionFactory);
        }

        #region IBasicDataHandler<SbsBranches> Members

        public void Save(SBSWebProject.Data.Entities.SbsBranches entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.SbsBranches entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.SbsBranches entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.SbsBranches entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.SbsBranches GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.SbsBranches)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
