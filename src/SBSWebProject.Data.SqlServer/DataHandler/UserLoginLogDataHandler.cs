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
	public class UserLoginLogDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UserLoginLog>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.UserLoginLog> de;

		public UserLoginLogDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.UserLoginLog> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<UserLoginLog> Members

		public void Save(SBSWebProject.Data.Entities.UserLoginLog entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.UserLoginLog entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.UserLoginLog entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.UserLoginLog entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.UserLoginLog GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.UserLoginLog)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
