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
	public class AirlineClassPathDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.AirlineClassPath>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.AirlineClassPath> de;

        public AirlineClassPathDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.AirlineClassPath>(this.sessionFactory);
        }

        #region IBasicDataHandler<AirlineClassPath> Members

        public void Save(SBSWebProject.Data.Entities.AirlineClassPath entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.AirlineClassPath entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.AirlineClassPath entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.AirlineClassPath entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.AirlineClassPath GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.AirlineClassPath)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
