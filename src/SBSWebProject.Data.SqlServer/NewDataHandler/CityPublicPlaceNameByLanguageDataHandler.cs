using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class CityPublicPlaceNameByLanguageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage> de;

        public CityPublicPlaceNameByLanguageDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage>(this.sessionFactory);
        }

        #region IBasicDataHandler<CityPublicPlaceNameByLanguage> Members

        public void Save(SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
