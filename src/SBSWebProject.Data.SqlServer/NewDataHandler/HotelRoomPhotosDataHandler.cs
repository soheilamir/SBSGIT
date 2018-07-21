using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class HotelRoomPhotosDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelRoomPhotos>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.HotelRoomPhotos> de;

        public HotelRoomPhotosDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.HotelRoomPhotos>(this.sessionFactory);
        }

        #region IBasicDataHandler<HotelRoomPhotos> Members

        public void Save(SBSWebProject.Data.Entities.HotelRoomPhotos entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelRoomPhotos entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelRoomPhotos entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelRoomPhotos entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelRoomPhotos GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelRoomPhotos)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
