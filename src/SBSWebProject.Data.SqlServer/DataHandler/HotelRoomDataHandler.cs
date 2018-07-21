using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class HotelRoomDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelRoom>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.HotelRoom> de;

        public HotelRoomDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.HotelRoom> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<HotelRoom> Members

        public void Save(SBSWebProject.Data.Entities.HotelRoom entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelRoom entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelRoom entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelRoom entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelRoom GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelRoom)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
