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
	public class RolesInSectionDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.RolesInSection>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.RolesInSection> de;

        public RolesInSectionDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.RolesInSection>(this.sessionFactory);
        }

        #region IBasicDataHandler<RolesInSection> Members

        public void Save(SBSWebProject.Data.Entities.RolesInSection entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.RolesInSection entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.RolesInSection entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.RolesInSection entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.RolesInSection GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.RolesInSection)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
