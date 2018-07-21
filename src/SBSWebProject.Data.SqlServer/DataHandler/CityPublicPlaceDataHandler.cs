using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class CityPublicPlaceDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CityPublicPlace>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.CityPublicPlace> de;

        public CityPublicPlaceDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.CityPublicPlace> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<CityPublicPlace> Members

        public void Save(SBSWebProject.Data.Entities.CityPublicPlace entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.CityPublicPlace entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.CityPublicPlace entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.CityPublicPlace entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.CityPublicPlace GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.CityPublicPlace)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
