using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class FacilitiesCategoryDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.FacilitiesCategory>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.FacilitiesCategory> de;

        public FacilitiesCategoryDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.FacilitiesCategory> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
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
