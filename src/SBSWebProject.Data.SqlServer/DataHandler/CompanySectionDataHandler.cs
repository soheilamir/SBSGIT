using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class CompanySectionDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CompanySection>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.CompanySection> de;

        public CompanySectionDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.CompanySection> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<CompanySection> Members

        public void Save(SBSWebProject.Data.Entities.CompanySection entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.CompanySection entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.CompanySection entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.CompanySection entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.CompanySection GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.CompanySection)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
