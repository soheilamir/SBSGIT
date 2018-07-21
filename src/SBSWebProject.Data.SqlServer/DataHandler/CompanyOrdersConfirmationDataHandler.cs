using NHibernate;
using SBSWebProject.Data.DataHandlers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
    public class CompanyOrdersConfirmationDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CompanyOrdersConfirmation>
    {
        ISession sessionFactory;
        IDomainEntity<SBSWebProject.Data.Entities.CompanyOrdersConfirmation> de;

        public CompanyOrdersConfirmationDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.CompanyOrdersConfirmation> de)
        {

            this.sessionFactory = sessionFactory;
            this.de = de;
        }

        #region IBasicDataHandler<Company> Members

        public void Save(SBSWebProject.Data.Entities.CompanyOrdersConfirmation entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.CompanyOrdersConfirmation entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.CompanyOrdersConfirmation entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.CompanyOrdersConfirmation entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.CompanyOrdersConfirmation GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.CompanyOrdersConfirmation)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
