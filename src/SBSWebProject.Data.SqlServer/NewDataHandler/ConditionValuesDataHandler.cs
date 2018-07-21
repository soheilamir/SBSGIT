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
	public class ConditionValuesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.ConditionValues>
	{
        ISessionFactory sessionFactory;
        DomainEntity<SBSWebProject.Data.Entities.ConditionValues> de;

        public ConditionValuesDataHandler(ISessionFactory sessionFactory)
        {

            this.sessionFactory = sessionFactory;
            this.de = new DomainEntity<SBSWebProject.Data.Entities.ConditionValues>(this.sessionFactory);
        }

        #region IBasicDataHandler<ConditionValues> Members

        public void Save(SBSWebProject.Data.Entities.ConditionValues entity)
        {
            this.de.Save(entity);
        }

        public void Update(SBSWebProject.Data.Entities.ConditionValues entity)
        {
            this.de.Update(entity);
        }

        public void Delete(SBSWebProject.Data.Entities.ConditionValues entity)
        {
            this.de.DeleteByState(entity);
        }

        public IList Search(SBSWebProject.Data.Entities.ConditionValues entity)
        {
            return this.de.GetByExample(entity, null);
        }

        public SBSWebProject.Data.Entities.ConditionValues GetEntity(long id)
        {
            return (SBSWebProject.Data.Entities.ConditionValues)this.de.GetEntityByID(id);
        }

        public IList SelectAll()
        {
            return this.de.GetEntitySByState(0);
        }

        #endregion

    }
}
