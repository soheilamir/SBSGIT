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
	public class UserLanguagesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UserLanguages>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.UserLanguages> de;

        public UserLanguagesDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.UserLanguages>(this.sessionFactory);
        }

        #region IBasicDataHandler<UserLanguages> Members

        public void Save(SBSWebProject.Data.Entities.UserLanguages entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.UserLanguages entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.UserLanguages entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.UserLanguages entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.UserLanguages GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.UserLanguages)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
