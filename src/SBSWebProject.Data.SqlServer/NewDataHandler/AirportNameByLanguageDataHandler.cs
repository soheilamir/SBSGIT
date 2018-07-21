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
	public class AirportNameByLanguageDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.AirportNameByLanguage>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.AirportNameByLanguage> de;

        public AirportNameByLanguageDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.AirportNameByLanguage>(this.sessionFactory);
        }

        #region IBasicDataHandler<AirportNameByLanguage> Members

        public void Save(SBSWebProject.Data.Entities.AirportNameByLanguage entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.AirportNameByLanguage entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.AirportNameByLanguage entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.AirportNameByLanguage entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.AirportNameByLanguage GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.AirportNameByLanguage)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
