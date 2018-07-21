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
	public class WebPageContextDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.WebPageContext>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.WebPageContext> de;

        public WebPageContextDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.WebPageContext>(this.sessionFactory);
        }

        #region IBasicDataHandler<WebPageContext> Members

        public void Save(SBSWebProject.Data.Entities.WebPageContext entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.WebPageContext entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.WebPageContext entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.WebPageContext entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.WebPageContext GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.WebPageContext)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion
    }
}
