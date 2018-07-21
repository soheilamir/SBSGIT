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
	public class UserCreditInfoDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UserCreditInfo>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.UserCreditInfo> de;

        public UserCreditInfoDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.UserCreditInfo>(this.sessionFactory);
        }

        #region IBasicDataHandler<UserCreditInfo> Members

        public void Save(SBSWebProject.Data.Entities.UserCreditInfo entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.UserCreditInfo entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.UserCreditInfo entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.UserCreditInfo entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.UserCreditInfo GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.UserCreditInfo)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
