using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class HotelAccessibilityDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.HotelAccessibility>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.HotelAccessibility> de;

        public HotelAccessibilityDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.HotelAccessibility>(this.sessionFactory);
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
