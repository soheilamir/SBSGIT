using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class HotelsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Hotels>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.Hotels> de;

        public HotelsDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.Hotels>(this.sessionFactory);
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
