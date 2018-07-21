using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class FacilitiesCategoryDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.FacilitiesCategory>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.FacilitiesCategory> de;

        public FacilitiesCategoryDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.FacilitiesCategory>(this.sessionFactory);
        }

        #region IBasicDataHandler<FacilitiesCategory> Members

        public void Save(SBSWebProject.Data.Entities.FacilitiesCategory entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.FacilitiesCategory entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.FacilitiesCategory entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.FacilitiesCategory entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.FacilitiesCategory GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.FacilitiesCategory)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
