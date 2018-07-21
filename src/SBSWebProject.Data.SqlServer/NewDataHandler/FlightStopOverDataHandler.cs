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
	public class FlightStopOverDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.FlightStopOver>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.FlightStopOver> de;

        public FlightStopOverDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.FlightStopOver>(this.sessionFactory);
        }

        #region IBasicDataHandler<FlightStopOver> Members

        public void Save(SBSWebProject.Data.Entities.FlightStopOver entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.FlightStopOver entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.FlightStopOver entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.FlightStopOver entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.FlightStopOver GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.FlightStopOver)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
