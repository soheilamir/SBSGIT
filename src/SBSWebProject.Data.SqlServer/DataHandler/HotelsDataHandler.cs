using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class HotelsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Hotels>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.Hotels> de;

        public HotelsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Hotels> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<Hotels> Members

        public void Save(SBSWebProject.Data.Entities.Hotels entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.Hotels entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.Hotels entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.Hotels entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.Hotels GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.Hotels)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
