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
	public class InsurancePriceTableDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.InsurancePriceTable>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.InsurancePriceTable> de;

        public InsurancePriceTableDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.InsurancePriceTable>(this.sessionFactory);
        }

        #region IBasicDataHandler<InsurancePriceTable> Members

        public void Save(SBSWebProject.Data.Entities.InsurancePriceTable entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.InsurancePriceTable entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.InsurancePriceTable entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.InsurancePriceTable entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.InsurancePriceTable GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.InsurancePriceTable)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
