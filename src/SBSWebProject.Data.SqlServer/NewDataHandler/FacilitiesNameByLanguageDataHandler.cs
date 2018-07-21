using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class FacilitiesNameByLanguageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.FacilitiesNameByLanguage>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.FacilitiesNameByLanguage> de;

        public FacilitiesNameByLanguageDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.FacilitiesNameByLanguage>(this.sessionFactory);
        }

        #region IBasicDataHandler<FacilitiesNameByLanguage> Members

        public void Save(SBSWebProject.Data.Entities.FacilitiesNameByLanguage entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.FacilitiesNameByLanguage entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.FacilitiesNameByLanguage entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.FacilitiesNameByLanguage entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.FacilitiesNameByLanguage GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.FacilitiesNameByLanguage)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
