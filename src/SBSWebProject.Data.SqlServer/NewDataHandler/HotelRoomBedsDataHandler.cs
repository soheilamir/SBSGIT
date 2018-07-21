using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class HotelRoomBedsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelRoomBeds>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.HotelRoomBeds> de;

        public HotelRoomBedsDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.HotelRoomBeds>(this.sessionFactory);
        }

        #region IBasicDataHandler<HotelRoomBeds> Members

        public void Save(SBSWebProject.Data.Entities.HotelRoomBeds entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelRoomBeds entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelRoomBeds entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelRoomBeds entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelRoomBeds GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelRoomBeds)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
