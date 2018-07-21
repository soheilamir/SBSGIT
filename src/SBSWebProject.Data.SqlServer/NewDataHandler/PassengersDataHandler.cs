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
	public class PassengersDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Passengers>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.Passengers> de;

        public PassengersDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.Passengers>(this.sessionFactory);
        }

        #region IBasicDataHandler<Passengers> Members

        public void Save(SBSWebProject.Data.Entities.Passengers entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.Passengers entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.Passengers entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.Passengers entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.Passengers GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.Passengers)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
