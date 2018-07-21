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
	public class InsuranceTravelIntervalDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.InsuranceTravelInterval>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.InsuranceTravelInterval> de;

        public InsuranceTravelIntervalDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.InsuranceTravelInterval>(this.sessionFactory);
        }

        #region IBasicDataHandler<InsuranceTravelInterval> Members

        public void Save(SBSWebProject.Data.Entities.InsuranceTravelInterval entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.InsuranceTravelInterval entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.InsuranceTravelInterval entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.InsuranceTravelInterval entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.InsuranceTravelInterval GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.InsuranceTravelInterval)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
