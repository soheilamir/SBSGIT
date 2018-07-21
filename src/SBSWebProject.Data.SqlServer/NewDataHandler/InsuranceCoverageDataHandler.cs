using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.NewDataHandler
{
    public class InsuranceCoverageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.InsuranceCoverage>
    {
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.InsuranceCoverage> de;

        public InsuranceCoverageDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.InsuranceCoverage>(this.sessionFactory);
        }

        #region IBasicDataHandler<InsuranceCoverage> Members

        public void Save(SBSWebProject.Data.Entities.InsuranceCoverage entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.InsuranceCoverage entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.InsuranceCoverage entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.InsuranceCoverage entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.InsuranceCoverage GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.InsuranceCoverage)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
