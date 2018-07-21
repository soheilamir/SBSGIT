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
	public class AirlineNameByLanguageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.AirlineNameByLanguage>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.AirlineNameByLanguage> de;

        public AirlineNameByLanguageDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.AirlineNameByLanguage>(this.sessionFactory);
        }

        #region IBasicDataHandler<AirlineNameByLanguage> Members

        public void Save(SBSWebProject.Data.Entities.AirlineNameByLanguage entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.AirlineNameByLanguage entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.AirlineNameByLanguage entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.AirlineNameByLanguage entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.AirlineNameByLanguage GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.AirlineNameByLanguage)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
