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
	public class AirlineMembersDataHandler : IBasicDataHandler<SBSWebProject.Data.Entities.AirlineMembers>
	{
		ISession sessionFactory;
		IDomainEntity<SBSWebProject.Data.Entities.AirlineMembers> de;

		public AirlineMembersDataHandler(ISession sessionFactory,
            IDomainEntity<SBSWebProject.Data.Entities.AirlineMembers> de)
		{

			this.sessionFactory = sessionFactory;
			this.de = de;
		}

		#region IBasicDataHandler<AirlineMembers> Members

		public void Save(SBSWebProject.Data.Entities.AirlineMembers entity)
		{
			this.de.Save(entity);
		}

		public void Update(SBSWebProject.Data.Entities.AirlineMembers entity)
		{
			this.de.Update(entity);
		}

		public void Delete(SBSWebProject.Data.Entities.AirlineMembers entity)
		{
			this.de.DeleteByState(entity);
		}

		public IList Search(SBSWebProject.Data.Entities.AirlineMembers entity)
		{
			return this.de.GetByExample(entity, null);
		}

		public SBSWebProject.Data.Entities.AirlineMembers GetEntity(long id)
		{
			return (SBSWebProject.Data.Entities.AirlineMembers)this.de.GetEntityByID(id);
		}

		public IList SelectAll()
		{
			return this.de.GetEntitySByState(0);
		}

		#endregion

	}
}
