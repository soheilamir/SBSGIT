using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class HotelPhotosDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelPhotos>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.HotelPhotos> de;

        public HotelPhotosDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.HotelPhotos> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
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
