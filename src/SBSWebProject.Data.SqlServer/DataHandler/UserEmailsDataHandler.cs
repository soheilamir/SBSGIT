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
	public class UserEmailsDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.UserEmails>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.UserEmails> de;

		public UserEmailsDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.UserEmails> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<UserEmails> Members

		public void Save(SBSWebProject.Data.Entities.UserEmails entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.UserEmails entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.UserEmails entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.UserEmails entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.UserEmails GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.UserEmails)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
