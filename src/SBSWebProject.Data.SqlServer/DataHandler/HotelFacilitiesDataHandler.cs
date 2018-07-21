using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class HotelFacilitiesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelFacilities>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.HotelFacilities> de;

        public HotelFacilitiesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.HotelFacilities> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<HotelFacilities> Members

        public void Save(SBSWebProject.Data.Entities.HotelFacilities entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelFacilities entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelFacilities entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelFacilities entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelFacilities GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelFacilities)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
