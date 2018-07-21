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
	public class InsuranceAgeIntervalDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.InsuranceAgeInterval>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.InsuranceAgeInterval> de;

        public InsuranceAgeIntervalDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.InsuranceAgeInterval>(this.sessionFactory);
        }

        #region IBasicDataHandler<InsuranceAgeInterval> Members

        public void Save(SBSWebProject.Data.Entities.InsuranceAgeInterval entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.InsuranceAgeInterval entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.InsuranceAgeInterval entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.InsuranceAgeInterval entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.InsuranceAgeInterval GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.InsuranceAgeInterval)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
