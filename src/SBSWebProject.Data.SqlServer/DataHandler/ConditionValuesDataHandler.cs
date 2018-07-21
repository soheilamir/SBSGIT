using System; 
using System.Collections.Generic; 
using System.Collections; 
using System.Linq; 
using System.Text;
using SBSWebProject.Data.Entities;
using SBSWebProject.Data.DataHandlers;
using NHibernate;

namespace SBSWebProject.Data.SqlServer.DataHandler
{
	public class ConditionValuesDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.ConditionValues>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.ConditionValues> de;

		public ConditionValuesDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.ConditionValues> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
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
