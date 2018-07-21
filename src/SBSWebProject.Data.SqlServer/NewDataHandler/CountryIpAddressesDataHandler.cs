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
	public class CountryIpAddressesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.CountryIpAddresses>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.CountryIpAddresses> de;

        public CountryIpAddressesDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.CountryIpAddresses>(this.sessionFactory);
        }

        #region IBasicDataHandler<CountryIpAddresses> Members

        public void Save(SBSWebProject.Data.Entities.CountryIpAddresses entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.CountryIpAddresses entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.CountryIpAddresses entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.CountryIpAddresses entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.CountryIpAddresses GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.CountryIpAddresses)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
