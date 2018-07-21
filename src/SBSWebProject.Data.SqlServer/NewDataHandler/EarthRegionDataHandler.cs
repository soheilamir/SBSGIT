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
	public class EarthRegionDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.EarthRegion>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.EarthRegion> de;

        public EarthRegionDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.EarthRegion>(this.sessionFactory);
        }

        #region IBasicDataHandler<EarthRegion> Members

        public void Save(SBSWebProject.Data.Entities.EarthRegion entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.EarthRegion entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.EarthRegion entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.EarthRegion entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.EarthRegion GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.EarthRegion)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
