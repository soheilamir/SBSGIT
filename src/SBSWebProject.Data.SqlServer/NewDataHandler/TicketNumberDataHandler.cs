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
	public class TicketNumberDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.TicketNumbers>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.TicketNumbers> de;

        public TicketNumberDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.TicketNumbers>(this.sessionFactory);
        }

        #region IBasicDataHandler<TicketNumbers> Members

        public void Save(SBSWebProject.Data.Entities.TicketNumbers entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.TicketNumbers entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.TicketNumbers entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.TicketNumbers entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.TicketNumbers GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.TicketNumbers)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
