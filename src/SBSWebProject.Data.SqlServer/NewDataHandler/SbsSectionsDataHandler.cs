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
	public class SbsSectionsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.SbsSections>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.SbsSections> de;

        public SbsSectionsDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.SbsSections>(this.sessionFactory);
        }

        #region IBasicDataHandler<SbsSections> Members

        public void Save(SBSWebProject.Data.Entities.SbsSections entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.SbsSections entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.SbsSections entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.SbsSections entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.SbsSections GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.SbsSections)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
