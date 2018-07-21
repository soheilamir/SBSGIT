using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class HotelRoomNightPriceDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelRoomNightPrice>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.HotelRoomNightPrice> de;

        public HotelRoomNightPriceDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.HotelRoomNightPrice> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<HotelRoomNightPrice> Members

        public void Save(SBSWebProject.Data.Entities.HotelRoomNightPrice entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelRoomNightPrice entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelRoomNightPrice entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelRoomNightPrice entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelRoomNightPrice GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelRoomNightPrice)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
