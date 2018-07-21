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
	public class ContinentDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Continent>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.Continent> de;

        public ContinentDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.Continent>(this.sessionFactory);
        }

        #region IBasicDataHandler<Continent> Members

        public void Save(SBSWebProject.Data.Entities.Continent entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.Continent entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.Continent entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.Continent entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.Continent GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.Continent)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
