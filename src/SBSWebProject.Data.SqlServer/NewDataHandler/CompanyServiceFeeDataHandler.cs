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
	public class CompanyServiceFeeDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CompanyServiceFee>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.CompanyServiceFee> de;

        public CompanyServiceFeeDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.CompanyServiceFee>(this.sessionFactory);
        }

        #region IBasicDataHandler<Files> Members

        public void Save(SBSWebProject.Data.Entities.CompanyServiceFee entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.CompanyServiceFee entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.CompanyServiceFee entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.CompanyServiceFee entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.CompanyServiceFee GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.CompanyServiceFee)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
