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
	public class AirportsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Airports>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.Airports> de;

        public AirportsDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.Airports>(this.sessionFactory);
        }

        #region IBasicDataHandler<Airports> Members

        public void Save(SBSWebProject.Data.Entities.Airports entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.Airports entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.Airports entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.Airports entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.Airports GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.Airports)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
