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
	public class ConditionTypeDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.ConditionType>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.ConditionType> de;

		public ConditionTypeDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.ConditionType> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<ConditionType> Members

		public void Save(SBSWebProject.Data.Entities.ConditionType entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.ConditionType entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.ConditionType entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.ConditionType entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.ConditionType GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.ConditionType)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
