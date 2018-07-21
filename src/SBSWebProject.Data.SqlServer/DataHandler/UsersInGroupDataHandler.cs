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
	public class UsersInGroupDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UsersInGroup>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.UsersInGroup> de;

		public UsersInGroupDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.UsersInGroup> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<UsersInGroup> Members

		public void Save(SBSWebProject.Data.Entities.UsersInGroup entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.UsersInGroup entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.UsersInGroup entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.UsersInGroup entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.UsersInGroup GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.UsersInGroup)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
