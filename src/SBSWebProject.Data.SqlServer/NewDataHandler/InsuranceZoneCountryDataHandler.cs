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
	public class InsuranceZoneCountryDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.InsuranceZoneCountry>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.InsuranceZoneCountry> de;

        public InsuranceZoneCountryDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.InsuranceZoneCountry>(this.sessionFactory);
        }

        #region IBasicDataHandler<InsuranceZoneCountry> Members

        public void Save(SBSWebProject.Data.Entities.InsuranceZoneCountry entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.InsuranceZoneCountry entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.InsuranceZoneCountry entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.InsuranceZoneCountry entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.InsuranceZoneCountry GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.InsuranceZoneCountry)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
