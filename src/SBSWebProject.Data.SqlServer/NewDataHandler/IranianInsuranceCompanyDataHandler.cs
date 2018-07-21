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
	public class IranianInsuranceCompanyDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.IranianInsuranceCompany>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.IranianInsuranceCompany> de;

        public IranianInsuranceCompanyDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.IranianInsuranceCompany>(this.sessionFactory);
        }

        #region IBasicDataHandler<IranianInsuranceCompany> Members

        public void Save(SBSWebProject.Data.Entities.IranianInsuranceCompany entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.IranianInsuranceCompany entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.IranianInsuranceCompany entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.IranianInsuranceCompany entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.IranianInsuranceCompany GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.IranianInsuranceCompany)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
