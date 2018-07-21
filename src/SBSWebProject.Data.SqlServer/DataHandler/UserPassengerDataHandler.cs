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
	public class UserPassengerDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UserPassenger>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.UserPassenger> de;

		public UserPassengerDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.UserPassenger> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<UserPassenger> Members

		public void Save(SBSWebProject.Data.Entities.UserPassenger entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.UserPassenger entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.UserPassenger entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.UserPassenger entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.UserPassenger GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.UserPassenger)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
