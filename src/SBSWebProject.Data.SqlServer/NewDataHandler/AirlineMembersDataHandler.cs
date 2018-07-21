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
	public class AirlineMembersDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.AirlineMembers>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.AirlineMembers> de;

        public AirlineMembersDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.AirlineMembers>(this.sessionFactory);
        }

        #region IBasicDataHandler<AirlineMembers> Members

        public void Save(SBSWebProject.Data.Entities.AirlineMembers entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.AirlineMembers entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.AirlineMembers entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.AirlineMembers entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.AirlineMembers GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.AirlineMembers)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
