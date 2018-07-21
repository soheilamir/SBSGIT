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
	public class UsersDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.Users>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.Users> de;

		public UsersDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.Users> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<Users> Members

		public void Save(SBSWebProject.Data.Entities.Users entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.Users entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.Users entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.Users entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.Users GetEntity(long id)
		{
            
            return (SBSWebProject.Data.Entities.Users)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
