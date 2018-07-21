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
	public class FlightFreeServiceDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.FlightFreeServices>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.FlightFreeServices> de;

        public FlightFreeServiceDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.FlightFreeServices>(this.sessionFactory);
        }

        #region IBasicDataHandler<FlightFreeServices> Members

        public void Save(SBSWebProject.Data.Entities.FlightFreeServices entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.FlightFreeServices entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.FlightFreeServices entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.FlightFreeServices entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.FlightFreeServices GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.FlightFreeServices)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
