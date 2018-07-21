using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class HotelPhotosDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelPhotos>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.HotelPhotos> de;

        public HotelPhotosDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.HotelPhotos>(this.sessionFactory);
        }

        #region IBasicDataHandler<HotelPhotos> Members

        public void Save(SBSWebProject.Data.Entities.HotelPhotos entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelPhotos entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelPhotos entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelPhotos entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelPhotos GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelPhotos)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
