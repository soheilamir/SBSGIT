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
	public class CompanyDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Company>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.Company> de;

        public CompanyDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.Company>(this.sessionFactory);
        }

        #region IBasicDataHandler<Company> Members

        public void Save(SBSWebProject.Data.Entities.Company entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.Company entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.Company entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.Company entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.Company GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.Company)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
