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
	public class WebPagesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.WebPages>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.WebPages> de;

        public WebPagesDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.WebPages>(this.sessionFactory);
        }

        #region IBasicDataHandler<WebPages> Members

        public void Save(SBSWebProject.Data.Entities.WebPages entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.WebPages entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.WebPages entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.WebPages entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.WebPages GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.WebPages)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
