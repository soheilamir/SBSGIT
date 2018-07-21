using NHibernate;
using SBSWebProject.Data.DataHandlers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class AirplaneTicketPreferedAirlinesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.AirplaneTicketPreferedAirlines>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.AirplaneTicketPreferedAirlines> de;

        public AirplaneTicketPreferedAirlinesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.AirplaneTicketPreferedAirlines> de)
        {

            this.sessionFactory = sessionFactory;
            this.de =  de;
        }

        #region IBasicDataHandler<AirplaneTicketPreferedAirlines> Members

        public void Save(SBSWebProject.Data.Entities.AirplaneTicketPreferedAirlines entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.AirplaneTicketPreferedAirlines entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.AirplaneTicketPreferedAirlines entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.AirplaneTicketPreferedAirlines entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.AirplaneTicketPreferedAirlines GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.AirplaneTicketPreferedAirlines)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
