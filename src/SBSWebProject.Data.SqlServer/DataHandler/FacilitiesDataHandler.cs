using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class FacilitiesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Facilities>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.Facilities> de;

        public FacilitiesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Facilities> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<Facilities> Members

        public void Save(SBSWebProject.Data.Entities.Facilities entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.Facilities entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.Facilities entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.Facilities entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.Facilities GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.Facilities)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
