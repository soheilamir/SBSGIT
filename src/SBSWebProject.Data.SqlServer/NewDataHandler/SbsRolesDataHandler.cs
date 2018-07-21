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
	public class SbsRolesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.SbsRoles>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.SbsRoles> de;

        public SbsRolesDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.SbsRoles>(this.sessionFactory);
        }

        #region IBasicDataHandler<SbsRoles> Members

        public void Save(SBSWebProject.Data.Entities.SbsRoles entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.SbsRoles entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.SbsRoles entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.SbsRoles entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.SbsRoles GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.SbsRoles)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
