using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class HotelAccessibilityDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelAccessibility>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.HotelAccessibility> de;

        public HotelAccessibilityDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.HotelAccessibility> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<HotelAccessibility> Members

        public void Save(SBSWebProject.Data.Entities.HotelAccessibility entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.HotelAccessibility entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.HotelAccessibility entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.HotelAccessibility entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.HotelAccessibility GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.HotelAccessibility)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
