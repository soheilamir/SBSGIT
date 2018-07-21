using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class HotelOrRoomConditionsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelOrRoomConditions>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.HotelOrRoomConditions> de;

        public HotelOrRoomConditionsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.HotelOrRoomConditions> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<HotelOrRoomConditions> Members

        public void Save(SBSWebProject.Data.Entities.HotelOrRoomConditions entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelOrRoomConditions entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelOrRoomConditions entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelOrRoomConditions entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelOrRoomConditions GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelOrRoomConditions)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
