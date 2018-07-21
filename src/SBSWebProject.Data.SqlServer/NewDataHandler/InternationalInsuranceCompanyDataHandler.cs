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
	public class InternationalInsuranceCompanyDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.InternationalInsuranceCompany>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.InternationalInsuranceCompany> de;

        public InternationalInsuranceCompanyDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.InternationalInsuranceCompany>(this.sessionFactory);
        }

        #region IBasicDataHandler<InternationalInsuranceCompany> Members

        public void Save(SBSWebProject.Data.Entities.InternationalInsuranceCompany entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.InternationalInsuranceCompany entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.InternationalInsuranceCompany entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.InternationalInsuranceCompany entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.InternationalInsuranceCompany GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.InternationalInsuranceCompany)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
