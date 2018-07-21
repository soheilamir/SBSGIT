using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class CityPublicPlaceNameByLanguageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage> de;

        public CityPublicPlaceNameByLanguageDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.CityPublicPlaceNameByLanguage> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
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
