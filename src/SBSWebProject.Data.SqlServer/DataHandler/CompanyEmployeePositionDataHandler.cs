using System.Collections;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class CompanyEmployeePositionDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CompanyEmployeePosition>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.CompanyEmployeePosition> de;

        public CompanyEmployeePositionDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.CompanyEmployeePosition> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<CompanyEmployeePosition> Members

        public void Save(SBSWebProject.Data.Entities.CompanyEmployeePosition entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.CompanyEmployeePosition entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.CompanyEmployeePosition entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.CompanyEmployeePosition entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.CompanyEmployeePosition GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.CompanyEmployeePosition)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
