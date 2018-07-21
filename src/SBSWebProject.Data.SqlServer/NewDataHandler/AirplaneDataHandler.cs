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
	public class AirplaneDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Airplane>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.Airplane> de;

        public AirplaneDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.Airplane>(this.sessionFactory);
        }

        #region IBasicDataHandler<Airplane> Members

        public void Save(SBSWebProject.Data.Entities.Airplane entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.Airplane entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.Airplane entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.Airplane entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.Airplane GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.Airplane)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
