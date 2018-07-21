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
	public class CityDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.City>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.City> de;

        public CityDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.City>(this.sessionFactory);
        }

        #region IBasicDataHandler<City> Members

        public void Save(SBSWebProject.Data.Entities.City entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.City entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.City entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.City entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.City GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.City)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
